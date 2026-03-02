import api from "./api";

export async function registerUserToGroup(userID) {
  if (!userID) {
    throw new Error("El ID del Scout es requerido.");
  }
  try {
    const response = await api.post(`/Registro/grupo/user`, { id: userID });
    return response.data;
  } catch (error) {
    if (error.response && error.response.data) {
      throw new Error(error.response.data);
    } else {
      console.error("Error al registrar miembro:", error.message);
      throw new Error("No se pudo conectar con el servidor.");
    }
  }
}

export async function cancelRegisterUserToGroup(userID) {
  if (!userID) {
    throw new Error("El ID del Scout es requerido.");
  }
  try {
    const response = await api.delete(`/Registro/grupo/user/${userID }`);
    return response.data;
  } catch (error) {
    if (error.response && error.response.data) {
      throw new Error(error.response.data);
    } else {
      console.error("Error al cancelar registro:", error.message);
      throw new Error("No se pudo conectar con el servidor.");
    }
  }
}
