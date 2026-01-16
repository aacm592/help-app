import { formatFecha } from "../../../utils/dateFormatter";
import ProfileInfoItem from "../ProfileInfoItem";

export default function ProfileBox({ user }) {
  return (
    <div className="space-y-6">
      <ProfileInfoItem icon="person" label="Nombre(s)" data={user.nombre} />
      <ProfileInfoItem icon="person" label="Apellido(s)" data={user.apellido} />
      <ProfileInfoItem
        icon="id_card"
        label="Carnet Identidad (CI)"
        data={user.ci}
      />
      <ProfileInfoItem
        icon="id_card"
        label="Complemento CI"
        data={user.complementoCi}
      />
      <ProfileInfoItem
        icon="cake"
        label="Fecha de Nacimiento"
        data={formatFecha(user.fechaNacimiento)}
      />
      <ProfileInfoItem icon="badge" label="Rol" data={user.rol} />{" "}
      <ProfileInfoItem icon="mobile" label="Celular" data={user.telf} />
      <ProfileInfoItem icon="wc" label="Género" data={user.genero} />
      {user.rol === "Scout" && (
        <>
          <ProfileInfoItem
            icon="arrow_warm_up"
            label="Etapa"
            data={user.etapa}
          />
          <ProfileInfoItem
            icon="school"
            label="Unidad Educativa"
            data={user.unidadEducativa}
          />
          <ProfileInfoItem icon="school" label="Nivel" data={user.curso} />
        </>
      )}
      {user.rol === "Dirigente" && (
        <>
          <ProfileInfoItem
            icon="sensor_occupied"
            label="Cargo 1"
            data={user.cargo1}
          />
          <ProfileInfoItem
            icon="sensor_occupied"
            label="Cargo 2"
            data={user.cargo2}
          />
          <ProfileInfoItem
            icon="school"
            label="Profesión"
            data={user.profesion}
          />
          <ProfileInfoItem
            icon="work"
            label="Ocupación"
            data={user.ocupacion}
          />
        </>
      )}
    </div>
  );
}
