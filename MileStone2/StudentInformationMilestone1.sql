CREATE DATABASE StudentInfo
ON PRIMARY 
(NAME=StudentDataFile1,
FILENAME='C:\SQLData\StudentDataFile1.mdf',
SIZE=10MB,
MAXSIZE=10GB,
FILEGROWTH=1MB
)
LOG ON 
(NAME=StudentLogFile1,
FILENAME='C:\SQLData\StudentLogFile1.ldf',
SIZE=10MB,
MAXSIZE=10GB,
FILEGROWTH=1MB
);

GO

USE StudentInfo

GO

CREATE TABLE StudentInformation(
"StudentNumber" "int" IDENTITY (1, 1) NOT NULL PRIMARY KEY,
"StudentName" nvarchar (20) NOT NULL ,
"StudentSurname" nvarchar (10) NOT NULL ,
"StudentImage" "image" NULL ,
"DateOfBirth" "datetime" NULL ,
"Gender" nvarchar (10) NOT NULL ,
"Phone" nvarchar (24) NULL ,
"Address" nvarchar (24) NULL ,
"ModuleCode" "int" NULL FOREIGN KEY REFERENCES  ModuleInformation(ModuleCode),
)

CREATE TABLE ModuleInformation(
"ModuleCode" "int" IDENTITY (1, 1) NOT NULL PRIMARY KEY,
"ModuleName" nvarchar (20) NOT NULL ,
"ModuleDescription" nvarchar (40) NOT NULL ,
"LinksForResources" nvarchar (40) NOT NULL ,
)
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[tblPet](
	[PetID] [int] IDENTITY(1,1) NOT NULL,
	[PetName] [varchar](50) NULL,
	[PetType] [varchar](50) NULL,
	[PetAge] [int] NULL,
	[UserID] [int] NULL,
 CONSTRAINT [PK_tblPet] PRIMARY KEY CLUSTERED 
(
	[PetID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[tblUser]    Script Date: 11/4/2021 9:22:40 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[tblUser](
	[UserID] [int] IDENTITY(1,1) NOT NULL,
	[Name] [varchar](50) NULL,
	[Surname] [varchar](50) NULL,
	[IDNumber] [varchar](20) NULL,
	[Gender] [varchar](50) NULL,
 CONSTRAINT [PK_tblUser] PRIMARY KEY CLUSTERED 
(
	[UserID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
SET IDENTITY_INSERT [dbo].[tblPet] ON 

INSERT [dbo].[tblPet] ([PetID], [PetName], [PetType], [PetAge], [UserID]) VALUES (1, N'Spotty', N'Dog', 12, 2)
INSERT [dbo].[tblPet] ([PetID], [PetName], [PetType], [PetAge], [UserID]) VALUES (2, N'Fluffy', N'Cat', 7, 1)
INSERT [dbo].[tblPet] ([PetID], [PetName], [PetType], [PetAge], [UserID]) VALUES (4, N'Simba', N'Dog', 5, 3)
SET IDENTITY_INSERT [dbo].[tblPet] OFF
SET IDENTITY_INSERT [dbo].[tblUser] ON 

INSERT [dbo].[tblUser] ([UserID], [Name], [Surname], [IDNumber], [Gender]) VALUES (1, N'John', N'Snow', N'9010305044085', N'Male')
INSERT [dbo].[tblUser] ([UserID], [Name], [Surname], [IDNumber], [Gender]) VALUES (2, N'Daniel', N'Walker', N'8805061450081', N'Female')
INSERT [dbo].[tblUser] ([UserID], [Name], [Surname], [IDNumber], [Gender]) VALUES (3, N'Jack', N'Yves', N'7504105088089', N'Male')
SET IDENTITY_INSERT [dbo].[tblUser] OFF
ALTER TABLE [dbo].[tblPet]  WITH CHECK ADD  CONSTRAINT [FK_tblPet_tblUser] FOREIGN KEY([UserID])
REFERENCES [dbo].[tblUser] ([UserID])
GO
ALTER TABLE [dbo].[tblPet] CHECK CONSTRAINT [FK_tblPet_tblUser]
GO
/****** Object:  StoredProcedure [dbo].[deleteid]    Script Date: 11/4/2021 9:22:40 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create proc [dbo].[deleteid]
 @idNumber varchar(max)
  AS
  BEGIN
	delete from tblPet where UserID in( select UserID from tblUser where IDNumber=@idNumber)
	delete from tblUser where IDNumber=@idNumber
  END
GO
/****** Object:  StoredProcedure [dbo].[Inserted]    Script Date: 11/4/2021 9:22:40 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
Create proc [dbo].[Inserted]
@name Varchar(max),
@surname Varchar(max),
@idNumber Varchar(max),
@gender Varchar(max)
AS
begin
INSERT INTO tblUser([Name],[Surname]
      ,[IDNumber]
      ,[Gender])
VALUES(@name,@surname,@idNumber,@gender)
end
GO
/****** Object:  StoredProcedure [dbo].[readPet]    Script Date: 11/4/2021 9:22:40 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
Create proc [dbo].[readPet]
@ids int
as
Begin
Select * from tblPet where UserID=@ids
end
GO
/****** Object:  StoredProcedure [dbo].[up1valall]    Script Date: 11/4/2021 9:22:40 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create proc [dbo].[up1valall]
  @id int,
  @name varchar(max),
  @surname varchar(max)
  AS
  BEGIN
  Update tblUser set Surname=@surname,Name=@name
  where UserID=@id
  END
GO
/****** Object:  StoredProcedure [dbo].[up1valname]    Script Date: 11/4/2021 9:22:40 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create proc [dbo].[up1valname]
  @id int,
  @name varchar(max)
  AS
  BEGIN
  Update tblUser set Name=@name
  where UserID=@id
  END
GO
/****** Object:  StoredProcedure [dbo].[up1valSurname]    Script Date: 11/4/2021 9:22:40 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

  create proc [dbo].[up1valSurname]
  @id int,
  @surname varchar(max)
  AS
  BEGIN
  Update tblUser set Surname=@surname
  where UserID=@id

  END
GO
/****** Object:  StoredProcedure [dbo].[ViewAll]    Script Date: 11/4/2021 9:22:40 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
Create proc [dbo].[ViewAll]
as
begin
Select * from tblUser
end
GO