import Button from "./Button";

export default function Modal({ isOpen, onClose, title, children }) {
  if (!isOpen) {
    return null;
  }

  return (
    <div
      className="fixed inset-0 bg-black bg-opacity-60 z-40 flex justify-center items-center p-4"
      onClick={onClose}
    >
      <div
        className="bg-white rounded-lg shadow-xl p-6 w-full max-w-md z-50"
        onClick={(e) => e.stopPropagation()}
      >
        <div className="flex justify-between items-center mb-4 pb-4 border-b">
          <h2 className="text-2xl font-bold text-purple-800">{title}</h2>
          <Button
            outline={false}
            className="p-1 rounded-full hover:bg-gray-200"
            onClick={onClose}
          >
            <span className="material-symbols-outlined text-gray-600">
              close
            </span>
          </Button>
        </div>

        <div>{children}</div>
      </div>
    </div>
  );
}
