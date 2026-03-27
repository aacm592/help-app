export default function RespGrupoRow({
  resp,
  tdClassName,
  trClassName,
  children,
}) {
  return (
    <tr className={trClassName}>
      <td className={`${tdClassName} text-md font-semibold text-gray-800`}>
        {resp.grupo}
      </td>
      <td className={tdClassName}>{resp.nombre}</td>
      <td className={tdClassName}>{resp.telf}</td>
      <td className={tdClassName}>{resp.registroStatus}</td>
      {children}
    </tr>
  );
}
