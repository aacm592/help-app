import { useState } from "react";
import MenuSection from "./MenuSection";
import Button from "../Button";
import { useAuth } from "../../contexts/AuthContext";

export default function SideMenu({ menuItems }) {
  const [isMobileOpen, setIsMobileOpen] = useState(false);
  const closeMenu = () => setIsMobileOpen(false);
  const visibilidad = isMobileOpen
    ? "translate-x-0"
    : "-translate-x-full md:translate-x-0";

  const { handleLogout } = useAuth();

  return (
    <>
      <div className="md:hidden fixed top-4 left-4 z-50">
        <Button
          onClick={() => setIsMobileOpen(!isMobileOpen)}
          className="p-2 bg-gray-300 rounded-lg"
          outline={false}
        >
          <span className="material-symbols-outlined">
            {isMobileOpen ? "close" : "menu"}
          </span>
        </Button>
      </div>
      <aside
        className={`${visibilidad} flex flex-col justify-between md:relative fixed top-0 left-0 h-screen z-40 w-full md:w-64 bg-purple-900 py-4 transition-transform duration-300`}
      >
        <div className="overflow-y-auto grow">
          {menuItems.map((mi, i) => (
            <MenuSection
              key={i}
              icon={mi.icon}
              title={mi.title}
              links={mi.links}
              onOptionClick={closeMenu}
            />
          ))}
        </div>

        <div className="mt-auto pt-4 border-t border-purple-800">
          <Button
            outline={false}
            className="hover:bg-purple-800 w-full rounded-none py-2 md:justify-between justify-center"
            onClick={handleLogout}
          >
            <div className="flex items-center gap-x-3 text-white px-4">
              <span className="material-symbols-outlined text-2xl">logout</span>
              <h2 className="text-lg font-bold">Cerrar Sesión</h2>
            </div>
          </Button>
        </div>
      </aside>
    </>
  );
}
