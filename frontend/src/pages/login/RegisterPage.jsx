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
      .min(4, { message: "Por favor, ingresa tu nombre completo" }),

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
    "space-x-4 md:space-x-6 w-full bg-fuchsia-100 px-7 py-1.5 !outline-purple-400 outline-3";
  const textClass = "text-[18px] md:text-[24px] text-black";
  const iconClass = "material-symbols-outlined text-4xl!";

  const [apiError, setApiError] = useState(null);

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

  return (
    <div className="flex flex-col justify-center items-center w-full py-8 bg-purple-600 min-h-screen h-full">
      <h2 className="text-3xl text-white font-bold mb-8 ">Crear Cuenta</h2>

      {apiError && (
        <div
          className="w-2/3 md:w-1/3 p-4 mb-4 text-sm text-red-800 rounded-lg bg-red-100"
          role="alert"
        >
          {apiError}
        </div>
      )}

      <FormProvider {...methods}>
        <form
          onSubmit={methods.handleSubmit(submit)}
          className="flex flex-col gap-y-6 w-2/3 md:w-1/3"
        >
          <Input
            label="Nombre Completo"
            name="nombre"
            type="text"
            placeholder="Juan Pérez"
          />

          <Input
            label="Nombre de usuario"
            name="nombreUsuario"
            type="text"
            placeholder="juanperez123"
          />

          <Input
            label="Fecha de Nacimiento"
            name="fechaNacimiento"
            type="date"
          />

          <Input
            label="Contraseña"
            name="contrasena"
            type="password"
            placeholder="••••••••"
          />

          <Input
            label="Repetir Contraseña"
            name="contrasenaRepeat"
            type="password"
            placeholder="••••••••"
          />

          <div className="flex justify-between gap-10">
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
