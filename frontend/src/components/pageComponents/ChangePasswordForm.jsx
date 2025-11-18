import { useForm, FormProvider } from "react-hook-form";
import { zodResolver } from "@hookform/resolvers/zod";
import { z } from "zod";
import { useState } from "react";
import Input from "../Input";
import Button from "../Button";
import { changePassword } from "../../services/authService";

const changePasswordSchema = z
  .object({
    contrasenaActual: z
      .string()
      .min(1, { message: "Ingresa tu contraseña actual" }),
    nuevaContrasena: z
      .string()
      .min(6, { message: "La contraseña debe tener al menos 6 caracteres" }),
    confirmarContrasena: z
      .string()
      .min(1, { message: "Por favor, repite la contraseña" }),
  })
  .refine((data) => data.nuevaContrasena === data.confirmarContrasena, {
    message: "Las contraseñas no coinciden",
    path: ["confirmarContrasena"],
  });

export default function ChangePasswordForm({ onSuccess, onCancel }) {
  const [apiError, setApiError] = useState(null);
  const [success, setSuccess] = useState(null);
  const [isLoading, setIsLoading] = useState(false);

  const methods = useForm({
    resolver: zodResolver(changePasswordSchema),
  });

  const submit = async (data) => {
    setApiError(null);
    setSuccess(null);
    setIsLoading(true);

    try {
      const response = await changePassword(data);
      setSuccess(response.message || "Contraseña actualizada con éxito.");
      methods.reset();

      if (onSuccess) {
        setTimeout(() => {
          onSuccess();
        }, 1500);
      }
    } catch (error) {
      setApiError(error.message || "Ocurrió un error desconocido.");
    } finally {
      setIsLoading(false);
    }
  };

  return (
    <div className="w-full">
      {apiError && (
        <div
          className="w-full p-3 mb-4 text-sm text-center text-red-800 rounded-lg bg-red-100"
          role="alert"
        >
          {apiError}
        </div>
      )}
      {success && (
        <div
          className="w-full p-3 mb-4 text-sm text-center text-green-800 rounded-lg bg-green-100"
          role="alert"
        >
          {success}
        </div>
      )}

      <FormProvider {...methods}>
        <form
          onSubmit={methods.handleSubmit(submit)}
          className="flex flex-col gap-y-5"
        >
          <Input
            label="Contraseña Actual"
            name="contrasenaActual"
            type="password"
            placeholder="••••••••"
            variant="light"
          />
          <Input
            label="Nueva Contraseña"
            name="nuevaContrasena"
            type="password"
            placeholder="••••••••"
            variant="light"
          />
          <Input
            label="Confirmar Nueva Contraseña"
            name="confirmarContrasena"
            type="password"
            placeholder="••••••••"
            variant="light"
          />

          <div className="flex gap-4 mt-4">
            <Button
              type="button"
              onClick={onCancel}
              className="w-full justify-center px-5 py-2 bg-gray-200 text-gray-800 rounded-full hover:bg-gray-300"
            >
              Cancelar
            </Button>
            <Button
              type="submit"
              disabled={isLoading || success}
              className="w-full justify-center px-5 py-2 bg-purple-600 text-white rounded-full hover:bg-purple-700"
            >
              {isLoading ? "Actualizando..." : "Actualizar"}
            </Button>
          </div>
        </form>
      </FormProvider>
    </div>
  );
}
