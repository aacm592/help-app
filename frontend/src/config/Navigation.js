export const getNavigation = (user) => {
  const sections = [];

  sections.push({
    icon: "person",
    title: "Yo",
    links: [
      {
        label: "Mi Perfil",
        path: user?.tipoId === 1 ? "/scout/profile" : "/diri/profile",
      },
    ],
  });

  if (user?.tipoId === 2) {
    user.unidades.forEach((unidad) => {
      sections.push({
        icon: "shield_person",
        title: `Unidad: ${unidad?.nombre || "S/N"}`,
        links: [
          { label: "Miembros", path: `/diri/unidad/${unidad.id}/miembros` },
          {
            label: "Gestionar Objetivos",
            path: `/diri/unidad/${unidad.id}/gestionar-objetivos`,
          },
          {
            label: "Gestionar Especialidades",
            path: `/diri/unidad/${unidad.id}/gestionar-especialidades`,
          },
        ],
      });
    });
  }

  if (user?.tipoId === 1) {
    sections.push(
      {
        icon: "checklist",
        title: "Objetivos",
        links: [
          { label: "Elegir", path: "/scout/objetivos" },
          { label: "Mi progreso", path: "/scout/objetivos/mi-progreso" },
        ],
      },
      {
        icon: "workspace_premium",
        title: "Especialidades",
        links: [
          { label: "Elegir", path: "/scout/especialidades" },
          {
            label: "Mi Progreso",
            path: "/scout/especialidades/mi-progreso",
          },
        ],
      },
    );
  }

  return sections;
};
