import { useEffect, useState } from "react";
import {
  getEspecialidadesPendientes,
  validateEspecialdiad,
} from "../../services/especialidadService";
import { useNavigate } from "react-router-dom";
import EspecialidadPendienteItem from "../../components/pageComponents/especialidades/EspecialidadPendienteItem";
import { useAuth } from "../../contexts/AuthContext";

export default function GestionarEspecialidadesPage() {
  const { user } = useAuth();
  const unidad = user?.unidades?.[0];
  const [pendientes, setPendientes] = useState([]);
  const [isLoading, setIsLoading] = useState(true);
  const [apiError, setApiError] = useState(null);
  const nav = useNavigate();

  useEffect(() => {
    if (!unidad) {
      nav("/home");
      return;
    }

    const getPendientes = async () => {
      setIsLoading(true);
      setApiError(null);
      try {
        const pendList = await getEspecialidadesPendientes(unidad.id);
        setPendientes(pendList);
      } catch (error) {
        console.error("Error al conseguir requisitos pendientes", error);
        setApiError("Hubo un problema al cargar las especialidades.");
      } finally {
        setIsLoading(false);
      }
    };

    getPendientes();
  }, [nav, unidad]);

  const validate = async (usuarioId, objetivoId, indx) => {
    try {
      const request = { usuarioId, objetivoId };
      await validateEspecialdiad(request);
      setPendientes((prev) => prev.filter((_, i) => i !== indx));
    } catch (error) {
      console.error("Error al validar requisitos", error);
      alert("No se pudo completar la validación.");
    }
  };

  const renderContent = () => {
    if (isLoading) {
      return (
        <div className="flex justify-center items-center p-10">
          <span className="material-symbols-outlined text-purple-700 text-6xl! animate-spin">
            progress_activity
          </span>
        </div>
      );
    }

    if (apiError) {
      return (
        <div className="w-full p-3 mb-4 text-sm text-center text-red-800 rounded-lg bg-red-100">
          {apiError}
        </div>
      );
    }

    if (pendientes.length === 0) {
      return (
        <p className="text-center text-gray-600 text-lg p-6 bg-gray-100 rounded-lg">
          No hay especialidades pendientes de validación.
        </p>
      );
    }

    return (
      <div className="space-y-5">
        {pendientes.map((p, i) => (
          <EspecialidadPendienteItem
            key={i}
            especialidad={p.especialidad}
            scout={p.scoutNombre}
            description={p.descripcion}
            scoutId={p.scoutId}
            id={p.requerimientoId}
            onConfirm={(usuarioId, objetivoId) => {
              validate(usuarioId, objetivoId, i);
            }}
          />
        ))}
      </div>
    );
  };

  return (
    <div className="w-full lg:md:w-3/4 md:w-4/5 mx-auto p-4 md:p-8">
      <div className="flex-1">
        <h1 className="text-purple-900 md:text-left text-center">
          Gestionar Especialidades
        </h1>
        {unidad && (
          <p className="text-xl text-violet-600 font-extrabold">
            Unidad: {unidad.nombre}
          </p>
        )}
      </div>

      {renderContent()}
    </div>
  );
}
