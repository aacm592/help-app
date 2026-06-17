import { BrowserRouter, Routes, Route } from "react-router-dom";
import MainPage from "./pages/login/MainPage";
import RegisterPage from "./pages/login/RegisterPage";
import SelectUnidadPage from "./pages/dirigente/SelectUnidadPage";
import CreateUnidadPage from "./pages/dirigente/CreateUnidadPage";
import RoleRedirectPage from "./components/RoleRedirectPage";
import JoinUnidadPage from "./pages/JoinUnidad";
import HomeUnidadDirigente from "./pages/dirigente/HomeUnidadDirigente";
import ObjetivosPage from "./pages/scout/ObjetivosPage";
import GestionarObjetivosPage from "./pages/dirigente/GestionarObjetivosPage";
import VerUnidadPage from "./pages/dirigente/VerUnidadPage";
import ProfilePage from "./pages/common/ProfilePage";
import MiProgresoPage from "./pages/scout/MiProgresoPage";
import VerProgresoScoutPage from "./pages/dirigente/VerProgresoScoutPage";
import ScrollToTop from "./components/ScrollToTop";
import ResetPasswordPage from "./pages/login/ResetPasswordPage";
import EspecialidadesPage from "./pages/scout/EspecialidadesPage";
import GestionarEspecialidadesPage from "./pages/dirigente/GestionarEspecialidadesPage";
import ScoutProfilePage from "./pages/dirigente/ScoutProfilePage";
import Layout from "./components/nav/Layout";
import Home from "./pages/common/Home";
import UnidadPage from "./pages/dirigente/UnidadPage";
import RoleProtectedRoute from "./components/pageComponents/protectedRoutes.jsx/RoleProtectedRoute";
import ProtectedRoute from "./components/pageComponents/protectedRoutes.jsx/ProtectedRoute";
import PermisoProtectedRoute from "./components/pageComponents/protectedRoutes.jsx/PermisoProtectedRoute";
import GroupMembersPage from "./pages/group/GroupMembersPage";
import ChooseUnidadToRegister from "./pages/group/ChooseUnidadToRegister";
import RegisterMembersPage from "./pages/group/RegisterMembersPage";
import RegistrosGrupoPage from "./pages/group/RegistrosGrupoPage";
import GroupAdminsPage from "./pages/group/GroupAdminsPage";
import RegisterGroupAdminsPage from "./pages/group/RegisterGroupAdminsPage";
import RegisterDistritoPage from "./pages/distrito/RegisterDistritoPage";
import RegistrosDistritoPage from "./pages/distrito/RegistrosDistritoPage";
import ResRegistrosDistPage from "./pages/distrito/ResRegistrosDistPage";
import AdminsDistritoPage from "./pages/distrito/AdminsDistritoPage";
import ResponsablesGrupoPage from "./pages/distrito/ResponsablesGrupoPage";
import AsignarObjetivosPage from "./pages/dirigente/AsignarObjetivosPage";
import AsignarEspecialidadPage from "./pages/dirigente/AsignarEspecialidadPage";

function App() {
  return (
    <BrowserRouter>
      <ScrollToTop />
      <Routes>
        <Route path="/" element={<MainPage />} />
        <Route path="/register" element={<RegisterPage />} />
        <Route path="/reset-password" element={<ResetPasswordPage />} />

        <Route element={<ProtectedRoute />}>
          <Route path="/home" element={<RoleRedirectPage />} />
          <Route path="/unirse-unidad" element={<JoinUnidadPage />} />
          <Route path="/inicio" element={<SelectUnidadPage />} />
        </Route>

        {/* --- Rutas para Dirigentes (Rol 2) --- */}
        <Route element={<RoleProtectedRoute allowedRoles={[2]} />}>
          <Route path="/crear-unidad" element={<CreateUnidadPage />} />

          <Route element={<Layout />}>
            <Route path="/diri" element={<Home />} />

            <Route
              path="/diri/unidad/:unidadId/home"
              element={<HomeUnidadDirigente />}
            />
            <Route
              path="/diri/unidad/:unidadId/asignar-objetivos/:scoutId"
              element={<AsignarObjetivosPage />}
            />

            <Route
              path="/diri/unidad/:unidadId/asignar-especialidades/:scoutId"
              element={<AsignarEspecialidadPage />}
            />

            <Route
              path="/diri/unidad/:unidadId/gestionar-objetivos"
              element={<GestionarObjetivosPage />}
            />

            <Route
              path="/diri/unidad/:unidadId/gestionar-especialidades"
              element={<GestionarEspecialidadesPage />}
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
              path="/diri/unidad/:unidadId/scout/:scoutId/perfil"
              element={<ScoutProfilePage />}
            />
            <Route path="/diri/profile" element={<ProfilePage />} />
            <Route path="/diri/unidad/:unidadId" element={<UnidadPage />} />

            {/* --- Rutas Grupo (Permisos 1 y 2) --- */}
            <Route element={<PermisoProtectedRoute allowedPermisos={[1, 2]} />}>
              <Route path="/grupo/miembros" element={<GroupMembersPage />} />
              <Route path="/grupo/admins" element={<GroupAdminsPage />} />
              <Route path="/grupo/registros" element={<RegistrosGrupoPage />} />
              <Route
                path="/grupo/registrar"
                element={<ChooseUnidadToRegister />}
              />
              <Route
                path="/grupo/registrar/:unidadId"
                element={<RegisterMembersPage />}
              />
              <Route
                path="/grupo/registrar/admins"
                element={<RegisterGroupAdminsPage />}
              />
            </Route>

            {/* --- Rutas Distrito (Permisos 3 y 4) --- */}
            <Route element={<PermisoProtectedRoute allowedPermisos={[3, 4]} />}>
              <Route
                path="/distrito/enviados"
                element={<RegisterDistritoPage />}
              />
              <Route
                path="/distrito/registros"
                element={<RegistrosDistritoPage />}
              />
              <Route
                path="/distrito/registros/resumen"
                element={<ResRegistrosDistPage />}
              />
              <Route path="/distrito/admins" element={<AdminsDistritoPage />} />
              <Route
                path="/distrito/responsables-grupo"
                element={<ResponsablesGrupoPage />}
              />
            </Route>
          </Route>
        </Route>

        {/* --- Rutas para Scouts (Rol 1) --- */}
        <Route element={<RoleProtectedRoute allowedRoles={[1]} />}>
          <Route element={<Layout />}>
            <Route path="/scout" element={<Home />} />

            <Route path="/scout/objetivos" element={<ObjetivosPage />} />
            <Route
              path="/scout/especialidades"
              element={<EspecialidadesPage />}
            />
            <Route path="/scout/profile" element={<ProfilePage />} />
            <Route path="/scout/progreso" element={<MiProgresoPage />} />
          </Route>
        </Route>
      </Routes>
    </BrowserRouter>
  );
}

export default App;
