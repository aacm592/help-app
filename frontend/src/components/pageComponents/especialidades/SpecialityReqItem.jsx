import Button from "../../Button";

export default function SpecialityReqItem({ info, status, id, onSelect }) {
  return (
    <div className="flex items-center justify-between w-full space-x-5 border-t">
      <span className="m-5">{info}</span>
      {status === "Sin iniciar" ? (
        <Button
          onClick={() => {
            onSelect(id);
          }}
          className="px-2 py-2 font-bold"
        >
          Seleccionar
        </Button>
      ) : (
        <span
          className={`font-black ${
            status === "Cumplido" ? "text-green-700" : "text-yellow-500"
          }`}
        >
          {status}
        </span>
      )}
    </div>
  );
}
