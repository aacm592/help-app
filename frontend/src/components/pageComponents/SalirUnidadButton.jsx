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

    if (esUltimoDirigente) {
      const confirmado = window.confirm(
        "ADVERTENCIA: Eres el último dirigente en esta unidad.\n\nSi sales, la unidad será eliminada permanentemente y todos los scouts serán expulsados.\n\n¿Estás seguro de que quieres continuar?"
      );
      if (!confirmado) {
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

  return (
    <div className={`w-full ${className || ""}`}>
      <Button
        dark
        className="w-full space-x-4 justify-center bg-red-700 hover:bg-red-600 px-7 py-2 outline-3"
        onClick={handleSalir}
        disabled={isLoading || disabled}
      >
        <span className="material-symbols-outlined text-4xl! text-white">
          exit_to_app
        </span>
        <p className="text-[18px] md:text-[22px] text-white">
          {isLoading ? "Saliendo..." : "Salir de la unidad"}
        </p>
      </Button>

      {apiError && <p className="text-center text-red-600 mt-2">{apiError}</p>}
    </div>
  );
}
