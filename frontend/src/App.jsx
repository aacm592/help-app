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

function App() {
  return (
    <BrowserRouter>
      <Routes>
        <Route path="/" element={<MainPage />} />
        <Route path="/register" element={<RegisterPage />} />

        <Route element={<ProtectedRoute />}>
          <Route path="/home" element={<RoleRedirectPage />} />
          <Route path="/unirse-unidad" element={<JoinUnidadPage />} />
        </Route>

        {/* Rutas para Dirigentes (Rol 2) */}
        <Route element={<RoleProtectedRoute allowedRoles={[2]} />}>
          <Route path="/diri" element={<SelectUnidadPage />} />
          <Route path="/diri/crear-unidad" element={<CreateUnidadPage />} />
          <Route
            path="/dirigente/unidad/:unidadId"
            element={<HomeUnidadDirigente />}
          />
        </Route>

        {/* Rutas para Scouts (Rol 1) */}
        <Route element={<RoleProtectedRoute allowedRoles={[1]} />}>
          <Route path="/scout/home" element={<HomeUnidadScout />} />
        </Route>
      </Routes>
    </BrowserRouter>
  );
}

export default App;
