-- Primeiro, adicionar as colunas da tabela Pessoa na tabela Cliente
ALTER TABLE Cliente
ADD 
    Nome VARCHAR(100) NOT NULL,
    Telefone VARCHAR(20),
    Email VARCHAR(100),
    CPF VARCHAR(11) UNIQUE,
    DataNascimento DATE,
    EnderecoId INT;

-- Adicionar constraint de chave estrangeira para Endereço
ALTER TABLE Cliente
ADD CONSTRAINT FK_Cliente_Endereco FOREIGN KEY (EnderecoId) REFERENCES Endereco(IdEndereco);

-- Adicionar as colunas da tabela Pessoa na tabela Funcionario
ALTER TABLE Funcionario
ADD 
    Nome VARCHAR(100) NOT NULL,
    Telefone VARCHAR(20),
    Email VARCHAR(100),
    CPF VARCHAR(11) UNIQUE,
    DataNascimento DATE,
    EnderecoId INT;

-- Adicionar constraint de chave estrangeira para Endereço
ALTER TABLE Funcionario
ADD CONSTRAINT FK_Funcionario_Endereco FOREIGN KEY (EnderecoId) REFERENCES Endereco(IdEndereco);

-- Exclui contraints
ALTER TABLE Cliente DROP CONSTRAINT FK__Cliente__PessoaI__47DBAE45;
ALTER TABLE Funcionario DROP CONSTRAINT FK__Funcionar__Pesso__48CFD27E;
   
-- Finalmente, remover a tabela Pessoa (após garantir que todos os dados foram migrados)
DROP TABLE Pessoa;

-- Remove coluna idPessoa DE CLIENTE e FUNCIONÁRIO
ALTER TABLE Cliente DROP COLUMN PessoaId;
ALTER TABLE Funcionario DROP COLUMN PessoaId;
