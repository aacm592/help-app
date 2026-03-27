import { useNavigate } from "react-router-dom";
import logo from "../../assets/florDeLiz.png";
import Button from "../../components/Button";
import { useAuth } from "../../contexts/AuthContext";
import LogOutButton from "../../components/pageComponents/LogoutButton";

export default function SelectUnidadPage() {
  const { user } = useAuth();
  const nav = useNavigate();

  return (
    <div className="bg-purple-600 min-h-screen h-full w-full py-10 flex flex-col">
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
        </div>
      </div>
    </div>
  );
}
