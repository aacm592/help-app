import { Outlet } from "react-router-dom";
import { getNavigation } from "../../config/Navigation";
import { useAuth } from "../../contexts/AuthContext";
import SideMenu from "./SideMenu";
import { useMemo } from "react";

export default function Layout() {
  const { user } = useAuth();

  const menu = useMemo(() => getNavigation(user), [user]);
  return (
    <div className="flex h-screen overflow-hidden">
      <SideMenu menuItems={menu} />
      <div className="flex-1 overflow-y-auto w-full">
        <Outlet />
      </div>
    </div>
  );
}
