import { NavLink } from "react-router-dom";

export default function NavItem({ to, icon, label }) {
  const commonStyle =
    "flex flex-col items-center justify-center gap-1 p-2 rounded-lg transition-colors";
  const activeStyle = "bg-purple-100 text-purple-800";
  const inactiveStyle =
    "text-gray-600 hover:bg-purple-50 hover:text-purple-700";

  const desktopStyle = "md:flex-row md:gap-2 md:px-3 md:py-2";
  const mobileStyle = "flex-grow";

  return (
    <>
      <NavLink
        to={to}
        className={({ isActive }) =>
          `md:hidden ${commonStyle} ${mobileStyle} ${
            isActive ? activeStyle : inactiveStyle
          }`
        }
      >
        <span className="material-symbols-outlined">{icon}</span>
        <span className="text-xs font-medium">{label}</span>
      </NavLink>

      <NavLink
        to={to}
        className={({ isActive }) =>
          `hidden md:flex ${commonStyle} ${desktopStyle} ${
            isActive ? activeStyle : inactiveStyle
          }`
        }
      >
        <span className="material-symbols-outlined">{icon}</span>
        <span className="text-sm font-bold">{label}</span>
      </NavLink>
    </>
  );
}
