import Button from "../../Button";

export default function MemberRow({
  member,
  fields,
  hasButton,
  onRegister,
  onCancel,
  deletLevel,
  tdClassName,
  trClassName,
  buttonClassName,
  cancelButtonClassName,
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
          {member.registroStatus === "No registrado" ? (
            <Button
              className={buttonClassName}
              onClick={() => onRegister(member.id)}
            >
              Registrar
            </Button>
          ) : member.registroStatus === deletLevel ? (
            <Button
              className={cancelButtonClassName}
              onClick={() => onCancel(member.id)}
            >
              Cancelar registro
            </Button>
          ) : (
            member.registroStatus
          )}
        </td>
      )}
    </tr>
  );
}
