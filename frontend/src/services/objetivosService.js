import api from "./api.js";

export const getObjetivosPorEtapa = async (etapaId) => {
  if (!etapaId) {
    throw new Error("El ID de la etapa es requerido.");
  }

  try {
    const response = await api.get(`/ObjetivoEducativo/etapa/${etapaId}`);
    return response.data;
  } catch (error) {
    console.error("Error al obtener objetivos por etapa", error);
    throw new Error("No se pudo cargar la lista de objetivos.");
  }
};

export const elegirObjetivo = async (objetivoId) => {
  if (!objetivoId) {
    throw new Error("El ID del objetivo es requerido.");
  }

  try {
    const response = await api.post("/ObjetivoUsuario/elegir", { objetivoId });
    return response.data;
  } catch (error) {
    console.error("Error al elegir el objetivo", error);
    const errorMessage =
      error.response?.data ||
      "No se pudo seleccionar el objetivo. Intenta más tarde.";
    throw new Error(errorMessage);
  }
};

export const validarObjetivo = async ({ usuarioId, objetivoId }) => {
  if (!objetivoId || !usuarioId) {
    throw new Error("El ID del objetivo y del usuario son requeridos.");
  }

  try {
    const response = await api.post("/ObjetivoUsuario/validar", {
      usuarioId,
      objetivoId,
    });
    return response.data;
  } catch (error) {
    console.error("Error al validar el objetivo", error);
    const errorMessage =
      error.response?.data ||
      "No se pudo validar el objetivo. Intenta más tarde.";
    throw new Error(errorMessage);
  }
};

export const getPendientesPorUnidad = async (unidadId) => {
  if (!unidadId) {
    throw new Error("El ID de la unidad es requerido.");
  }

  try {
    const response = await api.get(
      `/ObjetivoUsuario/unidad/${unidadId}/pendientes`
    );
    return response.data;
  } catch (error) {
    console.error("Error al obtener pendientes", error);
    const errorMessage =
      error.response?.data ||
      "No se pudo cargar la lista de pendientes. Intenta más tarde.";
    throw new Error(errorMessage);
  }
};

export const getProgresoAgrupado = async (scoutId) => {
  if (!scoutId) {
    throw new Error("El ID del Scout es requerido.");
  }

  try {
    const response = await api.get(
      `/ObjetivoUsuario/scout/${scoutId}/agrupados`
    );
    return response.data;
  } catch (error) {
    console.error("Error al obtener el progreso agrupado", error);
    const errorMessage =
      error.response?.data || "No se pudo cargar el progreso del Scout.";
    throw new Error(errorMessage);
  }
};

export const getResumenObjetivos = async () => {
  try {
    const response = await api.get(`/ObjetivoUsuario/resume`);
    return response.data;
  } catch (error) {
    console.error("Error al obtener el resumen de objetivos", error);
    const errorMessage =
      error.response?.data || "No se pudo cargar el resumen de objetivos.";
    throw new Error(errorMessage);
  }
};
