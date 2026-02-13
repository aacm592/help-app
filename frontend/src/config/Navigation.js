export const getNavigation = (user) => {
  const sections = [];

  // Definición de los links básicos para la sección "Yo"
  const userLinks = [
    {
      label: "Inicio",
      path: user?.tipoId === 1 ? "/scout" : "/diri",
    },
    {
      label: "Mi Perfil",
      path: user?.tipoId === 1 ? "/scout/profile" : "/diri/profile",
    },
  ];

  // Añadimos "Mi progreso" solo si es un Scout (tipoId 1)
  if (user?.tipoId === 1) {
    userLinks.push({
      label: "Mi progreso",
      path: "/scout/progreso",
    });
  }

  sections.push({
    icon: "person",
    title: "Yo",
    links: userLinks,
  });

  if (user?.tipoId === 2) {
    user.unidades.forEach((unidad) => {
      sections.push({
        icon: "shield_person",
        title: `Unidad: ${unidad?.nombre || "S/N"}`,
        links: [
          { label: "Ver Unidad", path: `/diri/unidad/${unidad.id}` },
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
        links: [{ label: "Elegir", path: "/scout/objetivos" }],
      },
      {
        icon: "workspace_premium",
        title: "Especialidades",
        links: [{ label: "Elegir", path: "/scout/especialidades" }],
      },
    );
  }

  return sections;
};
