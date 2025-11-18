/**
 * Formatea una cadena de fecha a un formato legible en español.
 * @param {string} fechaString - La cadena de fecha (ej. "2025-11-17T15:00:00Z").
 * @param {'long' | 'short'} format - El formato deseado.
 * 'long': 17 de noviembre de 2025
 * 'short': 17/11/2025
 * @returns {string} La fecha formateada o un fallback.
 */
export const formatFecha = (fechaString, format = "long") => {
  if (!fechaString) return "No especificada";

  try {
    const date = new Date(fechaString);
    if (isNaN(date.getTime())) {
      throw new Error("Fecha inválida");
    }

    let options = {
      year: "numeric",
      month: "long",
      day: "numeric",
      timeZone: "UTC",
    };

    if (format === "short") {
      options = {
        day: "2-digit",
        month: "2-digit",
        year: "numeric",
        timeZone: "UTC",
      };
    }

    return date.toLocaleDateString("es-ES", options);
  } catch (error) {
    console.error("Error formateando fecha:", error);
    return fechaString.split("T")[0];
  }
};
