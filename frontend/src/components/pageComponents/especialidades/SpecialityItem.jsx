import { useState } from "react";
import SpecialityReqItem from "./SpecialityReqItem";
import Button from "../../Button";
import { selectRequerimiento } from "../../../services/especialidadService";

export default function SpecialityItem({ name, status, description, req, onSelect }) {
  const [isOpen, setIsOpen] = useState(false);
  const [requerimientos, setRequerimientos] = useState(req);

  const selectReq = async (id, indx) => {
    try {
      const newReq = requerimientos.map((r, i) =>
        i === indx ? { ...r, status: "En Progreso" } : r
      );

      setRequerimientos(newReq);
      await selectRequerimiento(id);
      onSelect();
    } catch (error) {
      console.error("error al seleccionar el requisito", error);
    }
  };

  return (
    <div className="w-full border-2 p-4 my-3 rounded-2xl">
      <div className="space-y-2">
        <span className="flex justify-between">
          <p className="font-bold text-2xl">{name}</p>
          <span
            className={`font-black ${
              status === "Cumplido"
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
          {requerimientos.map((r, i) => (
            <SpecialityReqItem
              key={i}
              status={r.status}
              info={r.descripcion}
              id={r.id}
              onSelect={(x) => selectReq(x, i)}
            />
          ))}
        </div>
      )}
    </div>
  );
}
