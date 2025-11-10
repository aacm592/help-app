import api from "./api";

export const getGruposScout = async () => {
  try {
    const response = await api.get("/GrupoScout");
    return response.data;
  } catch (error) {
    console.error("Error al obtener Grupos Scout", error);
    throw new Error("No se pudo cargar la lista de grupos.");
  }
};

export const getGruposScoutPorDistrito = async (distritoId) => {
  if (!distritoId) {
    return [];
  }
  try {
    const response = await api.get(`/GrupoScout/${distritoId}`);
    return response.data;
  } catch (error) {
    console.error("Error al obtener Grupos Scout por distrito", error);
    throw new Error("No se pudo cargar la lista de grupos.");
  }
};
