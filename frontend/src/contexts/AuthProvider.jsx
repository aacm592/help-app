import { useState, useEffect } from "react";
import { AuthContext } from "./AuthContext";

export const AuthProvider = ({ children }) => {
  const [user, setUser] = useState(null);
  const [token, setToken] = useState(null);
  const [isAuthenticated, setIsAuthenticated] = useState(false);

  useEffect(() => {
    const storedToken = localStorage.getItem("ASBToken");
    const storedUser = localStorage.getItem("ASBUser");

    if (storedToken && storedUser) {
      setToken(storedToken);
      try {
        setUser(JSON.parse(storedUser));
      } catch (e) {
        console.error("Error parsing stored user", e);
        localStorage.removeItem("ASBToken");
        localStorage.removeItem("ASBUser");
        return;
      }
      setIsAuthenticated(true);
    }
  }, []);

  const handleLogin = (authData) => {
    const authToken = authData.token;
    const authUser = authData.user;

    if (authToken && authUser) {
      setToken(authToken);
      setUser(authUser);
      setIsAuthenticated(true);
      localStorage.setItem("ASBToken", authToken);
      localStorage.setItem("ASBUser", JSON.stringify(authUser));
    }
  };

  const handleLogout = () => {
    setToken(null);
    setUser(null);
    setIsAuthenticated(false);
    localStorage.removeItem("ASBToken");
    localStorage.removeItem("ASBUser");
  };

  return (
    <AuthContext.Provider
      value={{
        user,
        token,
        isAuthenticated,
        handleLogin,
        handleLogout,
      }}
    >
      {children}
    </AuthContext.Provider>
  );
};
