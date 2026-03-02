import api from "./api";

export async function registerUserToGroup(userID) {
  try {
    const response = await api.post(`/Registro/grupo/user`, { id: userID });
    return response.data;
  } catch (error) {
    if (error.response && error.response.data) {
      throw new Error(error.response.data);
    } else {
      console.error("Error al buscar la unidad:", error.message);
      throw new Error("No se pudo conectar con el servidor.");
    }
  }
}
