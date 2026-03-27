import { Navigate, Outlet } from "react-router-dom";
import { useAuth } from "../../../contexts/AuthContext";

export default function PermisoProtectedRoute({ allowedPermisos = [] }) {
  const { isAuthenticated, user } = useAuth();

  if (!isAuthenticated) {
    return <Navigate to="/" replace />;
  }

  const isAllowed =
    user && user?.permisos?.some((p) => allowedPermisos.includes(p.id));

  if (!isAllowed) {
    console.log("No cuenta con el permiso", allowedPermisos);
    return <Navigate to="/home" replace />;
  }

  return <Outlet />;
}
