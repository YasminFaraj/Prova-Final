import React from "react";
import { BrowserRouter, Link, Route, Routes } from "react-router-dom";
import cadastrarAluno from ".components/CadastrarAluno";

function App() {
  return (
    <div id="app">
      <div>
      <h1>Sistema de Imcs</h1>
    </div>
      <li>
        <Link to={"/pages/aluno/cadastrarAluno"}>
          Cadastrar Aluno{""}
        </Link>
      </li>
    </div>
  );
}

export default App;
