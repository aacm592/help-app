export default function ResumenProgresionScout({ etapa, areas }) {
  const thClassName = "border-y border-gray-100 px-2 py-5";
  const tdClassName = "border-y border-gray-300 px-2 py-4";
  return (
    <div className="w-full mb-10">
      <h2 className="text-xl font-bold text-purple-800 mb-4">{etapa}</h2>

      <div className="overflow-x-auto rounded-2xl border border-gray-300 shadow-sm">
        <table className="w-full border-collapse border border-gray-300 rounded-2xl">
          <thead className="bg-purple-300">
            <tr>
              <th className={thClassName}>Area</th>
              <th className={thClassName}>En Progreso</th>
              <th className={thClassName}>Terminados</th>
              <th className={thClassName}>Total</th>
            </tr>
          </thead>
          <tbody className="text-center bg-slate-50">
            {areas.map((a, i) => (
              <tr key={i} className="hover:bg-purple-100 transition-colors">
                <td
                  className={`${tdClassName} text-left font-semibold text-[18px]`}
                >
                  {a.area}
                </td>
                <td className={tdClassName}>{a.inProgressQuantity}</td>
                <td className={tdClassName}>{a.doneQuantity}</td>
                <td className={`${tdClassName} text-purple-700 font-bold`}>
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
