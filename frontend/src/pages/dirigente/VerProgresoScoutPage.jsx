import { useParams, useLocation, useNavigate } from "react-router-dom";
import ProgresoDisplay from "../../components/pageComponents/ProgresoDisplay";
import Button from "../../components/Button";

export default function VerProgresoScoutPage() {
  const { scoutId, unidadId } = useParams();
  const location = useLocation();
  const nav = useNavigate();

  const scoutNombre = location.state?.scoutNombre || "Scout---";

  return (
    <div className="w-full">
      <div className="flex justify-between items-center mb-6">
        <div className="flex items-center gap-2">
          <h1 className="text-purple-900">Progreso de:</h1>
          <p className="text-5xl font-bold text-violet-800">{scoutNombre}</p>
        </div>
        <Button
          className="px-4 py-2"
          onClick={() => nav(`/diri/unidad/${unidadId}/miembros`)}
        >
          <span className="material-symbols-outlined mr-2">arrow_back</span>
          Volver a Miembros
        </Button>
      </div>

      <ProgresoDisplay scoutId={scoutId} />
    </div>
  );
}
