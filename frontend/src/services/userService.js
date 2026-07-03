import api from "./api";

export const roverToDiri = async () => {
  try {
    const response = await api.post("/User/to-diri");
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
