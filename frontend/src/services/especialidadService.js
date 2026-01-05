import api from "./api";

export const getEspecialidades = async (ramaId) => {
  try {
    const response = await api.get(`/Especialidad/rama/${ramaId}`);
    return response.data;
  } catch (error) {
    console.error("Error al obtener las especialidades", error);
    throw new Error("No se pudo cargar la lista de especialidades.");
  }
};

export async function selectRequerimiento(id) {
  try {
    const response = await api.post(`/Especialidad/req/select/${id}`);
    return response.data;
  } catch (error) {
    console.error("Error al obtener las especialidades", error);
    throw new Error("No se pudo cargar la lista de especialidades.");
  }
}
