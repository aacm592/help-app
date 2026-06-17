import { useEffect, useState } from "react";
import SpecialitItem from "../../components/pageComponents/especialidades/SpecialityItem";
import { useAuth } from "../../contexts/AuthContext";
import {
  asignarRequerimiento,
  getEspecialidadesScout,
} from "../../services/especialidadService";
import { useLocation, useNavigate, useParams } from "react-router-dom";
import LoadingPage from "../../components/LoadingPage";
import SearchBar from "../../components/SearchBar";

export default function AsignarEspecialidadPage() {
  const location = useLocation();
  const nav = useNavigate();

  const { user } = useAuth();
  const unidad = user?.unidades?.[0];

  const [especialidades, setEspecialidades] = useState([]);
  const [isLoading, setIsLoading] = useState(true);

  const [searchTerm, setSearchTerm] = useState("");

  const { scoutId } = useParams();
  const scoutNombre = location.state?.scoutNombre || "Scout---";

  const especialidadesFiltradas = especialidades.filter((esp) =>
    esp.nombre.toLowerCase().includes(searchTerm.toLowerCase()),
  );

  useEffect(() => {
    if (!unidad) {
      nav("/home");
      return;
    }

    const cargarEspecialidades = async () => {
      setIsLoading(true);
      try {
        const esp = await getEspecialidadesScout(unidad.ramaId, scoutId);
        setEspecialidades(esp);
      } catch (error) {
        console.error("No se pudieron cargar las especialidades", error);
      } finally {
        setIsLoading(false);
      }
    };

    cargarEspecialidades();
  }, [unidad, nav, scoutId]);

  const selectReq = async (reqId, id) => {
    try {
      await asignarRequerimiento(scoutId, reqId);

      const req = especialidades.find(
        (e) => e.idEspecialidad === id,
      ).requerimientos;
      const newReq = req.map((r) =>
        reqId === r.id ? { ...r, status: "Cumplido" } : r,
      );

      const newEsp = especialidades.map((e) =>
        e.idEspecialidad === id
          ? { ...e, status: "En Progreso", requerimientos: newReq }
          : e,
      );
      setEspecialidades(newEsp);
    } catch (error) {
      console.error("error al seleccionar el requisito", error);
    }
  };

  if (isLoading) return <LoadingPage />;

  return (
    <div className="flex flex-col justify-center items-center w-full lg:md:w-3/4 md:w-4/5 mx-auto p-4 md:p-8">
      <h1 className="text-purple-900 md:text-left text-center">
        Especialidades {scoutNombre}
      </h1>

      <div className="md:w-3/4 lg:w-2/3 w-full">
        <SearchBar
          onSearch={(val) => setSearchTerm(val)}
          items={especialidades.map((e) => e.nombre)}
          onItemClicked={(name) => setSearchTerm(name)}
        />
      </div>

      <div className="w-full space-y-4">
        {especialidadesFiltradas.length > 0 ? (
          especialidadesFiltradas.map((e) => (
            <SpecialitItem
              key={e.idEspecialidad || e.nombre}
              name={e.nombre}
              status={e.status}
              description={e.descripcion}
              req={e.requerimientos}
              onSelect={(reqId) => selectReq(reqId, e.idEspecialidad)}
            />
          ))
        ) : (
          <p className="text-gray-500 text-center mt-10">
            No se encontraron especialidades.
          </p>
        )}
      </div>
    </div>
  );
}
