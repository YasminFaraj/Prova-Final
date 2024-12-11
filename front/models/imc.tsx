import { Aluno } from "./aluno";
export interface Imc{
    aluno: Aluno;
    imcId : string;
    criadoEm: string;
    categoria: string;
    peso : float;
    altura : float;
}