<p align="center">
  <img alt="GitHub language count" src="https://img.shields.io/github/languages/count/GabrielBueno200/StudentClassManager">

  <img alt="GitHub repo size" src="https://img.shields.io/github/repo-size/GabrielBueno200/StudentClassManager">
  
  <a href="https://github.com/GabrielBueno200/monty-hall">
    <img alt="GitHub last commit" src="https://img.shields.io/github/last-commit/GabrielBueno200/StudentClassManager">
  </a>
  
   <img alt="GitHub" src="https://img.shields.io/github/license/GabrielBueno200/StudentClassManager">
</p>

<!-- PROJECT LOGO -->
<p align="center">
  <img alt="C#" src="https://img.shields.io/badge/C%23-239120?style=for-the-badge&logo=c-sharp&logoColor=white"/>
  <img alt=".NET" src="https://img.shields.io/badge/.NET-5C2D91?style=for-the-badge&logo=.net&logoColor=white"/>
  <img alt="Html" src="https://img.shields.io/badge/HTML-239120?style=for-the-badge&logo=html5&logoColor=white"/>
  <img alt="CSS" src="https://img.shields.io/badge/CSS-239120?&style=for-the-badge&logo=css3&logoColor=white"/>
  <img alt="Boostrap" src="https://img.shields.io/badge/Bootstrap-563D7C?style=for-the-badge&logo=bootstrap&logoColor=white"/>
</p>



<!-- TABLE OF CONTENTS -->
<details open="open">
  <summary>Table of Contents</summary>
  <ol>
    <li>
      <a href="#-about-the-project">Sobre o projeto</a>
    </li>
    <li>
      <a href="#-how-to-run">Como rodar</a>
    </li>
  </ol>
</details>


<!-- ABOUT THE PROJECT -->
## 💻 Sobre o projeto
O projeto se propõe a ser um gerenciador de turmas e alunos, podendo realizar tarefas de CRUD de ambos, assim como relacioná-los entre si.

<!-- HOW TO RUN -->
## 🚀 Como rodar
 
### 1 - Criar base de dados 
O script utilizado para a criação da base de dados SQL Server foi baseado no diagrama proposto acima. Para executar o sistema, primeiro será necessário criá-la.
Para isso, foram utilizados os comandos abaixo:

```sql
CREATE DATABASE student_class_manager_db;

CREATE TABLE aluno (
    id INT IDENTITY(1,1) PRIMARY KEY,
    nome VARCHAR(255) NOT NULL,
    usuario VARCHAR(45) NOT NULL,
    senha CHAR(60) NOT NULL
);

CREATE TABLE turma (
    id INT IDENTITY(1,1) PRIMARY KEY,
    curso_id int NULL,
    turma VARCHAR(45) UNIQUE NOT NULL,
    ano int NOT NULL
);

CREATE TABLE aluno_turma (
	aluno_id INT,
	turma_id INT,
    CONSTRAINT aluno_id FOREIGN KEY (aluno_id) REFERENCES aluno(id) ON DELETE CASCADE,
    CONSTRAINT turma_id FOREIGN KEY (turma_id) REFERENCES turma(id) ON DELETE CASCADE
);
```
 
### 2 - Compilar e executar o projeto

- 2.1. Visual Studio:
  - Caso prefira executar pelo Visual Studio, primeiro será necessário abrir a solution "StudentClassManager.sln"
  - Após isso, basta executar a WebAPI, contida no projeto "StudentClassManager.API" e, em sequência, o frontend, contido no projeto StudentClassManager.WebUI 
  - Por fim, basta abrir o frontend no seu navegador, acessando a url "http://localhost:5232"

- 2.2. Linha de comando
  - Da mesma forma, será necessário executar ambos os projetos. Ao final, assim como dito antes, basta abrir o frontend no navegador. 
  ```bash
  cd src/StudentClassManager.WebUI
  dotnet run build
  ```
  ```bash
  cd src/StudentClassManager.API
  dotnet run build
  ```
