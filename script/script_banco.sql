USE [locacao_api]
GO
/****** Object:  Table [dbo].[tblagendamento]    Script Date: 21/01/2024 20:14:50 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[tblagendamento](
	[idage] [int] IDENTITY(1,1) NOT NULL,
	[datage] [date] NOT NULL,
	[idcli] [int] NOT NULL,
	[idvei] [int] NOT NULL,
	[valhorage] [decimal](18, 2) NOT NULL,
	[totHorage] [int] NOT NULL,
	[valTotal]  AS ([valhorage]*[totHorage]),
	[staage] [tinyint] NOT NULL,
	[datRetirada] [datetime] NULL,
	[datRetorno] [datetime] NULL,
 CONSTRAINT [PK_tblagendamento] PRIMARY KEY CLUSTERED 
(
	[idage] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[tblcategoria]    Script Date: 21/01/2024 20:14:50 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[tblcategoria](
	[idcat] [int] IDENTITY(1,1) NOT NULL,
	[nomcat] [varchar](20) NOT NULL,
 CONSTRAINT [PK_tblcategoria] PRIMARY KEY CLUSTERED 
(
	[idcat] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[tblcliente]    Script Date: 21/01/2024 20:14:50 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[tblcliente](
	[idcli] [int] IDENTITY(1,1) NOT NULL,
	[nomcli] [varchar](100) NOT NULL,
	[numcpfcli] [varchar](11) NOT NULL,
	[dtnasccli] [date] NOT NULL,
	[iduse] [int] NOT NULL,
 CONSTRAINT [PK_tblcliente] PRIMARY KEY CLUSTERED 
(
	[idcli] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[tblcombustivel]    Script Date: 21/01/2024 20:14:50 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[tblcombustivel](
	[idcom] [int] IDENTITY(1,1) NOT NULL,
	[nomcom] [varchar](10) NOT NULL,
 CONSTRAINT [PK_tblcombustivel] PRIMARY KEY CLUSTERED 
(
	[idcom] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[tblendereco]    Script Date: 21/01/2024 20:14:50 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[tblendereco](
	[idend] [int] IDENTITY(1,1) NOT NULL,
	[idcli] [int] NOT NULL,
	[nomend] [varchar](100) NOT NULL,
	[cepend] [char](10) NOT NULL,
	[ufend] [char](2) NOT NULL,
	[cidend] [varchar](120) NOT NULL,
	[baiend] [varchar](200) NOT NULL,
	[numend] [varchar](20) NULL,
	[compend] [varchar](30) NULL,
 CONSTRAINT [PK_tblendereco] PRIMARY KEY CLUSTERED 
(
	[idend] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[tblmarca]    Script Date: 21/01/2024 20:14:50 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[tblmarca](
	[idmar] [int] IDENTITY(1,1) NOT NULL,
	[nommar] [varchar](30) NOT NULL,
 CONSTRAINT [PK_tblmarca] PRIMARY KEY CLUSTERED 
(
	[idmar] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[tblmodelo]    Script Date: 21/01/2024 20:14:50 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[tblmodelo](
	[idmod] [int] IDENTITY(1,1) NOT NULL,
	[idmar] [int] NOT NULL,
	[nommod] [varchar](30) NOT NULL,
 CONSTRAINT [PK_tblmodelo] PRIMARY KEY CLUSTERED 
(
	[idmod] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[tbloperador]    Script Date: 21/01/2024 20:14:50 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[tbloperador](
	[matope] [int] NOT NULL,
	[nomope] [varchar](50) NOT NULL,
	[iduse] [int] NULL
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[tbluser]    Script Date: 21/01/2024 20:14:50 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[tbluser](
	[iduse] [int] IDENTITY(1,1) NOT NULL,
	[passuse] [varchar](255) NOT NULL,
	[iduseper] [int] NOT NULL,
 CONSTRAINT [PK__tbluser__250C90E5AAE5C67D] PRIMARY KEY CLUSTERED 
(
	[iduse] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[tbluserperfil]    Script Date: 21/01/2024 20:14:50 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[tbluserperfil](
	[iduseper] [int] NOT NULL,
	[nomuseper] [varchar](30) NOT NULL,
 CONSTRAINT [PK_tbluserperfil] PRIMARY KEY CLUSTERED 
(
	[iduseper] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[tblveiculo]    Script Date: 21/01/2024 20:14:50 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[tblveiculo](
	[idvei] [int] IDENTITY(1,1) NOT NULL,
	[idmar] [int] NOT NULL,
	[idmod] [int] NOT NULL,
	[idcat] [int] NOT NULL,
	[idcom] [int] NOT NULL,
	[plavei] [varchar](10) NOT NULL,
	[numlimpormalvei] [int] NOT NULL,
	[valhorvei] [decimal](18, 2) NOT NULL,
	[anovei] [int] NOT NULL,
 CONSTRAINT [PK_tblveiculo] PRIMARY KEY CLUSTERED 
(
	[idvei] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
SET IDENTITY_INSERT [dbo].[tblagendamento] ON 
GO
INSERT [dbo].[tblagendamento] ([idage], [datage], [idcli], [idvei], [valhorage], [totHorage], [staage], [datRetirada], [datRetorno]) VALUES (1, CAST(N'2024-01-21' AS Date), 1, 1, CAST(1.00 AS Decimal(18, 2)), 1, 0, NULL, NULL)
GO
SET IDENTITY_INSERT [dbo].[tblagendamento] OFF
GO
SET IDENTITY_INSERT [dbo].[tblcategoria] ON 
GO
INSERT [dbo].[tblcategoria] ([idcat], [nomcat]) VALUES (1, N'Básico')
GO
INSERT [dbo].[tblcategoria] ([idcat], [nomcat]) VALUES (2, N'Completo')
GO
INSERT [dbo].[tblcategoria] ([idcat], [nomcat]) VALUES (3, N'Luxo')
GO
SET IDENTITY_INSERT [dbo].[tblcategoria] OFF
GO
SET IDENTITY_INSERT [dbo].[tblcliente] ON 
GO
INSERT [dbo].[tblcliente] ([idcli], [nomcli], [numcpfcli], [dtnasccli], [iduse]) VALUES (1, N'Angelo', N'44032721009', CAST(N'1977-06-26' AS Date), 2)
GO
INSERT [dbo].[tblcliente] ([idcli], [nomcli], [numcpfcli], [dtnasccli], [iduse]) VALUES (2, N'Angelo teste2', N'87801947029', CAST(N'1977-06-27' AS Date), 5)
GO
SET IDENTITY_INSERT [dbo].[tblcliente] OFF
GO
SET IDENTITY_INSERT [dbo].[tblcombustivel] ON 
GO
INSERT [dbo].[tblcombustivel] ([idcom], [nomcom]) VALUES (1, N'Gasolina')
GO
INSERT [dbo].[tblcombustivel] ([idcom], [nomcom]) VALUES (2, N'Álcool')
GO
INSERT [dbo].[tblcombustivel] ([idcom], [nomcom]) VALUES (3, N'Diesel')
GO
SET IDENTITY_INSERT [dbo].[tblcombustivel] OFF
GO
SET IDENTITY_INSERT [dbo].[tblendereco] ON 
GO
INSERT [dbo].[tblendereco] ([idend], [idcli], [nomend], [cepend], [ufend], [cidend], [baiend], [numend], [compend]) VALUES (1, 1, N'Rua Bueno de andrade', N'01526000  ', N'UF', N'São Paulo', N'Aclimação', N'706', N'ap54')
GO
INSERT [dbo].[tblendereco] ([idend], [idcli], [nomend], [cepend], [ufend], [cidend], [baiend], [numend], [compend]) VALUES (2, 2, N'Rua Bueno de Andrade', N'01526000  ', N'SP', N'São Paulo', N'Aclimação', N'706', N'')
GO
SET IDENTITY_INSERT [dbo].[tblendereco] OFF
GO
SET IDENTITY_INSERT [dbo].[tblmarca] ON 
GO
INSERT [dbo].[tblmarca] ([idmar], [nommar]) VALUES (1, N'Toyota')
GO
INSERT [dbo].[tblmarca] ([idmar], [nommar]) VALUES (2, N'Volkswagen')
GO
INSERT [dbo].[tblmarca] ([idmar], [nommar]) VALUES (3, N'Ford')
GO
INSERT [dbo].[tblmarca] ([idmar], [nommar]) VALUES (4, N'Chevrolet')
GO
INSERT [dbo].[tblmarca] ([idmar], [nommar]) VALUES (5, N'Honda')
GO
INSERT [dbo].[tblmarca] ([idmar], [nommar]) VALUES (6, N'Nissan')
GO
INSERT [dbo].[tblmarca] ([idmar], [nommar]) VALUES (7, N'Mercedes-Benz')
GO
INSERT [dbo].[tblmarca] ([idmar], [nommar]) VALUES (8, N'BMW')
GO
INSERT [dbo].[tblmarca] ([idmar], [nommar]) VALUES (9, N'Audi')
GO
INSERT [dbo].[tblmarca] ([idmar], [nommar]) VALUES (10, N'Hyundai')
GO
SET IDENTITY_INSERT [dbo].[tblmarca] OFF
GO
SET IDENTITY_INSERT [dbo].[tblmodelo] ON 
GO
INSERT [dbo].[tblmodelo] ([idmod], [idmar], [nommod]) VALUES (1, 1, N'Corolla')
GO
INSERT [dbo].[tblmodelo] ([idmod], [idmar], [nommod]) VALUES (2, 1, N'Camry')
GO
INSERT [dbo].[tblmodelo] ([idmod], [idmar], [nommod]) VALUES (3, 1, N'Rav4')
GO
INSERT [dbo].[tblmodelo] ([idmod], [idmar], [nommod]) VALUES (4, 2, N'Golf')
GO
INSERT [dbo].[tblmodelo] ([idmod], [idmar], [nommod]) VALUES (5, 2, N'Jetta')
GO
INSERT [dbo].[tblmodelo] ([idmod], [idmar], [nommod]) VALUES (6, 2, N'Tiguan')
GO
INSERT [dbo].[tblmodelo] ([idmod], [idmar], [nommod]) VALUES (7, 3, N'Mustang')
GO
INSERT [dbo].[tblmodelo] ([idmod], [idmar], [nommod]) VALUES (8, 3, N'F-150')
GO
INSERT [dbo].[tblmodelo] ([idmod], [idmar], [nommod]) VALUES (9, 3, N'Explorer')
GO
INSERT [dbo].[tblmodelo] ([idmod], [idmar], [nommod]) VALUES (10, 4, N'Camaro')
GO
INSERT [dbo].[tblmodelo] ([idmod], [idmar], [nommod]) VALUES (11, 4, N'Silverado')
GO
INSERT [dbo].[tblmodelo] ([idmod], [idmar], [nommod]) VALUES (12, 4, N'Equinox')
GO
INSERT [dbo].[tblmodelo] ([idmod], [idmar], [nommod]) VALUES (13, 5, N'Civic')
GO
INSERT [dbo].[tblmodelo] ([idmod], [idmar], [nommod]) VALUES (14, 5, N'Accord')
GO
INSERT [dbo].[tblmodelo] ([idmod], [idmar], [nommod]) VALUES (15, 5, N'CR-V')
GO
INSERT [dbo].[tblmodelo] ([idmod], [idmar], [nommod]) VALUES (16, 6, N'Altima')
GO
INSERT [dbo].[tblmodelo] ([idmod], [idmar], [nommod]) VALUES (17, 6, N'Rogue')
GO
INSERT [dbo].[tblmodelo] ([idmod], [idmar], [nommod]) VALUES (18, 6, N'Pathfinder')
GO
INSERT [dbo].[tblmodelo] ([idmod], [idmar], [nommod]) VALUES (19, 7, N'C-Class')
GO
INSERT [dbo].[tblmodelo] ([idmod], [idmar], [nommod]) VALUES (20, 7, N'E-Class')
GO
INSERT [dbo].[tblmodelo] ([idmod], [idmar], [nommod]) VALUES (21, 7, N'GLC')
GO
INSERT [dbo].[tblmodelo] ([idmod], [idmar], [nommod]) VALUES (22, 8, N'3 Series')
GO
INSERT [dbo].[tblmodelo] ([idmod], [idmar], [nommod]) VALUES (23, 8, N'5 Series')
GO
INSERT [dbo].[tblmodelo] ([idmod], [idmar], [nommod]) VALUES (24, 8, N'X5')
GO
INSERT [dbo].[tblmodelo] ([idmod], [idmar], [nommod]) VALUES (25, 9, N'A4')
GO
INSERT [dbo].[tblmodelo] ([idmod], [idmar], [nommod]) VALUES (26, 9, N'Q5')
GO
INSERT [dbo].[tblmodelo] ([idmod], [idmar], [nommod]) VALUES (27, 9, N'A6')
GO
INSERT [dbo].[tblmodelo] ([idmod], [idmar], [nommod]) VALUES (28, 10, N'Elantra')
GO
INSERT [dbo].[tblmodelo] ([idmod], [idmar], [nommod]) VALUES (29, 10, N'Tucson')
GO
INSERT [dbo].[tblmodelo] ([idmod], [idmar], [nommod]) VALUES (30, 10, N'Santa Fe')
GO
SET IDENTITY_INSERT [dbo].[tblmodelo] OFF
GO
INSERT [dbo].[tbloperador] ([matope], [nomope], [iduse]) VALUES (123456, N'angelo', 1)
GO
INSERT [dbo].[tbloperador] ([matope], [nomope], [iduse]) VALUES (1111, N'Angelo teste', 4)
GO
SET IDENTITY_INSERT [dbo].[tbluser] ON 
GO
INSERT [dbo].[tbluser] ([iduse], [passuse], [iduseper]) VALUES (1, N'E2Gc/qBO6wiOoE14lzHv7dT73hDL+VO82UidOl6JzPCNlp7vbsrTwpo6YpKA5obPDD9dWoav88oSAgySOtxskg==', 1)
GO
INSERT [dbo].[tbluser] ([iduse], [passuse], [iduseper]) VALUES (2, N'2gb4O1FU2Lvi6CLM79O8mdhtqVpVV2IMiBYc9It5vVCX1XycvIEfIz5thohgAFb+BljdiQKpE3oTIO7aHUc3RQ==', 2)
GO
INSERT [dbo].[tbluser] ([iduse], [passuse], [iduseper]) VALUES (4, N'Z6v+yopTWHYGVemm/QiOcYDxD8yb+4+F0zdhJWdfpA4P/hq9GgghU1PCM9bgCWE+le7EJTgyp2GvKP83rFoVDA==', 1)
GO
INSERT [dbo].[tbluser] ([iduse], [passuse], [iduseper]) VALUES (5, N'hINs6+XTTdEl1gx8CN9xpWSKpE2Eo2/99Osn1R1gSERhSYJPo+aErdVjp4KYD5YBD8OQt43i4TGuZj9pfmt4aw==', 2)
GO
SET IDENTITY_INSERT [dbo].[tbluser] OFF
GO
INSERT [dbo].[tbluserperfil] ([iduseper], [nomuseper]) VALUES (1, N'OPERADOR')
GO
INSERT [dbo].[tbluserperfil] ([iduseper], [nomuseper]) VALUES (2, N'CLIENTE')
GO
SET IDENTITY_INSERT [dbo].[tblveiculo] ON 
GO
INSERT [dbo].[tblveiculo] ([idvei], [idmar], [idmod], [idcat], [idcom], [plavei], [numlimpormalvei], [valhorvei], [anovei]) VALUES (1, 4, 11, 1, 1, N'BVU0054', 30, CAST(10.00 AS Decimal(18, 2)), 2000)
GO
SET IDENTITY_INSERT [dbo].[tblveiculo] OFF
GO
ALTER TABLE [dbo].[tblagendamento] ADD  CONSTRAINT [DF_tblagendamento_staage]  DEFAULT ((0)) FOR [staage]
GO
ALTER TABLE [dbo].[tbloperador] ADD  CONSTRAINT [DF__tbloperad__nomop__267ABA7A]  DEFAULT (NULL) FOR [nomope]
GO
ALTER TABLE [dbo].[tbloperador] ADD  CONSTRAINT [DF__tbloperad__iduse__276EDEB3]  DEFAULT (NULL) FOR [iduse]
GO
ALTER TABLE [dbo].[tblagendamento]  WITH CHECK ADD  CONSTRAINT [FK_tblagendamento_tblcliente] FOREIGN KEY([idcli])
REFERENCES [dbo].[tblcliente] ([idcli])
GO
ALTER TABLE [dbo].[tblagendamento] CHECK CONSTRAINT [FK_tblagendamento_tblcliente]
GO
ALTER TABLE [dbo].[tblagendamento]  WITH CHECK ADD  CONSTRAINT [FK_tblagendamento_tblveiculo] FOREIGN KEY([idvei])
REFERENCES [dbo].[tblveiculo] ([idvei])
GO
ALTER TABLE [dbo].[tblagendamento] CHECK CONSTRAINT [FK_tblagendamento_tblveiculo]
GO
ALTER TABLE [dbo].[tblcliente]  WITH CHECK ADD  CONSTRAINT [FK_tblcliente_tbluser] FOREIGN KEY([iduse])
REFERENCES [dbo].[tbluser] ([iduse])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[tblcliente] CHECK CONSTRAINT [FK_tblcliente_tbluser]
GO
ALTER TABLE [dbo].[tblendereco]  WITH CHECK ADD  CONSTRAINT [FK_tblendereco_tblcliente] FOREIGN KEY([idcli])
REFERENCES [dbo].[tblcliente] ([idcli])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[tblendereco] CHECK CONSTRAINT [FK_tblendereco_tblcliente]
GO
ALTER TABLE [dbo].[tblmodelo]  WITH CHECK ADD  CONSTRAINT [FK_tblmodelo_tblmodelo] FOREIGN KEY([idmar])
REFERENCES [dbo].[tblmarca] ([idmar])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[tblmodelo] CHECK CONSTRAINT [FK_tblmodelo_tblmodelo]
GO
ALTER TABLE [dbo].[tbloperador]  WITH CHECK ADD  CONSTRAINT [FK_tbloperador_tbluser] FOREIGN KEY([iduse])
REFERENCES [dbo].[tbluser] ([iduse])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[tbloperador] CHECK CONSTRAINT [FK_tbloperador_tbluser]
GO
ALTER TABLE [dbo].[tbluser]  WITH CHECK ADD  CONSTRAINT [FK_tbluser_tbluserperfil] FOREIGN KEY([iduseper])
REFERENCES [dbo].[tbluserperfil] ([iduseper])
GO
ALTER TABLE [dbo].[tbluser] CHECK CONSTRAINT [FK_tbluser_tbluserperfil]
GO
ALTER TABLE [dbo].[tblveiculo]  WITH CHECK ADD  CONSTRAINT [FK_tblveiculo_tblcategoria] FOREIGN KEY([idcat])
REFERENCES [dbo].[tblcategoria] ([idcat])
GO
ALTER TABLE [dbo].[tblveiculo] CHECK CONSTRAINT [FK_tblveiculo_tblcategoria]
GO
ALTER TABLE [dbo].[tblveiculo]  WITH CHECK ADD  CONSTRAINT [FK_tblveiculo_tblcombustivel] FOREIGN KEY([idcom])
REFERENCES [dbo].[tblcombustivel] ([idcom])
GO
ALTER TABLE [dbo].[tblveiculo] CHECK CONSTRAINT [FK_tblveiculo_tblcombustivel]
GO
ALTER TABLE [dbo].[tblveiculo]  WITH CHECK ADD  CONSTRAINT [FK_tblveiculo_tblmarca] FOREIGN KEY([idmar])
REFERENCES [dbo].[tblmarca] ([idmar])
GO
ALTER TABLE [dbo].[tblveiculo] CHECK CONSTRAINT [FK_tblveiculo_tblmarca]
GO
ALTER TABLE [dbo].[tblveiculo]  WITH CHECK ADD  CONSTRAINT [FK_tblveiculo_tblmodelo] FOREIGN KEY([idmod])
REFERENCES [dbo].[tblmodelo] ([idmod])
GO
ALTER TABLE [dbo].[tblveiculo] CHECK CONSTRAINT [FK_tblveiculo_tblmodelo]
GO
