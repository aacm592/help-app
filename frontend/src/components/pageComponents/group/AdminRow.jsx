import Button from "../../Button";

export default function AdminRow({
  member,
  fields,
  hasButton,
  onDelete,
  tdClassName,
  trClassName,
  buttonClassName,
}) {
  return (
    <tr className={trClassName}>
      <td className={`${tdClassName} text-left font-semibold text-gray-800`}>
        {member.nombre}
      </td>
      <td className={tdClassName}>{member.edad}</td>
      <td className={tdClassName}>{member.rol}</td>

      {fields.map((field) => (
        <td key={field} className={tdClassName}>
          {member.datos[field]}
        </td>
      ))}

      <td className={`${tdClassName} text-purple-700 font-bold`}>
        {member.registroStatus}
      </td>

      {hasButton && (
        <td className={`${tdClassName} text-purple-700 font-bold`}>
          <Button className={buttonClassName} onClick={onDelete}>
            Quitar Administrador
          </Button>
        </td>
      )}
    </tr>
  );
}
