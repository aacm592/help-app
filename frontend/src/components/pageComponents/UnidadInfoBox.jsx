export default function UnidadInfoBox({ user, unidad }) {
  const infoItemClass = "py-2 flex items-center gap-3";
  const labelClass = "font-semibold text-gray-600";
  const dataClass = "text-xl font-bold text-purple-800";

  return (
    <div className="w-full border-b-2 ">
      <div className="flex justify-between items-center">
        <h1 className="text-purple-900">{unidad.nombre}</h1>
        <p className="text-3xl text-green-700 font-bold">{unidad.codigo}</p>
      </div>
      <div className="space-y-1">
        <div className={infoItemClass}>
          <p className={labelClass}>Usuario:</p>
          <p className={dataClass}>{user.nombre}</p>
        </div>

        <div className={infoItemClass}>
          <p className={labelClass}>Grupo Scout:</p>
          <p className={dataClass}>{unidad.grupoScoutNombre}</p>
        </div>

        <div className={infoItemClass}>
          <p className={labelClass}>Rama:</p>
          <p className={dataClass}>{unidad.ramaNombre}</p>
        </div>
      </div>
    </div>
  );
}
