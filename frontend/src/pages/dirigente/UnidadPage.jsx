import { useParams } from "react-router-dom";
import { useAuth } from "../../contexts/AuthContext";
import SalirUnidadButton from "../../components/pageComponents/SalirUnidadButton";
import { useEffect, useState } from "react";
import LoadingPage from "../../components/LoadingPage";
import Button from "../../components/Button";

export default function UnidadPage() {
  const { unidadId } = useParams();
  const { user } = useAuth();
  const infoItemClass = "py-2 flex items-center gap-3";
  const labelClass = "font-semibold text-gray-600";
  const dataClass = "text-xl font-bold text-purple-800";

  const [unidad, setUnidad] = useState();
  const [isCopied, setIsCopied] = useState(false);

  useEffect(() => {
    const actualUnidad = user?.unidades.find(
      (u) => u.id.toString() === unidadId,
    );
    setUnidad(actualUnidad);
  }, [user, unidadId]);

  const handleCopyCode = () => {
    if (unidad.codigo) {
      navigator.clipboard.writeText(unidad.codigo);
      setIsCopied(true);
      setTimeout(() => setIsCopied(false), 2000);
    }
  };

  if (!unidad) return <LoadingPage />;

  return (
    <div className="flex flex-col h-full w-full p-5 md:w-1/3 mx-auto py-6 justify-between">
      <div className="space-y-4">
        <h1 className="text-purple-900 text-center">{unidad.nombre}</h1>

        <div className={`${infoItemClass}`}>
          <span className={`${labelClass} space-x-3 items`}>Código:</span>
          <span className={dataClass}>{unidad.codigo}</span>

          <Button
            className="w-fit justify-center p-2 hover:bg-gray-200"
            onClick={handleCopyCode}
            outline={false}
          >
            <span className="material-symbols-outlined mr-2">
              {isCopied ? "check" : "content_copy"}
            </span>
          </Button>
        </div>

        <div className={infoItemClass}>
          <p className={labelClass}>Grupo Scout:</p>
          <p className={dataClass}>{unidad.grupoScoutNombre}</p>
        </div>

        <div className={infoItemClass}>
          <p className={labelClass}>Rama:</p>
          <p className={dataClass}>{unidad.ramaNombre}</p>
        </div>
      </div>

      <SalirUnidadButton
        className=""
        unidadId={unidadId}
        onSuccessRedirectPath={"/inicio"}
      />
    </div>
  );
}
