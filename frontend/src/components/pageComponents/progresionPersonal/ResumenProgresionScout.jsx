export default function ResumenProgresionScout({ etapa, areas }) {
  return (
    <div className="w-full mb-10">
      <h2 className="text-xl font-bold text-purple-800 mb-4">{etapa}</h2>

      <div className="overflow-hidden rounded-2xl border border-gray-300 shadow-sm">
        <table className="w-full border-collapse border border-gray-300 rounded-2xl">
          <thead className="bg-purple-300">
            <tr>
              <th className="border-y border-gray-100 p-4">Area</th>
              <th className="border-y border-gray-100 p-4">En Progreso</th>
              <th className="border-y border-gray-100 p-4">Terminados</th>
              <th className="border-y border-gray-100 p-4">Total</th>
            </tr>
          </thead>
          <tbody className="text-center bg-slate-50">
            {areas.map((a, i) => (
              <tr key={i} className="hover:bg-purple-100 transition-colors">
                <td className="border-y border-gray-300 p-4 text-left font-semibold text-[18px]">
                  {a.area}
                </td>
                <td className="border-y border-gray-300 p-4">
                  {a.inProgressQuantity}
                </td>
                <td className="border-y border-gray-300 p-4">{a.doneQuantity}</td>
                <td className="border-y border-gray-300 p-4 font-bold text-purple-700">
                  {a.totalQuantity}
                </td>
              </tr>
            ))}
          </tbody>
        </table>
      </div>
    </div>
  );
}
