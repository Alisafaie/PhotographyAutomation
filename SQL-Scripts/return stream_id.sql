DECLARE @Tbl table(id uniqueidentifier);

INSERT INTO [dbo].[MyDocumentStore] ([file_stream], [name])  OUTPUT INSERTED.[stream_id] INTO @Tbl
VALUES (@file_stream, @name);
SELECT Scope_Identity() as returnidentity