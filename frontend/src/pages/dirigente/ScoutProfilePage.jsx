import { useEffect, useState } from "react";
import { useLocation, useNavigate, useParams } from "react-router-dom";
import {
  getScoutProfileById,
  updateScoutProfileById,
} from "../../services/profileService";
import LoadingPage from "../../components/LoadingPage";
import logo from "../../assets/florDeLiz.png";
import Button from "../../components/Button";
import EditProfileForm from "../../components/pageComponents/profile/EditProfileForm";
import ProfileBox from "../../components/pageComponents/profile/ProfileBox";

export default function ScoutProfilePage() {
  const { scoutId, unidadId } = useParams();
  const location = useLocation();
  const scoutNombre = location.state?.scoutNombre || "Scout---";
  const rol = location.state?.rolNombre || "Rol---";
  const nav = useNavigate();

  const [perfil, setPerfil] = useState();
  const [isLoading, setIsLoading] = useState(true);
  const [isEditing, setIsEditing] = useState(false);

  useEffect(() => {
    const getPerfil = async () => {
      try {
        const scoutPerfil = await getScoutProfileById(scoutId);
        setPerfil({ ...scoutPerfil, rol });
      } catch (error) {
        console.log("Error al conseguir el perfil", error);
      } finally {
        setIsLoading(false);
      }
    };

    getPerfil();
  }, [rol, scoutId]);

  const updateProfile = async (data) => {
    try {
      await updateScoutProfileById(data, scoutId);
      setPerfil((prev) => ({ ...prev, ...data }));
    } catch (e) {
      console.error("No se pudo actualizar el perfil", e);
    } finally {
      setIsEditing(false);
    }
  };

  if (isLoading) return <LoadingPage />;

  return (
    <div className="w-full max-w-lg mx-auto pt-4">
      <div className="flex flex-col items-center space-y-5 md:flex-row-reverse md:justify-between w-full">
        <Button
          className="px-4 py-2 h-fit w-fit"
          onClick={() => nav(`/diri/unidad/${unidadId}/miembros`)}
        >
          <span className="material-symbols-outlined mr-2">arrow_back</span>
          Volver a Miembros
        </Button>
        <div className="flex flex-col items-center mb-10">
          <img
            src={logo}
            alt="Foto de perfil"
            className="w-32 h-32 rounded-full object-cover border-4 border-purple-300 p-1"
          />

          <h2 className="text-4xl font-bold text-purple-800 mt-4">
            {scoutNombre}
          </h2>
        </div>
      </div>

      <div>
        {isEditing ? (
          <EditProfileForm
            user={perfil}
            onCancel={() => setIsEditing(false)}
            onSuccess={(data) => updateProfile(data)}
          />
        ) : (
          <ProfileBox user={perfil} />
        )}

        {!isEditing && (
          <Button
            className="w-full text-center mt-2 px-5 py-2 bg-purple-500 text-white rounded-full hover:bg-purple-700 focus:outline-none focus:ring-2 focus:ring-purple-500 focus:ring-opacity-50"
            onClick={() => setIsEditing(true)}
          >
            Editar Perfil
          </Button>
        )}
      </div>
    </div>
  );
}
