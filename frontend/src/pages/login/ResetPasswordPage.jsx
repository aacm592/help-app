import { useForm, FormProvider } from "react-hook-form";
import { zodResolver } from "@hookform/resolvers/zod";
import { z } from "zod";
import { useState } from "react";
import Input from "../../components/Input";
import Button from "../../components/Button";
import { resetPassword } from "../../services/authService";
import { useNavigate } from "react-router-dom";

const resetSchema = z
  .object({
    nombreUsuario: z
      .string()
      .min(1, { message: "Ingresa tu nombre de usuario" }),
    resetCode: z.string().min(1, { message: "Ingresa el código de reseteo" }),
    nuevaContrasena: z
      .string()
      .min(6, { message: "La contraseña debe tener al menos 6 caracteres" }),

    confirmarContrasena: z
      .string()
      .min(1, { message: "Confirma la nueva contraseña" }),
  })
  .refine((data) => data.nuevaContrasena === data.confirmarContrasena, {
    message: "Las contraseñas no coinciden",
    path: ["confirmarContrasena"],
  });

export default function ResetPasswordPage() {
  const buttonClass =
    "space-x-4 xl:space-x-6 xl:w-3/7 w-full bg-fuchsia-100 px-7 py-1.5 !outline-purple-400 outline-3";
  const textClass = "text-[18px] xl:text-[24px] text-black";
  const iconClass = "material-symbols-outlined text-4xl!";

  const [apiError, setApiError] = useState(null);
  const [success, setSuccess] = useState(null);
  const [isLoading, setIsLoading] = useState(false);

  const [showPassword, setShowPassword] = useState(false);
  const icon = showPassword ? "visibility" : "visibility_off";
  const type = showPassword ? "text" : "password";

  const nav = useNavigate();

  const methods = useForm({
    resolver: zodResolver(resetSchema),
  });

  const passwordButton = (
    <Button
      type="button"
      onClick={() => {
        setShowPassword(!showPassword);
      }}
      outline={false}
      className="p-1 rounded-full text-gray-500 hover:bg-gray-200 active:text-purple-600"
    >
      <span className="material-symbols-outlined text-xl!">{icon}</span>
    </Button>
  );

  const submit = async (data) => {
    setApiError(null);
    setSuccess(null);
    setIsLoading(true);

    try {
      const response = await resetPassword(data);
      setSuccess(response.message + " Serás redirigido al inicio de sesión.");
      methods.reset();
      setTimeout(() => nav("/"), 3000);
    } catch (error) {
      setApiError(error.message || "Ocurrió un error desconocido");
    } finally {
      setIsLoading(false);
    }
  };

  return (
    <div className="flex flex-col justify-center items-center w-full py-8 bg-[#622599] min-h-screen h-full">
      <h2 className="text-3xl text-white font-bold mb-8 ">
        Cambiar Contraseña
      </h2>

      {apiError && (
        <div
          className="w-2/3 xl:w-1/3 p-4 mb-4 text-sm text-red-800 rounded-lg bg-red-100"
          role="alert"
        >
          {apiError}
        </div>
      )}
      {success && (
        <div
          className="w-2/3 xl:w-1/3 p-4 mb-4 text-sm text-green-800 rounded-lg bg-green-100"
          role="alert"
        >
          {success}
        </div>
      )}

      <FormProvider {...methods}>
        <form
          onSubmit={methods.handleSubmit(submit)}
          className="flex flex-col gap-y-6 w-2/3 xl:w-1/3"
        >
          <Input
            label="Nombre de usuario"
            name="nombreUsuario"
            type="text"
            placeholder="Ej: juanperez123"
          />

          <Input
            label="Código de Recuperación"
            name="resetCode"
            type="text"
            placeholder="Ej: ABC123"
          />

          <Input
            label="Nueva Contraseña"
            name="nuevaContrasena"
            type={type}
            placeholder="••••••••"
            rightContent={passwordButton}
          />

          <Input
            label="Confirmar Nueva Contraseña"
            name="confirmarContrasena"
            type={type}
            placeholder="••••••••"
            rightContent={passwordButton}
          />

          <div className="flex xl:flex-row flex-col gap-y-10 justify-between mt-4">
            <Button
              dark
              type="submit"
              className={buttonClass}
              disabled={isLoading}
            >
              <span className={`${iconClass} text-green-600`}>check</span>
              <p className={textClass}>Actualizar</p>
            </Button>
            <Button
              dark
              type="button"
              onClick={() => nav("/")}
              className={buttonClass}
            >
              <span className={`${iconClass} text-red-600`}>close</span>
              <p className={textClass}>Cancelar</p>
            </Button>
          </div>
        </form>
      </FormProvider>
    </div>
  );
}
