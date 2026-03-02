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

export const getMiembrosUnidad = async (unidadId) => {
  try {
    const response = await api.get(`/Unidad/miembros/${unidadId}`);
    return response.data;
  } catch (error) {
    if (error.response && error.response.data) {
      throw new Error(error.response.data);
    } else {
      console.error("Error al obtener miembros:", error.message);
      throw new Error("No se pudo conectar con el servidor.");
    }
  }
};

export const salirDeUnidad = async (unidadId) => {
  try {
    const response = await api.post("/Unidad/salir", { unidadId });
    return response.data;
  } catch (error) {
    if (error.response && error.response.data) {
      throw new Error(error.response.data);
    } else {
      console.error("Error al salir de la unidad:", error.message);
      throw new Error("No se pudo conectar con el servidor.");
    }
  }
};

export const removerDeUnidad = async (unidadId, usuarioToRemoveId) => {
  try {
    const response = await api.post("/Unidad/remover", {
      unidadId,
      usuarioToRemoveId,
    });
    return response.data;
  } catch (error) {
    if (error.response && error.response.data) {
      throw new Error(error.response.data);
    } else {
      console.error("Error al remover usuario:", error.message);
      throw new Error("No se pudo conectar con el servidor.");
    }
  }
};

export async function getMiembrosUnidadWithRegisters(unidadId) {
  try {
    const response = await api.get(`/Unidad/${unidadId}/registers`);
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
