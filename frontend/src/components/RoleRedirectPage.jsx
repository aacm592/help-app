import { useEffect } from "react";
import { useNavigate } from "react-router-dom";
import { useAuth } from "../contexts/AuthContext";

export default function RoleRedirectPage() {
  const { user } = useAuth();
  const navigate = useNavigate();

  useEffect(() => {
    if (user) {
      const tieneUnidades = user.unidades && user.unidades.length > 0;

      switch (user.tipoId) {
        case 1: // --- Rol Scout ---
          if (tieneUnidades) {
            navigate("/scout/home", { replace: true });
          } else {
            navigate("/unirse-unidad", { replace: true });
          }
          break;

        case 2: // --- Rol Dirigente ---
          navigate("/diri", { replace: true });
          break;

        default:
          // --- Otros roles o si no tiene tipoId ---
          navigate("/", { replace: true });
      }
    }
  }, [user, navigate]);

  return (
    <div className="flex justify-center items-center min-h-screen bg-purple-600">
      <h2 className="text-3xl text-white font-bold">Cargando...</h2>
    </div>
  );
}
