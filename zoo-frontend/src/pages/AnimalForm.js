import React, { useState } from "react";
import { createAnimal } from "../services/api";

function AnimalForm() {
  const [animal, setAnimal] = useState({
    nome: "",
    descricao: "",
    dataNascimento: "",
    especie: "",
    habitat: "",
    paisOrigem: "",
  });

  const handleChange = (e) => {
    const { name, value } = e.target;
    setAnimal({ ...animal, [name]: value });
  };

  const handleSubmit = async (e) => {
    e.preventDefault();
    await createAnimal(animal);
    alert("Animal cadastrado com sucesso!");
  };

  return (
    <form onSubmit={handleSubmit}>
      <h1>Cadastrar Animal</h1>
      <input name="nome" placeholder="Nome" onChange={handleChange} />
      <input name="descricao" placeholder="Descrição" onChange={handleChange} />
      <input name="dataNascimento" type="date" onChange={handleChange} />
      <input name="especie" placeholder="Espécie" onChange={handleChange} />
      <input name="habitat" placeholder="Habitat" onChange={handleChange} />
      <input
        name="paisOrigem"
        placeholder="País de Origem"
        onChange={handleChange}
      />
      <button type="submit">Salvar</button>
    </form>
  );
}

export default AnimalForm;
