import Button from "../Button";

export default function SerDirigenteButton({ onCLick }) {

  return (
    <Button className="w-full flex justify-center text-[18px] text-rose-400" onClick={onCLick}>
      Soy Dirigente
    </Button>
  );
}
