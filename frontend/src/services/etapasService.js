import api from "./api";

export const getEtapasPorRama = async (ramaId) => {
  if (!ramaId) {
    throw new Error("El ID de la rama es requerido.");
  }

  try {
    const response = await api.get(`/EtapaProgresion/rama/${ramaId}`);
    return response.data;
  } catch (error) {
    console.error("Error al obtener etapas por rama", error);
    throw new Error("No se pudo cargar la lista de etapas de progresión.");
  }
};
