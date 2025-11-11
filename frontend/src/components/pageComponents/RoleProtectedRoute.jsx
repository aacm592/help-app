import { Navigate, Outlet } from "react-router-dom";
import { useAuth } from "../../contexts/AuthContext";

export default function RoleProtectedRoute({ allowedRoles = [] }) {
  const { isAuthenticated, user } = useAuth();

  if (!isAuthenticated) {
    return <Navigate to="/" replace />;
  }

  const isAllowed = user && allowedRoles.includes(user.tipoId);

  if (!isAllowed) {
    return <Navigate to="/home" replace />;
  }

  return <Outlet />;
}
