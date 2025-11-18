import { useState, useEffect, useMemo } from "react";
import { useNavigate } from "react-router-dom";
import { useAuth } from "../../contexts/AuthContext";
import Button from "../../components/Button";
import { getEtapasPorRama } from "../../services/etapasService";
import {
  elegirObjetivo,
  getObjetivosPorEtapa,
} from "../../services/objetivosService";
import ObjetivoItem from "../../components/pageComponents/ObjetivoItem";

const TODOS = "TODOS";

export default function ObjetivosPage() {
  const { user } = useAuth();
  const nav = useNavigate();
  const unidad = user?.unidades?.[0];

  const [etapas, setEtapas] = useState([]);
  const [selectedEtapaId, setSelectedEtapaId] = useState("");
  const [areasDisponibles, setAreasDisponibles] = useState([]);
  const [selectedAreaNombre, setSelectedAreaNombre] = useState("");

  const [objetivos, setObjetivos] = useState([]);

  const [loadingEtapas, setLoadingEtapas] = useState(true);
  const [loadingObjetivos, setLoadingObjetivos] = useState(false);
  const [selectingObjetivoId, setSelectingObjetivoId] = useState(null);
  const [apiError, setApiError] = useState(null);
  const [successMessage, setSuccessMessage] = useState(null);

  useEffect(() => {
    if (!unidad) {
      nav("/home");
      return;
    }

    const cargarEtapas = async () => {
      setLoadingEtapas(true);
      setApiError(null);
      try {
        const etapasData = await getEtapasPorRama(unidad.ramaId);
        setEtapas(etapasData);
      } catch (error) {
        setApiError(error.message);
      } finally {
        setLoadingEtapas(false);
      }
    };

    cargarEtapas();
  }, [unidad, nav]);

  useEffect(() => {
    if (!selectedEtapaId) {
      setObjetivos([]);
      setAreasDisponibles([]);
      setSelectedAreaNombre("");
      return;
    }

    const cargarObjetivosYAreas = async () => {
      setLoadingObjetivos(true);
      setApiError(null);
      setSuccessMessage(null);
      setAreasDisponibles([]);
      setSelectedAreaNombre("");

      try {
        const objetivosData = await getObjetivosPorEtapa(selectedEtapaId);
        setObjetivos(objetivosData);

        const areasUnicas = [
          ...new Set(objetivosData.map((o) => o.areaCrecimientoNombre)),
        ];

        setAreasDisponibles([TODOS, ...areasUnicas.sort()]);
        setSelectedAreaNombre(TODOS);
      } catch (error) {
        setApiError(error.message);
      } finally {
        setLoadingObjetivos(false);
      }
    };

    cargarObjetivosYAreas();
  }, [selectedEtapaId]);

  const objetivosAgrupados = useMemo(() => {
    if (selectedAreaNombre !== TODOS || objetivos.length === 0) {
      return {};
    }
    return objetivos.reduce((grupos, objetivo) => {
      const area = objetivo.areaCrecimientoNombre;
      if (!grupos[area]) {
        grupos[area] = [];
      }
      grupos[area].push(objetivo);
      return grupos;
    }, {});
  }, [objetivos, selectedAreaNombre]);

  const objetivosFiltrados = useMemo(() => {
    if (selectedAreaNombre === TODOS || selectedAreaNombre === "") {
      return [];
    }
    return objetivos.filter(
      (o) => o.areaCrecimientoNombre === selectedAreaNombre
    );
  }, [objetivos, selectedAreaNombre]);

  const handleElegirObjetivo = async (objetivoId) => {
    setSelectingObjetivoId(objetivoId);
    setApiError(null);
    setSuccessMessage(null);

    try {
      await elegirObjetivo(objetivoId);
      setSuccessMessage("¡Objetivo seleccionado! Esperando validación.");

      setObjetivos((prevObjetivos) =>
        prevObjetivos.filter((o) => o.id !== objetivoId)
      );
    } catch (error) {
      setApiError(error.message);
    } finally {
      setSelectingObjetivoId(null);
    }
  };

  if (!unidad) {
    return (
      <div className="flex justify-center items-center min-h-screen bg-white">
        <h2 className="text-3xl text-purple-800 font-bold">Cargando...</h2>
      </div>
    );
  }

  return (
    <div className="flex flex-col items-center min-h-screen bg-gray-50 text-black p-8 w-screen">
      <div className="w-full max-w-4xl mx-auto">
        <div className="flex justify-between items-center mb-6">
          <h1 className="text-purple-900">Mis Objetivos</h1>
          <Button className="px-4 py-2" onClick={() => nav("/scout/home")}>
            <span className="material-symbols-outlined mr-2">arrow_back</span>
            Volver
          </Button>
        </div>

        {apiError && (
          <div
            className="w-full p-3 mb-4 text-sm text-center text-red-800 rounded-lg bg-red-100"
            role="alert"
          >
            {apiError}
          </div>
        )}
        {successMessage && (
          <div
            className="w-full p-3 mb-4 text-sm text-center text-green-800 rounded-lg bg-green-100"
            role="alert"
          >
            {successMessage}
          </div>
        )}

        <div className="mb-6 grid grid-cols-1 md:grid-cols-2 gap-4">
          <div>
            <label
              htmlFor="etapa-select"
              className="block mb-2 text-lg font-medium text-gray-900"
            >
              1. Selecciona tu Etapa
            </label>
            <select
              id="etapa-select"
              value={selectedEtapaId}
              onChange={(e) => setSelectedEtapaId(e.target.value)}
              disabled={loadingEtapas}
              className="bg-white border border-gray-300 text-gray-900 text-sm rounded-lg focus:ring-purple-500 focus:border-purple-500 block w-full p-2.5"
            >
              <option value="" disabled>
                {loadingEtapas ? "Cargando etapas..." : "Elige una etapa"}
              </option>
              {etapas.map((etapa) => (
                <option key={etapa.id} value={etapa.id}>
                  {etapa.nombre}
                </option>
              ))}
            </select>
          </div>

          <div>
            <label
              htmlFor="area-select"
              className="block mb-2 text-lg font-medium text-gray-900"
            >
              2. Elige un Área
            </label>
            <select
              id="area-select"
              value={selectedAreaNombre}
              onChange={(e) => setSelectedAreaNombre(e.target.value)}
              disabled={!selectedEtapaId || loadingObjetivos}
              className="bg-white border border-gray-300 text-gray-900 text-sm rounded-lg focus:ring-purple-500 focus:border-purple-500 block w-full p-2.5"
            >
              {loadingObjetivos && <option value="">Cargando...</option>}
              {!loadingObjetivos &&
                areasDisponibles.map((areaNombre) => (
                  <option key={areaNombre} value={areaNombre}>
                    {areaNombre}
                  </option>
                ))}
            </select>
          </div>
        </div>

        <div className="space-y-8">
          {loadingObjetivos ? (
            <div className="flex justify-center items-center p-10">
              <span className="material-symbols-outlined text-purple-700 animate-spin">
                progress_activity
              </span>
            </div>
          ) : selectedAreaNombre === TODOS ? (
            <>
              {objetivos.length === 0 && selectedEtapaId ? (
                <p className="text-center text-gray-600 text-lg p-6 bg-gray-100 rounded-lg">
                  ¡Felicidades! Parece que ya has seleccionado todos los
                  objetivos de esta etapa.
                </p>
              ) : (
                Object.keys(objetivosAgrupados).map((areaNombre) => (
                  <section key={areaNombre}>
                    <h2 className="text-2xl font-bold text-purple-800 mb-4 border-b-2 border-purple-200 pb-2">
                      {areaNombre}
                    </h2>
                    <div className="space-y-4">
                      {objetivosAgrupados[areaNombre].map((objetivo) => (
                        <ObjetivoItem
                          key={objetivo.id}
                          objetivo={objetivo}
                          onSelect={handleElegirObjetivo}
                          isLoading={selectingObjetivoId === objetivo.id}
                        />
                      ))}
                    </div>
                  </section>
                ))
              )}
            </>
          ) : selectedAreaNombre ? (
            <section>
              <h2 className="text-2xl font-bold text-purple-800 mb-4 border-b-2 border-purple-200 pb-2">
                Objetivos de {selectedAreaNombre}
              </h2>
              <div className="space-y-4">
                {objetivosFiltrados.map((objetivo) => (
                  <ObjetivoItem
                    key={objetivo.id}
                    objetivo={objetivo}
                    onSelect={handleElegirObjetivo}
                    isLoading={selectingObjetivoId === objetivo.id}
                  />
                ))}
                {objetivosFiltrados.length === 0 && (
                  <p className="text-center text-gray-600 text-lg p-6 bg-gray-100 rounded-lg">
                    ¡Felicidades! Parece que ya has seleccionado todos los
                    objetivos de esta área.
                  </p>
                )}
              </div>
            </section>
          ) : null}
        </div>
      </div>
    </div>
  );
}
