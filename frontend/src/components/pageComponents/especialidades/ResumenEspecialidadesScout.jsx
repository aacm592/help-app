export default function ResumenEspecialidadesScout({ especialidades }) {
  return (
    <div className="w-full mb-10">
      <div className="overflow-hidden rounded-2xl border border-gray-300 shadow-sm">
        <table className="w-full border-collapse">
          <thead className="bg-purple-300">
            <tr>
              <th className="border-y border-gray-100 p-4 text-left text-purple-900">
                Especialidad
              </th>
              <th className="border-y border-gray-100 p-4 text-purple-900">
                Status
              </th>
              <th className="border-y border-gray-100 p-4 text-purple-900">
                En progreso
              </th>
              <th className="border-y border-gray-100 p-4 text-purple-900">
                Terminados
              </th>
              <th className="border-y border-gray-100 p-4 text-purple-900">
                Totales
              </th>
            </tr>
          </thead>
          <tbody className="text-center bg-slate-50">
            {especialidades.map((a, i) => (
              <tr key={i} className="hover:bg-purple-100 transition-colors">
                <td className="border-y border-gray-300 p-4 text-left font-semibold text-[18px]">
                  {a.name}
                </td>
                <td className="border-y border-gray-300 p-4">
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
                <td className="border-y border-gray-300 p-4 text-gray-600">
                  {a.inProgressQuantity}
                </td>
                <td className="border-y border-gray-300 p-4 font-bold">
                  {a.doneQuantity}
                </td>
                <td className="border-y border-gray-300 p-4 font-bold text-purple-700">
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
