import { useForm, FormProvider } from "react-hook-form";
import { zodResolver } from "@hookform/resolvers/zod";
import { z } from "zod";

import Input from "../components/Input";
import Button from "../components/Button";

const registroSchema = z
  .object({
    nombre: z
      .string()
      .min(4, { message: "Por favor, ingresa tu nombre completo" }),

    nombreUsuario: z
      .string()
      .min(1, { message: "Por favor, ingresa un nombre de usuario" }),

    fechaNacimiento: z.date({
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

  const iconClass = "material-symbols-outlined text-green-600 !text-4xl";

  const methods = useForm({
    resolver: zodResolver(registroSchema),
  });

  const submit = (data) => {
    console.log("Datos a registrar:", data);

    // const response = await register(data); // (Si tu servicio es async)
    // console.log(response);
  };

  return (
    <div className="flex flex-col justify-center items-center w-full py-8">
      <h2 className="text-3xl text-white font-bold mb-8 ">Crear Cuenta</h2>

      <FormProvider {...methods}>
        <form
          onSubmit={methods.handleSubmit(submit)}
          className="flex flex-col gap-y-6 w-full"
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

          <Button dark type="submit" className={buttonClass}>
            <span className={iconClass}>person_add</span>
            <p className={textClass}>Registrarse</p>
          </Button>
        </form>
      </FormProvider>
    </div>
  );
}
