import { useEffect, useState } from "react";
import MiembrosUnidadTable from "../../components/pageComponents/group/MiembrosUnidadTable";
import LoadingPage from "../../components/LoadingPage";
import {
  getGroupAdminsRegisters,
  getGroupRegisters,
} from "../../services/registerService";
import GenericTable from "../../components/GenericTable";
import MemberRow from "../../components/pageComponents/group/MemberRow";

export default function RegistrosGrupoPage() {
  const [unidades, setUnidades] = useState([]);
  const [admins, setAdmins] = useState([]);
  const [isLoading, setIsLoading] = useState(true);
  const thClassName =
    "border-y border-gray-100 px-2 py-5 text-purple-900 font-bold";
  const tdClassName = "border-y border-gray-300 px-2 py-4";
  const tableClassName = "bg-violet-300";
  const trClassName = "hover:bg-violet-100 transition-colors";

  useEffect(() => {
    const getResumen = async () => {
      setIsLoading(true);
      try {
        const grupo = await getGroupRegisters();
        const a = await getGroupAdminsRegisters();
        setUnidades(grupo);
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
        Registros del grupo
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
            tableClassName={tableClassName}
            trClassName={trClassName}
          />
        ))}
        <h2 className="text-2xl font-bold text-purple-900">Administradores</h2>
        <GenericTable
          title=""
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
            "Estado de registro",
          ]}
        >
          {admins.map((d) => (
            <MemberRow
              key={d.id}
              member={d}
              fields={["profesion", "ocupacion", "cargo1", "cargo2"]}
              tdClassName={tdClassName}
              trClassName={trClassName}
            />
          ))}
        </GenericTable>
      </div>
    </div>
  );
}
