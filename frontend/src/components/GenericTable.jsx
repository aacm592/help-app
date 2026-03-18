export default function GenericTable({
  title,
  headers,
  children,
  theadClassName,
  tableClassName,
  thClassName,
}) {
  return (
    <div>
      <h2 className="text-xl font-bold text-purple-800 mb-4">{title}</h2>
      <div className="overflow-x-auto rounded-2xl border border-gray-300 shadow-sm">
        <table className={`${tableClassName} w-full border-collapse`}>
          <thead className={theadClassName}>
            <tr>
              {headers.map((header) => (
                <th key={header} className={thClassName}>
                  {header}
                </th>
              ))}
            </tr>
          </thead>
          <tbody className="text-center bg-slate-50">{children}</tbody>
        </table>
      </div>
    </div>
  );
}
