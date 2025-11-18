import { useState } from "react";
import { useNavigate } from "react-router-dom";
import { useAuth } from "../../contexts/AuthContext";
import { salirDeUnidad } from "../../services/unidadService";
import Button from "../Button";

export default function SalirUnidadButton({
  unidadId,
  onSuccessRedirectPath,
  className,
  esUltimoDirigente = false,
  disabled = false,
}) {
  const { removeUnitFromUser } = useAuth();
  const nav = useNavigate();

  const [isLoading, setIsLoading] = useState(false);
  const [apiError, setApiError] = useState(null);

  const handleSalir = async () => {
    if (isLoading || !unidadId) return;

    const confirmado = window.confirm(
      "¿Estás seguro de que quieres salir de esta unidad?"
    );
    if (!confirmado) {
      return;
    }

    if (esUltimoDirigente) {
      const confirmadoUltimo = window.confirm(
        "ADVERTENCIA: Eres el último dirigente en esta unidad.\n\nSi sales, la unidad será eliminada permanentemente y todos los scouts serán expulsados.\n\n¿Estás seguro de que quieres continuar?"
      );
      if (!confirmadoUltimo) {
        return;
      }
    }

    setIsLoading(true);
    setApiError(null);
    try {
      await salirDeUnidad(unidadId);
      removeUnitFromUser(unidadId);
      nav(onSuccessRedirectPath);
    } catch (error) {
      setApiError(error.message);
      setIsLoading(false);
    }
  };

  const defaultStyle =
    "flex items-center justify-center gap-2 px-5 py-2 bg-white text-red-700 border border-red-300 rounded-full hover:bg-red-50 focus:outline-none focus:ring-2 focus:ring-red-400 disabled:bg-gray-100 disabled:text-gray-400 disabled:border-gray-200";

  return (
    <div className={`flex flex-col items-center ${className || ""}`}>
      <Button
        outline={false}
        className={`${defaultStyle} w-full`}
        onClick={handleSalir}
        disabled={isLoading || disabled}
      >
        <span className="material-symbols-outlined text-lg!">
          {isLoading ? "progress_activity" : "exit_to_app"}
        </span>
        <p className="text-sm font-semibold">
          {isLoading ? "Saliendo..." : "Salir de la unidad"}
        </p>
      </Button>

      {apiError && (
        <p className="text-red-600 text-xs mt-1 text-center">{apiError}</p>
      )}
    </div>
  );
}
