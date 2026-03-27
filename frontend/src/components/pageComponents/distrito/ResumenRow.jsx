export default function ResumenRow({ grupo, tdClassName, trClassName }) {
  const total =
    grupo.lobatos + grupo.explos + grupo.pios + grupo.rovers + grupo.diris;
  return (
    <tr className={trClassName}>
      <td className={`${tdClassName} text-md font-semibold text-gray-800`}>
        {grupo.grupo}
      </td>
      <td className={tdClassName}>{grupo.lobatos}</td>
      <td className={tdClassName}>{grupo.explos}</td>
      <td className={tdClassName}>{grupo.pios}</td>
      <td className={tdClassName}>{grupo.rovers}</td>
      <td className={tdClassName}>{grupo.diris}</td>
      <td className={`${tdClassName} text-xl font-bold text-purple-900`}>
        {total}
      </td>
    </tr>
  );
}
