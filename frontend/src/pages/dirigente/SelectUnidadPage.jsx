import { useNavigate } from "react-router-dom";
import logo from "../../assets/florDeLiz.png";
import Button from "../../components/Button";
import { useAuth } from "../../contexts/AuthContext";
import LogOutButton from "../../components/pageComponents/LogoutButton";
import SerDirigenteButton from "../../components/pageComponents/SerDirigenteButton";
import { roverToDiri } from "../../services/userService";
import { useState } from "react";
import Modal from "../../components/Modal";

export default function SelectUnidadPage() {
  const { user } = useAuth();
  const { handleLogin } = useAuth();
  const nav = useNavigate();

  const [modalIsOpen, setModalIsOpen] = useState(false);
  const [confirmText, setConfirmText] = useState("");

  function calcularEdad(fechaNacimiento) {
    const hoy = new Date();
    const nacimiento = new Date(fechaNacimiento);
    let edad = hoy.getFullYear() - nacimiento.getFullYear();
    const diferenciaMeses = hoy.getMonth() - nacimiento.getMonth();

    if (
      diferenciaMeses < 0 ||
      (diferenciaMeses === 0 && hoy.getDate() < nacimiento.getDate())
    ) {
      edad--;
    }
    return edad;
  }

  const toDiri = async () => {
    if (confirmText === "SOY DIRIGENTE") {
      try {
        const user = await roverToDiri();
        handleLogin(user);
        modalIsOpen(false);
      } catch (error) {
        console.log(error);
      }
    }
  };

  const closeModal = () => {
    setModalIsOpen(false);
    setConfirmText("");
  };

  return (
    <div className="bg-[#622599] min-h-screen h-full w-full py-10 flex flex-col">
      <LogOutButton dark />

      <div className="flex flex-col justify-center items-center h-full w-full gap-y-8 grow">
        <h1 className="text-white text-center">
          Bienvenido, {user?.nombre || "Usuario"}
        </h1>
        <img
          src={logo}
          alt="Flor de Liz Nacional"
          className="w-1/2 md:w-auto"
        />

        <div className="lg:w-1/4 md:w-1/2 w-3/4 flex flex-col gap-8">
          <Button
            dark
            className="space-x-5 px-6 py-1.5"
            onClick={() => {
              nav("/unirse-unidad");
            }}
          >
            <span className="material-symbols-outlined text-white text-4xl!">
              camping
            </span>
            <p className="text-[16px] md:text-[20px] text-white">
              Unirse a una Unidad
            </p>
          </Button>

          {user?.tipoId === 2 && (
            <Button
              dark
              className="space-x-5 px-6 py-1.5"
              onClick={() => {
                nav("/crear-unidad");
              }}
            >
              <span className="material-symbols-outlined text-white text-4xl!">
                add
              </span>
              <p className="text-[16px] md:text-[20px] text-white">
                Crear Unidad
              </p>
            </Button>
          )}

          {calcularEdad(user.fechaNacimiento) > 18 && user.tipoId == 1 && (
            <SerDirigenteButton onCLick={() => setModalIsOpen(true)} />
          )}

          <Modal
            isOpen={modalIsOpen}
            onClose={closeModal}
            title={"Advertencia"}
          >
            <p>
              Al cambiar tu cuenta de Scout a Dirigente, la acción será
              permanente y no podrás revertirla a Scout. ¿Estás seguro de que
              deseas continuar?
            </p>
            <span className="block mt-4">
              <p>
                Para confirmar, por favor escribe <strong>SOY DIRIGENTE</strong>
                y presiona "Confirmar".
              </p>
            </span>
            <input
              type="text"
              value={confirmText}
              onChange={(e) => setConfirmText(e.target.value)}
              placeholder="Escribe aquí..."
              className="border p-2 w-full mt-2"
            />

            <div className="flex justify-end gap-2 mt-4">
              <Button
                onClick={closeModal}
                className="bg-gray-300 px-4 py-2 rounded"
              >
                Cancelar
              </Button>

              <Button
                onClick={toDiri}
                disabled={confirmText !== "SOY DIRIGENTE"}
                className={`px-4 py-2 rounded ${
                  confirmText === "SOY DIRIGENTE"
                    ? "bg-blue-600 text-white cursor-pointer"
                    : "bg-blue-300 text-white cursor-not-allowed!"
                }`}
              >
                Confirmar
              </Button>
            </div>
          </Modal>
        </div>
      </div>
    </div>
  );
}
