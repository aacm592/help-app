import { useFormContext } from "react-hook-form";

const SelectInput = ({
  label,
  name,
  variant = "dark",
  className,
  options = [],
  placeholder = "Selecciona...",
  ...rest
}) => {
  const {
    register,
    formState: { errors },
  } = useFormContext();

  const error = errors[name];
  const isDark = variant === "dark";

  const baseStyle = `w-full rounded-full p-3 focus:outline-none ring-2`;

  const labelStyle = isDark
    ? "text-white font-medium"
    : "text-gray-700 font-medium";

  const errorStyle = isDark
    ? "text-sm mt-1 text-amber-400"
    : "text-sm mt-1 text-red-600";

  const selectVariantStyle = isDark
    ? "bg-white text-black ring-purple-900 focus:ring-blue-800"
    : "bg-gray-100 text-gray-900 ring-purple-500 focus:ring-blue-800";

  const customSelectStyles = "appearance-none pr-10";

  return (
    <div className="w-full">
      <label htmlFor={name} className={labelStyle}>
        {label}
      </label>

      <div className="relative w-full">
        <select
          id={name}
          {...register(name)}
          {...rest}
          className={`${baseStyle} ${selectVariantStyle} ${customSelectStyles} ${
            className || ""
          }`}
        >
          {placeholder && (
            <option value="" disabled selected>
              {placeholder}
            </option>
          )}
          {options.map((option) => (
            <option key={option.id} value={option.id}>
              {option.nombre}
            </option>
          ))}
        </select>

        <span
          className={`material-symbols-outlined absolute top-1/2 right-3 -translate-y-1/2 
            ${isDark ? "text-black" : "text-gray-700"} 
            pointer-events-none`}
        >
          arrow_drop_down
        </span>
      </div>

      {error && <p className={errorStyle}>{error.message}</p>}
    </div>
  );
};

export default SelectInput;
