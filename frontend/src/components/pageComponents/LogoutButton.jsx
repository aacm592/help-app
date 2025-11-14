import { useAuth } from "../../contexts/AuthContext";
import Button from "../Button";

export default function LogOutButton({ dark = false }) {
  const { handleLogout } = useAuth();
  const color = dark ? "text-white" : "text-purple-800";

  return (
    <div className="w-full px-4 sm:px-20 flex justify-end h-fit">
      <Button
        outline={false}
        className={"w-fit flex-col justify-center items-center h-fit "}
        onClick={handleLogout}
      >
        <span className={`material-symbols-outlined ${color} text-4xl!`}>
          logout
        </span>
        <p className={color}>Cerrar Sesión</p>
      </Button>
    </div>
  );
}
