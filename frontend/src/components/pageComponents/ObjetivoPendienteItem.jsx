import { useState } from "react";
import Button from "../Button";
import { validarObjetivo } from "../../services/objetivosService";

export default function ObjetivoPendienteItem({
  pendiente,
  onAccionCompletada,
}) {
  const [isLoading, setIsLoading] = useState(false);
  const [apiError, setApiError] = useState(null);

  const {
    usuarioId,
    nombreScout,
    objetivoId,
    objetivoDescripcion,
    areaNombre,
  } = pendiente;

  const handleAccion = async (accionFn) => {
    setIsLoading(true);
    setApiError(null);
    try {
      await accionFn({ usuarioId, objetivoId });
      onAccionCompletada(objetivoId);
    } catch (error) {
      setApiError(error.message);
      setIsLoading(false);
    }
  };

  const handleValidar = () => {
    handleAccion(validarObjetivo);
  };

  return (
    <div className="w-full flex flex-col gap-4 p-4 bg-white rounded-lg shadow-md border border-gray-200">
      <div className="flex justify-between items-start">
        <div className="flex-1 text-left">
          <p className="text-sm font-semibold text-purple-700">{areaNombre}</p>
          <p className="text-lg text-gray-800">{objetivoDescripcion}</p>
          <p className="text-sm text-gray-600 mt-1">
            Solicitado por: <span className="font-medium">{nombreScout}</span>
          </p>
        </div>

        <div className="flex flex-col sm:flex-row gap-2 ml-4">
          <Button
            className="px-4 py-2 text-sm bg-green-100 text-green-800 hover:bg-green-200"
            onClick={handleValidar}
            disabled={isLoading}
          >
            {isLoading ? (
              <span className="material-symbols-outlined animate-spin">
                progress_activity
              </span>
            ) : (
              "Cumple"
            )}
          </Button>
        </div>
      </div>

      {apiError && (
        <div
          className="w-full p-2 text-xs text-center text-red-800 rounded-lg bg-red-100"
          role="alert"
        >
          {apiError}
        </div>
      )}
    </div>
  );
}
