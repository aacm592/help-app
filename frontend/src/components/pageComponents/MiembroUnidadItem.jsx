import { useState } from "react";
import Button from "../Button";
import { useNavigate, useParams } from "react-router-dom";

const ROLES = {
  SCOUT: 1,
};

export default function MiembroUnidadItem({
  miembro,
  currentUserId,
  onRemove,
  isLoading,
  onGenerateCode,
  isGeneratingCode,
}) {
  const { id: miembroId, nombre, tipoId } = miembro;
  const esScout = tipoId === ROLES.SCOUT;
  const rolNombre = esScout ? "Scout" : "Dirigente";

  const nav = useNavigate();
  const { unidadId } = useParams();

  const [isExpanded, setIsExpanded] = useState(false);

  const isActionDisabled = isLoading || isGeneratingCode;

  const handleVerProgreso = () => {
    nav(`/diri/unidad/${unidadId}/scout/${miembroId}/progreso`, {
      state: { scoutNombre: nombre },
    });
  };

  const handleVerPerfil = () => {
    nav(`/diri/unidad/${unidadId}/scout/${miembroId}/perfil`, {
      state: { scoutNombre: nombre, rolNombre },
    });
  };

  const handleAsignarObj = () => {
    nav(`/diri/unidad/${unidadId}/asignar-objetivos/${miembroId}`, {
      state: { scoutNombre: nombre },
    });
  };

  const handleAsignarEsp = () => {
    nav(`/diri/unidad/${unidadId}/asignar-especialidades/${miembroId}`, {
      state: { scoutNombre: nombre },
    });
  };

  return (
    <div className="w-full bg-white rounded-lg shadow-sm border border-gray-200 overflow-hidden transition-all duration-200">
      <div
        className="p-4 flex items-center justify-between cursor-pointer hover:bg-gray-50 transition-colors"
        onClick={() => setIsExpanded(!isExpanded)}
      >
        <div>
          <p className="text-lg text-gray-800 font-medium leading-tight">
            {nombre}
          </p>
          <p className="text-sm text-gray-500 font-medium mt-1">{rolNombre}</p>
        </div>

        <div className="flex items-center text-gray-400">
          <span
            className={`material-symbols-outlined transition-transform duration-300 ${isExpanded ? "rotate-180" : ""}`}
          >
            expand_more
          </span>
        </div>
      </div>

      {isExpanded && (
        <div className="p-4 pt-2 bg-gray-50/50 border-t border-gray-100 flex flex-wrap gap-3 animate-fade-in-down">
          {esScout && (
            <>
              <Button
                className="flex-1 flex items-center justify-center gap-2 px-4 py-2 text-sm bg-white border border-blue-200 text-blue-700 hover:bg-blue-50 rounded-md transition-colors min-w-[120px]"
                onClick={handleVerProgreso}
                disabled={isActionDisabled}
              >
                <span className="material-symbols-outlined text-base">
                  trending_up
                </span>
                Progreso
              </Button>

              <Button
                className="flex-1 flex items-center justify-center gap-2 px-4 py-2 text-sm bg-white border border-purple-200 text-purple-700 hover:bg-purple-50 rounded-md transition-colors min-w-[120px]"
                onClick={handleVerPerfil}
                disabled={isActionDisabled}
              >
                <span className="material-symbols-outlined text-base">
                  person
                </span>
                Perfil
              </Button>

              <Button
                className="flex-1 flex items-center justify-center gap-2 px-4 py-2 text-sm bg-white border border-amber-200 text-amber-700 hover:bg-amber-50 rounded-md transition-colors min-w-[120px]"
                onClick={() => onGenerateCode(miembro)}
                disabled={isActionDisabled}
              >
                {isGeneratingCode ? (
                  <span className="material-symbols-outlined animate-spin text-base">
                    progress_activity
                  </span>
                ) : (
                  <>
                    <span className="material-symbols-outlined text-base">
                      key
                    </span>
                    Reset Pass
                  </>
                )}
              </Button>

              <Button
                className="flex-1 flex items-center justify-center gap-2 px-4 py-2 text-sm bg-white border border-purple-200 text-purple-700 hover:bg-purple-50 rounded-md transition-colors min-w-[120px]"
                onClick={handleAsignarObj}
                disabled={isActionDisabled}
              >
                <span className="material-symbols-outlined text-base">
                  person
                </span>
                Asignar Objetivos
              </Button>

              <Button
                className="flex-1 flex items-center justify-center gap-2 px-4 py-2 text-sm bg-white border border-purple-200 text-purple-700 hover:bg-purple-50 rounded-md transition-colors min-w-[120px]"
                onClick={handleAsignarEsp}
                disabled={isActionDisabled}
              >
                <span className="material-symbols-outlined text-base">
                  workspace_premium
                </span>
                Asignar Especialidades
              </Button>
            </>
          )}

          {miembroId !== currentUserId && (
            <Button
              className="flex-1 flex items-center justify-center gap-2 px-4 py-2 text-sm bg-white border border-red-200 text-red-700 hover:bg-red-50 rounded-md transition-colors min-w-[120px]"
              onClick={() => onRemove(miembro)}
              disabled={isActionDisabled}
            >
              {isLoading ? (
                <span className="material-symbols-outlined animate-spin text-base">
                  progress_activity
                </span>
              ) : (
                <>
                  <span className="material-symbols-outlined text-base">
                    person_remove
                  </span>
                  Sacar
                </>
              )}
            </Button>
          )}
        </div>
      )}
    </div>
  );
}
