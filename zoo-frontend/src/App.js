import React from "react";
import { BrowserRouter as Router, Routes, Route, Link } from "react-router-dom";
import AnimaisList from "./pages/AnimaisList";
import AnimalForm from "./pages/AnimalForm";
import AnimalEdit from "./pages/AnimalEdit";

function App() {
  return (
    <Router>
      <nav>
        <ul>
          <li>
            <Link to="/animais">Lista de Animais</Link>
          </li>
          <li>
            <Link to="/animais/novo">Cadastrar Animal</Link>
          </li>
          <li>
            <Link to="/animais/editar">Editar Animais</Link> {/* Novo link */}
          </li>
        </ul>
      </nav>
      <Routes>
        <Route path="/animais" element={<AnimaisList />} />
        <Route path="/animais/novo" element={<AnimalForm />} />
        <Route path="/animais/editar" element={<AnimalEdit />} />{" "}
        {/* Nova rota */}
      </Routes>
    </Router>
  );
}

export default App;
