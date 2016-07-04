CREATE TABLE [dbo].[Students]
(
	[Id] INT NOT NULL, 
    [FirstName] NVARCHAR(50) NOT NULL, 
    [LastName] NVARCHAR(50) NOT NULL, 
    [Group_] INT NOT NULL, 
    [Course] INT NOT NULL,
	CONSTRAINT [PK_Students] PRIMARY KEY CLUSTERED ([Id] ASC),
	FOREIGN KEY ([Group_]) REFERENCES Groups([Id])
	
)
