USE [IfrsDocs]
GO
/****** Object:  Table [dbo].[Course]    Script Date: 24/07/2022 01:46:22 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Course](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Description] [varchar](100) NOT NULL,
	[CreateDate] [datetime] NOT NULL,
	[UpdateDate] [datetime] NULL,
 CONSTRAINT [PK_Course] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[DocumentOption]    Script Date: 24/07/2022 01:46:22 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[DocumentOption](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[DocumentType] [varchar](30) NOT NULL,
	[FieldType] [varchar](20) NULL,
	[Description] [varchar](100) NOT NULL,
	[CreateDate] [datetime] NOT NULL,
	[UpdateDate] [datetime] NULL,
 CONSTRAINT [PK_DocumentOption] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Form]    Script Date: 24/07/2022 01:46:22 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Form](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[UserId] [int] NULL,
	[Email] [varchar](30) NULL,
	[Name] [varchar](50) NULL,
	[CPF] [varchar](30) NULL,
	[CourseId] [int] NULL,
	[ReceiveDocumentType] [varchar](100) NULL,
	[DocumentType] [varchar](50) NULL,
	[Status] [varchar](50) NULL,
	[CreateDate] [datetime] NOT NULL,
	[UpdateDate] [datetime] NULL,
	[CreateBy] [varchar](50) NULL,
	[UpdateBy] [varchar](50) NULL,
 CONSTRAINT [PK_Form] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[FormCanceled]    Script Date: 24/07/2022 01:46:22 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[FormCanceled](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[FormId] [int] NOT NULL,
	[CanceledDate] [datetime] NOT NULL,
	[CanceledBy] [varchar](50) NULL,
 CONSTRAINT [PK_FormCanceled] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[FormDocumentOption]    Script Date: 24/07/2022 01:46:22 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[FormDocumentOption](
	[FormId] [int] NOT NULL,
	[DocumentOptionId] [int] NOT NULL
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Role]    Script Date: 24/07/2022 01:46:22 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Role](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Description] [varchar](20) NOT NULL,
 CONSTRAINT [PK_Role] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[User]    Script Date: 24/07/2022 01:46:22 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[User](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Description] [varchar](50) NULL,
	[Email] [varchar](50) NOT NULL,
	[CPF] [varchar](30) NOT NULL,
	[Password] [varchar](30) NOT NULL,
	[RoleId] [int] NOT NULL,
	[CreateDate] [datetime] NOT NULL,
	[UpdateDate] [datetime] NULL,
 CONSTRAINT [PK_User] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
SET IDENTITY_INSERT [dbo].[Course] ON 

INSERT [dbo].[Course] ([Id], [Description], [CreateDate], [UpdateDate]) VALUES (1, N'(Superior) Análise e Desenvolvimento de Sistemas', CAST(N'2022-07-18T01:34:10.443' AS DateTime), NULL)
INSERT [dbo].[Course] ([Id], [Description], [CreateDate], [UpdateDate]) VALUES (3, N'(PROEJA) Agroecologia', CAST(N'2022-07-24T01:05:49.183' AS DateTime), NULL)
INSERT [dbo].[Course] ([Id], [Description], [CreateDate], [UpdateDate]) VALUES (4, N'(PROEJA) Comércio', CAST(N'2022-07-24T01:05:49.183' AS DateTime), NULL)
INSERT [dbo].[Course] ([Id], [Description], [CreateDate], [UpdateDate]) VALUES (5, N'(Subsequente) Turismo', CAST(N'2022-07-24T01:06:55.127' AS DateTime), NULL)
INSERT [dbo].[Course] ([Id], [Description], [CreateDate], [UpdateDate]) VALUES (6, N'(Integrado) Eletrônica', CAST(N'2022-07-24T01:06:55.127' AS DateTime), NULL)
INSERT [dbo].[Course] ([Id], [Description], [CreateDate], [UpdateDate]) VALUES (7, N'(Integrado) Lazer', CAST(N'2022-07-24T01:06:55.127' AS DateTime), NULL)
INSERT [dbo].[Course] ([Id], [Description], [CreateDate], [UpdateDate]) VALUES (8, N'(Integrado) Informática', CAST(N'2022-07-24T01:06:55.127' AS DateTime), NULL)
INSERT [dbo].[Course] ([Id], [Description], [CreateDate], [UpdateDate]) VALUES (9, N'(Superior) Letras Português e Espanhol', CAST(N'2022-07-24T01:06:55.127' AS DateTime), NULL)
INSERT [dbo].[Course] ([Id], [Description], [CreateDate], [UpdateDate]) VALUES (10, N'(Superior) Análise e Desenvolvimento de Sistemas', CAST(N'2022-07-24T01:06:55.127' AS DateTime), NULL)
INSERT [dbo].[Course] ([Id], [Description], [CreateDate], [UpdateDate]) VALUES (11, N'(Superior) Eletrônica Insdustrial', CAST(N'2022-07-24T01:06:55.127' AS DateTime), NULL)
INSERT [dbo].[Course] ([Id], [Description], [CreateDate], [UpdateDate]) VALUES (12, N'(Superior) Gestão Desportiva e de Lazer', CAST(N'2022-07-24T01:06:55.127' AS DateTime), NULL)
INSERT [dbo].[Course] ([Id], [Description], [CreateDate], [UpdateDate]) VALUES (13, N'(Superior) Processos Gerenciais', CAST(N'2022-07-24T01:06:55.127' AS DateTime), NULL)
SET IDENTITY_INSERT [dbo].[Course] OFF
GO
SET IDENTITY_INSERT [dbo].[DocumentOption] ON 

INSERT [dbo].[DocumentOption] ([Id], [DocumentType], [FieldType], [Description], [CreateDate], [UpdateDate]) VALUES (1, N'Historico', N'CHECKBOX', N'Historico Parcial', CAST(N'2022-07-24T01:15:58.290' AS DateTime), NULL)
INSERT [dbo].[DocumentOption] ([Id], [DocumentType], [FieldType], [Description], [CreateDate], [UpdateDate]) VALUES (2, N'Historico', N'CHECKBOX', N'Ementas das disciplinas cursadas', CAST(N'2022-07-24T01:15:58.290' AS DateTime), NULL)
INSERT [dbo].[DocumentOption] ([Id], [DocumentType], [FieldType], [Description], [CreateDate], [UpdateDate]) VALUES (3, N'Historico', N'TEXT', N'Justificativa', CAST(N'2022-07-24T01:15:58.290' AS DateTime), NULL)
INSERT [dbo].[DocumentOption] ([Id], [DocumentType], [FieldType], [Description], [CreateDate], [UpdateDate]) VALUES (4, N'Comprovante', N'CHECKBOX', N'Declaração de vínculo ao IFRS', CAST(N'2022-07-24T01:18:08.053' AS DateTime), NULL)
INSERT [dbo].[DocumentOption] ([Id], [DocumentType], [FieldType], [Description], [CreateDate], [UpdateDate]) VALUES (5, N'Comprovante', N'CHECKBOX', N'Atestado de Atividade', CAST(N'2022-07-24T01:18:08.053' AS DateTime), NULL)
INSERT [dbo].[DocumentOption] ([Id], [DocumentType], [FieldType], [Description], [CreateDate], [UpdateDate]) VALUES (6, N'Comprovante', N'CHECKBOX', N'Atestado de provável concluinte', CAST(N'2022-07-24T01:18:08.053' AS DateTime), NULL)
INSERT [dbo].[DocumentOption] ([Id], [DocumentType], [FieldType], [Description], [CreateDate], [UpdateDate]) VALUES (7, N'Comprovante', N'CHECKBOX', N'Atestado de matrícula', CAST(N'2022-07-24T01:18:08.053' AS DateTime), NULL)
INSERT [dbo].[DocumentOption] ([Id], [DocumentType], [FieldType], [Description], [CreateDate], [UpdateDate]) VALUES (8, N'Comprovante', N'CHECKBOX', N'Atestado de frequência', CAST(N'2022-07-24T01:18:08.053' AS DateTime), NULL)
INSERT [dbo].[DocumentOption] ([Id], [DocumentType], [FieldType], [Description], [CreateDate], [UpdateDate]) VALUES (9, N'Comprovante', N'TEXT', N'Observação', CAST(N'2022-07-24T01:18:08.053' AS DateTime), NULL)
SET IDENTITY_INSERT [dbo].[DocumentOption] OFF
GO
SET IDENTITY_INSERT [dbo].[Form] ON 

INSERT [dbo].[Form] ([Id], [UserId], [Email], [Name], [CPF], [CourseId], [ReceiveDocumentType], [DocumentType], [Status], [CreateDate], [UpdateDate], [CreateBy], [UpdateBy]) VALUES (1, NULL, NULL, NULL, NULL, 1, N'ByEmail', N'Comprovante', N'Pendente', CAST(N'2022-07-24T01:28:56.140' AS DateTime), CAST(N'2022-07-24T01:40:11.543' AS DateTime), NULL, NULL)
INSERT [dbo].[Form] ([Id], [UserId], [Email], [Name], [CPF], [CourseId], [ReceiveDocumentType], [DocumentType], [Status], [CreateDate], [UpdateDate], [CreateBy], [UpdateBy]) VALUES (2, NULL, NULL, NULL, NULL, 1, N'2', N'Historico', N'Pendente', CAST(N'2022-07-24T01:28:56.140' AS DateTime), CAST(N'2022-07-24T01:33:42.360' AS DateTime), NULL, NULL)
SET IDENTITY_INSERT [dbo].[Form] OFF
GO
SET IDENTITY_INSERT [dbo].[Role] ON 

INSERT [dbo].[Role] ([Id], [Description]) VALUES (1, N'Admin')
INSERT [dbo].[Role] ([Id], [Description]) VALUES (2, N'Aluno')
SET IDENTITY_INSERT [dbo].[Role] OFF
GO
SET IDENTITY_INSERT [dbo].[User] ON 

INSERT [dbo].[User] ([Id], [Description], [Email], [CPF], [Password], [RoleId], [CreateDate], [UpdateDate]) VALUES (1, N'Guilherme', N'guilherme@email.com', N'2391819203', N'123', 1, CAST(N'2022-07-23T19:35:42.000' AS DateTime), NULL)
SET IDENTITY_INSERT [dbo].[User] OFF
GO
ALTER TABLE [dbo].[Course] ADD  CONSTRAINT [DF_Course_CreateDate]  DEFAULT (getdate()) FOR [CreateDate]
GO
ALTER TABLE [dbo].[DocumentOption] ADD  CONSTRAINT [DF_DocumentOption_CreateDate]  DEFAULT (getdate()) FOR [CreateDate]
GO
ALTER TABLE [dbo].[Form] ADD  CONSTRAINT [DF_Form_CreateDate]  DEFAULT (getdate()) FOR [CreateDate]
GO
ALTER TABLE [dbo].[User] ADD  CONSTRAINT [DF_User_CreateDate]  DEFAULT (getdate()) FOR [CreateDate]
GO
