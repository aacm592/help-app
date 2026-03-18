import GenericTable from "../../GenericTable";
import RegisterRow from "./RegisterRow";

export default function ScoutsTable({
  scouts,
  tableClassName,
  thClassName,
  tdClassName,
  trClassName,
}) {
  return (
    <GenericTable
      title=""
      tableClassName={tableClassName}
      thClassName={thClassName}
      headers={[
        "Grupo",
        "Rama",
        "Nombre",
        "Fecha Nacimiento",
        "Edad",
        "U. Educativa",
        "Curso",
        "Etapa",
        "Estado de registro",
      ]}
    >
      {scouts.map((s) => (
        <RegisterRow
          key={s.id}
          member={s}
          fields={["unidadEducativa", "curso", "etapa"]}
          tdClassName={tdClassName}
          trClassName={trClassName}
        />
      ))}
    </GenericTable>
  );
}
