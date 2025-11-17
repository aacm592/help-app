import { useAuth } from "../../contexts/AuthContext";
import logo from "../../assets/florDeLiz.png";
import ProfileInfoItem from "../../components/pageComponents/ProfileInfoItem";
import { useState } from "react";
import Button from "../../components/Button";
import Modal from "../../components/Modal";
import ChangePasswordForm from "../../components/pageComponents/ChangePasswordForm";

const formatFecha = (fechaString) => {
  if (!fechaString) return "No especificada";
  try {
    const date = new Date(fechaString);
    if (isNaN(date.getTime())) {
      throw new Error("Fecha inválida");
    }
    return date.toLocaleDateString("es-ES", {
      year: "numeric",
      month: "long",
      day: "numeric",
      timeZone: "UTC",
    });
  } catch (error) {
    console.error("Error formateando fecha:", error);
    return fechaString;
  }
};

export default function ProfilePage() {
  const { user } = useAuth();
  const [isModalOpen, setIsModalOpen] = useState(false);

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
          className="mt-2 px-5 py-2 bg-purple-600 text-white rounded-full hover:bg-purple-700 focus:outline-none focus:ring-2 focus:ring-purple-500 focus:ring-opacity-50"
          onClick={() => setIsModalOpen(true)}
        >
          Cambiar Contraseña
        </Button>
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
