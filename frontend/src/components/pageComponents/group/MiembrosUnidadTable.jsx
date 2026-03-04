import GenericTable from "../../GenericTable";
import MemberRow from "./MemberRow";

export default function MiembrosUnidadTable({
  unidad,
  rama,
  scouts,
  dirigentes,
  tableClassName,
  thClassName,
  tdClassName,
  trClassName,
  onRegister,
  hasButon = false,
  deletLevel,
  onCancel,
}) {
  const buttonClassName = "w-full p-2 justify-center rounded-md";
  const cancelButtonClassName = `${buttonClassName} bg-red-600 text-yellow-300 border-red-950`;

  const commonProps = {
    hasButton: hasButon,
    onRegister,
    onCancel,
    deletLevel,
    tdClassName,
    trClassName,
    buttonClassName,
    cancelButtonClassName,
  };

  return (
    <div className="w-full mb-10 flex flex-col gap-8">
      <header>
        <h2 className="text-2xl font-bold text-purple-900">Unidad: {unidad}</h2>
        <h2 className="text-2xl font-bold text-purple-900">Rama: {rama}</h2>
      </header>

      <GenericTable
        title="Scouts"
        tableClassName={tableClassName}
        thClassName={thClassName}
        headers={[
          "Nombre",
          "Edad",
          "Rol",
          "U. Educativa",
          "Curso",
          "Etapa",
          "Estado",
          ...(hasButon ? ["Acción"] : []),
        ]}
      >
        {scouts.map((s) => (
          <MemberRow
            key={s.id}
            member={s}
            fields={["unidadEducativa", "curso", "etapa"]}
            {...commonProps}
          />
        ))}
      </GenericTable>

      <GenericTable
        title="Dirigentes"
        tableClassName={tableClassName}
        thClassName={thClassName}
        headers={[
          "Nombre",
          "Edad",
          "Rol",
          "Profesión",
          "Ocupación",
          "Cargo 1",
          "Cargo 2",
          "Estado",
          ...(hasButon ? ["Acción"] : []),
        ]}
      >
        {dirigentes.map((d) => (
          <MemberRow
            key={d.id}
            member={d}
            fields={["profesion", "ocupacion", "cargo1", "cargo2"]}
            {...commonProps}
          />
        ))}
      </GenericTable>
    </div>
  );
}
