import Button from "../../Button";

export default function EspecialidadPendienteItem({
  id,
  especialidad,
  scout,
  scoutId,
  description,
  onConfirm,
}) {
  return (
    <div className="flex justify-between items-center border border-gray-200 p-2 rounded-2xl shadow-md">
      <div className="flex flex-col pr-8 space-y-2">
        <p className="text-sm font-semibold text-purple-700">{especialidad}</p>
        <p className="text-lg text-gray-800">{description}</p>
        <p className="text-sm text-gray-600 mt-1">
          Solicitado por: <span className="font-medium">{scout}</span>
        </p>
      </div>
      <Button
        className="px-4 py-2 text-sm hover:bg-slate-200"
        onClick={() => onConfirm(scoutId, id)}
      >
        Confirmar
      </Button>
    </div>
  );
}
