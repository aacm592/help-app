import { useForm, FormProvider } from "react-hook-form";
import { zodResolver } from "@hookform/resolvers/zod";
import { z } from "zod";
import { useState } from "react";
import { useNavigate } from "react-router-dom";
import { useAuth } from "../contexts/AuthContext";
import { joinUnidad } from "../services/unidadService";
import Input from "../components/Input";
import Button from "../components/Button";

const joinSchema = z.object({
  codigo: z
    .string()
    .min(1, { message: "Por favor, ingresa un código de unidad" }),
});

export default function JoinUnidadPage() {
  const { addUnitToUser } = useAuth();
  const nav = useNavigate();
  const [apiError, setApiError] = useState(null);

  const buttonClass =
    "space-x-4 xl:space-x-6 xl:w-3/7 w-full bg-fuchsia-100 px-7 py-1.5 !outline-purple-400 outline-3";
  const textClass = "text-[18px] xl:text-[24px] text-black";
  const iconClass = "material-symbols-outlined text-4xl!";

  const methods = useForm({
    resolver: zodResolver(joinSchema),
  });

  const submit = async (data) => {
    setApiError(null);
    try {
      const nuevaUnidad = await joinUnidad(data.codigo);

      addUnitToUser(nuevaUnidad);

      nav("/home");
    } catch (error) {
      setApiError(error.message);
    }
  };

  return (
    <div className="flex flex-col justify-center items-center w-full py-8 bg-purple-600 min-h-screen h-full">
      <h2 className="text-3xl text-white font-bold mb-8 ">Unirse a Unidad</h2>

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
            label="Código de la Unidad"
            name="codigo"
            type="text"
            placeholder="Ej: aB3xZ9"
          />

          <div className="flex xl:flex-row flex-col gap-y-10 justify-between mt-4">
            <Button dark type="submit" className={buttonClass}>
              <span className={`${iconClass} text-green-600`}>check</span>
              <p className={textClass}>Unirse</p>
            </Button>
            <Button
              dark
              type="button"
              onClick={() => nav("/home")}
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
