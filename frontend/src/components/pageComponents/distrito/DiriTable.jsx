import GenericTable from "../../GenericTable";
import RegisterRow from "./RegisterRow";

export default function DiriTable({
  dirigentes,
  tableClassName,
  thClassName,
  tdClassName,
  trClassName,
}) {
  return (
    <GenericTable
      title=""
      theadClassName={tableClassName}
      thClassName={thClassName}
      headers={[
        "Grupo",
        "Rama",
        "Nombre",
        "Fecha Nacimiento",
        "Edad",
        "Profesión",
        "Ocupación",
        "Cargo 1",
        "Cargo 2",
        "Estado de registro",
      ]}
    >
      {dirigentes.map((d) => (
        <RegisterRow
          key={d.id}
          member={d}
          fields={["profesion", "ocupacion", "cargo1", "cargo2"]}
          tdClassName={tdClassName}
          trClassName={trClassName}
        />
      ))}
    </GenericTable>
  );
}
