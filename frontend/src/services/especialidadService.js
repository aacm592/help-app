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

export async function getEspecialidadesPendientes(unidadId) {
  try {
    const response = await api.get(`/Especialidad/unidad/${unidadId}`);
    return response.data;
  } catch (error) {
    console.error("Error al obtener requisitos pendientes", error);
    throw new Error("No se pudo cargar la lista de requisitos pendientes.");
  }
}

export async function validateEspecialdiad(data) {
  try {
    const response = await api.post("/Especialidad/req/val", data);
    return response.data;
  } catch (error) {
    console.error("Error al validar el requisito", error);
    throw new Error("No se pudo validar el requisito.");
  }
}

export async function getResumenEspecialidades() {
  try {
    const response = await api.get("/Especialidad/resume/");
    return response.data;
  } catch (error) {
    console.error("Error al obtener resumen de especialidades", error);
    throw new Error("No se pudo cargar el resumen de especialidades.");
  }
}
