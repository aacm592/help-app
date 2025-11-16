import MainLayout from "./MainLayout";

const scoutLinks = [
  { path: "/scout/home", label: "Home", icon: "home" },
  { path: "/scout/profile", label: "Yo", icon: "person" },
  { path: "/scout/progreso", label: "Mi Progreso", icon: "auto_stories" },
];

export default function ScoutLayout() {
  return <MainLayout links={scoutLinks} />;
}
