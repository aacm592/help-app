import { useEffect, useState } from "react";
import { useParams, useNavigate } from "react-router-dom";
import { useAuth } from "../../contexts/AuthContext";
import Button from "../../components/Button";
import UnidadInfoBox from "../../components/pageComponents/UnidadInfoBox";

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
        nav("/diri");
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
      <div className="flex flex-col items-center w-full">
        <UnidadInfoBox user={user} unidad={unidad} />
      </div>

      <div className="w-full lg:w-1/3 flex flex-col gap-6 py-10">
        <Button
          className={buttonClass}
          onClick={() => nav(`/diri/unidad/${unidadId}/miembros`)}
        >
          <span className={iconClass}>groups</span>
          <p className={textClass}>Ver Mi Unidad</p>
        </Button>
        <Button
          className={buttonClass}
          onClick={() => nav(`/diri/unidad/${unidadId}/gestionar-objetivos`)}
        >
          <span className={iconClass}>checklist</span>
          <p className={textClass}>Gestionar Objetivos</p>
        </Button>

        <Button className={buttonClass} onClick={() => nav("/diri")}>
          <span className={iconClass}>arrow_back</span>
          <p className={textClass}>Ir a otra unidad</p>
        </Button>
      </div>
    </div>
  );
}
