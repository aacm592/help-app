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

export const getResumenEnviadosAlDistrito = async () => {
  try {
    const response = await api.get("/Distrito/registers/enviadosDistrito");
    return response.data;
  } catch (error) {
    console.error("Error al obtener Distritos", error);
    throw new Error("No se pudo cargar los registros recividos del distrito.");
  }
};

export const getResumenRegistrosDistrito = async () => {
  try {
    const response = await api.get("/Distrito/registers/resumen");
    return response.data;
  } catch (error) {
    console.error("Error al obtener Distritos", error);
    throw new Error("No se pudo cargar el resumen de registros del distrito.");
  }
};

export const getRegistrosDistrito = async () => {
  try {
    const response = await api.get("/Distrito/registers");
    return response.data;
  } catch (error) {
    console.error("Error al obtener Distritos", error);
    throw new Error("No se pudo cargar los registros del distrito.");
  }
};

export const getAdminsDistrito = async () => {
  try {
    const response = await api.get("/Distrito/admins");
    return response.data;
  } catch (error) {
    console.error("Error al obtener Distritos", error);
    throw new Error("No se pudo cargar los registros del distrito.");
  }
};

export const getRespGrupo = async () => {
  try {
    const response = await api.get("/Distrito/groups/responsables");
    return response.data;
  } catch (error) {
    console.error("Error al obtener responsables de grupo", error);
    throw new Error("No se pudo cargar los responsables de grupo.");
  }
};
