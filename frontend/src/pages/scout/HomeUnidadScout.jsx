import Button from "../../components/Button";
import { useAuth } from "../../contexts/AuthContext";
import { useNavigate } from "react-router-dom";

export default function HomeUnidadScout() {
  const { user } = useAuth();
  const nav = useNavigate();

  const unidad = user?.unidades?.[0];

  const handleSalirUnidad = () => {
    console.log("Saliendo de la unidad...");
  };

  if (!unidad) {
    setTimeout(() => nav("/home"), 1000);
    return (
      <div className="flex justify-center items-center min-h-screen bg-purple-600">
        <h2 className="text-3xl text-white font-bold">
          Unidad no encontrada...
        </h2>
      </div>
    );
  }

  return (
    <div>
      <div>
        <p>Nombre unidad: {unidad.nombre}</p>
        <p>Rama: {unidad.ramaNombre}</p>
        <p>Nombre usuario: {user.nombre}</p>
        <p>Grupo: {unidad.grupoScoutNombre}</p>
        <p>Código para unirse: {unidad.codigo}</p>
      </div>

      <div>
        <Button>Objetivos</Button>
        <Button>Especialidades</Button>
      </div>

      <Button onClick={handleSalirUnidad}>Salir de la unidad</Button>
    </div>
  );
}
