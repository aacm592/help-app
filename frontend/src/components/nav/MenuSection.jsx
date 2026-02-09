import { useState } from "react";
import Button from "../Button";

export default function MenuSection({ icon, title, links, onOptionClick }) {
  const [isOpen, setIsOpen] = useState(false);
  return (
    <div className="w-full mb-6">
      <Button
        onClick={() => setIsOpen(!isOpen)}
        outline={false}
        className={
          "hover:bg-purple-800 w-full rounded-none py-2 md:justify-between justify-center"
        }
      >
        <div className="flex items-center gap-x-3 text-white px-4">
          <span className="material-symbols-outlined text-2xl">{icon}</span>
          <h2 className="text-lg font-bold">{title}</h2>
        </div>
      </Button>

      <nav
        className={`overflow-hidden transition-all duration-300 ease-in-out ${
          isOpen ? "max-h-60 opacity-100" : "max-h-0 opacity-0"
        }`}
      >
        <ul>
          {links.map((link, index) => (
            <li
              key={index}
              onClick={() => onOptionClick()}
              className="group flex active:scale-95 items-center md:px-12 px-0 py-3 text-purple-200 hover:bg-purple-800 hover:text-white cursor-pointer transition-colors justify-center md:justify-start"
            >
              <span className="text-sm font-medium">{link}</span>
            </li>
          ))}
        </ul>
      </nav>
    </div>
  );
}
