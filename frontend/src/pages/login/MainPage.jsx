import Button from "../../components/Button";
import logo from "../../assets/florDeLiz.png";
import { useNavigate } from "react-router-dom";
import LoginComponent from "../../components/pageComponents/LoginComponent";

function MainPage() {
  const buttonClass = "space-x-5 px-6 py-1.5";
  const textClass = "text-[16px] md:text-[20px] text-white";
  const iconClass = "material-symbols-outlined text-white text-4xl!";
  const navigate = useNavigate();

  return (
    <div className="flex flex-col justify-center items-center bg-purple-600 min-h-screen h-full w-screen py-10 gap-y-8">
      <h1 className="text-white">Bienvenido</h1>
      <img src={logo} alt="Flor de Liz Nacional" className="w-1/2 md:w-auto" />

      <div className="flex flex-col justify-center items-center md:w-xl w-2/3">
        <LoginComponent />
        <Button
          dark
          className={buttonClass}
          onClick={() => {
            navigate("/register");
          }}
        >
          <span className={iconClass}>person_add</span>
          <p className={textClass}>Registrarse</p>
        </Button>
        <button
          onClick={() => navigate("/reset-password")}
          className="text-white text-sm mt-6 hover:text-amber-300"
        >
          ¿Olvidaste tu contraseña?
        </button>
      </div>
    </div>
  );
}

export default MainPage;
