export default function MiembrosUnidadTable({
  unidad,
  rama,
  scouts,
  dirigentes,
}) {
  const thClassName =
    "border-y border-gray-100 px-2 py-5 text-purple-900 font-bold";
  const tdClassName = "border-y border-gray-300 px-2 py-4";

  return (
    <div className="w-full mb-10 flex flex-col gap-4">
      <div>
        <h2 className="text-2xl font-bold text-purple-900 mb-4">
          Unidad: {unidad}
        </h2>
        <h2 className="text-2xl font-bold text-purple-900 mb-4">
          Rama: {rama}
        </h2>
        <h2 className="text-xl font-bold text-purple-800 mb-4">Scouts</h2>

        <div className="overflow-x-auto rounded-2xl border border-gray-300 shadow-sm">
          <table className="w-full border-collapse">
            <thead className="bg-purple-300">
              <tr>
                <th className={thClassName}>Nombre</th>
                <th className={thClassName}>Edad</th>
                <th className={thClassName}>Rol</th>
                <th className={thClassName}>Unidad Educativa</th>
                <th className={thClassName}>Curso</th>
                <th className={thClassName}>Etapa</th>
                <th className={thClassName}>Registro</th>
              </tr>
            </thead>
            <tbody className="text-center bg-slate-50">
              {scouts.map((a, i) => (
                <tr key={i} className="hover:bg-purple-100 transition-colors">
                  <td
                    className={`${tdClassName} text-left font-semibold text-gray-800`}
                  >
                    {a.nombre}
                  </td>
                  <td className={tdClassName}>{a.edad}</td>
                  <td className={tdClassName}>{a.rol}</td>
                  <td className={tdClassName}>{a.datos.unidadEducativa}</td>
                  <td className={tdClassName}>{a.datos.curso}</td>
                  <td className={tdClassName}>{a.datos.etapa}</td>
                  <td className={`${tdClassName} text-purple-700 font-bold`}>
                    {a.registroStatus}
                  </td>
                </tr>
              ))}
            </tbody>
          </table>
        </div>
      </div>

      <div>
        <h2 className="text-xl font-bold text-purple-800 mb-4">Dirigentes</h2>
        <div className="overflow-x-auto rounded-2xl border border-gray-300 shadow-sm">
          <table className="w-full border-collapse">
            <thead className="bg-purple-300">
              <tr>
                <th className={thClassName}>Nombre</th>
                <th className={thClassName}>Edad</th>
                <th className={thClassName}>Rol</th>
                <th className={thClassName}>Profesión</th>
                <th className={thClassName}>Ocupación</th>
                <th className={thClassName}>Cargo 1</th>
                <th className={thClassName}>Cargo 2</th>
                <th className={thClassName}>Registro</th>
              </tr>
            </thead>
            <tbody className="text-center bg-slate-50">
              {dirigentes.map((a) => (
                <tr
                  key={a.id}
                  className="hover:bg-purple-100 transition-colors"
                >
                  <td
                    className={`${tdClassName} text-left font-semibold text-gray-800`}
                  >
                    {a.nombre}
                  </td>
                  <td className={tdClassName}>{a.edad}</td>
                  <td className={tdClassName}>{a.rol}</td>
                  <td className={tdClassName}>{a.datos.profesion}</td>
                  <td className={tdClassName}>{a.datos.ocupacion}</td>
                  <td className={tdClassName}>{a.datos.cargo1}</td>
                  <td className={tdClassName}>{a.datos.cargo2}</td>
                  <td className={`${tdClassName} text-purple-700 font-bold`}>
                    {a.registroStatus}
                  </td>
                </tr>
              ))}
            </tbody>
          </table>
        </div>
      </div>
    </div>
  );
}
