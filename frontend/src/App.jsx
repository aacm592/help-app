import { BrowserRouter, Routes, Route } from "react-router-dom";
import MainPage from "./pages/login/MainPage";
import RegisterPage from "./pages/login/RegisterPage";
import ProtectedRoute from "./components/ProtectedRoute";
import LogedInPage from "./pages/LogedInPage";

function App() {
  return (
    <BrowserRouter>
      <Routes>
        <Route path="/" element={<MainPage />} />
        <Route path="/register" element={<RegisterPage />} />
        <Route element={<ProtectedRoute />}>
          <Route path="/home" element={<LogedInPage />} />
        </Route>
      </Routes>
    </BrowserRouter>
  );
}

export default App;
