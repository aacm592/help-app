import { useEffect, useState } from "react";
import { getUnidadeDeGrupo } from "../../services/grupoService";
import Button from "../../components/Button";
import LoadingPage from "../../components/LoadingPage";
import { useNavigate } from "react-router-dom";

export default function ChooseUnidadToRegister() {
  const [unidades, setUnidades] = useState([]);
  const [isLoading, setIsLoading] = useState(true);
  const nav = useNavigate();

  useEffect(() => {
    const getUnidades = async () => {
      setIsLoading(true);
      try {
        const grupo = await getUnidadeDeGrupo();
        setUnidades(grupo);
      } catch (error) {
        console.error("Error al obtener unidades", error);
      } finally {
        setIsLoading(false);
      }
    };

    getUnidades();
  }, []);

  if (isLoading) return <LoadingPage />;

  return (
    <div className="w-full p-4 flex flex-col justify-center">
      <h1 className="text-purple-900 text-center">Unidades</h1>
      <div className="w-full p-4 flex flex-col items-center">
        {unidades.map((u) => (
          <Button
            key={u.id}
            className="p-4 flex flex-col w-full lg:w-1/3 border-2 m-10 rounded-xl hover:bg-purple-300 active:bg-purple-500 "
            onClick={() => {
              nav(`/grupo/registrar/${u.id}`);
            }}
          >
            <h2 className="text-2xl">{u.nombre}</h2>
            <h3 className="text-lg"> Miembros: {u.total}</h3>
            <h3 className="text-lg"> Registrados: {u.registrados}</h3>
          </Button>
        ))}
        <Button
          className="p-4 flex flex-col w-full lg:w-1/3 border-2 m-10 rounded-xl hover:bg-purple-300 active:bg-purple-500 "
          onClick={() => {
            nav(`/grupo/registrar/admins`);
          }}
        >
          <h2 className="text-2xl">Administradores</h2>
        </Button>
      </div>
    </div>
  );
}
