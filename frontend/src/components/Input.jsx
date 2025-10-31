import { useFormContext } from "react-hook-form";

const Input = ({ label, name, variant = "dark", className, ...rest }) => {
  const {
    register,
    formState: { errors },
  } = useFormContext();

  const error = errors[name];
  const isDark = variant === "dark";

  const baseInputStyle = `w-full rounded-full p-3 focus:outline-none ring-2`;

  const labelStyle = isDark
    ? "text-white font-medium"
    : "text-gray-700 font-medium";

  const errorStyle = isDark
    ? "text-sm mt-1 text-amber-400"
    : "text-sm mt-1 text-red-600";

  const inputVariantStyle = isDark
    ? "bg-white text-black placeholder-gray-500 ring-purple-900 focus:ring-blue-800"
    : "bg-gray-100 text-gray-900 placeholder-gray-500 ring-purple-500 focus:ring-blue-800";

  return (
    <div className="w-full">
      <label htmlFor={name} className={labelStyle}>
        {label}
      </label>

      <input
        id={name}
        {...register(name)}
        {...rest}
        className={`${baseInputStyle} ${inputVariantStyle} ${className || ""}`}
      />

      {error && <p className={errorStyle}>{error.message}</p>}
    </div>
  );
};

export default Input;
