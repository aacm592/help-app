import { useAuth } from "../../contexts/AuthContext";
import logo from "../../assets/florDeLiz.png";

export default function Home() {
  const { user } = useAuth();
  return (
    <div>
      <div className="flex flex-col items-center mb-10">
        <img
          src={logo}
          alt="Foto de perfil"
          className="w-40 h-40 rounded-full border-4 border-purple-300 p-2"
        />

        <h2 className="text-4xl font-bold text-purple-800 mt-4">
          {user.nombreUsuario}
        </h2>
      </div>
    </div>
  );
}
