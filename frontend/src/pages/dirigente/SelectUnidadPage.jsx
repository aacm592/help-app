import { useNavigate } from "react-router-dom";
import logo from "../../assets/florDeLiz.png";
import Button from "../../components/Button";
import { useAuth } from "../../contexts/AuthContext";
import LogOutButton from "../../components/pageComponents/LogoutButton";

export default function SelectUnidadPage() {
  const { user } = useAuth();
  const nav = useNavigate();
  const tieneUnidades = user?.unidades && user.unidades.length > 0;

  const handleUnidadClick = (unidadId) => {
    nav(`/diri/unidad/${unidadId}`);
  };

  return (
    <div className="bg-purple-600 min-h-screen h-full w-screen py-10 flex flex-col">
      <LogOutButton dark />

      <div className="flex flex-col justify-center items-center h-full w-full gap-y-8 grow">
        <h1 className="text-white">Bienvenido, {user?.nombre || "Usuario"}</h1>
        <img
          src={logo}
          alt="Flor de Liz Nacional"
          className="w-1/2 md:w-auto"
        />

        {tieneUnidades ? (
          <>
            <p className="text-white text-2xl font-semibold">
              Selecciona una Unidad
            </p>
            <div className="lg:w-1/4 md:w-1/2 w-3/4 flex flex-col gap-4">
              {user.unidades.map((unidad) => (
                <Button
                  key={unidad.id}
                  dark
                  className="justify-center px-6 py-1.5"
                  onClick={() => handleUnidadClick(unidad.id)}
                >
                  <p className="text-[16px] md:text-[20px] text-white">
                    {unidad.nombre}
                  </p>
                </Button>
              ))}
            </div>
            <hr className="w-3/4 md:w-1/2 lg:w-1/4 my-4 border-t-2 border-white" />
          </>
        ) : (
          <p className="text-white">Aún no estás dentro de una manada</p>
        )}

        <div className="lg:w-1/4 md:w-1/2 w-3/4 flex flex-col gap-8">
          <Button
            dark
            className="space-x-5 px-6 py-1.5"
            onClick={() => {
              nav("/unirse-unidad");
            }}
          >
            <span className="material-symbols-outlined text-white !text-4xl">
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
                nav("/diri/crear-unidad");
              }}
            >
              <span className="material-symbols-outlined text-white !text-4xl">
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
