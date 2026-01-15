import { useForm, FormProvider } from "react-hook-form";
import Input from "../../Input";
import Button from "../../Button";

export default function EditProfileForm({ user, onCancel, onSuccess }) {
  const methods = useForm({
    defaultValues: {
      nombre: user.nombre || "",
      apellido: user.apellido || "",
      telf: user.telf || "",
      ci: user.ci || "",
      complementoCi: user.complementoCi || "",
      genero: user.genero || "",
      email: user.email || "",
      unidadEducativa: user.unidadEducativa || "",
      curso: user.curso || "",
      ocupacion: user.ocupacion || "",
      profesion: user.profesion || "",
      etapa: user.etapa || "",
      cargo1: user.cargo1 || "",
      cargo2: user.cargo2 || "",
    },
  });

  const onSubmit = async (data) => {
    try {
      onSuccess(data);
    } catch (error) {
      console.error("Error al actualizar", error);
    }
  };

  return (
    <FormProvider {...methods}>
      <form onSubmit={methods.handleSubmit(onSubmit)} className="space-y-4">
        <Input label="Nombre(s)" name="nombre" variant="light" />
        <Input label="Apellido(s)" name="apellido" variant="light" />
        <Input label="Celular" name="telf" variant="light" />
        <Input label="Carnet de identidad (CI)" name="ci" variant="light" />
        <Input label="Complemento CI" name="complementoCi" variant="light" />
        <Input label="Género" name="genero" variant="light" />
        <Input label="E-mail" name="email" variant="light" />

        {user.unidadEducativa && (
          <>
            <Input
              label="Unidad Educativa"
              name="unidadEducativa"
              variant="light"
            />
            <Input label="Nivel" name="curso" variant="light" />
            <Input label="Etapa" name="etapa" variant="light" />
          </>
        )}

        {user.profesion && (
          <>
            <Input label="Ocupación" name="ocupacion" variant="light" />
            <Input label="Profesión" name="profesion" variant="light" />
            <Input label="Cargo 1" name="cargo1" variant="light" />
            <Input label="Cargo 2" name="cargo2" variant="light" />
          </>
        )}

        <div className="flex gap-2 pt-4">
          <Button
            type="submit"
            className="bg-emerald-500 text-white w-full p-4"
          >
            Guardar Cambios
          </Button>
          <Button
            type="button"
            onClick={onCancel}
            className="bg-gray-200 text-gray-700 w-full p-4"
          >
            Cancelar
          </Button>
        </div>
      </form>
    </FormProvider>
  );
}
