import { useEffect, useState } from "react";
import { useParams, useNavigate } from "react-router-dom";
import { useAuth } from "../../contexts/AuthContext";
import Button from "../../components/Button";
import UnidadInfoBox from "../../components/pageComponents/UnidadInfoBox";
import LogOutButton from "../../components/pageComponents/LogoutButton";

export default function HomeUnidadDirigente() {
  const { unidadId } = useParams();
  const { user } = useAuth();
  const nav = useNavigate();
  const [unidad, setUnidad] = useState(null);

  const buttonClass = "w-full space-x-10 justify-center px-7 py-2";
  const textClass = "text-[18px] md:text-[22px] text-purple-800";
  const iconClass = "material-symbols-outlined !text-4xl text-purple-800";

  useEffect(() => {
    if (user && user.unidades) {
      const unidadEncontrada = user.unidades.find(
        (u) => u.id.toString() === unidadId
      );
      if (unidadEncontrada) {
        setUnidad(unidadEncontrada);
      } else {
        nav("/dirigente");
      }
    }
  }, [user, unidadId, nav]);

  if (!unidad) {
    return (
      <div className="flex justify-center items-center min-h-screen bg-white">
        <h2 className="text-3xl text-purple-800 font-bold">Cargando...</h2>
      </div>
    );
  }

  return (
    <div className="flex flex-col items-center min-h-screen bg-white text-black p-8">
      <div className="flex flex-col items-center w-full py-10">
        <UnidadInfoBox user={user} unidad={unidad} />
      </div>

      <div className="w-full lg:w-1/3 flex flex-col gap-6">
        <Button className={buttonClass}>
          <span className={iconClass}>groups</span>
          <p className={textClass}>Ver Mi Unidad</p>
        </Button>
        <Button
          className={buttonClass}
          onClick={() =>
            nav(`/dirigente/unidad/${unidadId}/gestionar-objetivos`)
          }
        >
          <span className={iconClass}>checklist</span>
          <p className={textClass}>Gestionar Objetivos</p>
        </Button>

        <Button className={buttonClass} onClick={() => nav("/diri")}>
          <span className={iconClass}>arrow_back</span>
          <p className={textClass}>Ir a otra unidad</p>
        </Button>

        <Button
          dark
          className="w-full space-x-4 justify-center bg-red-700 hover:bg-red-600 px-7 py-2 outline-3 mt-2"
          onClick={() => console.log("Saliendo de la unidad...")}
        >
          <span className="material-symbols-outlined !text-4xl text-white">
            exit_to_app
          </span>
          <p className="text-[18px] md:text-[22px] text-white">
            Salir de la unidad
          </p>
        </Button>
      </div>
    </div>
  );
}
