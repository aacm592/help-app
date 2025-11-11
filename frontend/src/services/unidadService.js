import api from "./api";

export const createUnidad = async (unidadData) => {
  try {
    const response = await api.post("/Unidad/crear", unidadData);
    return response.data;
  } catch (error) {
    if (error.response && error.response.data) {
      throw new Error(error.response.data);
    } else {
      console.error("Error al crear la unidad:", error.message);
      throw new Error("No se pudo conectar con el servidor.");
    }
  }
};

export const joinUnidad = async (codigo) => {
  try {
    const response = await api.post("/Unidad/unirse", { codigo });
    return response.data;
  } catch (error) {
    if (error.response && error.response.data) {
      throw new Error(error.response.data);
    } else {
      console.error("Error al unirse a la unidad:", error.message);
      throw new Error("No se pudo conectar con el servidor.");
    }
  }
};
