import axios from "axios";

const API_URL = "http://localhost:5050/api";

export const getAnimais = async () => {
  const response = await axios.get(`${API_URL}/animais`);
  return response.data;
};

export const createAnimal = async (animal) => {
  const response = await axios.post(`${API_URL}/animais`, animal);
  return response.data;
};

export const deleteAnimal = async (id) => {
  const response = await axios.delete(`${API_URL}/animais/${id}`);
  return response.data;
};

export const getCuidados = async (id) => {
  const response = await axios.get(`${API_URL}/animais/${id}/cuidados`);
  return response.data;
};

export const updateAnimal = async (id, animal) => {
  const response = await axios.put(`${API_URL}/animais/${id}`, animal);
  return response.data;
};

// Adicione a função associarCuidado
export const associarCuidado = async (animalId, cuidado) => {
  const response = await axios.post(
    `${API_URL}/animais/${animalId}/cuidados`,
    cuidado
  );
  return response.data;
};
