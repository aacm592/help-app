import Button from "../Button";

export default function ObjetivoItem({
  objetivo,
  onSelect,
  isLoading = false,
}) {
  const handleSelectClick = () => {
    if (!isLoading) {
      onSelect(objetivo.id);
    }
  };

  return (
    <div className="w-full flex items-center justify-between gap-4 p-4 bg-white rounded-lg shadow-md border border-gray-200">
      <p className="text-left text-gray-700 flex-1">{objetivo.descripcion}</p>
      <Button
        className="px-4 py-2 text-sm"
        onClick={handleSelectClick}
        disabled={isLoading}
      >
        {isLoading ? (
          <span className="material-symbols-outlined animate-spin">
            progress_activity
          </span>
        ) : (
          "Seleccionar"
        )}
      </Button>
    </div>
  );
}
