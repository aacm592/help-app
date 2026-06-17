import { useState } from "react";
import SpecialityReqItem from "./SpecialityReqItem";
import Button from "../../Button";

export default function SpecialityItem({
  name,
  status,
  description,
  req,
  onSelect,
}) {
  const [isOpen, setIsOpen] = useState(false);

  return (
    <div className="w-full border-2 p-4 my-3 rounded-2xl">
      <div className="space-y-2">
        <span className="flex justify-between">
          <p className="font-bold text-2xl">{name}</p>
          <span
            className={`font-black ${
              status === "Completada"
                ? "text-green-800"
                : status === "En Progreso"
                  ? "text-yellow-600"
                  : "text-gray-500"
            }`}
          >
            {status}
          </span>{" "}
        </span>
        <p>{description}</p>
        <div>
          <Button
            outline={false}
            className="p-2 text-purple-700"
            onClick={() => setIsOpen(!isOpen)}
          >
            {isOpen ? "Ver menos" : "Ver mas"}
          </Button>
        </div>
      </div>
      {isOpen && (
        <div className="">
          {req.map((r, i) => (
            <SpecialityReqItem
              key={i}
              status={r.status}
              info={r.descripcion}
              id={r.id}
              onSelect={(reqId) => onSelect(reqId)}
            />
          ))}
        </div>
      )}
    </div>
  );
}
