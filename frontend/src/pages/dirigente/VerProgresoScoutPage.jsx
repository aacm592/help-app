import { useParams, useLocation, useNavigate } from "react-router-dom";
import Button from "../../components/Button";
import { useEffect, useState } from "react";
import { getResumenObjetivosByScoutId } from "../../services/objetivosService";
import { getResumenEspecialidadesByScoutId } from "../../services/especialidadService";
import LoadingPage from "../../components/LoadingPage";
import ResumenProgresionScout from "../../components/pageComponents/progresionPersonal/ResumenProgresionScout";
import ResumenEspecialidadesScout from "../../components/pageComponents/especialidades/ResumenEspecialidadesScout";

export default function VerProgresoScoutPage() {
  const { scoutId, unidadId } = useParams();
  const location = useLocation();
  const nav = useNavigate();

  const scoutNombre = location.state?.scoutNombre || "Scout---";

  const [resumenObjetivos, setResumenObjetivos] = useState([]);
  const [resumenEspecialidades, setResumenEspecialidades] = useState([]);
  const [isLoading, setIsLoading] = useState(true);

  useEffect(() => {
    const getResumen = async () => {
      setIsLoading(true);
      try {
        const resumenO = await getResumenObjetivosByScoutId(scoutId);
        const resumenE = await getResumenEspecialidadesByScoutId(scoutId);
        setResumenObjetivos(resumenO);
        setResumenEspecialidades(resumenE);
      } catch (error) {
        console.error("Error al obtener resumenes", error);
      } finally {
        setIsLoading(false);
      }
    };

    getResumen();
  }, [scoutId]);

  if (isLoading) return <LoadingPage />;

  return (
    <div className="w-full">
      <div className="flex justify-between items-center mb-6">
        <div className="flex items-center gap-2">
          <h1 className="text-purple-900">Progreso de:</h1>
          <p className="text-5xl font-bold text-violet-800">{scoutNombre}</p>
        </div>
        <Button
          className="px-4 py-2"
          onClick={() => nav(`/diri/unidad/${unidadId}/miembros`)}
        >
          <span className="material-symbols-outlined mr-2">arrow_back</span>
          Volver a Miembros
        </Button>
      </div>

      <h2 className="text-purple-900 text-3xl font-bold">
        Progresión personal
      </h2>
      {resumenObjetivos.map((e, i) => (
        <ResumenProgresionScout
          key={i}
          etapa={e.etapa}
          areas={e.objetivosAreaResume}
        />
      ))}

      <h2 className="text-purple-900 text-3xl font-bold">Especialidades</h2>
      <ResumenEspecialidadesScout especialidades={resumenEspecialidades} />
    </div>
  );
}
