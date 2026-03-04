import { useEffect, useState } from "react";
import LoadingPage from "../../components/LoadingPage";
import { getAdminsDeGrupo } from "../../services/grupoService";
import GenericTable from "../../components/GenericTable";
import MemberRow from "../../components/pageComponents/group/MemberRow";
import {
  cancelRegisterUserToGroup,
  registerUserToGroup,
} from "../../services/registerService";

export default function RegisterGroupAdminsPage() {
  const [admins, setAdmins] = useState([]);
  const [isLoading, setIsLoading] = useState(true);
  const thClassName =
    "border-y border-gray-100 px-2 py-5 text-green-900 font-bold";
  const tdClassName = "border-y border-gray-300 px-2 py-4";
  const tableClassName = "bg-sky-200";
  const trClassName = "hover:bg-indigo-50 transition-colors";

  const buttonClassName = "w-full p-2 justify-center rounded-md";
  const cancelButtonClassName = `${buttonClassName} bg-red-600 text-yellow-300 border-red-950`;

  const commonProps = {
    tdClassName,
    trClassName,
    buttonClassName,
    cancelButtonClassName,
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

  const register = async (id) => {
    try {
      await registerUserToGroup(id);

      const newAdmins = admins.map((m) =>
        m.id === id ? { ...m, registroStatus: "RegistroGrupo" } : m,
      );
      setAdmins(newAdmins);

      alert("Usuario registrado en el grupo con éxito");
    } catch (error) {
      console.error("Error al registrar miembro:", error);
      alert(error || "No se pudo completar el registro");
    }
  };

  const cancelRgister = async (id) => {
    try {
      await cancelRegisterUserToGroup(id);

      const newAdmins = admins.map((m) =>
        m.id === id ? { ...m, registroStatus: "No registrado" } : m,
      );
      setAdmins(newAdmins);

      alert("Registro cancelado");
    } catch (error) {
      console.error("Error al cancelar registro:", error);
      alert(error.response?.data || "No se pudo cancelar el registro");
    }
  };

  if (isLoading) return <LoadingPage />;
  return (
    <div className="w-full md:px-10 px-4 py-4">
      <h1 className="text-purple-900 md:text-left text-center">
        Registrar miembros
      </h1>
      <GenericTable
        title="Administradores"
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
          "Acción",
        ]}
      >
        {admins.map((d) => (
          <MemberRow
            key={d.id}
            member={d}
            fields={["profesion", "ocupacion", "cargo1", "cargo2"]}
            {...commonProps}
            deletLevel={"RegistroGrupo"}
            hasButton
            onRegister={register}
            onCancel={cancelRgister}
          />
        ))}
      </GenericTable>
    </div>
  );
}
