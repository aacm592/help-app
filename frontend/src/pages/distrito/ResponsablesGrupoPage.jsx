import { useEffect, useState } from "react";
import LoadingPage from "../../components/LoadingPage";
import GenericTable from "../../components/GenericTable";
import Button from "../../components/Button";
import { getRespGrupo } from "../../services/distritoService";
import { addRespGrupo, deleteRespGrupo } from "../../services/permisoService";
import RespGrupoRow from "../../components/pageComponents/distrito/RespGrupoRow";
import Modal from "../../components/Modal";

export default function ResponsablesGrupoPage() {
  const [admins, setAdmins] = useState([]);
  const [isLoading, setIsLoading] = useState(true);
  const [isSubmitting, setIsSubmitting] = useState(false);

  const [isModalOpen, setIsModalOpen] = useState(false);
  const [selectedGrupo, setSelectedGrupo] = useState(null);
  const [username, setUsername] = useState("");

  const thClassName =
    "border-y border-gray-100 px-2 py-5 text-green-900 font-bold";
  const tdClassName = "border-y border-gray-300 px-2 py-4 items-center";
  const tableClassName = "bg-sky-200";
  const trClassName = "hover:bg-indigo-50 transition-colors";

  const fetchAdmins = async () => {
    try {
      const a = await getRespGrupo();
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

  const handleAddClick = (grupo) => {
    setSelectedGrupo(grupo);
    setUsername("");
    setIsModalOpen(true);
  };

  const handleConfirmAdd = async () => {
    if (!username.trim()) return alert("Ingresa un nombre de usuario");

    setIsSubmitting(true);
    try {
      await addRespGrupo(username, selectedGrupo.grupoId);
      setIsModalOpen(false);
      await fetchAdmins();
    } catch (error) {
      alert(error.response?.data || "Error al asignar responsable");
    } finally {
      setIsSubmitting(false);
    }
  };

  const handleDelete = async (adminId) => {
    if (!window.confirm("¿Estás seguro de quitar a este responsable?")) return;

    try {
      await deleteRespGrupo(adminId);
      await fetchAdmins();
    } catch (error) {
      console.error("Error al eliminar", error);
    }
  };

  if (isLoading) return <LoadingPage />;

  return (
    <div className="w-full md:px-10 px-4 py-4">
      <h1 className="text-purple-900 md:text-left text-center text-2xl font-bold mb-4">
        Responsables de Grupo
      </h1>

      <GenericTable
        title="Listado de Administradores"
        tableClassName={tableClassName}
        thClassName={thClassName}
        headers={[
          "Grupo",
          "Nombre",
          "Telf/Celular",
          "Estado Registro",
          "Acción",
        ]}
      >
        {admins.map((r) => (
          <RespGrupoRow
            key={r.grupoId}
            resp={r}
            tdClassName={tdClassName}
            trClassName={trClassName}
          >
            <td className={tdClassName}>
              {r.id === 0 || r.nombre === "Sin responsable" ? (
                <Button
                  className="bg-green-600 hover:bg-green-700 text-white px-3 py-1 rounded"
                  onClick={() => handleAddClick(r)}
                >
                  Asignar
                </Button>
              ) : (
                <Button
                  className="bg-red-600 hover:bg-red-700 text-white px-3 py-1 rounded"
                  onClick={() => handleDelete(r.id)}
                >
                  Quitar
                </Button>
              )}
            </td>
          </RespGrupoRow>
        ))}
      </GenericTable>

      <Modal
        isOpen={isModalOpen}
        onClose={() => !isSubmitting && setIsModalOpen(false)}
        title="Asignar Responsable"
      >
        <div className="flex flex-col gap-4">
          <p className="text-gray-600">
            Asignando responsable para el grupo:{" "}
            <span className="font-bold">{selectedGrupo?.grupo}</span>
          </p>

          <input
            type="text"
            placeholder="Username del usuario"
            className="border p-2 rounded-md focus:outline-purple-500"
            value={username}
            onChange={(e) => setUsername(e.target.value)}
            disabled={isSubmitting}
          />

          <div className="flex justify-end gap-2 mt-4">
            <Button
              className="bg-gray-300 text-gray-700 px-4 py-2 rounded"
              onClick={() => setIsModalOpen(false)}
              disabled={isSubmitting}
            >
              Cancelar
            </Button>
            <Button
              className="bg-purple-700 text-white px-4 py-2 rounded disabled:opacity-50"
              onClick={handleConfirmAdd}
              disabled={isSubmitting}
            >
              {isSubmitting ? "Guardando..." : "Confirmar"}
            </Button>
          </div>
        </div>
      </Modal>
    </div>
  );
}
