import { formatFecha } from "../../utils/dateFormatter";

export default function ObjetivoProgresoItem({ objetivo }) {
  const {
    status,
    objetivoDescripcion,
    fechaSeleccion,
    fechaAprobacion,
    dirigenteAproboNombre,
  } = objetivo;

  const esCumplido = status === "Cumplido";

  const statusClass = esCumplido
    ? "text-green-600 bg-green-100"
    : "text-amber-600 bg-amber-100";
  const icon = esCumplido ? "check_circle" : "pending";

  return (
    <div
      className={`flex items-start gap-3 p-3 border-l-4 ${
        esCumplido ? "border-green-500" : "border-amber-500"
      } bg-white rounded-r-md shadow-sm`}
    >
      <span className={`material-symbols-outlined ${statusClass} rounded-full`}>
        {icon}
      </span>
      <div className="flex-1">
        <p className="text-gray-800">{objetivoDescripcion}</p>
        <p
          className={`text-sm font-semibold ${statusClass} inline-block px-2 py-0.5 rounded-md mt-1`}
        >
          {status}
        </p>
        <div className="text-xs text-gray-500 mt-2 space-y-1">
          <p>
            <span className="font-semibold">Seleccionado:</span>{" "}
            {formatFecha(fechaSeleccion, "short") || "N/A"}
          </p>

          {esCumplido && fechaAprobacion && (
            <>
              <p>
                <span className="font-semibold">Aprobado:</span>{" "}
                {formatFecha(fechaAprobacion, "short")}
              </p>
              {dirigenteAproboNombre && (
                <p>
                  <span className="font-semibold">Por:</span>{" "}
                  {dirigenteAproboNombre}
                </p>
              )}
            </>
          )}
        </div>
      </div>
    </div>
  );
}
