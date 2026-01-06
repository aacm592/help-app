import { useEffect, useState } from "react";
import {
  getEspecialidadesPendientes,
  validateEspecialdiad,
} from "../../services/especialidadService";
import { useNavigate } from "react-router-dom";
import EspecialidadPendienteItem from "../../components/pageComponents/especialidades/EspecialidadPendienteItem";
import { useAuth } from "../../contexts/AuthContext";
import LoadingPage from "../../components/LoadingPage";
import Button from "../../components/Button";

export default function GestionarEspecialidadesPage() {
  const { user } = useAuth();
  const unidad = user.unidades[0];
  const [pendientes, setPendientes] = useState([]);
  const [isLoading, setIsLoading] = useState(true);
  const nav = useNavigate();

  useEffect(() => {
    if (!unidad) {
      nav("/home");
      return;
    }

    const getPendientes = async () => {
      setIsLoading(true);
      try {
        const pendList = await getEspecialidadesPendientes(unidad.id);
        setPendientes(pendList);
      } catch (error) {
        console.error("Error al conseguir requisitos pendientes", error);
      } finally {
        setIsLoading(false);
      }
    };

    getPendientes();
  }, [nav, unidad]);

  const validate = async (usuarioId, objetivoId, indx) => {
    try {
      const request = { usuarioId, objetivoId };
      console.log(request);
      await validateEspecialdiad(request);
      const newList = pendientes.filter((_, i) => i !== indx);
      setPendientes(newList);
    } catch (error) {
      console.error("Error al validar requisitos", error);
    }
  };

  if (isLoading) return <LoadingPage />;

  return (
    <div className="flex flex-col w-full items-center">
      <div className="flex flex-col md:items-center space-y-5 items-end md:flex-row-reverse md:justify-between md:w-3/4 lg:w-1/2 w-full">
        <Button className="px-4 py-2 h-fit w-fit" onClick={() => nav(-1)}>
          <span className="material-symbols-outlined mr-2">arrow_back</span>
          Volver
        </Button>
        <h1 className="text-purple-900 w-full md:text-left text-center">Gestionar especialidades</h1>
      </div>
      <p className="text-2xl text-left md:w-3/4 lg:w-1/2 w-full font-extrabold">
        Unidad: {unidad.nombre}
      </p>
      <div className="space-y-5 md:w-3/4 lg:w-1/2 w-full">
        {pendientes.map((p, i) => (
          <EspecialidadPendienteItem
            key={i}
            especialidad={p.especialidad}
            scout={p.scoutNombre}
            description={p.descripcion}
            scoutId={p.scoutId}
            id={p.requerimientoId}
            onConfirm={(usuarioId, objetivoId) => {
              console.log(p);
              validate(usuarioId, objetivoId, i);
            }}
          />
        ))}
      </div>
    </div>
  );
}
