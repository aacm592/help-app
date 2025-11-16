import { useParams } from "react-router-dom";
import MainLayout from "./MainLayout";

export default function DirigenteUnitLayout() {
  const { unidadId } = useParams();

  const dirigenteLinks = [
    { path: `/diri/unidad/${unidadId}/home`, label: "Home Unidad", icon: "home" },
    { path: `/diri/unidad/${unidadId}/profile`, label: "Yo", icon: "person" },
  ];

  return <MainLayout links={dirigenteLinks} />;
}
