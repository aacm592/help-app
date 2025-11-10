import api from "./api";

export const getDistritos = async () => {
  try {
    const response = await api.get("/Distrito");
    return response.data;
  } catch (error) {
    console.error("Error al obtener Distritos", error);
    throw new Error("No se pudo cargar la lista de distritos.");
  }
};
