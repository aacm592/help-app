import { useState } from "react";
import MenuSection from "./MenuSection";
import Button from "../Button";

export default function SideMenu({ menuItems }) {
  const [isMobileOpen, setIsMobileOpen] = useState(false);
  const closeMenu = () => setIsMobileOpen(false);
  const visibilidad = isMobileOpen
    ? "translate-x-0"
    : "-translate-x-full md:translate-x-0";
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
        className={`
        ${visibilidad} 
        fixed md:relative top-0 left-0 h-full z-40
        w-full md:w-64 
        bg-purple-900 py-4 overflow-y-auto transition-transform duration-300
      `}
      >
        {menuItems.map((mi) => {
          <MenuSection
            icon={mi.icon}
            title={mi.tittle}
            links={mi.links}
            onOptionClick={closeMenu}
          />;
        })}
      </aside>
    </>
  );
}
