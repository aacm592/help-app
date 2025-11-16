import { useState, useEffect } from "react";
import { useParams, useNavigate } from "react-router-dom";
import ObjetivoPendienteItem from "../../components/pageComponents/ObjetivoPendienteItem.jsx";
import Button from "../../components/Button.jsx";
import { useAuth } from "../../contexts/AuthContext.jsx";
import { getPendientesPorUnidad } from "../../services/objetivosService.js";

export default function GestionarObjetivosPage() {
  const { unidadId } = useParams();
  const { user } = useAuth();
  const nav = useNavigate();

  const [pendientes, setPendientes] = useState([]);
  const [loading, setLoading] = useState(true);
  const [apiError, setApiError] = useState(null);

  const unidadActual = user?.unidades.find((u) => u.id.toString() === unidadId);

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
      prevPendientes.filter((p) => p.objetivoId !== objetivoIdEliminado)
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
    <div className="flex flex-col items-center min-h-screen bg-gray-50 text-black p-8 w-screen">
      <div className="w-full max-w-4xl mx-auto">
        <div className="flex justify-between items-center mb-6">
          <div className="flex-1">
            <h1 className="text-purple-900">Validar Objetivos</h1>
            {unidadActual && (
              <p className="text-xl text-gray-700">{unidadActual.nombre}</p>
            )}
          </div>
          <Button
            className="px-4 py-2"
            onClick={() => nav(`/diri/unidad/${unidadId}/home`)}
          >
            <span className="material-symbols-outlined mr-2">arrow_back</span>
            Volver
          </Button>
        </div>

        {renderContent()}
      </div>
    </div>
  );
}
