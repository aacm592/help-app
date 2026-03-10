import { useEffect, useState } from "react";
import GroupRegisters from "../../components/pageComponents/distrito/GroupRegisters";
import { getResumenEnviadosAlDistrito } from "../../services/distritoService";

export default function RegisterDistritoPage() {
  const [grupos, setGrupos] = useState([]);

  useEffect(() => {
    const getResumen = async () => {
      try {
        const resumen = await getResumenEnviadosAlDistrito();
        console.log(resumen);
        setGrupos(resumen);
      } catch (error) {
        console.error("Error al conseguir los registros", error);
      }
    };

    getResumen();
  }, []);

  return (
    <div className="w-full p-4 flex flex-col justify-center items-center">
      <h1 className="text-purple-900 md:text-left text-center">
        Registrar al distrito
      </h1>
      <div className="flex flex-col justify-center w-full items-center">
        <div className="w-full md:w-1/3 flex flex-col space-y-10">
          {grupos.map((g, i) => (
            <div key={i}>
              <GroupRegisters grupo={g} />
            </div>
          ))}
        </div>
      </div>
    </div>
  );
}
