import { useState, useEffect } from "react";
import { useParams } from "react-router-dom";
import ObjetivoPendienteItem from "../../components/pageComponents/ObjetivoPendienteItem.jsx";
import { useAuth } from "../../contexts/AuthContext.jsx";
import { getPendientesPorUnidad } from "../../services/objetivosService.js";

export default function GestionarObjetivosPage() {
  const { unidadId } = useParams();
  const { user } = useAuth();

  const [pendientes, setPendientes] = useState([]);
  const [loading, setLoading] = useState(true);
  const [apiError, setApiError] = useState(null);

  const unidad = user?.unidades.find((u) => u.id.toString() === unidadId);

  useEffect(() => {
    const cargarPendientes = async () => {
      setLoading(true);
      setApiError(null);
      try {
        const data = await getPendientesPorUnidad(unidadId);
        setPendientes(data);
      } catch (error) {
        setApiError(error.message);
      } finally {
        setLoading(false);
      }
    };

    cargarPendientes();
  }, [unidadId]);

  const handleAccionCompletada = (objetivoIdEliminado) => {
    setPendientes((prevPendientes) =>
      prevPendientes.filter((p) => p.objetivoId !== objetivoIdEliminado),
    );
  };

  const renderContent = () => {
    if (loading) {
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
        <div
          className="w-full p-3 mb-4 text-sm text-center text-red-800 rounded-lg bg-red-100"
          role="alert"
        >
          {apiError}
        </div>
      );
    }

    if (pendientes.length === 0) {
      return (
        <p className="text-center text-gray-600 text-lg p-6 bg-gray-100 rounded-lg">
          No hay objetivos pendientes de validación en esta unidad.
        </p>
      );
    }

    return (
      <div className="space-y-4">
        {pendientes.map((pendiente) => (
          <ObjetivoPendienteItem
            key={`${pendiente.usuarioId}-${pendiente.objetivoId}`}
            pendiente={pendiente}
            onAccionCompletada={handleAccionCompletada}
          />
        ))}
      </div>
    );
  };

  return (
    <div className="w-full lg:md:w-3/4 md:w-4/5 mx-auto p-4 md:p-8">
      <div className="flex-1">
        <h1 className="text-purple-900 md:text-left text-center">
          Gestionar Objetivos
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
