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

    -- Remover constraints antigas (referências à coluna PessoaId) de forma dinâmica
    DECLARE @ConstraintName_Cliente NVARCHAR(128);
    SELECT @ConstraintName_Cliente = name
    FROM sys.foreign_keys
    WHERE parent_object_id = OBJECT_ID('Cliente')
      AND referenced_object_id = OBJECT_ID('Pessoa');

    IF @ConstraintName_Cliente IS NOT NULL
    BEGIN
        EXEC('ALTER TABLE Cliente DROP CONSTRAINT ' + @ConstraintName_Cliente);
    END

    DECLARE @ConstraintName_Funcionario NVARCHAR(128);
    SELECT @ConstraintName_Funcionario = name
    FROM sys.foreign_keys
    WHERE parent_object_id = OBJECT_ID('Funcionario')
      AND referenced_object_id = OBJECT_ID('Pessoa');

    IF @ConstraintName_Funcionario IS NOT NULL
    BEGIN
        EXEC('ALTER TABLE Funcionario DROP CONSTRAINT ' + @ConstraintName_Funcionario);
    END

    -- Remover coluna PessoaId das tabelas
    IF COL_LENGTH('Cliente', 'PessoaId') IS NOT NULL
        ALTER TABLE Cliente DROP COLUMN PessoaId;

    IF COL_LENGTH('Funcionario', 'PessoaId') IS NOT NULL
        ALTER TABLE Funcionario DROP COLUMN PessoaId;

    -- Remover a tabela Pessoa (após migração)
    IF OBJECT_ID('Pessoa', 'U') IS NOT NULL
        DROP TABLE Pessoa;

    -- Confirma as alterações
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