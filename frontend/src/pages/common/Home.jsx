import { useAuth } from "../../contexts/AuthContext";
import logo from "../../assets/florDeLiz.png";
import ProfileInfoItem from "../../components/pageComponents/ProfileInfoItem";
import SalirUnidadButton from "../../components/pageComponents/SalirUnidadButton";
import { useEffect, useState } from "react";

export default function Home() {
  const { user } = useAuth();
  const [group, setGroup] = useState();
  useEffect(() => {
    if (user.unidades.length > 0) {
      setGroup(user.unidades[0].grupoScoutNombre);
    } else {
      setGroup("No se pudo cargar el grupo");
    }
  }, [user.unidades]);
  const icon = "fiber_manual_record";
  return (
    <div className="w-full h-full max-w-lg mx-auto py-8 flex flex-col justify-between p-4">
      <div className="flex flex-col items-center space-y-6">
        <img src={logo} alt="Foto de perfil" className="w-40 h-40 p-2" />
        <div className="flex flex-col items-center text-center">
          <h2 className="text-3xl font-bold text-[#0094B4]">
            {`${user.nombre} ${user.apellidos}`}
          </h2>
          <h2 className="text-2xl font-bold text-[#82e6de] saturate-40">
            {user.nombreUsuario}
          </h2>
        </div>

        <div className="space-y-6 w-full items-start">
          <ProfileInfoItem icon={icon} label="Grupo" data={group} />
          <>
            {user.unidades.map((u, i) => (
              <div key={i}>
                <ProfileInfoItem icon={icon} label={"Unidad"} data={u.nombre} />
              </div>
            ))}
          </>
        </div>
      </div>

      {user.tipoId === 1 && (
        <SalirUnidadButton
          unidadId={user.unidades[0].id}
          onSuccessRedirectPath={"/inicio"}
        />
      )}
    </div>
  );
}
