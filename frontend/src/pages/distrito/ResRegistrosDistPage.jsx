import { useEffect, useState } from "react";
import { getResumenRegistrosDistrito } from "../../services/distritoService";
import ResumenRow from "../../components/pageComponents/distrito/ResumenRow";
import GenericTable from "../../components/GenericTable";

export default function ResRegistrosDistPage() {
  const [grupos, setGrupos] = useState([]);

  const thClassName =
    "border-y border-gray-100 px-2 py-5 text-green-900 font-bold";
  const tdClassName = "border-y border-gray-300 px-2 py-4";
  const tableClassName = "bg-teal-200";
  const trClassName = "hover:bg-indigo-50 transition-colors justify-evenly";

  useEffect(() => {
    const getResumen = async () => {
      try {
        const resumen = await getResumenRegistrosDistrito();
        setGrupos(resumen);
      } catch (error) {
        console.error("Error al conseguir los registros", error);
      }
    };

    getResumen();
  }, []);

  return (
    <div className="w-full md:px-10 px-4 py-4">
      <h1 className="text-purple-900 md:text-left text-center">
        Resumen Registros Distritales
      </h1>
      <GenericTable
        title=""
        theadClassName={tableClassName}
        tableClassName="table-fixed"
        thClassName={thClassName}
        headers={["Grupo", "L", "E", "P", "R", "D", "Total"]}
      >
        {grupos.map((s, i) => (
          <ResumenRow
            key={i}
            grupo={s}
            tdClassName={tdClassName}
            trClassName={trClassName}
          />
        ))}
      </GenericTable>
    </div>
  );
}
