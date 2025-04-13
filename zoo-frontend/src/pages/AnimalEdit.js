import React, { useState, useEffect } from "react";
import { useNavigate } from "react-router-dom";
import {
  getAnimais,
  updateAnimal,
  deleteAnimal,
  associarCuidado,
} from "../services/api";

function AnimalEdit() {
  const navigate = useNavigate(); // Para redirecionar após salvar
  const [animais, setAnimais] = useState([]);
  const [error, setError] = useState(null);
  const [novoCuidado, setNovoCuidado] = useState({}); // Armazena os cuidados para cada animal

  // Opções para Nome do Cuidado e Frequência
  const opcoesNomeCuidado = [
    "Alimentação",
    "Exame Veterinário",
    "Vacinação",
    "Treinamento",
  ];
  const opcoesFrequencia = ["Diária", "Semanal", "Mensal"];

  // Carrega todos os animais ao montar o componente
  useEffect(() => {
    const fetchAnimais = async () => {
      try {
        const data = await getAnimais(); // Obtém todos os animais
        setAnimais(data);
      } catch (err) {
        console.error("Erro ao carregar animais:", err);
        setError("Erro ao carregar os dados dos animais.");
      }
    };
    fetchAnimais();
  }, []);

  const handleChange = (id, e) => {
    const { name, value } = e.target;
    setAnimais((prevAnimais) =>
      prevAnimais.map((animal) =>
        animal.id === id ? { ...animal, [name]: value } : animal
      )
    );
  };

  const handleSave = async () => {
    try {
      for (const animal of animais) {
        await updateAnimal(animal.id, animal); // Atualiza cada animal no backend
      }
      alert("Alterações salvas com sucesso!");
      navigate("/animais"); // Redireciona para a lista de animais
    } catch (err) {
      console.error("Erro ao salvar alterações:", err);
      alert("Não foi possível salvar as alterações.");
    }
  };

  const handleDelete = async (id) => {
    if (window.confirm("Tem certeza que deseja excluir este animal?")) {
      try {
        await deleteAnimal(id); // Remove o animal do backend
        setAnimais(animais.filter((animal) => animal.id !== id)); // Atualiza a lista local
        alert("Animal excluído com sucesso!");
      } catch (err) {
        console.error("Erro ao excluir animal:", err);
        alert("Não foi possível excluir o animal.");
      }
    }
  };

  const handleCuidadoChange = (id, e) => {
    const { name, value } = e.target;
    setNovoCuidado((prevCuidados) => ({
      ...prevCuidados,
      [id]: { ...prevCuidados[id], [name]: value },
    }));
  };

  const handleAddCuidado = async (id) => {
    const cuidado = novoCuidado[id];
    if (
      !cuidado ||
      !cuidado.nome ||
      !cuidado.descricao ||
      !cuidado.frequencia
    ) {
      alert("Preencha todos os campos do cuidado antes de adicionar.");
      return;
    }

    try {
      // Envia o cuidado ao backend
      await associarCuidado(id, cuidado);
      alert(
        `Cuidado "${cuidado.nome}" com frequência "${cuidado.frequencia}" adicionado ao animal com ID: ${id}.`
      );

      // Limpa os campos de cuidado para o animal
      setNovoCuidado((prevCuidados) => ({
        ...prevCuidados,
        [id]: { nome: "", descricao: "", frequencia: "" },
      }));
    } catch (err) {
      console.error("Erro ao adicionar cuidado:", err);
      alert("Não foi possível adicionar o cuidado.");
    }
  };

  if (error) {
    return <div>{error}</div>;
  }

  return (
    <div>
      <h1>Editar Animais</h1>
      {animais.length === 0 ? (
        <p>Nenhum animal encontrado.</p>
      ) : (
        <table border="1" style={{ borderCollapse: "collapse", width: "100%" }}>
          <thead>
            <tr>
              <th>Nome</th>
              <th>Descrição</th>
              <th>Data de Nascimento</th>
              <th>Espécie</th>
              <th>Habitat</th>
              <th>País de Origem</th>
              <th>Ações</th>
            </tr>
          </thead>
          <tbody>
            {animais.map((animal) => (
              <tr key={animal.id}>
                <td>
                  <input
                    name="nome"
                    value={animal.nome}
                    onChange={(e) => handleChange(animal.id, e)}
                  />
                </td>
                <td>
                  <input
                    name="descricao"
                    value={animal.descricao}
                    onChange={(e) => handleChange(animal.id, e)}
                  />
                </td>
                <td>
                  <input
                    name="dataNascimento"
                    type="date"
                    value={animal.dataNascimento.split("T")[0]} // Formata a data
                    onChange={(e) => handleChange(animal.id, e)}
                  />
                </td>
                <td>
                  <input
                    name="especie"
                    value={animal.especie}
                    onChange={(e) => handleChange(animal.id, e)}
                  />
                </td>
                <td>
                  <input
                    name="habitat"
                    value={animal.habitat}
                    onChange={(e) => handleChange(animal.id, e)}
                  />
                </td>
                <td>
                  <input
                    name="paisOrigem"
                    value={animal.paisOrigem}
                    onChange={(e) => handleChange(animal.id, e)}
                  />
                </td>
                <td>
                  <button onClick={() => handleSave()}>Salvar</button>
                  <button onClick={() => handleDelete(animal.id)}>
                    Excluir
                  </button>
                  <div>
                    <h4>Adicionar Cuidados</h4>
                    <select
                      name="nome"
                      value={novoCuidado[animal.id]?.nome || ""}
                      onChange={(e) => handleCuidadoChange(animal.id, e)}
                    >
                      <option value="">Selecione o Nome do Cuidado</option>
                      {opcoesNomeCuidado.map((opcao) => (
                        <option key={opcao} value={opcao}>
                          {opcao}
                        </option>
                      ))}
                    </select>
                    <textarea
                      name="descricao"
                      placeholder="Descrição"
                      value={novoCuidado[animal.id]?.descricao || ""}
                      onChange={(e) => handleCuidadoChange(animal.id, e)}
                    />
                    <select
                      name="frequencia"
                      value={novoCuidado[animal.id]?.frequencia || ""}
                      onChange={(e) => handleCuidadoChange(animal.id, e)}
                    >
                      <option value="">Selecione a Frequência</option>
                      {opcoesFrequencia.map((opcao) => (
                        <option key={opcao} value={opcao}>
                          {opcao}
                        </option>
                      ))}
                    </select>
                    <button onClick={() => handleAddCuidado(animal.id)}>
                      Adicionar
                    </button>
                  </div>
                </td>
              </tr>
            ))}
          </tbody>
        </table>
      )}
    </div>
  );
}

export default AnimalEdit;
