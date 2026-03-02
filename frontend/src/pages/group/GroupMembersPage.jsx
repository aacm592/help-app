import { useEffect, useState } from "react";
import MiembrosUnidadTable from "../../components/pageComponents/group/MiembrosUnidadTable";
import LoadingPage from "../../components/LoadingPage";
import { getGroupMembers } from "../../services/grupoService";

export default function GroupMembersPage() {
  const [unidades, setUnidades] = useState([]);
  const [isLoading, setIsLoading] = useState(true);
  const thClassName =
    "border-y border-gray-100 px-2 py-5 text-purple-900 font-bold";
  const tdClassName = "border-y border-gray-300 px-2 py-4";
  const tableClassName = "bg-purple-300";

  useEffect(() => {
    const getResumen = async () => {
      setIsLoading(true);
      try {
        const grupo = await getGroupMembers();
        setUnidades(grupo);
      } catch (error) {
        console.error("Error al obtener resumenes", error);
      } finally {
        setIsLoading(false);
      }
    };

    getResumen();
  }, []);

  if (isLoading) return <LoadingPage />;
  return (
    <div className="w-full p-4">
      <h1 className="text-purple-900 md:text-left text-center">
        Miembros del grupo
      </h1>
      {unidades.map((u) => (
        <>
          <MiembrosUnidadTable
            key={u.id}
            unidad={u.nombre}
            scouts={u.scouts}
            dirigentes={u.dirigentes}
            rama={u.rama}
            thClassName={thClassName}
            tdClassName={tdClassName}
            tableClassName={tableClassName}
          />
          <br />
        </>
      ))}
    </div>
  );
}
