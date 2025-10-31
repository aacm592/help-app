import Button from "../components/Button";
import logo from "../assets/florDeLiz.png";
import LoginComponent from "../components/LoginComponent";

function MainPage() {
  const buttonClass = "space-x-5 px-6 py-1.5";
  const textClass = "text-[16px] md:text-[20px] text-white";
  const iconClass = "material-symbols-outlined text-white !text-4xl";

  return (
    <div className="flex flex-col justify-center items-center bg-purple-800 min-h-screen h-full w-screen py-10 gap-y-8">
      <h1 className="text-white">Bienvenido</h1>
      <img src={logo} alt="Flor de Liz Nacional" className="w-1/2 md:w-auto" />

      <div className="flex flex-col justify-center items-center md:w-xl w-2/3">
        <LoginComponent />
        <Button dark className={buttonClass}>
          <span className={iconClass}>person_add</span>
          <p className={textClass}>Registrarse</p>
        </Button>
      </div>
    </div>
  );
}

export default MainPage;
