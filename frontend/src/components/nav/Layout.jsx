import { Outlet } from "react-router-dom";
import { getNavigation } from "../../config/Navigation";
import { useAuth } from "../../contexts/AuthContext";
import SideMenu from "./SideMenu";

export default function Layout() {
  const { user } = useAuth();
  const menu = getNavigation(user);

  return (
    <div className="flex h-screen overflow-hidden">
      <SideMenu menuItems={menu} />
      <div className="flex-1 bg-gray-100 overflow-y-auto p-4 md:p-8">
        <Outlet />
      </div>
    </div>
  );
}
