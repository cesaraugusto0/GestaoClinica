USE dbGestaoClinica;
GO

BEGIN TRY
    BEGIN TRANSACTION;

    -- Apagar dados existentes
   	DELETE FROM Agendamento;
	DELETE FROM StatusAgenda;


    -- Remover constraints FK StatusAgenda
    DECLARE @ConstraintNameFK_StatusAgenda NVARCHAR(128);
    SELECT @ConstraintNameFK_StatusAgenda = name
    FROM sys.foreign_keys
    WHERE parent_object_id = OBJECT_ID('Agendamento')
      AND referenced_object_id = OBJECT_ID('StatusAgenda');

    IF @ConstraintNameFK_StatusAgenda IS NOT NULL
    BEGIN
        EXEC('ALTER TABLE Agendamento DROP CONSTRAINT ' + @ConstraintNameFK_StatusAgenda);
    END
    
  
    DROP TABLE StatusAgenda;
   
    ALTER TABLE Agendamento DROP COLUMN StatusAgendaId;
	ALTER TABLE Agendamento ADD StatusAgenda VARCHAR(20) NOT NULL;


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