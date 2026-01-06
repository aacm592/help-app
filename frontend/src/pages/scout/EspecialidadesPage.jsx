import { useEffect, useState } from "react";
import SpecialitItem from "../../components/pageComponents/especialidades/SpecialityItem";
import { useAuth } from "../../contexts/AuthContext";
import { getEspecialidades } from "../../services/especialidadService";
import { useNavigate } from "react-router-dom";
import LoadingPage from "../../components/LoadingPage";
import SearchBar from "../../components/SearchBar";

export default function EspecialidadesPage() {
  const { user } = useAuth();
  const unidad = user?.unidades?.[0];
  const [especialidades, setEspecialidades] = useState([]);
  const [isLoading, setIsLoading] = useState(true);

  const [searchTerm, setSearchTerm] = useState("");

  const especialidadesFiltradas = especialidades.filter((esp) =>
    esp.nombre.toLowerCase().includes(searchTerm.toLowerCase())
  );
  
  const nav = useNavigate();

  useEffect(() => {
    if (!unidad) {
      nav("/home");
      return;
    }

    const cargarEspecialidades = async () => {
      setIsLoading(true);
      try {
        const esp = await getEspecialidades(unidad.ramaId);
        setEspecialidades(esp);
      } catch (error) {
        console.error("No se pudieron cargar las especialidades", error);
      } finally {
        setIsLoading(false);
      }
    };

    cargarEspecialidades();
  }, [unidad, nav]);

  const selectReq = (indx) => {
    const newEsp = especialidades.map((r, i) =>
      i === indx ? { ...r, status: "En Progreso" } : r
    );
    setEspecialidades(newEsp);
  };

  if (isLoading) return <LoadingPage />;

  return (
    <div className="flex flex-col items-center p-4 gap-6">
      <h1 className="text-3xl font-bold text-gray-800">Especialidades</h1>

      <div className="md:w-3/4 lg:w-2/3 w-full">
        <SearchBar
          onSearch={(val) => setSearchTerm(val)}
          items={especialidades.map((e) => e.nombre)}
          onItemClicked={(name) => setSearchTerm(name)}
        />
      </div>

      <div className="md:w-3/4 lg:w-2/3 w-full space-y-4">
        {especialidadesFiltradas.length > 0 ? (
          especialidadesFiltradas.map((e, i) => (
            <SpecialitItem
              key={i}
              name={e.nombre}
              status={e.status}
              description={e.descripcion}
              req={e.requerimientos}
              onSelect={() => selectReq(i)}
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
