import axios from "axios";

import api from "./api";

const url = axios.create({
  baseURL: import.meta.env.VITE_API_BASE_URL,
});

export async function login(credentials) {
  try {
    const response = await url.post("/Auth/login", credentials);
    return response.data;
  } catch (error) {
    if (error.response && error.response.data) {
      throw new Error(error.response.data);
    } else {
      console.error("Error while login", error);
      throw new Error("No se pudo conectar. Intenta más tarde.");
    }
  }
}

export async function register(userData) {
  try {
    const response = await url.post("/Auth/register", userData);

    return response.data;
  } catch (error) {
    if (error.response && error.response.data) {
      throw new Error(error.response.data);
    } else {
      console.error("Error during registration:", error.message);
      throw new Error("No se pudo conectar con el servidor.");
    }
  }
}

export async function changePassword(passwordData) {
  try {
    const response = await api.post("/Auth/change-password", passwordData);
    return response.data;
  } catch (error) {
    if (error.response && error.response.data) {
      throw new Error(error.response.data);
    } else {
      console.error("Error al cambiar contraseña:", error.message);
      throw new Error("No se pudo conectar con el servidor.");
    }
  }
}

export async function generateResetCode(scoutId) {
  try {
    const response = await api.post("/Auth/generate-reset-code", { scoutId });
    return response.data;
  } catch (error) {
    if (error.response && error.response.data) {
      throw new Error(error.response.data);
    } else {
      console.error("Error al generar código:", error.message);
      throw new Error("No se pudo conectar con el servidor.");
    }
  }
}

export async function resetPassword(resetData) {
  try {
    const response = await url.post("/reset-password", resetData);
    return response.data;
  } catch (error) {
    if (error.response && error.response.data) {
      throw new Error(error.response.data);
    } else {
      console.error("Error al resetear contraseña:", error.message);
      throw new Error("No se pudo conectar con el servidor.");
    }
  }
}
