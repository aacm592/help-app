export default function Button({ onClick, dark, children, className }) {
  const outline = () => {
    return dark ? "outline-white" : "outline-purple-800";
  };

  return (
    <button
      onClick={onClick}
      className={`flex flex-row items-center outline-1 rounded-2xl ${outline()} cursor-pointer transition active:scale-95 ${className}`}
    >
      {children}
    </button>
  );
}
