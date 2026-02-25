import { useAuth } from "../../contexts/AuthContext";
import logo from "../../assets/florDeLiz.png";
import { useState, useEffect } from "react";
import { useParams } from "react-router-dom";
import Button from "../../components/Button";
import Modal from "../../components/Modal";
import ChangePasswordForm from "../../components/pageComponents/ChangePasswordForm";
import SalirUnidadButton from "../../components/pageComponents/SalirUnidadButton";
import { getMiembrosUnidad } from "../../services/unidadService";
import {
  getDiriProfile,
  getScoutProfile,
  updateDiriProfile,
  updateScoutProfile,
} from "../../services/profileService";
import LoadingPage from "../../components/LoadingPage";
import ProfileBox from "../../components/pageComponents/profile/ProfileBox";
import EditProfileForm from "../../components/pageComponents/profile/EditProfileForm";

export default function ProfilePage() {
  const { user } = useAuth();
  const { unidadId: unidadIdParam } = useParams();
  const [isModalOpen, setIsModalOpen] = useState(false);

  const [esUltimoDirigente, setEsUltimoDirigente] = useState(false);
  const [loadingCheck, setLoadingCheck] = useState(true);
  const [currentUnit, setCurrentUnit] = useState(null);
  const [redirectPath, setRedirectPath] = useState("/");
  const [perfil, setPerfil] = useState();
  const [isLoading, setIsLoading] = useState(true);
  const rol =
    user.tipoId === 1 ? "Scout" : user.tipoId === 2 ? "Dirigente" : "Usuario";
  const [isEditing, setIsEditing] = useState(false);

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

      const comprobarMiembros = async () => {
        try {
          const miembros = await getMiembrosUnidad(currentUnit.id);

          const dirigentes = miembros.filter((m) => m.tipoId === 2);

          if (dirigentes.length === 1 && dirigentes[0].id === user.id) {
            setEsUltimoDirigente(true);
          } else {
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

  useEffect(() => {
    const obtenerPerfil = async () => {
      try {
        setIsLoading(true);
        const myProfile =
          user.tipoId === 1 ? await getScoutProfile() : await getDiriProfile();
        setPerfil({ ...myProfile, rol });
      } catch (error) {
        console.error("Error al obtener el perfil", error);
      } finally {
        setIsLoading(false);
      }
    };

    obtenerPerfil();
  }, [rol, user.tipoId]);

  const updateProfile = async (data) => {
    try {
      user.tipoId === 1
        ? await updateScoutProfile(data)
        : await updateDiriProfile(data);

      setPerfil((prev) => ({ ...prev, ...data }));
    } catch (e) {
      console.error("No se pudo actualizar el perfil", e);
    } finally {
      setIsEditing(false);
    }
  };

  if (!user) {
    return (
      <div className="p-8">
        <h1 className="text-purple-900">Mi Perfil (Yo)</h1>
        <p className="mt-4 text-gray-700">Cargando datos del usuario...</p>
      </div>
    );
  }

  if (isLoading) {
    return <LoadingPage />;
  }
  return (
    <div className="w-full max-w-lg mx-auto px-4 py-8">
      <div className="flex flex-col items-center mb-10">
        <img
          src={logo}
          alt="Foto de perfil"
          className="w-40 h-40 rounded-full border-4 border-purple-300 p-2"
        />

        <h2 className="text-4xl font-bold text-purple-800 mt-4">
          {user.nombreUsuario}
        </h2>
      </div>

      {isEditing ? (
        <EditProfileForm
          user={perfil}
          onCancel={() => setIsEditing(false)}
          onSuccess={(data) => updateProfile(data)}
        />
      ) : (
        <ProfileBox user={perfil} />
      )}
      <hr className="my-8 border-gray-200" />

      <div className="flex flex-col items-center">
        <h3 className="text-lg font-semibold text-gray-700 mb-2">Opciones</h3>

        {!isEditing && (
          <Button
            className="w-full text-center mt-2 px-5 py-2 bg-purple-500 text-white rounded-full hover:bg-purple-700 focus:outline-none focus:ring-2 focus:ring-purple-500 focus:ring-opacity-50"
            onClick={() => setIsEditing(true)}
          >
            Editar Perfil
          </Button>
        )}

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
