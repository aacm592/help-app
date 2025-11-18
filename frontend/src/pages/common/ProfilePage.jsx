import { useAuth } from "../../contexts/AuthContext";
import logo from "../../assets/florDeLiz.png";
import ProfileInfoItem from "../../components/pageComponents/ProfileInfoItem";
import { useState, useEffect } from "react";
import { useParams } from "react-router-dom";
import Button from "../../components/Button";
import Modal from "../../components/Modal";
import ChangePasswordForm from "../../components/pageComponents/ChangePasswordForm";
import SalirUnidadButton from "../../components/pageComponents/SalirUnidadButton";
import { getMiembrosUnidad } from "../../services/unidadService";
import { formatFecha } from "../../utils/dateFormatter";

export default function ProfilePage() {
  const { user } = useAuth();
  const { unidadId: unidadIdParam } = useParams();
  const [isModalOpen, setIsModalOpen] = useState(false);

  const [esUltimoDirigente, setEsUltimoDirigente] = useState(false);
  const [loadingCheck, setLoadingCheck] = useState(true);
  const [currentUnit, setCurrentUnit] = useState(null);
  const [redirectPath, setRedirectPath] = useState("/");

  useEffect(() => {
    if (user) {
      let unitToLeave = null;

      if (user.tipoId === 1 && user.unidades?.length > 0) {
        unitToLeave = user.unidades[0];
        setRedirectPath("/home");
        setLoadingCheck(false);
      } else if (user.tipoId === 2 && unidadIdParam) {
        unitToLeave = user.unidades.find(
          (u) => u.id.toString() === unidadIdParam
        );
        setRedirectPath("/diri");
      }
      setCurrentUnit(unitToLeave);
    }
  }, [user, unidadIdParam]);

  useEffect(() => {
    if (user?.tipoId === 2 && currentUnit) {
      setLoadingCheck(true);
      console.log(
        "[DEBUG] Comprobando miembros para la unidad:",
        currentUnit.id
      );

      const comprobarMiembros = async () => {
        try {
          const miembros = await getMiembrosUnidad(currentUnit.id);
          console.log("[DEBUG] Miembros obtenidos:", miembros);

          const dirigentes = miembros.filter((m) => m.tipoId === 2);
          console.log("[DEBUG] Dirigentes encontrados:", dirigentes);

          if (dirigentes.length === 1 && dirigentes[0].id === user.id) {
            console.log("[DEBUG] ¡ES EL ÚLTIMO DIRIGENTE!");
            setEsUltimoDirigente(true);
          } else {
            console.log("[DEBUG] No es el último dirigente.");
            setEsUltimoDirigente(false);
          }
        } catch (error) {
          console.error("Error al comprobar miembros:", error.message);
          console.log("[DEBUG] ERROR al cargar miembros. Asumiendo 'false'.");
          setEsUltimoDirigente(false);
        } finally {
          setLoadingCheck(false);
        }
      };
      comprobarMiembros();
    } else {
      setLoadingCheck(false);
    }
  }, [currentUnit, user]);

  if (!user) {
    return (
      <div className="p-8">
        <h1 className="text-purple-900">Mi Perfil (Yo)</h1>
        <p className="mt-4 text-gray-700">Cargando datos del usuario...</p>
      </div>
    );
  }

  const rol =
    user.tipoId === 1 ? "Scout" : user.tipoId === 2 ? "Dirigente" : "Usuario";

  return (
    <div className="w-full max-w-lg mx-auto pt-4">
      <div className="flex flex-col items-center mb-10">
        <img
          src={logo}
          alt="Foto de perfil"
          className="w-32 h-32 rounded-full object-cover border-4 border-purple-300 p-1"
        />

        <h2 className="text-4xl font-bold text-purple-800 mt-4">
          {user.nombreUsuario}
        </h2>
      </div>

      <div className="space-y-6">
        <ProfileInfoItem
          icon="person"
          label="Nombre Completo"
          data={user.nombre}
        />

        <ProfileInfoItem
          icon="cake"
          label="Fecha de Nacimiento"
          data={formatFecha(user.fechaNacimiento)}
        />

        <ProfileInfoItem icon="badge" label="Rol" data={rol} />
      </div>

      <hr className="my-8 border-gray-200" />

      <div className="flex flex-col items-center">
        <h3 className="text-lg font-semibold text-gray-700 mb-2">Opciones</h3>
        <Button
          className="w-full text-center mt-2 px-5 py-2 bg-purple-600 text-white rounded-full hover:bg-purple-700 focus:outline-none focus:ring-2 focus:ring-purple-500 focus:ring-opacity-50"
          onClick={() => setIsModalOpen(true)}
        >
          Cambiar Contraseña
        </Button>

        {currentUnit && (
          <SalirUnidadButton
            unidadId={currentUnit.id}
            onSuccessRedirectPath={redirectPath}
            className="mt-4 w-full"
            esUltimoDirigente={esUltimoDirigente}
            disabled={loadingCheck}
          />
        )}
      </div>

      <Modal
        isOpen={isModalOpen}
        onClose={() => setIsModalOpen(false)}
        title="Cambiar Contraseña"
      >
        <ChangePasswordForm
          onCancel={() => setIsModalOpen(false)}
          onSuccess={() => setIsModalOpen(false)}
        />
      </Modal>
    </div>
  );
}
