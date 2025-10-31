import { useForm, FormProvider } from "react-hook-form";
import { zodResolver } from "@hookform/resolvers/zod";
import { z } from "zod";
import { useState } from "react";

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

  const [loginError, setLoginError] = useState(null);

  const methods = useForm({
    resolver: zodResolver(loginSchema),
  });

  const submit = async (data) => {
    setLoginError(null);

    try {
      const response = await login(data);

      console.log("¡Login exitoso!", response.token);
    } catch (error) {
      const errorMessage = error.message || "Ocurrió un error";

      if (errorMessage.includes("Credenciales inválidas.")) {
        setLoginError("Usuario o contraseña incorrectos.");
      } else {
        setLoginError("No se pudo conectar. Intenta más tarde.");
      }
    }
  };

  return (
    <div className="flex flex-col justify-center items-center w-full py-8">
      <h2 className="text-3xl text-white font-bold mb-8 ">Iniciar Sesión</h2>

      {loginError && (
        <div
          className="w-full p-3 mb-4 text-sm text-center text-red-800 rounded-lg bg-red-100"
          role="alert"
        >
          {loginError}
        </div>
      )}

      <FormProvider {...methods}>
        <form
          onSubmit={methods.handleSubmit(submit)}
          className="flex flex-col gap-y-6 w-full"
        >
          <Input
            label="Nombre de usuario"
            name="nombreUsuario"
            type="text"
            placeholder="Usuario123"
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
