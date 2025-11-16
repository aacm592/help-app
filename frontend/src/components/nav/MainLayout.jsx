import { Outlet } from "react-router-dom";
import NavBar from "./NavBar";
import LogOutButton from "../pageComponents/LogoutButton";

export default function MainLayout({ links }) {
  return (
    <div className="flex flex-col min-h-screen">
      <header className="w-full bg-white shadow-md">
        <LogOutButton />
        <div className="hidden md:block justify-center">
          <NavBar links={links} />
        </div>
      </header>

      <main className="grow w-full p-4 md:p-8 pb-24 md:pb-8">
        <Outlet />
      </main>

      <div className="md:hidden">
        <NavBar links={links} />
      </div>
    </div>
  );
}
