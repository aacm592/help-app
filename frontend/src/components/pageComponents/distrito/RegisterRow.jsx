import { formatFecha } from "../../../utils/dateFormatter";

export default function RegisterRow({
  member,
  fields,
  tdClassName,
  trClassName,
}) {
  return (
    <tr className={trClassName}>
      <td className={`${tdClassName} font-semibold text-gray-800`}>
        {member.grupo}
      </td>
      <td className={tdClassName}>{member.rama}</td>
      <td className={tdClassName}>{member.nombre}</td>
      <td className={tdClassName}>{formatFecha(member.fechaNacimiento)}</td>
      <td className={tdClassName}>{member.edad}</td>
      {fields.map((field) => (
        <td key={field} className={tdClassName}>
          {member.datos[field]}
        </td>
      ))}

      <td className={`${tdClassName} text-purple-700 font-bold`}>
        {member.registroStatus}
      </td>
    </tr>
  );
}
