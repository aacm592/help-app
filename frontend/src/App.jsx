import { BrowserRouter, Routes, Route } from "react-router-dom";
import MainPage from "./pages/login/MainPage";
import RegisterPage from "./pages/login/RegisterPage";
import ProtectedRoute from "./components/ProtectedRoute";
import LogedInPage from "./pages/LogedInPage";
import CreateUnidadPage from "./pages/CreateUnidadPage";

function App() {
  return (
    <BrowserRouter>
      <Routes>
        <Route path="/" element={<MainPage />} />
        <Route path="/register" element={<RegisterPage />} />
        <Route element={<ProtectedRoute />}>
          <Route path="/home" element={<LogedInPage />} />
          <Route path="/crear-unidad" element={<CreateUnidadPage />} />{" "}
        </Route>
      </Routes>
    </BrowserRouter>
  );
}

export default App;
