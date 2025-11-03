import axios from "axios";

const url = axios.create({
  baseURL: "http://localhost:5095/api/Auth",
});

export async function login(credentials) {
  try {
    const response = await url.post("/login", credentials);
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
    const response = await url.post("/register", userData);

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
