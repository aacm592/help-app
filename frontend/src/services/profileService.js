import api from "./api";

export async function getScoutProfile() {
  try {
    const response = await api.get(`/Profile/scout`);
    return response.data;
  } catch (error) {
    console.error("Error al obtener el perfil del scout", error);
    const errorMessage =
      error.response?.data || "No se pudo cargar el perfil del scout.";
    throw new Error(errorMessage);
  }
}

export async function getScoutProfileById(scoutId) {
  try {
    const response = await api.get(`/Profile/scout/${scoutId}`);
    return response.data;
  } catch (error) {
    console.error("Error al obtener el perfil del scout", error);
    const errorMessage =
      error.response?.data || "No se pudo cargar el perfil del scout.";
    throw new Error(errorMessage);
  }
}

export async function getDiriProfile() {
  try {
    const response = await api.get(`/Profile/diri`);
    return response.data;
  } catch (error) {
    console.error("Error al obtener el perfil del dirigente", error);
    const errorMessage =
      error.response?.data || "No se pudo cargar el perfil del dirigente.";
    throw new Error(errorMessage);
  }
}

export async function updateScoutProfile(data) {
  try {
    const response = await api.put(`/Profile/scout`, data);
    return response.data;
  } catch (error) {
    console.error("Error al actualizar el perfil del scout", error);
    const errorMessage =
      error.response?.data || "No se pudo actualizar el perfil del scout.";
    throw new Error(errorMessage);
  }
}

export async function updateDiriProfile(data) {
  try {
    const response = await api.put(`/Profile/diri`, data);
    return response.data;
  } catch (error) {
    console.error("Error al actualizar el perfil del dirigente", error);
    const errorMessage =
      error.response?.data || "No se pudo actualizar el perfil del dirigente.";
    throw new Error(errorMessage);
  }
}
