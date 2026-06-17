import { useForm, FormProvider } from "react-hook-form";
import { zodResolver } from "@hookform/resolvers/zod";
import { z } from "zod";
import { useState } from "react";
import Input from "../../components/Input";
import Button from "../../components/Button";
import { register } from "../../services/authService";
import { useNavigate } from "react-router-dom";

const registroSchema = z
  .object({
    nombre: z
      .string()
      .min(4, { message: "Por favor, ingresa tu(s) nombre(s)" }),

    apellido: z
      .string()
      .min(6, { message: "Por favor, ingresa tus apellidos" }),

    nombreUsuario: z
      .string()
      .min(1, { message: "Por favor, ingresa un nombre de usuario" }),

    fechaNacimiento: z.coerce.date({
      required_error: "Por favor, ingresa tu fecha de nacimiento",
      invalid_type_error: "La fecha de nacimiento no es válida",
    }),

    contrasena: z
      .string()
      .min(6, { message: "La contraseña debe tener al menos 6 caracteres" }),

    contrasenaRepeat: z
      .string()
      .min(1, { message: "Por favor, repite la contraseña" }),
  })
  .refine((data) => data.contrasena === data.contrasenaRepeat, {
    message: "Las contraseñas no coinciden",
    path: ["contrasenaRepeat"],
  });

export default function RegisterPage() {
  const buttonClass =
    "space-x-4 xl:space-x-6 xl:w-3/7 w-full bg-fuchsia-100 px-7 py-1.5 !outline-purple-400 outline-3";
  const textClass = "text-[18px] xl:text-[24px] text-black";
  const iconClass = "material-symbols-outlined text-4xl!";

  const [apiError, setApiError] = useState(null);

  const [showPassword, setShowPassword] = useState(false);
  const icon = showPassword ? "visibility" : "visibility_off";
  const type = showPassword ? "text" : "password";

  const nav = useNavigate();

  const methods = useForm({
    resolver: zodResolver(registroSchema),
  });

  const submit = async (data) => {
    setApiError(null);
    methods.clearErrors("nombreUsuario");

    try {
      const response = await register(data);

      nav("/");
      console.log("¡Registro exitoso!", response);
      methods.reset();
    } catch (error) {
      const errorMessage = error.message || "Ocurrió un error desconocido";

      if (errorMessage.includes("El nombre de usuario ya está en uso")) {
        methods.setError("nombreUsuario", {
          type: "manual",
          message: "Este nombre de usuario ya existe, por favor elige otro.",
        });
      } else {
        setApiError(`Error al registrar: ${errorMessage}`);
      }
    }
  };

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

  return (
    <div className="flex flex-col justify-center items-center w-full py-8 bg-[#622599] min-h-screen h-full">
      <h2 className="text-3xl text-white font-bold mb-8 ">Crear Cuenta</h2>

      {apiError && (
        <div
          className="w-2/3 xl:w-1/3 p-4 mb-4 text-sm text-red-800 rounded-lg bg-red-100"
          role="alert"
        >
          {apiError}
        </div>
      )}

      <FormProvider {...methods}>
        <form
          onSubmit={methods.handleSubmit(submit)}
          className="flex flex-col gap-y-6 w-2/3 xl:w-1/3"
        >
          <Input
            label="Nombres"
            name="nombre"
            type="text"
            placeholder="Ej: Juan Pérez"
          />

          <Input
            label="Apellidos"
            name="apellido"
            type="text"
            placeholder="Ej: Juan Pérez"
          />

          <Input
            label="Nombre de usuario"
            name="nombreUsuario"
            type="text"
            placeholder="Ej: Juanito123"
          />

          <Input
            label="Fecha de Nacimiento"
            name="fechaNacimiento"
            type="date"
          />

          <Input
            label="Contraseña"
            name="contrasena"
            type={type}
            placeholder="••••••••"
            rightContent={passwordButton}
          />

          <Input
            label="Repetir Contraseña"
            name="contrasenaRepeat"
            type={type}
            placeholder="••••••••"
            rightContent={passwordButton}
          />

          <div className="flex xl:flex-row flex-col gap-y-10 justify-between">
            <Button dark type="submit" className={buttonClass}>
              <span className={`${iconClass} text-green-600`}>check</span>
              <p className={textClass}>Registrarse</p>
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
