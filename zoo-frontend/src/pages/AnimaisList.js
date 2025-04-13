import { getAnimais, getCuidados } from "../services/api";
import React, { useEffect, useState } from "react";

function AnimaisList() {
  const [animais, setAnimais] = useState([]);
  const [cuidados, setCuidados] = useState({}); // Armazena os cuidados de cada animal
  const [error, setError] = useState(null);

  useEffect(() => {
    const fetchData = async () => {
      try {
        const data = await getAnimais();
        setAnimais(data);
      } catch (err) {
        console.error("Erro ao buscar animais:", err);
        setError("Não foi possível carregar os animais.");
      }
    };
    fetchData();
  }, []);

  const handleVerCuidados = async (id) => {
    try {
      const cuidadosDoAnimal = await getCuidados(id); // Chama a API para obter os cuidados
      setCuidados((prevCuidados) => ({
        ...prevCuidados,
        [id]: cuidadosDoAnimal, // Atualiza os cuidados no estado
      }));
    } catch (err) {
      console.error("Erro ao buscar cuidados:", err);
      alert("Não foi possível carregar os cuidados.");
    }
  };

  if (error) {
    return <div>{error}</div>;
  }

  return (
    <div>
      <h1>Lista de Animais</h1>
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
                <td>{animal.nome}</td>
                <td>{animal.descricao}</td>
                <td>{new Date(animal.dataNascimento).toLocaleDateString()}</td>
                <td>{animal.especie}</td>
                <td>{animal.habitat}</td>
                <td>{animal.paisOrigem}</td>
                <td>
                  <button onClick={() => handleVerCuidados(animal.id)}>
                    Ver Cuidados
                  </button>
                  {cuidados[animal.id] && (
                    <div>
                      <h4>Cuidados:</h4>
                      <ul>
                        {cuidados[animal.id].map((cuidado, index) => (
                          <li key={index}>
                            <strong>{cuidado.nome}</strong>: {cuidado.descricao}{" "}
                            ({cuidado.frequencia})
                          </li>
                        ))}
                      </ul>
                    </div>
                  )}
                </td>
              </tr>
            ))}
          </tbody>
        </table>
      )}
    </div>
  );
}

export default AnimaisList;
