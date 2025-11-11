import { useEffect, useState } from "react";
import { useParams, useNavigate } from "react-router-dom";
import { useAuth } from "../../contexts/AuthContext";
import Button from "../../components/Button";

export default function HomeUnidadDirigente() {
  const { unidadId } = useParams();
  const { user } = useAuth();
  const nav = useNavigate();
  const [unidad, setUnidad] = useState(null);

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
      <div className="flex justify-center items-center min-h-screen bg-purple-600">
        <h2 className="text-3xl text-white font-bold">Cargando datos...</h2>
      </div>
    );
  }

  return (
    <div>
      <div>
        <p>Nombre de usuario: {user.nombre}</p>
        <p>Grupo: {unidad.grupoScoutNombre}</p>
        <p>Rama: {unidad.ramaNombre}</p>
        <p>Unidad: {unidad.nombre}</p>
        <p>Código: {unidad.codigo}</p>
      </div>

      <div>
        <Button>Ver unidad</Button>
        <Button>Objetivos</Button>
        <Button>Especialidades</Button>
        <Button onClick={() => nav("/diri")}>Ir a otra unidad</Button>
      </div>

      <Button>Salir de la unidad</Button>
    </div>
  );
}
