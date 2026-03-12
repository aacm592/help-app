import { useEffect, useState } from "react";
import GroupRegisters from "../../components/pageComponents/distrito/GroupRegisters";
import { getResumenEnviadosAlDistrito } from "../../services/distritoService";
import { registerDistrito } from "../../services/registerService";

export default function RegisterDistritoPage() {
  const [grupos, setGrupos] = useState([]);

  useEffect(() => {
    const getResumen = async () => {
      try {
        const resumen = await getResumenEnviadosAlDistrito();
        setGrupos(resumen);
      } catch (error) {
        console.error("Error al conseguir los registros", error);
      }
    };

    getResumen();
  }, []);

  const aproveRegisters = async (registros, indx) => {
    console.log(registros);
    try {
      const r = await registerDistrito(registros);
      const newGrupos = grupos.filter((_, i) => i == !indx);
      alert(r || "Usuarios registrados con éxito");

      setGrupos(newGrupos);
    } catch (error) {
      console.error("Error al registrar miembros:", error);
      alert(error || "No se pudo completar el registro");
    }
  };

  return (
    <div className="w-full p-4 flex flex-col justify-center items-center">
      <h1 className="text-purple-900 md:text-left text-center">
        Registros recividos
      </h1>
      <div className="flex flex-col justify-center w-full items-center">
        <div className="w-full md:w-1/3 flex flex-col space-y-10">
          {grupos.map((g, i) => (
            <div key={i}>
              <GroupRegisters
                grupo={g}
                onClick={() => aproveRegisters(g.registros, i)}
              />
            </div>
          ))}
        </div>
      </div>
    </div>
  );
}
