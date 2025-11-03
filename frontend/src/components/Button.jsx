export default function Button({
  onClick,
  dark,
  children,
  className,
  type,
  outline = true,
}) {
  const outlineCss = () => {
    if (!outline) return;
    return dark ? "outline-1 outline-white" : "outline-1 outline-purple-800";
  };

  return (
    <button
      onClick={onClick}
      type={type}
      className={`flex items-center rounded-full ${outlineCss()} cursor-pointer transition active:scale-95 ${className}`}
    >
      {children}
    </button>
  );
}
