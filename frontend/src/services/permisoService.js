import api from "./api";

export async function addGroupAdmin(userName) {
  if (!userName) {
    throw new Error("El userName del Scout es requerido.");
  }
  try {
    const response = await api.post(`/Permiso/admin/grupo`, userName);
    return response.data;
  } catch (error) {
    if (error.response && error.response.data) {
      throw new Error(error.response.data);
    } else {
      console.error("Error al registrar miembro:", error.message);
      throw new Error("No se pudo conectar con el servidor.");
    }
  }
}

export async function deleteGroupAdmin(userId) {
  if (!userId) {
    throw new Error("El userId es requerido.");
  }
  try {
    const response = await api.delete(`/Permiso/admin/grupo/${userId}`);
    return response.data;
  } catch (error) {
    if (error.response && error.response.data) {
      throw new Error(error.response.data);
    } else {
      console.error("Error al registrar miembro:", error.message);
      throw new Error("No se pudo conectar con el servidor.");
    }
  }
}

export async function addDistritoAdmin(userName) {
  if (!userName) {
    throw new Error("El userName del Scout es requerido.");
  }
  try {
    const response = await api.post(`/Permiso/admin/distrito`, userName);
    return response.data;
  } catch (error) {
    if (error.response && error.response.data) {
      throw new Error(error.response.data);
    } else {
      console.error("Error al registrar miembro:", error.message);
      throw new Error("No se pudo conectar con el servidor.");
    }
  }
}

export async function deleteDistritoAdmin(userId) {
  if (!userId) {
    throw new Error("El userId es requerido.");
  }
  try {
    const response = await api.delete(`/Permiso/admin/distrito/${userId}`);
    return response.data;
  } catch (error) {
    if (error.response && error.response.data) {
      throw new Error(error.response.data);
    } else {
      console.error("Error al registrar miembro:", error.message);
      throw new Error("No se pudo conectar con el servidor.");
    }
  }
}

export async function addRespGrupo(userName, grupoId) {
  if (!userName) {
    throw new Error("El userName del Scout es requerido.");
  }
  try {
    const response = await api.post(`/Permiso/responsable/grupo`, {
      id: grupoId,
      nombre: userName,
    });
    return response.data;
  } catch (error) {
    if (error.response && error.response.data) {
      throw new Error(error.response.data);
    } else {
      console.error("Error al registrar miembro:", error.message);
      throw new Error("No se pudo conectar con el servidor.");
    }
  }
}

export async function deleteRespGrupo(userId) {
  if (!userId) {
    throw new Error("El userId es requerido.");
  }
  try {
    const response = await api.delete(`/Permiso/responsable/grupo/${userId}`);
    return response.data;
  } catch (error) {
    if (error.response && error.response.data) {
      throw new Error(error.response.data);
    } else {
      console.error("Error al registrar miembro:", error.message);
      throw new Error("No se pudo conectar con el servidor.");
    }
  }
}
