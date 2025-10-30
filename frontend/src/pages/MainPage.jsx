import Button from "../components/Button";
import logo from "../assets/florDeLiz.png";

function MainPage() {
  const buttonClass = "space-x-6 md:w-xl w-2/3 px-7 py-1.5";
  const textClass = "text-[18px] md:text-[24px] text-white";
  const iconClass = "material-symbols-outlined text-white !text-4xl";

  return (
    <div className="flex flex-col justify-center items-center bg-purple-800 min-h-screen h-full w-screen py-10 gap-y-8">
      <h1 className="text-white">Bienvenido</h1>
      <img src={logo} alt="Flor de Liz Nacional" className="w-1/2 md:w-auto" />

      <Button dark className={buttonClass}>
        <span className={iconClass}>person_add</span>
        <p className={textClass}>Registrarse</p>
      </Button>

      <Button dark className={buttonClass}>
        <span className={iconClass}>person_check</span>
        <p className={textClass}>Iniciar sesión</p>
      </Button>
    </div>
  );
}

export default MainPage;
