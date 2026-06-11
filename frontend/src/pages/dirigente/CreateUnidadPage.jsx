import { useForm, FormProvider } from "react-hook-form";
import { zodResolver } from "@hookform/resolvers/zod";
import { z } from "zod";
import { useState, useEffect, useCallback } from "react";
import { useNavigate } from "react-router-dom";
import Input from "../../components/Input";
import SelectInput from "../../components/SelectInput";
import Button from "../../components/Button";
import { getRamas } from "../../services/ramasService";
import {
  getGruposScout,
  getGruposScoutPorDistrito,
} from "../../services/grupoService";
import { createUnidad } from "../../services/unidadService";
import { getDistritos } from "../../services/distritoService";
import { useAuth } from "../../contexts/AuthContext";

const createUnidadSchema = z.object({
  nombre: z
    .string()
    .min(3, { message: "El nombre debe tener al menos 3 caracteres" }),
  ramaId: z.coerce.number().min(1, { message: "Debes seleccionar una rama" }),

  grupoScoutId: z.coerce
    .number()
    .min(1, { message: "Debes seleccionar un grupo scout" }),
});

export default function CreateUnidadPage() {
  const buttonClass =
    "space-x-4 xl:space-x-6 xl:w-3/7 w-full bg-fuchsia-100 px-7 py-1.5 !outline-purple-400 outline-3";
  const textClass = "text-[18px] xl:text-[24px] text-black";
  const iconClass = "material-symbols-outlined text-4xl!";


  const [apiError, setApiError] = useState(null);
  const [ramas, setRamas] = useState([]);
  const [grupos, setGrupos] = useState([]);
  const [isLoading, setIsLoading] = useState(true);
  const [distritos, setDistritos] = useState([]);
  const { addUnitToUser } = useAuth();

  const nav = useNavigate();

  const methods = useForm({
    resolver: zodResolver(createUnidadSchema),
    defaultValues: {
      ramaId: "",
      grupoScoutId: "",
      distritoId: "",
    },
  });

  const { watch, setValue } = methods;
  const watchedDistritoId = watch("distritoId");

  useEffect(() => {
    async function loadDropdownData() {
      try {
        setIsLoading(true);
        const [ramasData, gruposData, distritosData] = await Promise.all([
          getRamas(),
          getGruposScout(),
          getDistritos(),
        ]);
        setRamas(ramasData);
        setGrupos(gruposData);
        setDistritos(distritosData);
      } catch (error) {
        setApiError(error.message);
      } finally {
        setIsLoading(false);
      }
    }
    loadDropdownData();
  }, []);

  const setGruposByDistrito = useCallback(async (distritoId) => {
    setApiError(null);
    try {
      const filteredGrupos = await getGruposScoutPorDistrito(distritoId);
      setGrupos(filteredGrupos);
    } catch (error) {
      setApiError(error.message);
      setGrupos([]);
    }
  }, []);

  useEffect(() => {
    const districtIdNumber = Number(watchedDistritoId);

    if (districtIdNumber > 0) {
      setGruposByDistrito(districtIdNumber);
      setValue("grupoScoutId", "");
    } else {
      setGrupos([]);
      setValue("grupoScoutId", "");
    }
  }, [watchedDistritoId, setGruposByDistrito, setValue]);

  const submit = async (data) => {
    setApiError(null);
    try {
      const nuevaUnidad = await createUnidad(data);
      addUnitToUser(nuevaUnidad);
      nav("/home");
    } catch (error) {
      setApiError(`Error al crear la unidad: ${error.message}`);
    }
  };

  if (isLoading) {
    return (
      <div className="flex justify-center items-center min-h-screen bg-[#622599]">
        <h2 className="text-3xl text-white font-bold">Cargando...</h2>
      </div>
    );
  }

  return (
    <div className="flex flex-col justify-center items-center w-full py-8 bg-[#622599] min-h-screen h-full">
      <h2 className="text-3xl text-white font-bold mb-8 ">Crear Unidad</h2>

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
            label="Nombre de la Unidad"
            name="nombre"
            type="text"
            placeholder="Ej: Baloo, Felinos, etc..."
          />

          <SelectInput
            label="Distrito"
            name="distritoId"
            options={distritos}
            placeholder="Selecciona una distrito..."
          />

          <SelectInput
            label="Rama"
            name="ramaId"
            options={ramas}
            placeholder="Selecciona una rama..."
          />

          <SelectInput
            label="Grupo Scout"
            name="grupoScoutId"
            options={grupos}
            placeholder="Selecciona un grupo..."
          />

          <div className="flex xl:flex-row flex-col gap-y-10 justify-between mt-4 w-full">
            <Button dark type="submit" className={buttonClass}>
              <span className={`${iconClass} text-green-600`}>check</span>
              <p className={textClass}>Crear</p>
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
