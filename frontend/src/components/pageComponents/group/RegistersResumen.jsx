import Button from "../../Button";

export default function RegistersResumen({ grupo, onClick, buttonMessage }) {
  const pClassname = "w-full md:w-fit px-3 flex justify-between text-lg";
  const spanClassname = "px-2 font-black";
  return (
    <div className="w-full bg-violet-100 p-8 rounded-2xl border-3 border-purple-900">
      <h2 className="text-xl font-bold w-full text-center">{grupo.grupo}</h2>
      <div className="flex md:flex-row flex-col space-x-3 space-y-3 justify-between md:items-center">
        <div className=" w-full">
          <p className={pClassname}>
            Lobatos: <span className={spanClassname}>{grupo.lobatos}</span>
          </p>
          <p className={pClassname}>
            Exploradores: <span className={spanClassname}>{grupo.explos}</span>
          </p>
          <p className={pClassname}>
            Pioneros: <span className={spanClassname}>{grupo.pios}</span>
          </p>
          <p className={pClassname}>
            Rovers: <span className={spanClassname}>{grupo.rovers}</span>
          </p>
          <p className={pClassname}>
            Dirigentes: <span className={spanClassname}>{grupo.diris}</span>
          </p>
        </div>
        <div className=" w-full">
          <p className={pClassname}>
            Registrados al Grupo:
            <span className={spanClassname}>{grupo.registroGrupo}</span>
          </p>
          <p className={pClassname}>
            Enviados al Distrito:
            <span className={spanClassname}>{grupo.enviadosDistrito}</span>
          </p>
          <p className={pClassname}>
            Registrados al Distrito:
            <span className={spanClassname}>{grupo.registroDistrito}</span>
          </p>
          <p className={pClassname}>
            Enviados a la Nacional:
            <span className={spanClassname}>{grupo.enviadosNacional}</span>
          </p>
          <p className={pClassname}>
            Enviados a la Nacional:
            <span className={spanClassname}>{grupo.registroNacional}</span>
          </p>
        </div>
        <Button
          className={"w-full md:w-1/2 p-4 h-fit bg-purple-700 text-white justify-center"}
          onClick={onClick}
        >
          {buttonMessage}
        </Button>
      </div>
    </div>
  );
}
