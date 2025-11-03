export default function Button({ onClick, dark, children, className, type }) {
  const outline = () => {
    return dark ? "outline-white" : "outline-purple-800";
  };

  return (
    <button
      onClick={onClick}
      type={type}
      className={`flex flex-row items-center outline-1 rounded-full ${outline()} cursor-pointer transition active:scale-95 ${className}`}
    >
      {children}
    </button>
  );
}
