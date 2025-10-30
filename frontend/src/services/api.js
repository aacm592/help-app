import axios from "axios";

const API_URL = "http://localhost:5095/api/auth";

const register = (registerData) => {
  return axios.post(`${API_URL}/register`, registerData);
};

const login = (loginData) => {
  return axios.post(`${API_URL}/login`, loginData);
};

const logout = () => {
  localStorage.removeItem("userToken");
};

const getToken = () => {
  return localStorage.getItem("userToken");
};

const authService = {
  register,
  login,
  logout,
  getToken,
};

export default authService;
