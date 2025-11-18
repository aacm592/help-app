import { useState, useEffect } from "react";
import { useParams, useNavigate } from "react-router-dom";
import { useAuth } from "../../contexts/AuthContext";
import Button from "../../components/Button";
import {
  getMiembrosUnidad,
  removerDeUnidad,
} from "../../services/unidadService";
import MiembroUnidadItem from "../../components/pageComponents/MiembroUnidadItem";
import { generateResetCode } from "../../services/authService";
import Modal from "../../components/Modal";

export default function VerUnidadPage() {
  const { unidadId } = useParams();
  const { user } = useAuth();
  const nav = useNavigate();

  const [miembros, setMiembros] = useState([]);
  const [loading, setLoading] = useState(true);
  const [apiError, setApiError] = useState(null);

  const [removingId, setRemovingId] = useState(null);
  const [generatingCodeId, setGeneratingCodeId] = useState(null);

  const [isCodeModalOpen, setIsCodeModalOpen] = useState(false);
  const [generatedCode, setGeneratedCode] = useState(null);
  const [scoutForCode, setScoutForCode] = useState(null);
  const [isCopied, setIsCopied] = useState(false);

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

  const handleRemover = async (miembroARemover) => {
    if (removingId) return;

    const confirmado = window.confirm(
      `¿Estás seguro de que quieres sacar a ${miembroARemover.nombre} de la unidad?`
    );
    if (!confirmado) {
      return;
    }

    setRemovingId(miembroARemover.id);
    setApiError(null);
    try {
      await removerDeUnidad(unidadId, miembroARemover.id);
      setMiembros((prev) => prev.filter((m) => m.id !== miembroARemover.id));
    } catch (error) {
      setApiError(error.message);
    } finally {
      setRemovingId(null);
    }
  };

  const handleGenerateCode = async (miembro) => {
    if (generatingCodeId || removingId) return;

    setGeneratingCodeId(miembro.id);
    setApiError(null);
    setIsCopied(false);
    try {
      const response = await generateResetCode(miembro.id);

      setGeneratedCode(response.resetCode);
      setScoutForCode(miembro.nombre);

      setIsCodeModalOpen(true);
    } catch (error) {
      setApiError(error.message);
    } finally {
      setGeneratingCodeId(null);
    }
  };
  const handleCopyCode = () => {
    if (generatedCode) {
      navigator.clipboard.writeText(generatedCode);
      setIsCopied(true);
      setTimeout(() => setIsCopied(false), 2000);
    }
  };

  const handleCloseModal = () => {
    setIsCodeModalOpen(false);
    setGeneratedCode(null);
    setScoutForCode(null);
    setIsCopied(false);
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
            onGenerateCode={handleGenerateCode}
            isGeneratingCode={generatingCodeId === miembro.id}
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
            onClick={() => nav(`/diri/unidad/${unidadId}/home`)}
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

        <Modal
          isOpen={isCodeModalOpen}
          onClose={handleCloseModal}
          title={`Código para ${scoutForCode || ""}`}
        >
          <div className="flex flex-col items-center gap-4">
            <p className="text-center text-gray-700">
              Comparte este código con el scout. Expira en 1 hora.
            </p>
            <code className="text-4xl font-bold text-purple-800 bg-purple-100 p-4 rounded-lg tracking-widest">
              {generatedCode}
            </code>
            <Button
              className="w-full justify-center px-5 py-2 bg-purple-600 text-white rounded-full hover:bg-purple-700"
              onClick={handleCopyCode}
            >
              <span className="material-symbols-outlined mr-2">
                {isCopied ? "check" : "content_copy"}
              </span>
              {isCopied ? "¡Copiado!" : "Copiar Código"}
            </Button>
            <Button
              className="w-full justify-center px-5 py-2 bg-gray-200 text-gray-800 rounded-full hover:bg-gray-300"
              onClick={handleCloseModal}
            >
              Cerrar
            </Button>
          </div>
        </Modal>
      </div>
    </div>
  );
}
