import SideMenu from "./SideMenu";

export default function Layout() {
  return (
    <div className="flex h-screen sticky top-0">
      <SideMenu />

      <div className="flex-1 bg-gray-100">
        {/* Your page content goes here */}
      </div>
    </div>
  );
}
