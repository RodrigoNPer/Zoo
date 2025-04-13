# ZooAPI

Projeto de gerenciamento de animais e cuidados, desenvolvido com **.NET** no backend e **React** no frontend.

---

## **Como Rodar o Projeto**

### **Pré-requisitos**

Certifique-se de ter as seguintes ferramentas instaladas no seu ambiente:

1. **Backend**:
   - [.NET SDK](https://dotnet.microsoft.com/download) (versão 6.0 ou superior).
   - Banco de dados SQL Server configurado.
2. **Frontend**:
   - [Node.js](https://nodejs.org/) (versão 16 ou superior).
   - Um gerenciador de pacotes como `npm` (instalado junto com o Node.js).

---

### **Passos para Rodar o Backend**

1. **Clone o Repositório**:

   ```bash
   git clone https://github.com/RodrigoNPer/Zoo.git
   cd ZooAPI

   ```

2.Configure o Banco de Dados.
No arquivo appsettings.json, configure a string de conexão para o seu banco de dados SQL Server:
"ConnectionStrings": {
"DefaultConnection": "Server=SEU_SERVIDOR;Database=ZooDB;Trusted_Connection=True;MultipleActiveResultSets=true"
}

3.Aplique as Migrations.
Execute o comando para criar as tabelas no banco de dados: dotnet ef database update

4.Inicie o Servidor.
Execute o comando para iniciar o backend: dotnet run
O backend estará disponível em http://localhost:5050.

### **Passos para Rodar o Frontend**

Passos para Rodar o Frontend
Navegue até a Pasta do zoo-frontend: cd zoo-frontend

Instale as Dependências
Execute o comando para instalar as dependências do projeto: npm install

Inicie o Servidor de Desenvolvimento
Execute o comando para iniciar o frontend:npm start

O frontend estará disponível em http://localhost:3000.
Funcionalidades Implementadas
Listagem de Animais:
Exibe uma tabela com informações detalhadas de todos os animais cadastrados.
Cadastro de Animais:
Permite adicionar novos animais ao sistema.
Edição de Animais:
Permite editar as informações de animais existentes.
Exclusão de Animais:
Permite excluir animais do sistema.
Adição de Cuidados:
Permite adicionar cuidados específicos para cada animal.
Associação de Cuidados a Animais:
Permite associar cuidados já cadastrados a animais específicos.
