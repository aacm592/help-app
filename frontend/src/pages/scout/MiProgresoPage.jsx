import ProgresoDisplay from "../../components/pageComponents/ProgresoDisplay";
import ResumenProgresionScout from "../../components/pageComponents/progresionPersonal/ResumenProgresionScout";
import { getResumenObjetivos } from "../../services/objetivosService";
import { useEffect, useState } from "react";
import ResumenEspecialidadesScout from "../../components/pageComponents/especialidades/ResumenEspecialidadesScout";
import { getResumenEspecialidades } from "../../services/especialidadService";
import LoadingPage from "../../components/LoadingPage";

export default function MiProgresoPage() {
  const [resumenObjetivos, setResumenObjetivos] = useState([]);
  const [resumenEspecialidades, setResumenEspecialidades] = useState([]);
  const [isLoading, setIsLoading] = useState(true);

  useEffect(() => {
    const getResumen = async () => {
      setIsLoading(true);
      try {
        const resumenO = await getResumenObjetivos();
        const resumenE = await getResumenEspecialidades();
        setResumenObjetivos(resumenO);
        setResumenEspecialidades(resumenE);
      } catch (error) {
        console.error("Error al obtener resumenes", error);
      } finally {
        setIsLoading(false);
      }
    };

    getResumen();
  }, []);

  if (isLoading) return <LoadingPage />;

  return (
    <div className="w-full">
      <h1 className="text-purple-950 w-full text-center">Mi Progreso</h1>
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

      <h2 className="text-purple-900 text-3xl font-bold">
        Especialidades
      </h2>
      <ResumenEspecialidadesScout especialidades={resumenEspecialidades} />
    </div>
  );
}
