import { useEffect, useState } from "react";
import { useNavigate } from "react-router-dom";
import { Aluno } from "../models/aluno";
import { Imc } from "../models/imc";

function CadastrarAluno(){
    const navigate = useNavigate();
    const [nome, setNome] = useState("");
    const [sobrenome, setSobrenome] = useState("");
    const [peso, setPeso] = useState("");
    const [altura, setAltura] = useState("");
    useEffect(() => ){
        carregarImcs();
    },[]);

    function carregarImcs(){
        fetch("http://localhost:5134/api/aluno/cadastrar")
        .then((resposta) => resposta.json())
        .then((imcs: Imc[]) => {
        setImcs(imcs);
        });
    }
    function cadastrarAluno(e: any){
        const aluno: Aluno = {
            nome: Nome,
            peso: Peso,
            altura: Altura,
        };
        fetch("http://localhost:5134/api/aluno/cadastrar",{
        method: "POST",
        headers:{
            "Content-Type":"application/json",
        },
        body:JSON.stringify(aluno),
        })
        .then((resposta) => resposta.json())
        .then((aluno: Aluno) => {
            navigate("pages/aluno/listar");
        });
        e.preventDefault();
    }
    return(
        <div>
            <h1>Cadastrar aluno</h1>
            <form onSubmit={CadastrarAluno}>
                <label>Nome:</label>
                <input
                type="text"
                placeholder="Digite o nome"
                onChange={(e:any) => setNome(e.target.value)}
                required
                />
                <br />
                <label>Altura</label>
                <input
                type="number"
                placeholder="Digite a altura"
                onChange={(e:any) => setAltura(e.target.value)}
                required
                />
                <br />
                <label>Peso</label>
                <input
                type="number"
                placeholder="Digite o peso"
                onChange={(e:any) => setPeso(e.target.value)}
                required
                />
            </form>
        </div>
    )
}