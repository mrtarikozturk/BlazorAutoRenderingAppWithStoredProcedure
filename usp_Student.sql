-- Read all strudents
--ALTER Proc [DBO].[usp_Get_Students]
--AS
--BEGIN 
--	SELECT Id, Name, Birthday, Age FROM DBO.Student WITH (NOLOCK)
--END

 -- GetById

--Create Proc [DBO].[usp_Get_StudentById]
--(
--	@Id INT
--)
--AS
--BEGIN 
--	SELECT Id, Name, Birthday, Age FROM DBO.Student WITH (NOLOCK)
--	WHERE Id = @Id
--END


-- Insert

--ALTER Proc [DBO].[usp_Insert_Student]
--(
--	@Name NVARCHAR(MAX),
--	@Age INT,
--	@Birthday DATETIME2(7)
--)
--AS
--BEGIN 
--BEGIN TRY
--	BEGIN TRAN
--		INSERT  DBO.Student( Name, Birthday, Age)
--		VALUES
--		(
--		@Name,
--		@Birthday,
--		@Age
--		)
--	COMMIT TRAN
--END TRY
--BEGIN CATCH
--	ROLLBACK TRAN
--END CATCH
--END

-- uppdate

--Create Proc [DBO].[usp_Update_Student]
--(
--	@Id INT,
--	@Name NVARCHAR(MAX),
--	@Age INT,
--	@Birthday DATETIME2(7)
--)
--AS
--BEGIN 
--DECLARE @RowCount INT = 0
--	BEGIN TRY
--		SET @RowCount = (SELECT COUNT(1) FROM DBO.Student WITH (NOLOCK) WHERE Id = @Id)
--		IF(@RowCount > 0)
--			BEGIN
--				BEGIN TRAN
--					UPDATE DBO.Student
--						SET 
--							Name = @Name
--							,Age = @Age
--							,Birthday = @Birthday
--						WHERE Id = @Id
--				COMMIT TRAN
--			END
--	END TRY
--BEGIN CATCH
--	ROLLBACK TRAN
--END CATCH
--END

-- delete

Create Proc [DBO].[usp_Update_Student]
(
	@Id INT
)
AS
BEGIN 
DECLARE @RowCount INT = 0
	BEGIN TRY
		SET @RowCount = (SELECT COUNT(1) FROM DBO.Student WITH (NOLOCK) WHERE Id = @Id)
		IF(@RowCount > 0)
			BEGIN
				BEGIN TRAN
					DELETE FROM DBO.Student
						WHERE Id = @Id
				COMMIT TRAN
			END
	END TRY
BEGIN CATCH
	ROLLBACK TRAN
END CATCH
END