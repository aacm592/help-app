import NavItem from "./NavItem";

export default function NavBar({ links = [] }) {
  return (
    <>
      <nav className="hidden md:flex w-full bg-white shadow-md p-4 justify-center items-center">
        <div className="flex w-full max-w-4/5 justify-between">
          {links.map((link) => (
            <NavItem
              key={link.path}
              to={link.path}
              icon={link.icon}
              label={link.label}
            />
          ))}
        </div>
      </nav>

      <nav className="md:hidden fixed bottom-0 left-0 right-0 w-full bg-white border-t border-gray-200 shadow-lg flex justify-around items-center p-1">
        {links.map((link) => (
          <NavItem
            key={link.path}
            to={link.path}
            icon={link.icon}
            label={link.label}
          />
        ))}
      </nav>
    </>
  );
}
