import api from "./api";

export const getRamas = async () => {
  try {
    const response = await api.get("/Rama");
    return response.data;
  } catch (error) {
    console.error("Error al obtener Ramas", error);
    throw new Error("No se pudo cargar la lista de ramas.");
  }
};
