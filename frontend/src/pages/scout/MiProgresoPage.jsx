import { useAuth } from "../../contexts/AuthContext";
import ProgresoDisplay from "../../components/pageComponents/ProgresoDisplay";

export default function MiProgresoPage() {
  const { user } = useAuth();

  return (
    <div className="w-full">
      <h1 className="text-purple-900 mb-6">Mi Progreso</h1>
      <ProgresoDisplay scoutId={user?.id} />
    </div>
  );
}
