import { useEffect, useState } from "react";
import { getRegistrosDistrito } from "../../services/distritoService";
import { getGruposScoutPorDistrito } from "../../services/grupoService";
import ScoutsTable from "../../components/pageComponents/distrito/ScoutsTable";
import DiriTable from "../../components/pageComponents/distrito/DiriTable";
import LoadingPage from "../../components/LoadingPage";

export default function RegistrosDistritoPage() {
  const [registros, setRegistros] = useState({ scouts: [], dirigentes: [] });
  const [loading, setLoading] = useState(true);

  const [tipoRegistro, setTipoRegistro] = useState("Scouts");
  const [rama, setRama] = useState("Todos");
  const [grupos, setGrupos] = useState([]);
  const [grupoFiltro, setGrupoFiltro] = useState("Todos");

  const thClassName =
    "border-y border-gray-100 px-2 py-5 text-green-900 font-bold";
  const tdClassName = "border-y border-gray-300 px-2 py-4";
  const tableClassName = "bg-sky-200";
  const trClassName = "hover:bg-indigo-50 transition-colors";

  useEffect(() => {
    const fetchData = async () => {
      try {
        const fetchedRegistros = await getRegistrosDistrito();
        const validRegistros = fetchedRegistros || {
          scouts: [],
          dirigentes: [],
        };
        

        setRegistros(validRegistros);

        if (validRegistros.id) {
          const fetchedGrupos = await getGruposScoutPorDistrito(
            validRegistros.id,
          );
          setGrupos(fetchedGrupos || []);
        }
      } catch (error) {
        console.error("Error al cargar los datos", error);
      } finally {
        setLoading(false);
      }
    };

    fetchData();
  }, []);

  const baseData =
    tipoRegistro === "Dirigentes" ? registros.dirigentes : registros.scouts;

  const tableData = baseData.filter((item) => {
    const matchesRama =
      tipoRegistro === "Dirigentes" || rama === "Todos" || item.rama === rama;
    const matchesGrupo = grupoFiltro === "Todos" || item.grupo === grupoFiltro;

    return matchesRama && matchesGrupo;
  });

  if (loading) return <LoadingPage />;

  return (
    <div className="w-full md:px-10 px-4 py-4">
      <h1 className="text-purple-900 md:text-left text-center">
        Registros Distritales
      </h1>

      <div className="flex flex-col md:flex-row md:gap-7 gap-4">
        <select
          value={tipoRegistro}
          onChange={(e) => setTipoRegistro(e.target.value)}
          className="p-4 md:py-7 rounded-xl bg-violet-200 hover:bg-violet-400"
        >
          <option className="bg-white" value="Scouts">
            Scouts
          </option>
          <option className="bg-white" value="Dirigentes">
            Dirigentes
          </option>
        </select>

        <select
          value={grupoFiltro}
          onChange={(e) => setGrupoFiltro(e.target.value)}
          className="p-4 md:py-7 rounded-xl bg-violet-200 hover:bg-violet-400"
        >
          <option className="bg-white" value="Todos">
            Todos los Grupos
          </option>
          {grupos.map((grupo) => (
            <option className="bg-white" key={grupo.id} value={grupo.nombre}>
              {grupo.nombre}
            </option>
          ))}
        </select>

        {tipoRegistro !== "Dirigentes" && (
          <select
            value={rama}
            onChange={(e) => setRama(e.target.value)}
            className="p-4 md:py-7 rounded-xl bg-violet-200 hover:bg-violet-400"
          >
            <option className="bg-white" value="Todos">
              Todas las Ramas
            </option>
            <option className="bg-white" value="Lobatos">
              Lobatos
            </option>
            <option className="bg-white" value="Exploradores">
              Exploradores
            </option>
            <option className="bg-white" value="Pioneros">
              Pioneros
            </option>
            <option className="bg-white" value="Rovers">
              Rovers
            </option>
          </select>
        )}
      </div>

      <div className="mt-6">
        {tipoRegistro === "Dirigentes" ? (
          <DiriTable
            dirigentes={tableData}
            thClassName={thClassName}
            tdClassName={tdClassName}
            tableClassName={tableClassName}
            trClassName={trClassName}
          />
        ) : (
          <ScoutsTable
            scouts={tableData}
            thClassName={thClassName}
            tdClassName={tdClassName}
            tableClassName={tableClassName}
            trClassName={trClassName}
          />
        )}
      </div>
    </div>
  );
}
