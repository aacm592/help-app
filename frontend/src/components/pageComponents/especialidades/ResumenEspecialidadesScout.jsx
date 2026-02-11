export default function ResumenEspecialidadesScout({ especialidades }) {
  const thClassName = "border-y border-gray-100 px-2 py-5";
  const tdClassName = "border-y border-gray-300 px-2 py-4";

  return (
    <div className="w-full mb-10">
      <div className="overflow-x-auto rounded-2xl border border-gray-300 shadow-sm">
        <table className="w-full border-collapse overflow-x-auto">
          <thead className="bg-purple-300">
            <tr>
              <th className={`${thClassName} text-left`}>Especialidad</th>
              <th className={thClassName}>Status</th>
              <th className={thClassName}>En progreso</th>
              <th className={thClassName}>Terminados</th>
              <th className={thClassName}>Totales</th>
            </tr>
          </thead>
          <tbody className="text-center bg-slate-50">
            {especialidades.map((a, i) => (
              <tr key={i} className="hover:bg-purple-100 transition-colors">
                <td
                  className={`${tdClassName} text-left font-semibold text-[18px]`}
                >
                  {a.name}
                </td>
                <td className={tdClassName}>
                  <span
                    className={`px-3 py-1 rounded-full text-purple-800 text-sm font-medium ${
                      a.status === "En Progreso"
                        ? "bg-amber-100"
                        : "bg-green-100"
                    }`}
                  >
                    {a.status}
                  </span>
                </td>
                <td className={tdClassName}>{a.inProgressQuantity}</td>
                <td className={tdClassName}>{a.doneQuantity}</td>
                <td className={`${tdClassName} text-purple-700 font-bold`}>
                  {a.requirementQuantity}
                </td>
              </tr>
            ))}
          </tbody>
        </table>
      </div>
    </div>
  );
}
