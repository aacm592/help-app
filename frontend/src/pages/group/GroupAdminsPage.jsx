import { useEffect, useState } from "react";
import LoadingPage from "../../components/LoadingPage";
import { getAdminsDeGrupo } from "../../services/grupoService";
import GenericTable from "../../components/GenericTable";
import MemberRow from "../../components/pageComponents/group/MemberRow";

export default function GroupAdminsPage() {
  const [admins, setAdmins] = useState([]);
  const [isLoading, setIsLoading] = useState(true);
  const thClassName =
    "border-y border-gray-100 px-2 py-5 text-green-900 font-bold";
  const tdClassName = "border-y border-gray-300 px-2 py-4";
  const tableClassName = "bg-sky-200";
  const trClassName = "hover:bg-indigo-50 transition-colors";

  const commonProps = {
    tdClassName,
    trClassName,
  };

  useEffect(() => {
    const getResumen = async () => {
      setIsLoading(true);
      try {
        const a = await getAdminsDeGrupo();
        setAdmins(a);
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
      <GenericTable
        title="Dirigentes"
        tableClassName={tableClassName}
        thClassName={thClassName}
        headers={[
          "Nombre",
          "Edad",
          "Rol",
          "Profesión",
          "Ocupación",
          "Cargo 1",
          "Cargo 2",
          "Estado",
        ]}
      >
        {admins.map((d) => (
          <MemberRow
            key={d.id}
            member={d}
            fields={["profesion", "ocupacion", "cargo1", "cargo2"]}
            {...commonProps}
          />
        ))}
      </GenericTable>
    </div>
  );
}
