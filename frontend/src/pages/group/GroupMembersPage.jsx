import { useEffect, useState } from "react";
import MiembrosUnidadTable from "../../components/pageComponents/group/MiembrosUnidadTable";
import LoadingPage from "../../components/LoadingPage";
import { getGroupMembers } from "../../services/grupoService";

export default function GroupMembersPage() {
  const [unidades, setUnidades] = useState([]);
  const [isLoading, setIsLoading] = useState(true);
  const thClassName =
    "border-y border-gray-100 px-2 py-5 text-green-900 font-bold";
  const tdClassName = "border-y border-gray-300 px-2 py-4";
  const tableClassName = "bg-sky-200";
  const trClassName = "hover:bg-indigo-50 transition-colors";
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
    <div className="w-full md:px-10 px-4 py-4">
      <h1 className="text-purple-900 md:text-left text-center">
        Miembros del grupo
      </h1>
      <div className="flex flex-col py-6 gap-10">
        {unidades.map((u) => (
          <MiembrosUnidadTable
            key={u.id}
            unidad={u.nombre}
            scouts={u.scouts}
            dirigentes={u.dirigentes}
            rama={u.rama}
            thClassName={thClassName}
            tdClassName={tdClassName}
            theadClassName={tableClassName}
            trClassName={trClassName}
          />
        ))}
      </div>
    </div>
  );
}
