import { useState, useEffect } from "react";
import { useParams, useNavigate } from "react-router-dom";
import { useAuth } from "../../contexts/AuthContext";
import Button from "../../components/Button";
import {
  getMiembrosUnidad,
  removerDeUnidad,
} from "../../services/unidadService";
import MiembroUnidadItem from "../../components/pageComponents/MiembroUnidadItem";

export default function VerUnidadPage() {
  const { unidadId } = useParams();
  const { user } = useAuth();
  const nav = useNavigate();

  const [miembros, setMiembros] = useState([]);
  const [loading, setLoading] = useState(true);
  const [apiError, setApiError] = useState(null);

  const [removingId, setRemovingId] = useState(null);

  const unidadActual = user?.unidades.find((u) => u.id.toString() === unidadId);

  useEffect(() => {
    const cargarMiembros = async () => {
      setLoading(true);
      setApiError(null);
      try {
        const data = await getMiembrosUnidad(unidadId);
        setMiembros(data);
      } catch (error) {
        setApiError(error.message);
      } finally {
        setLoading(false);
      }
    };
    cargarMiembros();
  }, [unidadId]);

  const handleRemover = async (usuarioARemoverId) => {
    if (removingId) return;

    setRemovingId(usuarioARemoverId);
    setApiError(null);
    try {
      await removerDeUnidad(unidadId, usuarioARemoverId);
      setMiembros((prev) => prev.filter((m) => m.id !== usuarioARemoverId));
    } catch (error) {
      setApiError(error.message);
    } finally {
      setRemovingId(null);
    }
  };

  const renderContent = () => {
    if (loading) {
      return (
        <div className="flex justify-center items-center p-10">
          <span className="material-symbols-outlined text-purple-700 !text-6xl animate-spin">
            progress_activity
          </span>
        </div>
      );
    }

    if (miembros.length === 0) {
      return (
        <p className="text-center text-gray-600 text-lg p-6 bg-gray-100 rounded-lg">
          No hay miembros en esta unidad.
        </p>
      );
    }

    return (
      <div className="space-y-4">
        {miembros.map((miembro) => (
          <MiembroUnidadItem
            key={miembro.id}
            miembro={miembro}
            currentUserId={user.id}
            onRemove={handleRemover}
            isLoading={removingId === miembro.id}
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
            <h1 className="text-purple-900">Miembros de la Unidad</h1>
            {unidadActual && (
              <p className="text-xl text-gray-700">{unidadActual.nombre}</p>
            )}
          </div>
          <Button
            className="px-4 py-2"
            onClick={() => nav(`/diri/unidad/${unidadId}`)}
          >
            <span className="material-symbols-outlined mr-2">arrow_back</span>
            Volver
          </Button>
        </div>

        {apiError && (
          <div
            className="w-full p-3 mb-4 text-sm text-center text-red-800 rounded-lg bg-red-100"
            role="alert"
          >
            {apiError}
          </div>
        )}

        {renderContent()}
      </div>
    </div>
  );
}
