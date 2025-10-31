import { useForm, FormProvider } from "react-hook-form";
import { zodResolver } from "@hookform/resolvers/zod";
import { z } from "zod";

import Input from "./Input";
import Button from "./Button";
import { login } from "../services/authService";

const loginSchema = z.object({
  nombreUsuario: z
    .string()
    .min(1, { message: "Por favor, ingresa tu ususario" }),
  contrasena: z
    .string()
    .min(1, { message: "Por favor, ingresa tu contraseña" }),
});

export default function LoginComponent() {
  const buttonClass =
    "space-x-4 md:space-x-6 w-full bg-fuchsia-100 px-7 py-1.5 !outline-purple-400 outline-3";
  const textClass = "text-[18px] md:text-[24px] text-black";
  const iconClass = "material-symbols-outlined text-green-600 !text-4xl";

  const methods = useForm({
    resolver: zodResolver(loginSchema),
  });

  const submit = (data) => {
    const token = login(data);
    console.log(token);
  };

  return (
    <div className="flex flex-col justify-center items-center w-full py-8">
      <h2 className="text-3xl text-white font-bold mb-8 ">Iniciar Sesión</h2>

      <FormProvider {...methods}>
        <form
          onSubmit={methods.handleSubmit(submit)}
          className="flex flex-col gap-y-6 w-full"
        >
          <Input
            label="Nombre de usuario"
            name="nombreUsuario"
            type="text"
            placeholder="tu@correo.com"
          />

          <Input
            label="Contraseña"
            name="contrasena"
            type="password"
            placeholder="••••••••"
          />

          <Button dark type="submit" className={buttonClass}>
            <span className={iconClass}>person_check</span>
            <p className={textClass}>Iniciar sesión</p>
          </Button>
        </form>
      </FormProvider>
    </div>
  );
}
