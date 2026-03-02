import { useEffect, useState } from "react";
import { useParams } from "react-router-dom";
import { getMiembrosUnidadWithRegisters } from "../../services/unidadService";
import LoadingPage from "../../components/LoadingPage";
import MiembrosUnidadTable from "../../components/pageComponents/group/MiembrosUnidadTable";
import { registerUserToGroup } from "../../services/registerService";

export default function RegisterMembersPage() {
  const { unidadId } = useParams();
  const [unidad, setUnidad] = useState();
  const [isLoading, setIsLoading] = useState(true);

  const thClassName =
    "border-y border-gray-100 px-2 py-5 text-purple-900 font-bold";
  const tdClassName = "border-y border-gray-300 px-2 py-4";
  const tableClassName = "bg-purple-300";

  useEffect(() => {
    const getUnidad = async () => {
      try {
        const fetchedUnidad = await getMiembrosUnidadWithRegisters(unidadId);
        setUnidad(fetchedUnidad);
      } catch (error) {
        console.log("Error al conseguir el perfil", error);
      } finally {
        setIsLoading(false);
      }
    };

    getUnidad();
  }, [unidadId]);

  const register = async (id) => {
    try {
      await registerUserToGroup(id);

      setUnidad((prevUnidad) => {
        const updateMemberStatus = (members) =>
          members.map((m) =>
            m.id === id ? { ...m, registroStatus: "RegistroGrupo" } : m,
          );

        return {
          ...prevUnidad,
          scouts: updateMemberStatus(prevUnidad.scouts),
          dirigentes: updateMemberStatus(prevUnidad.dirigentes),
        };
      });

      alert("Usuario registrado en el grupo con éxito");
    } catch (error) {
      console.error("Error al registrar miembro:", error);
      alert(error.response?.data || "No se pudo completar el registro");
    }
  };

  if (isLoading) return <LoadingPage />;

  return (
    <div className="w-full p-4">
      <h1 className="text-purple-900 md:text-left text-center">
        Registrar miembros
      </h1>
      <MiembrosUnidadTable
        unidad={unidad.nombre}
        scouts={unidad.scouts}
        dirigentes={unidad.dirigentes}
        rama={unidad.rama}
        thClassName={thClassName}
        tdClassName={tdClassName}
        tableClassName={tableClassName}
        deletLevel={"RegistroGrupo"}
        hasButon
        onRegister={register}
      />
    </div>
  );
}
