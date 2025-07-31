USE dbGestaoClinica;
GO

BEGIN TRY
    BEGIN TRANSACTION;

    -- Apagar dados existentes
    DELETE FROM Cliente;
    DELETE FROM Funcionario;

    -- =================== ALTERAÇÕES NA TABELA Cliente ===================
    ALTER TABLE Cliente
    ADD 
        Nome VARCHAR(100) NOT NULL DEFAULT 'Desconhecido',
        Telefone VARCHAR(20),
        Email VARCHAR(100),
        CPF VARCHAR(11) UNIQUE,
        DataNascimento DATE,
        EnderecoId INT;

    ALTER TABLE Cliente
    ADD CONSTRAINT FK_Cliente_Endereco 
    FOREIGN KEY (EnderecoId) REFERENCES Endereco(IdEndereco);

    -- =================== ALTERAÇÕES NA TABELA Funcionario ===================
    ALTER TABLE Funcionario
    ADD 
        Nome VARCHAR(100) NOT NULL DEFAULT 'Desconhecido',
        Telefone VARCHAR(20),
        Email VARCHAR(100),
        CPF VARCHAR(11) UNIQUE,
        DataNascimento DATE,
        EnderecoId INT;

    ALTER TABLE Funcionario
    ADD CONSTRAINT FK_Funcionario_Endereco 
    FOREIGN KEY (EnderecoId) REFERENCES Endereco(IdEndereco);

    -- Remover constraints antigas (referências à tabela Pessoa)
    ALTER TABLE Cliente DROP CONSTRAINT FK__Cliente__PessoaI__47DBAE45;
    ALTER TABLE Funcionario DROP CONSTRAINT FK__Funcionar__Pesso__48CFD27E;

    -- Remover coluna PessoaId das tabelas
    ALTER TABLE Cliente DROP COLUMN PessoaId;
    ALTER TABLE Funcionario DROP COLUMN PessoaId;

    -- Remover a tabela Pessoa (após migração)
    DROP TABLE Pessoa;

    -- Se tudo correr bem, confirma as alterações
    COMMIT TRANSACTION;
    PRINT 'Transação concluída com sucesso. Tabela Pessoa removida e estrutura atualizada.';
END TRY
BEGIN CATCH
    -- Em caso de erro, desfaz todas as alterações
    IF @@TRANCOUNT > 0
        ROLLBACK TRANSACTION;

    -- Exibe mensagem de erro
    DECLARE @ErrorMessage NVARCHAR(4000) = ERROR_MESSAGE();
    DECLARE @ErrorSeverity INT = ERROR_SEVERITY();
    DECLARE @ErrorState INT = ERROR_STATE();

    RAISERROR('Erro na transação: %s', @ErrorSeverity, @ErrorState, @ErrorMessage);
END CATCH;
