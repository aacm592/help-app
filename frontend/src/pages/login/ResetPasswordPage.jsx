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
    "space-x-4 md:space-x-6 w-full bg-fuchsia-100 px-7 py-1.5 !outline-purple-400 outline-3";
  const textClass = "text-[18px] md:text-[24px] text-black";
  const iconClass = "material-symbols-outlined text-4xl!";

  const [apiError, setApiError] = useState(null);
  const [success, setSuccess] = useState(null);
  const [isLoading, setIsLoading] = useState(false);

  const nav = useNavigate();

  const methods = useForm({
    resolver: zodResolver(resetSchema),
  });

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
    <div className="flex flex-col justify-center items-center w-full py-8 bg-purple-600 min-h-screen h-full">
      <h2 className="text-3xl text-white font-bold mb-8 ">
        Resetear Contraseña
      </h2>

      {apiError && (
        <div
          className="w-2/3 md:w-1/3 p-4 mb-4 text-sm text-red-800 rounded-lg bg-red-100"
          role="alert"
        >
          {apiError}
        </div>
      )}
      {success && (
        <div
          className="w-2/3 md:w-1/3 p-4 mb-4 text-sm text-green-800 rounded-lg bg-green-100"
          role="alert"
        >
          {success}
        </div>
      )}

      <FormProvider {...methods}>
        <form
          onSubmit={methods.handleSubmit(submit)}
          className="flex flex-col gap-y-6 w-2/3 md:w-1/3"
        >
          <Input
            label="Nombre de usuario"
            name="nombreUsuario"
            type="text"
            placeholder="Ej: juanperez123"
          />

          <Input
            label="Código de Reseteo"
            name="resetCode"
            type="text"
            placeholder="Ej: ABC123"
          />

          <Input
            label="Nueva Contraseña"
            name="nuevaContrasena"
            type="password"
            placeholder="••••••••"
          />

          <Input
            label="Confirmar Nueva Contraseña"
            name="confirmarContrasena"
            type="password"
            placeholder="••••••••"
          />

          <div className="flex justify-between gap-10 mt-4">
            <Button
              dark
              type="submit"
              className={buttonClass}
              disabled={isLoading}
            >
              <span className={`${iconClass} text-green-600`}>check</span>
              <p className={textClass}>Resetear</p>
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
