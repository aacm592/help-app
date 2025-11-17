import Button from "../Button";
import { useNavigate, useParams } from "react-router-dom";

export default function MiembroUnidadItem({
  miembro,
  currentUserId,
  onRemove,
  isLoading,
  onGenerateCode,
  isGeneratingCode,
}) {
  const { id: miembroId, nombre, tipoId } = miembro;
  const rolNombre = tipoId === 1 ? "Scout" : "Dirigente";

  const nav = useNavigate();
  const { unidadId } = useParams();

  const handleVerProgreso = () => {
    nav(`/diri/unidad/${unidadId}/scout/${miembroId}/progreso`, {
      state: { scoutNombre: nombre },
    });
  };

  return (
    <div className="w-full flex items-center justify-between gap-4 p-4 bg-white rounded-lg shadow-md border border-gray-200">
      <div>
        <p className="text-lg text-gray-800 font-medium">{nombre}</p>
        <p className="text-sm text-purple-700 font-semibold">{rolNombre}</p>
      </div>

      <div className="flex flex-wrap gap-2 justify-end">
        {tipoId === 1 && (
          <Button
            className="px-4 py-2 text-sm bg-blue-100 text-blue-800 hover:bg-blue-200"
            onClick={handleVerProgreso}
          >
            Progreso
          </Button>
        )}

        {tipoId === 1 && (
          <Button
            className="px-4 py-2 text-sm bg-yellow-100 text-yellow-800 hover:bg-yellow-200"
            onClick={() => onGenerateCode(miembro)}
            disabled={isLoading || isGeneratingCode}
          >
            {isGeneratingCode ? (
              <span className="material-symbols-outlined animate-spin">
                progress_activity
              </span>
            ) : (
              "Reset Pass"
            )}
          </Button>
        )}

        {miembroId !== currentUserId && (
          <Button
            className="px-4 py-2 text-sm bg-red-100 text-red-800 hover:bg-red-200"
            onClick={() => onRemove(miembroId)}
            disabled={isLoading || isGeneratingCode}
          >
            {isLoading ? (
              <span className="material-symbols-outlined animate-spin">
                progress_activity
              </span>
            ) : (
              "Sacar"
            )}
          </Button>
        )}
      </div>
    </div>
  );
}
