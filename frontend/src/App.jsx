import { BrowserRouter, Routes, Route } from "react-router-dom";
import MainPage from "./pages/login/MainPage";
import RegisterPage from "./pages/login/RegisterPage";
import SelectUnidadPage from "./pages/dirigente/SelectUnidadPage";
import CreateUnidadPage from "./pages/dirigente/CreateUnidadPage";
import ProtectedRoute from "./components/pageComponents/ProtectedRoute";
import RoleProtectedRoute from "./components/pageComponents/RoleProtectedRoute";
import RoleRedirectPage from "./components/RoleRedirectPage";
import JoinUnidadPage from "./pages/JoinUnidad";
import HomeUnidadScout from "./pages/scout/HomeUnidadScout";
import HomeUnidadDirigente from "./pages/dirigente/HomeUnidadDirigente";
import ObjetivosPage from "./pages/scout/ObjetivosPage";
import GestionarObjetivosPage from "./pages/dirigente/GestionarObjetivosPage";
import VerUnidadPage from "./pages/dirigente/VerUnidadPage";
import DirigenteUnitLayout from "./components/nav/DirigenteUnitLayout";
import ProfilePage from "./pages/common/ProfilePage";
import ScoutLayout from "./components/nav/ScoutLayout";
import MiProgresoPage from "./pages/scout/MiProgresoPage";
import VerProgresoScoutPage from "./pages/dirigente/VerProgresoScoutPage";
import ScrollToTop from "./components/ScrollToTop";

function App() {
  return (
    <BrowserRouter>
      <ScrollToTop />
      <Routes>
        <Route path="/" element={<MainPage />} />
        <Route path="/register" element={<RegisterPage />} />

        <Route element={<ProtectedRoute />}>
          <Route path="/home" element={<RoleRedirectPage />} />
          <Route path="/unirse-unidad" element={<JoinUnidadPage />} />
        </Route>

        {/* --- Rutas para Dirigentes (Rol 2) --- */}
        <Route element={<RoleProtectedRoute allowedRoles={[2]} />}>
          <Route path="/diri" element={<SelectUnidadPage />} />
          <Route path="/diri/crear-unidad" element={<CreateUnidadPage />} />

          <Route element={<DirigenteUnitLayout />}>
            <Route
              path="/diri/unidad/:unidadId/home"
              element={<HomeUnidadDirigente />}
            />
            <Route
              path="/diri/unidad/:unidadId/gestionar-objetivos"
              element={<GestionarObjetivosPage />}
            />
            <Route
              path="/diri/unidad/:unidadId/miembros"
              element={<VerUnidadPage />}
            />
            <Route
              path="/diri/unidad/:unidadId/scout/:scoutId/progreso"
              element={<VerProgresoScoutPage />}
            />
            <Route
              path="/diri/unidad/:unidadId/profile"
              element={<ProfilePage />}
            />
          </Route>
        </Route>

        {/* --- Rutas para Scouts (Rol 1) --- */}
        <Route element={<RoleProtectedRoute allowedRoles={[1]} />}>
          <Route element={<ScoutLayout />}>
            <Route path="/scout/home" element={<HomeUnidadScout />} />
            <Route path="/scout/objetivos" element={<ObjetivosPage />} />
            <Route path="/scout/profile" element={<ProfilePage />} />
            <Route path="/scout/progreso" element={<MiProgresoPage />} />
          </Route>
        </Route>
      </Routes>
    </BrowserRouter>
  );
}

export default App;
