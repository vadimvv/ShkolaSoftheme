/*
Шаблон скрипта после развертывания							
--------------------------------------------------------------------------------------
 В данном файле содержатся инструкции SQL, которые будут добавлены в скрипт построения.		
 Используйте синтаксис SQLCMD для включения файла в скрипт после развертывания.			
 Пример:      :r .\myfile.sql								
 Используйте синтаксис SQLCMD для создания ссылки на переменную в скрипте после развертывания.		
 Пример:      :setvar TableName MyTable							
               SELECT * FROM [$(TableName)]					
--------------------------------------------------------------------------------------
*/

Use [Database1]
Go

Set Identity_INSERT [Groups] ON

INSERT INTO [dbo].Groups ([Id],[GroupName])
VALUES (1,'TR-21'),
		(2,'TM-21'),
		(3,'TI-21'),
		(4,'TA-11'),
		(5,'TV-31');

SET IDENTITY_INSERT [Groups] OFF

INSERT INTO [dbo].Students ([Id],[FirstName],[LastName],[Group],[Course])
VALUES (1,'Ivashyn', 'Vadym', 1,4),
		(2,'Tkachuk','Artem',1,4),
		(3,'Tyshchuk','Andriy',4,5);
