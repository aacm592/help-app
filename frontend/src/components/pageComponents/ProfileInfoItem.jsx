export default function ProfileInfoItem({ icon, label, data }) {
  return (
    <div className="flex items-center gap-4 w-full">
      <span className="material-symbols-outlined text-purple-600 text-4xl!">
        {icon}
      </span>
      <div className="flex flex-col">
        <span className="text-md font-semibold text-gray-500">{label}</span>
        <p className="text-xl text-gray-800 font-medium">{data}</p>
      </div>
    </div>
  );
}
