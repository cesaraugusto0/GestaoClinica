USE dbGestaoClinica;
GO

BEGIN TRY
    BEGIN TRANSACTION;

    -- Apagar dados existentes
    DELETE FROM Cliente;
    DELETE FROM Funcionario;
   	DELETE FROM Agendamento;


    -- Remover constraints FK Cliente
    DECLARE @ConstraintNameFK_Cliente NVARCHAR(128);
    SELECT @ConstraintNameFK_Cliente = name
    FROM sys.foreign_keys
    WHERE parent_object_id = OBJECT_ID('Agendamento')
      AND referenced_object_id = OBJECT_ID('Cliente');

    IF @ConstraintNameFK_Cliente IS NOT NULL
    BEGIN
        EXEC('ALTER TABLE Agendamento DROP CONSTRAINT ' + @ConstraintNameFK_Cliente);
    END
    
    -- Remover constraints FK Funcionario
    DECLARE @ConstraintNameFK_Funcionario NVARCHAR(128);
    SELECT @ConstraintNameFK_Funcionario = name
    FROM sys.foreign_keys
    WHERE parent_object_id = OBJECT_ID('Agendamento')
      AND referenced_object_id = OBJECT_ID('Funcionario');

    IF @ConstraintNameFK_Funcionario IS NOT NULL
    BEGIN
        EXEC('ALTER TABLE Agendamento DROP CONSTRAINT ' + @ConstraintNameFK_Funcionario);
    END
    
    -- Remover constraints PK Cliente
    DECLARE @ConstraintNamePK_Cliente NVARCHAR(128);
    SELECT @ConstraintNamePK_Cliente = name
    FROM sys.key_constraints
    WHERE parent_object_id = OBJECT_ID('Cliente')
      AND type = 'PK';

    IF @ConstraintNamePK_Cliente IS NOT NULL
    BEGIN
        EXEC('ALTER TABLE Cliente DROP CONSTRAINT ' + @ConstraintNamePK_Cliente);
    END
    
    -- Remover constraints PK Funcionario
    DECLARE @ConstraintNamePK_Funcionario NVARCHAR(128);
    SELECT @ConstraintNamePK_Funcionario = name
    FROM sys.key_constraints
    WHERE parent_object_id = OBJECT_ID('Funcionario')
      AND type = 'PK';

    IF @ConstraintNamePK_Funcionario IS NOT NULL
    BEGIN
        EXEC('ALTER TABLE Funcionario DROP CONSTRAINT ' + @ConstraintNamePK_Funcionario);
    END
    
    -- Remover constraints UQ Cliente
    DECLARE @ConstraintNameUQ_Cliente NVARCHAR(128);
    SELECT @ConstraintNameUQ_Cliente = name
    FROM sys.key_constraints
    WHERE parent_object_id = OBJECT_ID('Cliente')
      AND type = 'UQ';

    IF @ConstraintNameUQ_Cliente IS NOT NULL
    BEGIN
        EXEC('ALTER TABLE Cliente DROP CONSTRAINT ' + @ConstraintNameUQ_Cliente);
    END
    
    -- Remover constraints UQ Funcionario
    DECLARE @ConstraintNameUQ_Funcionario NVARCHAR(128);
    SELECT @ConstraintNameUQ_Funcionario = name
    FROM sys.key_constraints
    WHERE parent_object_id = OBJECT_ID('Funcionario')
      AND type = 'UQ';

    IF @ConstraintNameUQ_Funcionario IS NOT NULL
    BEGIN
        EXEC('ALTER TABLE Funcionario DROP CONSTRAINT ' + @ConstraintNameUQ_Funcionario);
    END

    DROP TABLE Cliente ;
    DROP TABLE Funcionario;
   
   	-- Cria a nova tabela
	CREATE TABLE Cliente (
	    IdCliente INT IDENTITY(1,1) PRIMARY KEY NOT NULL,
	    Nome NVARCHAR(100) NOT NULL,
	    CPF NVARCHAR(11) NOT NULL,
	    DataNascimento DATE NULL,
	    Email NVARCHAR(100) NULL,
	    Telefone NVARCHAR(20) NULL,
	    EnderecoId INT NULL,
	    Ativo BIT NOT NULL DEFAULT 1,
	    Observacoes NVARCHAR(MAX) NULL,
	    DataCriacao DATETIME NOT NULL DEFAULT GETDATE(),
	    UltimaAtualizacao DATETIME NULL,
	    
	    -- Constraints adicionais
	    CONSTRAINT UQ_Cliente_CPF UNIQUE (CPF),
	    CONSTRAINT CK_Cliente_Email CHECK (Email LIKE '%@%.%' OR Email IS NULL),
	    CONSTRAINT FK_Cliente_Endereco FOREIGN KEY (EnderecoId) REFERENCES Endereco(IdEndereco)
	);

	-- Cria a nova tabela
	CREATE TABLE Funcionario (
	    IdFuncionario INT IDENTITY(1,1) PRIMARY KEY NOT NULL,
	    Nome NVARCHAR(100) NOT NULL,
	    CPF NVARCHAR(11) NOT NULL,
	    DataNascimento DATE NULL,
	    Email NVARCHAR(100) NOT NULL,
	    Telefone NVARCHAR(20) NOT NULL,
	    SenhaHash NVARCHAR(255) NOT NULL,
	    Perfil NVARCHAR(50) NOT NULL,
	    EnderecoId INT NULL,
	    Ativo BIT NOT NULL DEFAULT 1,
	    DataCriacao DATETIME NOT NULL DEFAULT GETDATE(),
	    UltimaAtualizacao DATETIME NULL,
	    
	    -- Constraints adicionais
	    CONSTRAINT UQ_Funcionario_CPF UNIQUE (CPF),
	    CONSTRAINT UQ_Funcionario_Email UNIQUE (Email),
	    CONSTRAINT CK_Funcionario_Email CHECK (Email LIKE '%@%.%'),
	    CONSTRAINT FK_Funcionario_Endereco FOREIGN KEY (EnderecoId) REFERENCES Endereco(IdEndereco)
	);

	ALTER TABLE Agendamento
    ADD CONSTRAINT FK_Agendamento_Cliente 
    FOREIGN KEY (ClienteId) REFERENCES Cliente(IdCliente);
   
   	ALTER TABLE Agendamento
    ADD CONSTRAINT FK_Agendamento_Funcionario 
    FOREIGN KEY (FuncionarioId) REFERENCES Funcionario(IdFuncionario);


    -- Confirma as alterações
    COMMIT TRANSACTION;
    PRINT 'Transação concluída com sucesso.';
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