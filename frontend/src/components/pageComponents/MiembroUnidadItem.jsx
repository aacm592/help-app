import Button from "../Button";

export default function MiembroUnidadItem({
  miembro,
  currentUserId,
  onRemove,
  isLoading,
}) {
  const { id: miembroId, nombre, tipoId } = miembro;

  const rolNombre = tipoId === 1 ? "Scout" : "Dirigente";

  return (
    <div className="w-full flex items-center justify-between gap-4 p-4 bg-white rounded-lg shadow-md border border-gray-200">
      <div>
        <p className="text-lg text-gray-800 font-medium">{nombre}</p>
        <p className="text-sm text-purple-700 font-semibold">{rolNombre}</p>
      </div>

      {miembroId !== currentUserId && (
        <Button
          className="px-4 py-2 text-sm bg-red-100 text-red-800 hover:bg-red-200"
          onClick={() => onRemove(miembroId)}
          disabled={isLoading}
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
  );
}
