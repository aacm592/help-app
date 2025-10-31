import axios from "axios";

const url = axios.create({
  baseURL: "http://localhost:5095/api/Auth",
});

export async function login(credentials) {
  try {
    const response = await url.post("/login", credentials);

    return response.data;
  } catch (error) {
    console.error("Error while login", error);
    return null;
  }
}
