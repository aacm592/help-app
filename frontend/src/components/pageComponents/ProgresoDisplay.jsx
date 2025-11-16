import { useState, useEffect } from "react";
import { getProgresoAgrupado } from "../../services/objetivosService";
import ObjetivoProgresoItem from "./ObjetivoProgresoItem";

export default function ProgresoDisplay({ scoutId }) {
  const [ramas, setRamas] = useState([]);
  const [loading, setLoading] = useState(true);
  const [apiError, setApiError] = useState(null);

  useEffect(() => {
    if (!scoutId) return;

    const cargarProgreso = async () => {
      setLoading(true);
      setApiError(null);
      try {
        const data = await getProgresoAgrupado(scoutId);
        setRamas(data);
      } catch (error) {
        setApiError(error.message);
      } finally {
        setLoading(false);
      }
    };

    cargarProgreso();
  }, [scoutId]);

  if (loading) {
    return (
      <div className="flex justify-center items-center p-10">
        <span className="material-symbols-outlined text-purple-700 text-6xl! animate-spin">
          progress_activity
        </span>
      </div>
    );
  }

  if (apiError) {
    return (
      <div
        className="w-full p-3 mb-4 text-sm text-center text-red-800 rounded-lg bg-red-100"
        role="alert"
      >
        {apiError}
      </div>
    );
  }

  if (ramas.length === 0) {
    return (
      <p className="text-center text-gray-600 text-lg p-6 bg-gray-100 rounded-lg">
        Este scout aún no tiene objetivos seleccionados.
      </p>
    );
  }

  return (
    <div className="space-y-10">
      {ramas.map((rama) => (
        <section key={rama.id}>
          <h2 className="text-3xl font-bold text-purple-900 mb-4">
            Rama: {rama.nombre}
          </h2>
          {rama.etapas.map((etapa) => (
            <div key={etapa.id} className="mb-6 ml-4">
              <h3 className="text-2xl font-semibold text-purple-800 mb-3">
                {etapa.nombre}
              </h3>
              <div className="space-y-4 ml-4">
                {etapa.areas.map((area) => (
                  <div key={area.id}>
                    <h4 className="text-xl font-medium text-gray-700 mb-2">
                      {area.nombre}
                    </h4>
                    <div className="space-y-2 ml-4">
                      {area.objetivos.map((obj) => (
                        <ObjetivoProgresoItem
                          key={obj.objetivoId}
                          objetivo={obj}
                        />
                      ))}
                    </div>
                  </div>
                ))}
              </div>
            </div>
          ))}
        </section>
      ))}
    </div>
  );
}
