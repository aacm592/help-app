import { useEffect, useState } from "react";
import LoadingPage from "../../components/LoadingPage";
import { getAdminsDeGrupo } from "../../services/grupoService";
import GenericTable from "../../components/GenericTable";
import Button from "../../components/Button";
import { addGroupAdmin, deleteGroupAdmin } from "../../services/permisoService";
import AdminRow from "../../components/pageComponents/group/AdminRow";

export default function GroupAdminsPage() {
  const [admins, setAdmins] = useState([]);
  const [isLoading, setIsLoading] = useState(true);
  const [isSubmitting, setIsSubmitting] = useState(false);
  const [adminUserName, setAdminUsername] = useState("");

  const thClassName =
    "border-y border-gray-100 px-2 py-5 text-green-900 font-bold";
  const tdClassName = "border-y border-gray-300 px-2 py-4";
  const tableClassName = "bg-sky-200";
  const trClassName = "hover:bg-indigo-50 transition-colors";
  const buttonClassName =
    "w-full p-2 justify-center rounded-md bg-red-600 text-yellow-300 border-red-950";

  const fetchAdmins = async () => {
    try {
      const a = await getAdminsDeGrupo();
      setAdmins(a);
    } catch (error) {
      console.error("Error al obtener administradores", error);
    } finally {
      setIsLoading(false);
    }
  };

  useEffect(() => {
    fetchAdmins();
  }, []);

  const handleAddAdmin = async () => {
    if (!adminUserName.trim()) return alert("Ingresa un nombre de usuario");

    setIsSubmitting(true);
    try {
      await addGroupAdmin(adminUserName);
      alert("Administrador añadido con éxito");
      setAdminUsername("");
      fetchAdmins();
    } catch (error) {
      alert(error || "Error al añadir administrador");
    } finally {
      setIsSubmitting(false);
    }
  };

  const handleDeleteAdmin = async (id) => {
    setIsSubmitting(true);
    try {
      await deleteGroupAdmin(id);
      alert("Administrador eliminado con éxito");
      fetchAdmins();
    } catch (error) {
      alert(error || "Error al eliminar administrador");
    } finally {
      setIsSubmitting(false);
    }
  };

  if (isLoading) return <LoadingPage />;
  return (
    <div className="w-full md:px-10 px-4 py-4">
      <h1 className="text-purple-900 md:text-left text-center">
        Administradores
      </h1>
      <div className="bg-white p-6 rounded-xl shadow-sm border border-gray-200 flex flex-col md:flex-row gap-4 items-end">
        <div className="flex flex-col gap-2 w-full md:w-1/3">
          <label className="text-sm font-semibold text-gray-600">
            Username del usuario
          </label>
          <input
            type="text"
            className="border border-gray-300 p-2 rounded-md focus:ring-2 focus:ring-purple-500 outline-none"
            placeholder="ej: scout_pro_2024"
            value={adminUserName}
            onChange={(e) => setAdminUsername(e.target.value)}
          />
        </div>
        <Button
          onClick={handleAddAdmin}
          disabled={isSubmitting}
          className="w'fit px-4 py-2 rounded-md"
        >
          {isSubmitting ? "Añadiendo..." : "Añadir administrador"}
        </Button>
      </div>
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
          "Estado",
          "Estado de registro",
        ]}
      >
        {admins.map((d) => (
          <AdminRow
            key={d.id}
            member={d}
            fields={["profesion", "ocupacion", "cargo1", "cargo2"]}
            tdClassName={tdClassName}
            trClassName={trClassName}
            buttonClassName={buttonClassName}
            hasButton
            onDelete={() => {
              handleDeleteAdmin(d.id);
            }}
          />
        ))}
      </GenericTable>
    </div>
  );
}
