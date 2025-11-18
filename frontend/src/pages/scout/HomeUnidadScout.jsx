import Button from "../../components/Button";
import UnidadInfoBox from "../../components/pageComponents/UnidadInfoBox";
import { useAuth } from "../../contexts/AuthContext";
import { useNavigate } from "react-router-dom";

export default function HomeUnidadScout() {
  const { user } = useAuth();
  const nav = useNavigate();
  const unidad = user?.unidades?.[0];

  const buttonClass = "w-full space-x-10 justify-center px-7 py-2";
  const textClass = "text-[18px] md:text-[22px] text-purple-800";
  const iconClass = "material-symbols-outlined text-4xl! text-purple-800";

  if (!unidad) {
    setTimeout(() => nav("/home"), 1000);
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
        <Button className={buttonClass} onClick={() => nav("/scout/objetivos")}>
          <span className={iconClass}>checklist</span>
          <p className={textClass}>Objetivos</p>
        </Button>

        <Button className={buttonClass}>
          <span className={iconClass}>workspace_premium</span>
          <p className={textClass}>Especialidades</p>
        </Button>
      </div>
    </div>
  );
}
