drop database SeliaIntegradorProfitHomolog;
USE [master]
GO
/****** Object:  Database [SeliaIntegradorProfitHomolog]    Script Date: 20/02/2018 19:01:09 ******/
CREATE DATABASE [SeliaIntegradorProfitHomolog]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'SeliaIntegradorProfitHomolog', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL14.MSSQLSERVER\MSSQL\DATA\SeliaIntegradorProfitHomolog.mdf' , SIZE = 73728KB , MAXSIZE = UNLIMITED, FILEGROWTH = 65536KB )
 LOG ON 
( NAME = N'SeliaIntegradorProfitHomolog_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL14.MSSQLSERVER\MSSQL\DATA\SeliaIntegradorProfitHomolog_log.ldf' , SIZE = 73728KB , MAXSIZE = 2048GB , FILEGROWTH = 65536KB )
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [SeliaIntegradorProfitHomolog].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [SeliaIntegradorProfitHomolog] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [SeliaIntegradorProfitHomolog] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [SeliaIntegradorProfitHomolog] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [SeliaIntegradorProfitHomolog] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [SeliaIntegradorProfitHomolog] SET ARITHABORT OFF 
GO
ALTER DATABASE [SeliaIntegradorProfitHomolog] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [SeliaIntegradorProfitHomolog] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [SeliaIntegradorProfitHomolog] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [SeliaIntegradorProfitHomolog] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [SeliaIntegradorProfitHomolog] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [SeliaIntegradorProfitHomolog] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [SeliaIntegradorProfitHomolog] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [SeliaIntegradorProfitHomolog] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [SeliaIntegradorProfitHomolog] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [SeliaIntegradorProfitHomolog] SET  ENABLE_BROKER 
GO
ALTER DATABASE [SeliaIntegradorProfitHomolog] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [SeliaIntegradorProfitHomolog] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [SeliaIntegradorProfitHomolog] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [SeliaIntegradorProfitHomolog] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [SeliaIntegradorProfitHomolog] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [SeliaIntegradorProfitHomolog] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [SeliaIntegradorProfitHomolog] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [SeliaIntegradorProfitHomolog] SET RECOVERY FULL 
GO
ALTER DATABASE [SeliaIntegradorProfitHomolog] SET  MULTI_USER 
GO
ALTER DATABASE [SeliaIntegradorProfitHomolog] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [SeliaIntegradorProfitHomolog] SET DB_CHAINING OFF 
GO
ALTER DATABASE [SeliaIntegradorProfitHomolog] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [SeliaIntegradorProfitHomolog] SET TARGET_RECOVERY_TIME = 60 SECONDS 
GO
ALTER DATABASE [SeliaIntegradorProfitHomolog] SET DELAYED_DURABILITY = DISABLED 
GO
EXEC sys.sp_db_vardecimal_storage_format N'SeliaIntegradorProfitHomolog', N'ON'
GO
USE [SeliaIntegradorProfitHomolog]
GO
/****** Object:  Table [dbo].[INT_ADAPTER]    Script Date: 20/02/2018 19:01:09 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[INT_ADAPTER](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[NOME] [varchar](100) NULL,
PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[INT_CABECALHOREST]    Script Date: 20/02/2018 19:01:09 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[INT_CABECALHOREST](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[INTERFACERESTID] [int] NULL,
	[NOME] [varchar](100) NOT NULL,
	[VALOR] [varchar](200) NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[INT_CONTENTTYPE]    Script Date: 20/02/2018 19:01:09 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[INT_CONTENTTYPE](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[CONTENTTYPE] [varchar](100) NULL,
PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[int_email]    Script Date: 20/02/2018 19:01:09 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[int_email](
	[id] [int] NULL,
	[Usuario] [varchar](100) NULL,
	[Senha] [varchar](100) NULL,
	[Smtp] [varchar](100) NULL,
	[Porta] [int] NULL,
	[EnableSsl] [bit] NULL,
	[Assunto] [ntext] NULL,
	[From] [ntext] NULL,
	[To] [ntext] NULL
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[INT_FILA]    Script Date: 20/02/2018 19:01:09 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[INT_FILA](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[INTEGRACAOID] [int] NULL,
	[DATACRIACAO] [datetime] NULL,
	[CONTEUDO] [text] NULL DEFAULT (NULL),
	[CHAVEPRIMARIA] [varchar](1000) NULL,
	[CHAVESECUNDARIA] [varchar](1000) NULL,
	[STATUSID] [int] NULL,
	[LOGINTEGRACAOID] [int] NULL,
	[DESTINOID] [int] NULL,
	[ContagemTentativa] [int] NOT NULL DEFAULT ((0)),
PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[int_HoraExecucao]    Script Date: 20/02/2018 19:01:09 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[int_HoraExecucao](
	[Chave] [varchar](300) NOT NULL,
	[Data] [datetime] NULL,
PRIMARY KEY CLUSTERED 
(
	[Chave] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[INT_INTEGRACAO]    Script Date: 20/02/2018 19:01:09 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[INT_INTEGRACAO](
	[ID] [int] NOT NULL,
	[NOME] [varchar](200) NULL,
	[INTERFACEID] [int] NULL,
	[ADAPTERID] [int] NULL,
	[STATUS] [char](1) NULL CONSTRAINT [DF__INT_INTEG__STATU__5535A963]  DEFAULT ((1)),
	[EMUSO] [char](1) NULL CONSTRAINT [DF__INT_INTEG__EMUSO__5629CD9C]  DEFAULT ((0)),
	[EXECUCAOHORARIOS] [varchar](200) NULL,
	[EXECUCAOMINUTOS] [int] NULL,
	[DATAHORAULTIMAEXECUCAO] [datetime] NULL,
	[DESTINOID] [int] NULL,
	[PKPRIMARIA] [varchar](300) NULL,
	[PKSECUNDARIA] [varchar](300) NULL,
	[ACAOINICIAL] [varchar](300) NULL,
	[ACAOFINAL] [varchar](300) NULL,
	[CONSUMIDOR] [int] NULL,
	[ELEMENTOREGISTRO] [varchar](200) NULL,
	[ACAOENFILEIRAMENTO] [varchar](500) NULL,
	[ACAORETURNOERRO] [varchar](300) NULL,
	[ALERTASREGISTROS] [int] NULL,
	[IDTIPOINTEGRACAO] [int] NULL,
	[ContagemTentativa] [int] NOT NULL DEFAULT ((1)),
	[NivelParalelismo] [int] NULL DEFAULT ((1)),
	[ACAOCABECALHO] [varchar](255) NULL,
	[NODESNAOUTILIZADOS] [varchar](255) NULL,
 CONSTRAINT [PK__INT_INTE__3214EC27286302EC] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[INT_INTERFACEARQUIVOTEXTO]    Script Date: 20/02/2018 19:01:09 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[INT_INTERFACEARQUIVOTEXTO](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[NOME] [varchar](100) NULL,
	[SISTEMAID] [int] NULL,
	[FTP] [varchar](100) NULL,
	[LOGIN] [varchar](100) NULL,
	[SENHA] [varchar](100) NULL,
	[URL] [varchar](100) NULL,
	[DELIMITADOR] [varchar](5) NULL,
	[DIRETORIO] [varchar](100) NULL,
	[ENCODING] [varchar](100) NULL,
PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[INT_INTERFACEDB]    Script Date: 20/02/2018 19:01:09 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[INT_INTERFACEDB](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[NOME] [varchar](100) NULL,
	[SISTEMAID] [int] NULL,
	[CONNECTIONSTRING] [varchar](4000) NULL,
	[STOREDPROCEDURE] [varchar](4000) NULL,
	[DATABASENAMEFACTORY] [varchar](4000) NULL,
PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[INT_INTERFACEREST]    Script Date: 20/02/2018 19:01:09 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[INT_INTERFACEREST](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[NOME] [varchar](100) NOT NULL,
	[SISTEMAID] [int] NOT NULL,
	[URL] [varchar](500) NOT NULL,
	[LOGIN] [varchar](100) NULL CONSTRAINT [DF__INT_INTER__LOGIN__398D8EEE]  DEFAULT (NULL),
	[SENHA] [varchar](200) NULL CONSTRAINT [DF__INT_INTER__SENHA__3A81B327]  DEFAULT (NULL),
	[VERBOHTTPID] [int] NOT NULL,
	[TIPOAUTENTICACAOID] [int] NULL CONSTRAINT [DF__INT_INTER__TIPOA__3B75D760]  DEFAULT (NULL),
	[RETURNROOTELEMENTPAI] [varchar](100) NULL CONSTRAINT [DF__INT_INTER__RETUR__3C69FB99]  DEFAULT (NULL),
	[RETURNROOTELEMENTLISTA] [varchar](100) NULL CONSTRAINT [DF__INT_INTER__RETUR__3D5E1FD2]  DEFAULT (NULL),
	[CONTENTTYPE] [varchar](100) NULL CONSTRAINT [DF__INT_INTER__CONTE__3E52440B]  DEFAULT (NULL),
	[CONTENTTYPEID] [int] NULL CONSTRAINT [DF__INT_INTER__CONTE__3F466844]  DEFAULT (NULL),
 CONSTRAINT [PK__INT_INTERFACERES__1FCDBCEB] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[INT_INTERFACEWEBSERVICE]    Script Date: 20/02/2018 19:01:09 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[INT_INTERFACEWEBSERVICE](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[NOME] [varchar](100) NULL,
	[SISTEMAID] [int] NULL,
	[URL] [varchar](100) NULL,
	[LOGIN] [varchar](100) NULL,
	[SENHA] [varchar](100) NULL,
	[METODO] [varchar](100) NULL,
	[ACTION] [varchar](300) NULL,
PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[INT_LOGFILA]    Script Date: 20/02/2018 19:01:09 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[INT_LOGFILA](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[LOGINTEGRACAOID] [int] NULL,
	[DATACRIACAO] [datetime] NULL,
	[CONTEUDO] [text] NULL,
	[CHAVEPRIMARIA] [varchar](300) NULL,
	[CHAVESECUNDARIA] [varchar](300) NULL,
	[CONTEUDOFILA] [text] NULL,
	[CONTEUDORETORNO] [text] NULL,
	[FILAID] [int] NULL,
	[RetornoSemTratamento] [text] NULL,
	[IntegracaoId] [int] NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[INT_LOGINTEGRACAO]    Script Date: 20/02/2018 19:01:09 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[INT_LOGINTEGRACAO](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[INTEGRACAOID] [int] NULL,
	[QTDREGISTROS] [int] NULL,
	[CONTEUDO] [text] NULL,
	[DATACRIACAO] [datetime] NULL,
	[STATUS] [int] NULL,
PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
/****** Object:  Table [dbo].[INT_LOGINTEGRACAO_2]    Script Date: 20/02/2018 19:01:09 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[INT_LOGINTEGRACAO_2](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[INTEGRACAOID] [int] NULL,
	[QTDREGISTROS] [int] NULL,
	[CONTEUDO] [text] NULL,
	[DATACRIACAO] [datetime] NULL,
	[STATUS] [int] NULL,
PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
/****** Object:  Table [dbo].[INT_MAPEAMENTO]    Script Date: 20/02/2018 19:01:09 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[INT_MAPEAMENTO](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[INTEGRACAOID] [int] NULL,
	[DE] [varchar](1000) NULL,
	[PARA] [varchar](1000) NULL,
	[VALOR] [varchar](400) NULL,
	[MULTI] [int] NULL,
	[PAIID] [int] NULL,
	[CONFIGURACAO] [varchar](300) NULL,
	[TIPOVALOR] [varchar](100) NULL,
	[ACAO] [varchar](500) NULL,
	[VALORDEPARA] [int] NULL,
	[BITQUERYSTRING] [bit] NULL,
	[BITMAPRETORNO] [bit] NULL,
	[BITXMLENTRADA] [bit] NULL,
	[BITEXCLUIRBRANCO] [bit] NULL,
	[ELEMENTOMULT] [varchar](255) NULL,
 CONSTRAINT [PK__INT_MAPEAMENTO__060DEAE8] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[INT_MAPEAMENTODEPARA]    Script Date: 20/02/2018 19:01:09 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[INT_MAPEAMENTODEPARA](
	[ID] [int] NOT NULL,
	[DE] [varchar](1000) NULL,
	[PARA] [varchar](1000) NULL,
	[MAPEAMENTOID] [int] NULL,
	[INFOS_ADICIONAIS] [varchar](3000) NULL,
	[INTEGRACAOID] [int] NULL,
PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[INT_PARAMETRODB]    Script Date: 20/02/2018 19:01:09 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[INT_PARAMETRODB](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[INTERFACEDBID] [int] NULL,
	[DE] [varchar](1000) NULL,
	[PARA] [varchar](1000) NULL,
	[RETORNO] [int] NULL,
	[PAIID] [int] NULL,
PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[INT_PARAMETROWEBSERVICE]    Script Date: 20/02/2018 19:01:09 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[INT_PARAMETROWEBSERVICE](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[INTERFACEWEBSERVICEID] [int] NULL,
	[DE] [varchar](1000) NULL,
	[PARA] [varchar](1000) NULL,
	[RETORNO] [int] NULL,
	[PAIID] [int] NULL,
PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[INT_SISTEMA]    Script Date: 20/02/2018 19:01:09 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[INT_SISTEMA](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[NOME] [varchar](100) NULL,
PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[INT_STATUS]    Script Date: 20/02/2018 19:01:09 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[INT_STATUS](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[NOME] [varchar](100) NULL,
PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[INT_TIPOAUTENTICACAOREST]    Script Date: 20/02/2018 19:01:09 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[INT_TIPOAUTENTICACAOREST](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[NOME] [varchar](100) NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[INT_USUARIO]    Script Date: 20/02/2018 19:01:09 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[INT_USUARIO](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[USUARIO] [varchar](255) NOT NULL,
	[SENHA] [varchar](500) NULL,
	[INCLUSAO] [datetime] NOT NULL,
	[EMAIL] [varchar](255) NULL,
PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[INT_VERBOHTTP]    Script Date: 20/02/2018 19:01:09 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[INT_VERBOHTTP](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[NOME] [varchar](100) NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
ALTER TABLE [dbo].[INT_CONTENTTYPE] ADD  DEFAULT (NULL) FOR [CONTENTTYPE]
GO
ALTER TABLE [dbo].[INT_LOGFILA] ADD  DEFAULT ((1)) FOR [IntegracaoId]
GO
ALTER TABLE [dbo].[INT_USUARIO] ADD  DEFAULT (NULL) FOR [SENHA]
GO
ALTER TABLE [dbo].[INT_USUARIO] ADD  DEFAULT (NULL) FOR [EMAIL]
GO
ALTER TABLE [dbo].[INT_CABECALHOREST]  WITH NOCHECK ADD  CONSTRAINT [FK__INT_CABEC__INTER__403A8C7D] FOREIGN KEY([INTERFACERESTID])
REFERENCES [dbo].[INT_INTERFACEREST] ([ID])
GO
ALTER TABLE [dbo].[INT_CABECALHOREST] CHECK CONSTRAINT [FK__INT_CABEC__INTER__403A8C7D]
GO
ALTER TABLE [dbo].[INT_INTERFACEREST]  WITH NOCHECK ADD  CONSTRAINT [fk_int_interfacerest_CONTENTTYPE] FOREIGN KEY([CONTENTTYPEID])
REFERENCES [dbo].[INT_CONTENTTYPE] ([ID])
GO
ALTER TABLE [dbo].[INT_INTERFACEREST] CHECK CONSTRAINT [fk_int_interfacerest_CONTENTTYPE]
GO
ALTER TABLE [dbo].[INT_INTERFACEREST]  WITH NOCHECK ADD  CONSTRAINT [fk_int_interfacerest_TIPOAUTENTICACAOREST] FOREIGN KEY([TIPOAUTENTICACAOID])
REFERENCES [dbo].[INT_TIPOAUTENTICACAOREST] ([ID])
GO
ALTER TABLE [dbo].[INT_INTERFACEREST] CHECK CONSTRAINT [fk_int_interfacerest_TIPOAUTENTICACAOREST]
GO
ALTER TABLE [dbo].[INT_INTERFACEREST]  WITH NOCHECK ADD  CONSTRAINT [fk_int_interfacerest_VERBOHTTP] FOREIGN KEY([VERBOHTTPID])
REFERENCES [dbo].[INT_VERBOHTTP] ([ID])
GO
ALTER TABLE [dbo].[INT_INTERFACEREST] CHECK CONSTRAINT [fk_int_interfacerest_VERBOHTTP]
GO
ALTER TABLE [dbo].[INT_LOGFILA]  WITH CHECK ADD  CONSTRAINT [FK_INT_LOGFILA__22_f_INT_INTEGRACAO] FOREIGN KEY([IntegracaoId])
REFERENCES [dbo].[INT_INTEGRACAO] ([ID])
GO
ALTER TABLE [dbo].[INT_LOGFILA] CHECK CONSTRAINT [FK_INT_LOGFILA__22_f_INT_INTEGRACAO]
GO
/****** Object:  StoredProcedure [dbo].[SP_GSH_DEL_OLD_LOGS]    Script Date: 20/02/2018 19:01:09 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[SP_GSH_DEL_OLD_LOGS]
AS
BEGIN

declare @affectedLogIntegracao int;
declare @affectedLogFila int;
declare @roundLogIntegracao int;
declare @roundLogFila int;

set @roundLogIntegracao = 9999;
set @roundLogFila = 9999;

set @affectedLogIntegracao = 0;
set @affectedLogFila = 0;

declare @startDate datetime;
select @startDate = getDate();

while datediff(second, @startDate, getDate()) < 25 AND (@roundLogIntegracao > 1 OR @roundLogFila > 1)
BEGIN

	DELETE 
	FROM int_logintegracao
	WHERE ID IN (
		SELECT top 100 ID
		FROM int_logintegracao
		WHERE DATEDIFF(minute, datacriacao, getdate()) > 28800
			AND ID NOT IN (SELECT LogINTEGRACAOID FROM INT_FILA)
		ORDER BY id asc
	)
  
	SET @roundLogIntegracao = @@ROWCOUNT;
	--print '@roundLogIntegracao: ' + cast(@roundLogIntegracao as varchar(20))
	SET @affectedLogIntegracao = @affectedLogIntegracao + @roundLogIntegracao;
	--print '@affectedLogIntegracao: ' + cast(@affectedLogIntegracao as varchar(20))

	DELETE 
	FROM int_logfila
	WHERE ID IN (
		SELECT top 100 ID
		FROM int_logfila
		WHERE DATEDIFF(minute, datacriacao, getdate()) > 28800
		  AND FILAID NOT IN (SELECT ID FROM INT_FILA)
		ORDER BY id asc
	)

	SET @roundLogFila = @@ROWCOUNT;
	--print '@roundLogFila: ' + cast(@roundLogFila as varchar(20))
	SET @affectedLogFila = @affectedLogFila + @roundLogFila;
	--print '@affectedLogFila: ' + cast(@affectedLogFila as varchar(20))

END

SELECT @affectedLogIntegracao 'Integracao', @affectedLogFila 'Fila'

END

GO
/****** Object:  StoredProcedure [dbo].[SP_GSH_INS_HORAEXECUCAO]    Script Date: 20/02/2018 19:01:09 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[SP_GSH_INS_HORAEXECUCAO] (
	@chave varchar(300),
	@data datetime
)
AS
BEGIN

	IF EXISTS (SELECT Data FROM int_HoraExecucao WHERE Chave = @chave)
	BEGIN
		IF EXISTS (SELECT Data FROM int_HoraExecucao WHERE Chave = @chave AND Data < @data)
		BEGIN
			UPDATE int_HoraExecucao
			SET Data = dateadd(millisecond, 100, @data)
			WHERE Chave = @chave
		END
	END
	ELSE
	BEGIN
		INSERT INTO int_HoraExecucao (Chave, Data) VALUES (@chave, @Data)
	END
	
END


GO
/****** Object:  StoredProcedure [dbo].[SP_GSH_SEL_HORAEXECUCAO]    Script Date: 20/02/2018 19:01:09 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[SP_GSH_SEL_HORAEXECUCAO] (
	@chave varchar(300)
)
AS
BEGIN

	SELECT Data FROM int_HoraExecucao WHERE Chave = @chave

END


GO
/****** Object:  StoredProcedure [dbo].[SP_INT_DEL_FILAID]    Script Date: 20/02/2018 19:01:09 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
/*!50003 SET sql_mode              = @saved_sql_mode */
/*!50003 SET character_set_client  = @saved_cs_client */
/*!50003 SET character_set_results = @saved_cs_results */
/*!50003 SET collation_connection  = @saved_col_connection */
/*!50003 DROP PROCEDURE IF EXISTS SP_INT_DEL_FILAID */
/*!50003 SET @saved_cs_client      = @@character_set_client */
/*!50003 SET @saved_cs_results     = @@character_set_results */
/*!50003 SET @saved_col_connection = @@collation_connection */
/*!50003 SET character_set_client  = utf8 */
/*!50003 SET character_set_results = utf8 */
/*!50003 SET collation_connection  = utf8_general_ci */
/*!50003 SET @saved_sql_mode       = @@sql_mode */
/*!50003 SET sql_mode              = 'STRICT_TRANS_TABLES,NO_AUTO_CREATE_USER,NO_ENGINE_SUBSTITUTION' */
CREATE PROCEDURE [dbo].[SP_INT_DEL_FILAID](@p_filaID INT)
AS BEGIN

 DELETE FROM
    INT_Fila
  WHERE
    ID =  @p_filaID  ;
    
END


GO
/****** Object:  StoredProcedure [dbo].[SP_INT_DEL_LOGMEMORY]    Script Date: 20/02/2018 19:01:09 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
/*!50003 SET sql_mode              = @saved_sql_mode */
/*!50003 SET character_set_client  = @saved_cs_client */
/*!50003 SET character_set_results = @saved_cs_results */
/*!50003 SET collation_connection  = @saved_col_connection */
/*!50003 DROP PROCEDURE IF EXISTS SP_INT_DEL_LOGMEMORY */
/*!50003 SET @saved_cs_client      = @@character_set_client */
/*!50003 SET @saved_cs_results     = @@character_set_results */
/*!50003 SET @saved_col_connection = @@collation_connection */
/*!50003 SET character_set_client  = utf8 */
/*!50003 SET character_set_results = utf8 */
/*!50003 SET collation_connection  = utf8_general_ci */
/*!50003 SET @saved_sql_mode       = @@sql_mode */
/*!50003 SET sql_mode              = 'STRICT_TRANS_TABLES,NO_AUTO_CREATE_USER,NO_ENGINE_SUBSTITUTION' */
CREATE PROCEDURE [dbo].[SP_INT_DEL_LOGMEMORY]
AS BEGIN

        DELETE FROM INT_LOGFILA WHERE DATACRIACAO < DATEADD(minute, -30, GETDATE());
		DELETE FROM INT_LOGINTEGRACAO WHERE DATACRIACAO < DATEADD(minute, -30, GETDATE());
        
END ;

/*!50003 SET sql_mode              = @saved_sql_mode */
/*!50003 SET character_set_client  = @saved_cs_client */
/*!50003 SET character_set_results = @saved_cs_results */
/*!50003 SET collation_connection  = @saved_col_connection */
/*!50003 DROP PROCEDURE IF EXISTS SP_INT_INS_FILA */
/*!50003 SET @saved_cs_client      = @@character_set_client */
/*!50003 SET @saved_cs_results     = @@character_set_results */
/*!50003 SET @saved_col_connection = @@collation_connection */
/*!50003 SET character_set_client  = utf8 */
/*!50003 SET character_set_results = utf8 */
/*!50003 SET collation_connection  = utf8_general_ci */
/*!50003 SET @saved_sql_mode       = @@sql_mode */
/*!50003 SET sql_mode              = 'STRICT_TRANS_TABLES,NO_AUTO_CREATE_USER,NO_ENGINE_SUBSTITUTION' */


GO
/****** Object:  StoredProcedure [dbo].[SP_INT_INS_FILA]    Script Date: 20/02/2018 19:01:09 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[SP_INT_INS_FILA](
	@p_integracaoID INT,
	@p_dataCriacao DATETIME ,
	@p_conteudo TEXT,
	@p_chavePrimaria TEXT ,
	@p_chaveSecundaria TEXT ,
	@p_statusID INT,
	@p_logIntegracaoID INT,
	@p_destinoID INT)
AS BEGIN

 INSERT INTO 
    INT_Fila
    (
      INTEGRACAOID,
      DATACRIACAO,
      CONTEUDO,
      CHAVEPRIMARIA,
      CHAVESECUNDARIA,
      STATUSID,
      LOGINTEGRACAOID,
      DESTINOID
    )
    VALUES
    (
      @p_integracaoID,
	  GETDATE(),
      @p_conteudo,
      @p_chavePrimaria,
      @p_chaveSecundaria,
      @p_statusID,
      @p_logIntegracaoID,
      @p_destinoID
    );
    
END ;

/*!50003 SET sql_mode              = @saved_sql_mode */
/*!50003 SET character_set_client  = @saved_cs_client */
/*!50003 SET character_set_results = @saved_cs_results */
/*!50003 SET collation_connection  = @saved_col_connection */
/*!50003 DROP PROCEDURE IF EXISTS SP_INT_INS_LOGFILA */
/*!50003 SET @saved_cs_client      = @@character_set_client */
/*!50003 SET @saved_cs_results     = @@character_set_results */
/*!50003 SET @saved_col_connection = @@collation_connection */
/*!50003 SET character_set_client  = utf8 */
/*!50003 SET character_set_results = utf8 */
/*!50003 SET collation_connection  = utf8_general_ci */
/*!50003 SET @saved_sql_mode       = @@sql_mode */
/*!50003 SET sql_mode              = 'STRICT_TRANS_TABLES,NO_AUTO_CREATE_USER,NO_ENGINE_SUBSTITUTION' */


GO
/****** Object:  StoredProcedure [dbo].[SP_INT_INS_LOGFILA]    Script Date: 20/02/2018 19:01:09 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[SP_INT_INS_LOGFILA]( @p_logIntegracaoID INT ,
  @p_dataCriacao DATETIME,
  @p_conteudo TEXT,
  @p_conteudoFila TEXT,
  @p_chavePrimaria TEXT,
  @p_chaveSecundaria TEXT = null,
  @p_conteudoRetornoSemTratamento text = null,
  @p_conteudoRetorno TEXT = null,  
  @p_filaID INT,
  @p_integracaoID bigint)
AS BEGIN

INSERT INTO  
    INT_LogFila
    (
      LOGINTEGRACAOID,
      DATACRIACAO,
      CONTEUDO,
      CHAVEPRIMARIA,
      CHAVESECUNDARIA,
      CONTEUDORETORNO,
      CONTEUDOFILA,
	  RetornoSemTratamento,
      FilaID,
      IntegracaoID
    )
    VALUES
    (
      @p_logIntegracaoID,
      GETDATE(),
      @p_conteudo,
      @p_chavePrimaria,
      @p_chaveSecundaria,
      @p_conteudoRetorno,
      @p_conteudoFila,
	  @p_conteudoRetornoSemTratamento,
      @p_filaID,
      @p_integracaoID
    );
    
END ;

/*!50003 SET sql_mode              = @saved_sql_mode */
/*!50003 SET character_set_client  = @saved_cs_client */
/*!50003 SET character_set_results = @saved_cs_results */
/*!50003 SET collation_connection  = @saved_col_connection */
/*!50003 DROP PROCEDURE IF EXISTS SP_INT_INS_LOGINTEGRACAO */
/*!50003 SET @saved_cs_client      = @@character_set_client */
/*!50003 SET @saved_cs_results     = @@character_set_results */
/*!50003 SET @saved_col_connection = @@collation_connection */
/*!50003 SET character_set_client  = utf8 */
/*!50003 SET character_set_results = utf8 */
/*!50003 SET collation_connection  = utf8_general_ci */
/*!50003 SET @saved_sql_mode       = @@sql_mode */
/*!50003 SET sql_mode              = 'STRICT_TRANS_TABLES,NO_AUTO_CREATE_USER,NO_ENGINE_SUBSTITUTION' */


GO
/****** Object:  StoredProcedure [dbo].[SP_INT_INS_LOGINTEGRACAO]    Script Date: 20/02/2018 19:01:09 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[SP_INT_INS_LOGINTEGRACAO]( @p_integracaoID INT,
    @p_quantidadeRegistros INT,
    @p_conteudo TEXT,
    @p_dataCriacao DATETIME,
    @p_status INT)
AS BEGIN

INSERT INTO INT_LogIntegracao ( INTEGRACAOID, QTDREGISTROS, CONTEUDO, DATACRIACAO, Status )
    VALUES ( @p_integracaoID, @p_quantidadeRegistros, @p_conteudo, GETDATE(), @p_status);
    
    SELECT @@identity AS INTEGRACAOID;
    
END ;

/*!50003 SET sql_mode              = @saved_sql_mode */
/*!50003 SET character_set_client  = @saved_cs_client */
/*!50003 SET character_set_results = @saved_cs_results */
/*!50003 SET collation_connection  = @saved_col_connection */
/*!50003 DROP PROCEDURE IF EXISTS SP_INT_SEL_CABECALHOSREST */
/*!50003 SET @saved_cs_client      = @@character_set_client */
/*!50003 SET @saved_cs_results     = @@character_set_results */
/*!50003 SET @saved_col_connection = @@collation_connection */
/*!50003 SET character_set_client  = utf8 */
/*!50003 SET character_set_results = utf8 */
/*!50003 SET collation_connection  = utf8_general_ci */
/*!50003 SET @saved_sql_mode       = @@sql_mode */
/*!50003 SET sql_mode              = 'STRICT_TRANS_TABLES,NO_AUTO_CREATE_USER,NO_ENGINE_SUBSTITUTION' */


GO
/****** Object:  StoredProcedure [dbo].[SP_INT_SEL_CABECALHOSREST]    Script Date: 20/02/2018 19:01:09 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[SP_INT_SEL_CABECALHOSREST](@p_interfaceID INT)
AS BEGIN

 select ID, interfaceRestId, Nome, valor from int_cabecalhorest 
 where interfaceRestId = @p_interfaceID;

END ;

/*!50003 SET sql_mode              = @saved_sql_mode */
/*!50003 SET character_set_client  = @saved_cs_client */
/*!50003 SET character_set_results = @saved_cs_results */
/*!50003 SET collation_connection  = @saved_col_connection */
/*!50003 DROP PROCEDURE IF EXISTS SP_INT_SEL_FILA */
/*!50003 SET @saved_cs_client      = @@character_set_client */
/*!50003 SET @saved_cs_results     = @@character_set_results */
/*!50003 SET @saved_col_connection = @@collation_connection */
/*!50003 SET character_set_client  = utf8 */
/*!50003 SET character_set_results = utf8 */
/*!50003 SET collation_connection  = utf8_general_ci */
/*!50003 SET @saved_sql_mode       = @@sql_mode */
/*!50003 SET sql_mode              = 'STRICT_TRANS_TABLES,NO_AUTO_CREATE_USER,NO_ENGINE_SUBSTITUTION' */


GO
/****** Object:  StoredProcedure [dbo].[SP_INT_SEL_EMAIL_DADOS]    Script Date: 20/02/2018 19:01:09 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[SP_INT_SEL_EMAIL_DADOS] AS
BEGIN

  
  SELECT ID, USUARIO, SENHA, SMTP, PORTA, enableSsl, ASSUNTO, [FROM], [TO] FROM int_email;
    

END


GO
/****** Object:  StoredProcedure [dbo].[SP_INT_SEL_EMAIL_ERRO]    Script Date: 20/02/2018 19:01:09 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[SP_INT_SEL_EMAIL_ERRO] AS
BEGIN

  
  SELECT integracao.id,
		   integracao.nome,
           fila.totalErro 
	FROM int_integracao AS integracao
    INNER JOIN(SELECT integracaoid, 
					   COUNT(id) AS totalErro
				FROM int_fila
				WHERE statusId = 2
				GROUP BY integracaoid
				HAVING COUNT(id) >= (SELECT ALERTASREGISTROS
									FROM int_integracao
                                    WHERE ID = int_fila.integracaoid)) AS fila
	ON integracao.id = fila.integracaoid;
    

END


GO
/****** Object:  StoredProcedure [dbo].[SP_INT_SEL_FILA]    Script Date: 20/02/2018 19:01:09 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[SP_INT_SEL_FILA]( @p_DestinoID INT)
AS BEGIN

SELECT
		ID,
		IntegracaoID,
		DataCriacao,
		Conteudo,
		ChavePrimaria,
		ChaveSecundaria,
		StatusID,
		LogIntegracaoID,
		DestinoID
	FROM
		INT_Fila
	WHERE
		DestinoID = @p_DestinoID;    
        
END ;

/*!50003 SET sql_mode              = @saved_sql_mode */
/*!50003 SET character_set_client  = @saved_cs_client */
/*!50003 SET character_set_results = @saved_cs_results */
/*!50003 SET collation_connection  = @saved_col_connection */
/*!50003 DROP PROCEDURE IF EXISTS SP_INT_SEL_FILABYCHAVEPRIMARIA */
/*!50003 SET @saved_cs_client      = @@character_set_client */
/*!50003 SET @saved_cs_results     = @@character_set_results */
/*!50003 SET @saved_col_connection = @@collation_connection */
/*!50003 SET character_set_client  = utf8 */
/*!50003 SET character_set_results = utf8 */
/*!50003 SET collation_connection  = utf8_general_ci */
/*!50003 SET @saved_sql_mode       = @@sql_mode */
/*!50003 SET sql_mode              = 'STRICT_TRANS_TABLES,NO_AUTO_CREATE_USER,NO_ENGINE_SUBSTITUTION' */


GO
/****** Object:  StoredProcedure [dbo].[SP_INT_SEL_FILABYCHAVEPRIMARIA]    Script Date: 20/02/2018 19:01:09 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[SP_INT_SEL_FILABYCHAVEPRIMARIA]( @p_DestinoID INT,
  @p_ChavePrimaria VARCHAR(200),
  @p_chaveSecundaria varchar(200) = null)
AS BEGIN
SELECT TOP 1
		ID,
		IntegracaoID,
		DataCriacao,
		Conteudo,
		ChavePrimaria,
		ChaveSecundaria,
		StatusID,
		LogIntegracaoID,
		DestinoID
	FROM
		INT_Fila
	WHERE
		DestinoID = @p_DestinoID and
		ChavePrimaria = @p_ChavePrimaria and
		(@p_chaveSecundaria is null or ChaveSecundaria = @p_chaveSecundaria)
	ORDER BY ID DESC
END ;

/*!50003 SET sql_mode              = @saved_sql_mode */
/*!50003 SET character_set_client  = @saved_cs_client */
/*!50003 SET character_set_results = @saved_cs_results */
/*!50003 SET collation_connection  = @saved_col_connection */
/*!50003 DROP PROCEDURE IF EXISTS SP_INT_SEL_FILABYDESTINOID */
/*!50003 SET @saved_cs_client      = @@character_set_client */
/*!50003 SET @saved_cs_results     = @@character_set_results */
/*!50003 SET @saved_col_connection = @@collation_connection */
/*!50003 SET character_set_client  = utf8 */
/*!50003 SET character_set_results = utf8 */
/*!50003 SET collation_connection  = utf8_general_ci */
/*!50003 SET @saved_sql_mode       = @@sql_mode */
/*!50003 SET sql_mode              = 'STRICT_TRANS_TABLES,NO_AUTO_CREATE_USER,NO_ENGINE_SUBSTITUTION' */


GO
/****** Object:  StoredProcedure [dbo].[SP_INT_SEL_FILABYDESTINOID]    Script Date: 20/02/2018 19:01:09 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[SP_INT_SEL_FILABYDESTINOID]( @p_DestinoID INT)
AS BEGIN
SELECT
top 3000
		ID,
		IntegracaoID,
		DataCriacao,
		Conteudo,
		ChavePrimaria,
		ChaveSecundaria,
		StatusID,
		LogIntegracaoID,
		DestinoID
	FROM
		INT_Fila
	WHERE
		DestinoID = @p_DestinoID;
END ;

/*!50003 SET sql_mode              = @saved_sql_mode */
/*!50003 SET character_set_client  = @saved_cs_client */
/*!50003 SET character_set_results = @saved_cs_results */
/*!50003 SET collation_connection  = @saved_col_connection */
/*!50003 DROP PROCEDURE IF EXISTS SP_INT_SEL_FILABYINTERFACEID */
/*!50003 SET @saved_cs_client      = @@character_set_client */
/*!50003 SET @saved_cs_results     = @@character_set_results */
/*!50003 SET @saved_col_connection = @@collation_connection */
/*!50003 SET character_set_client  = utf8 */
/*!50003 SET character_set_results = utf8 */
/*!50003 SET collation_connection  = utf8_general_ci */
/*!50003 SET @saved_sql_mode       = @@sql_mode */
/*!50003 SET sql_mode              = 'STRICT_TRANS_TABLES,NO_AUTO_CREATE_USER,NO_ENGINE_SUBSTITUTION' */


GO
/****** Object:  StoredProcedure [dbo].[SP_INT_SEL_FILABYINTERFACEID]    Script Date: 20/02/2018 19:01:09 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[SP_INT_SEL_FILABYINTERFACEID]( @p_IntegracaoID INT)
AS BEGIN
SELECT
		ID,
		IntegracaoID,
		DataCriacao,
		Conteudo,
		ChavePrimaria,
		ChaveSecundaria,
		StatusID,
		LogIntegracaoID,
		DestinoID
	FROM
		INT_Fila
	WHERE
		DestinoID = @p_IntegracaoID and statusid = 1;
END ;

/*!50003 SET sql_mode              = @saved_sql_mode */
/*!50003 SET character_set_client  = @saved_cs_client */
/*!50003 SET character_set_results = @saved_cs_results */
/*!50003 SET collation_connection  = @saved_col_connection */
/*!50003 DROP PROCEDURE IF EXISTS SP_INT_SEL_FILABYSTATUSID */
/*!50003 SET @saved_cs_client      = @@character_set_client */
/*!50003 SET @saved_cs_results     = @@character_set_results */
/*!50003 SET @saved_col_connection = @@collation_connection */
/*!50003 SET character_set_client  = utf8 */
/*!50003 SET character_set_results = utf8 */
/*!50003 SET collation_connection  = utf8_general_ci */
/*!50003 SET @saved_sql_mode       = @@sql_mode */
/*!50003 SET sql_mode              = 'STRICT_TRANS_TABLES,NO_AUTO_CREATE_USER,NO_ENGINE_SUBSTITUTION' */


GO
/****** Object:  StoredProcedure [dbo].[SP_INT_SEL_FILABYSTATUSID]    Script Date: 20/02/2018 19:01:09 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[SP_INT_SEL_FILABYSTATUSID]( @p_DestinoID INT,
  @p_StatusID INT)
AS BEGIN

	DECLARE @limite int;
	SET @limite = (SELECT TOP 1 ContagemTentativa FROM int_integracao WHERE ID = @p_DestinoID)

	SELECT
	top 1000
		ID,
		IntegracaoID,
		DataCriacao,
		Conteudo,
		ChavePrimaria,
		ChaveSecundaria,
		StatusID,
		LogIntegracaoID,
		DestinoID
	FROM
		INT_Fila
	WHERE
		DestinoID = @p_DestinoID
	and ((StatusID = @p_StatusID) OR (@p_StatusID = 1 AND ContagemTentativa < @limite))
	order by ContagemTentativa asc;
END ;


GO
/****** Object:  StoredProcedure [dbo].[SP_INT_SEL_INTEGRACAO]    Script Date: 20/02/2018 19:01:09 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[SP_INT_SEL_INTEGRACAO]
AS BEGIN
		
      SELECT 
		i.ID,
		i.NOME,
		i.INTERFACEID,
		i.ADAPTERID,
		i.STATUS,
		i.EMUSO,
		i.EXECUCAOHORARIOS,
		i.EXECUCAOMINUTOS,
		i.DATAHORAULTIMAEXECUCAO,
		i.DESTINOID,
		i.PKPRIMARIA,
		i.PKSECUNDARIA,
		i.ACAOINICIAL,
		i.ACAOFINAL,
		i.ACAOEnfileiramento,
		i.CONSUMIDOR,
		i.ELEMENTOREGISTRO,
		i.NivelParalelismo
	FROM 
		INT_Integracao  i
	WHERE 
		consumidor=0;
			
	END ;

/*!50003 SET sql_mode              = @saved_sql_mode */
/*!50003 SET character_set_client  = @saved_cs_client */
/*!50003 SET character_set_results = @saved_cs_results */
/*!50003 SET collation_connection  = @saved_col_connection */
/*!50003 DROP PROCEDURE IF EXISTS SP_INT_SEL_INTEGRACAOBYID */
/*!50003 SET @saved_cs_client      = @@character_set_client */
/*!50003 SET @saved_cs_results     = @@character_set_results */
/*!50003 SET @saved_col_connection = @@collation_connection */
/*!50003 SET character_set_client  = utf8 */
/*!50003 SET character_set_results = utf8 */
/*!50003 SET collation_connection  = utf8_general_ci */
/*!50003 SET @saved_sql_mode       = @@sql_mode */
/*!50003 SET sql_mode              = 'STRICT_TRANS_TABLES,NO_AUTO_CREATE_USER,NO_ENGINE_SUBSTITUTION' */


GO
/****** Object:  StoredProcedure [dbo].[SP_INT_SEL_INTEGRACAOBYID]    Script Date: 20/02/2018 19:01:09 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO


CREATE PROCEDURE [dbo].[SP_INT_SEL_INTEGRACAOBYID]( @p_integracaoID INT)
AS BEGIN
SELECT 
		ID,
		NOME,
		INTERFACEID,
		ADAPTERID,
		STATUS,
		EMUSO,
		EXECUCAOHORARIOS,
		EXECUCAOMINUTOS,
		DATAHORAULTIMAEXECUCAO,
		DESTINOID,
		PKPRIMARIA,
		PKSECUNDARIA,
		ACAOINICIAL,
		ACAOFINAL,
		CONSUMIDOR,
		ELEMENTOREGISTRO,
		ACAOENFILEIRAMENTO,
        ACAORETURNOERRO,
		ACAOCABECALHO,
		NODESNAOUTILIZADOS,
		NivelParalelismo
	FROM 
		INT_Integracao  
	WHERE
		ID = @p_integracaoID;
        
END ;

/*!50003 SET sql_mode              = @saved_sql_mode */
/*!50003 SET character_set_client  = @saved_cs_client */
/*!50003 SET character_set_results = @saved_cs_results */
/*!50003 SET collation_connection  = @saved_col_connection */
/*!50003 DROP PROCEDURE IF EXISTS SP_INT_SEL_INTEGRACAOEXECUCAO */
/*!50003 SET @saved_cs_client      = @@character_set_client */
/*!50003 SET @saved_cs_results     = @@character_set_results */
/*!50003 SET @saved_col_connection = @@collation_connection */
/*!50003 SET character_set_client  = utf8 */
/*!50003 SET character_set_results = utf8 */
/*!50003 SET collation_connection  = utf8_general_ci */
/*!50003 SET @saved_sql_mode       = @@sql_mode */
/*!50003 SET sql_mode              = 'STRICT_TRANS_TABLES,NO_AUTO_CREATE_USER,NO_ENGINE_SUBSTITUTION' */




GO
/****** Object:  StoredProcedure [dbo].[SP_INT_SEL_INTEGRACAOEXECUCAO]    Script Date: 20/02/2018 19:01:09 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[SP_INT_SEL_INTEGRACAOEXECUCAO]( @p_consumidor INT)
AS BEGIN
SELECT 
		ID,
		NOME,
		INTERFACEID,
		ADAPTERID,
		STATUS,
		EMUSO,
		EXECUCAOHORARIOS,
		EXECUCAOMINUTOS,
		DATAHORAULTIMAEXECUCAO,
		DESTINOID,
		PKPRIMARIA,
		PKSECUNDARIA,
		ACAOINICIAL,
		ACAOFINAL,
		CONSUMIDOR,
		ELEMENTOREGISTRO,
		ACAOENFILEIRAMENTO,
        ACAORETURNOERRO,
		NivelParalelismo
	FROM 
		INT_Integracao  
	WHERE
		STATUS = 1
		AND EMUSO = 0
		AND CONSUMIDOR = @p_consumidor;
END ;

/*!50003 SET sql_mode              = @saved_sql_mode */
/*!50003 SET character_set_client  = @saved_cs_client */
/*!50003 SET character_set_results = @saved_cs_results */
/*!50003 SET collation_connection  = @saved_col_connection */
/*!50003 DROP PROCEDURE IF EXISTS SP_INT_SEL_INTERFACEBYIDADPID */
/*!50003 SET @saved_cs_client      = @@character_set_client */
/*!50003 SET @saved_cs_results     = @@character_set_results */
/*!50003 SET @saved_col_connection = @@collation_connection */
/*!50003 SET character_set_client  = utf8 */
/*!50003 SET character_set_results = utf8 */
/*!50003 SET collation_connection  = utf8_general_ci */
/*!50003 SET @saved_sql_mode       = @@sql_mode */
/*!50003 SET sql_mode              = 'STRICT_TRANS_TABLES,NO_AUTO_CREATE_USER,NO_ENGINE_SUBSTITUTION' */


GO
/****** Object:  StoredProcedure [dbo].[SP_INT_SEL_IntegracaoExecucaoIDS]    Script Date: 20/02/2018 19:01:09 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE procedure [dbo].[SP_INT_SEL_IntegracaoExecucaoIDS]
(
	@p_consumidor bit
)
AS
BEGIN

	SELECT id as id FROM int_integracao
	WHERE status = 1 AND (@p_consumidor IS NULL OR CONSUMIDOR = @p_consumidor)
	ORDER BY datahoraultimaexecucao asc

END

GO
/****** Object:  StoredProcedure [dbo].[SP_INT_SEL_IntegracaoParaExecutar]    Script Date: 20/02/2018 19:01:09 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO


CREATE procedure [dbo].[SP_INT_SEL_IntegracaoParaExecutar]
(
	@p_integracaoID int
)
AS
BEGIN
	
	set xact_abort on
	begin transaction

	 SELECT 
         int_integracao.ID, 
         int_integracao.NOME, 
         int_integracao.INTERFACEID, 
         int_integracao.ADAPTERID, 
         int_integracao.STATUS, 
         int_integracao.EMUSO, 
         int_integracao.EXECUCAOHORARIOS, 
         int_integracao.EXECUCAOMINUTOS, 
         int_integracao.DATAHORAULTIMAEXECUCAO, 
         int_integracao.DESTINOID, 
         int_integracao.PKPRIMARIA, 
         int_integracao.PKSECUNDARIA, 
         int_integracao.ACAOINICIAL, 
         int_integracao.ACAOFINAL, 
         int_integracao.CONSUMIDOR, 
         int_integracao.ELEMENTOREGISTRO, 
         int_integracao.ACAOENFILEIRAMENTO, 
         int_integracao.ACAORETURNOERRO,
		 int_integracao.ACAOCABECALHO,
		 int_integracao.NODESNAOUTILIZADOS,
		 int_integracao.NivelParalelismo
      FROM dbo.int_integracao WITH (HOLDLOCK XLOCK ROWLOCK)
      WHERE int_integracao.ID = @p_integracaoID
	    and int_integracao.STATUS = 1
		and int_integracao.EMUSO = 0

	update int_integracao set emuso = 1 where id = @p_integracaoID

	commit transaction
END



GO
/****** Object:  StoredProcedure [dbo].[SP_INT_SEL_INTERFACEBYIDADPID]    Script Date: 20/02/2018 19:01:09 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[SP_INT_SEL_INTERFACEBYIDADPID]( @p_adapterID INT,
  @p_interfaceID INT)
AS BEGIN
    IF @p_adapterID = 1 -- WEB SERVICE
      SELECT ID, NOME, SISTEMAID, URL, LOGIN, SENHA, METODO, ACTION FROM INT_InterfaceWebService WHERE ID = @p_interfaceID;
	ELSE IF @p_adapterID = 2    -- BANCO DE DADOS
      SELECT ID, NOME, SISTEMAID, CONNECTIONSTRING, STOREDPROCEDURE, DATABASENAMEFACTORY FROM INT_InterfaceDB WHERE ID = @p_interfaceID;   
    ELSE IF @p_adapterID= 3  -- ARQUIVO TEXTO
      SELECT ID, NOME, SISTEMAID, FTP, LOGIN, SENHA, URL, DELIMITADOR, DIRETORIO, ENCODING FROM INT_InterfaceArquivoTexto WHERE ID = @p_interfaceID ;
    ELSE IF @p_adapterID =4 
	  select Id, Nome, SIstemaID, Url, Login, Senha, VerboHttpId, TipoAutenticacaoID, ReturnRootElementPai, ReturnRootElementLista, ContentType, ContentTypeId from int_InterfaceRest WHERE ID = @p_interfaceID;
END ;

/*!50003 SET sql_mode              = @saved_sql_mode */
/*!50003 SET character_set_client  = @saved_cs_client */
/*!50003 SET character_set_results = @saved_cs_results */
/*!50003 SET collation_connection  = @saved_col_connection */
/*!50003 DROP PROCEDURE IF EXISTS SP_INT_SEL_LOGFILA */
/*!50003 SET @saved_cs_client      = @@character_set_client */
/*!50003 SET @saved_cs_results     = @@character_set_results */
/*!50003 SET @saved_col_connection = @@collation_connection */
/*!50003 SET character_set_client  = utf8 */
/*!50003 SET character_set_results = utf8 */
/*!50003 SET collation_connection  = utf8_general_ci */
/*!50003 SET @saved_sql_mode       = @@sql_mode */
/*!50003 SET sql_mode              = 'STRICT_TRANS_TABLES,NO_AUTO_CREATE_USER,NO_ENGINE_SUBSTITUTION' */


GO
/****** Object:  StoredProcedure [dbo].[SP_INT_SEL_LOGFILA]    Script Date: 20/02/2018 19:01:09 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[SP_INT_SEL_LOGFILA]( @p_IntegracaoID INT)
AS BEGIN
SELECT f.ID,
		f.LOGINTEGRACAOID,
		f.DATACRIACAO,
		f.CONTEUDO,
		f.CHAVEPRIMARIA,
		f.CHAVESECUNDARIA,
		f.CONTEUDOFILA,
		f.CONTEUDORETORNO,
		f.FilaID
	FROM 
		INT_LOGFILA f
		INNER JOIN INT_FILA fi on fi.id = f.filaid
	WHERE 
		fi.INTEGRACAOID = @p_INTEGRACAOID and fi.statusid = 2
		AND (f.CONTEUDO IS NOT NULL or f.CONTEUDOFILA IS NOT NULL or f.CONTEUDORETORNO IS NOT NULL);
END ;

/*!50003 SET sql_mode              = @saved_sql_mode */
/*!50003 SET character_set_client  = @saved_cs_client */
/*!50003 SET character_set_results = @saved_cs_results */
/*!50003 SET collation_connection  = @saved_col_connection */
/*!50003 DROP PROCEDURE IF EXISTS SP_INT_SEL_LOGINTEGRACAO */
/*!50003 SET @saved_cs_client      = @@character_set_client */
/*!50003 SET @saved_cs_results     = @@character_set_results */
/*!50003 SET @saved_col_connection = @@collation_connection */
/*!50003 SET character_set_client  = utf8 */
/*!50003 SET character_set_results = utf8 */
/*!50003 SET collation_connection  = utf8_general_ci */
/*!50003 SET @saved_sql_mode       = @@sql_mode */
/*!50003 SET sql_mode              = 'STRICT_TRANS_TABLES,NO_AUTO_CREATE_USER,NO_ENGINE_SUBSTITUTION' */


GO
/****** Object:  StoredProcedure [dbo].[SP_INT_SEL_LOGINTEGRACAO]    Script Date: 20/02/2018 19:01:09 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[SP_INT_SEL_LOGINTEGRACAO]( @p_IntegracaoID INT)
AS BEGIN
SELECT TOP 1
		li.ID,
		li.INTEGRACAOID,
		li.QTDREGISTROS,
		li.CONTEUDO,
		li.DATACRIACAO,
		Li.Status
	FROM 
		INT_LOGINTEGRACAO li
	WHERE 
		li.IntegracaoID = @p_IntegracaoID
	ORDER BY DataCriacao desc
END ;

/*!50003 SET sql_mode              = @saved_sql_mode */
/*!50003 SET character_set_client  = @saved_cs_client */
/*!50003 SET character_set_results = @saved_cs_results */
/*!50003 SET collation_connection  = @saved_col_connection */
/*!50003 DROP PROCEDURE IF EXISTS SP_INT_SEL_LOGINTEGRACAOQTD */
/*!50003 SET @saved_cs_client      = @@character_set_client */
/*!50003 SET @saved_cs_results     = @@character_set_results */
/*!50003 SET @saved_col_connection = @@collation_connection */
/*!50003 SET character_set_client  = utf8 */
/*!50003 SET character_set_results = utf8 */
/*!50003 SET collation_connection  = utf8_general_ci */
/*!50003 SET @saved_sql_mode       = @@sql_mode */
/*!50003 SET sql_mode              = 'STRICT_TRANS_TABLES,NO_AUTO_CREATE_USER,NO_ENGINE_SUBSTITUTION' */


GO
/****** Object:  StoredProcedure [dbo].[SP_INT_SEL_LOGINTEGRACAOQTD]    Script Date: 20/02/2018 19:01:09 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[SP_INT_SEL_LOGINTEGRACAOQTD](@p_IntegracaoID INT)
AS BEGIN
SELECT TOP 1
		li.ID,
		li.INTEGRACAOID,
		li.QTDREGISTROS,
		li.CONTEUDO,
		li.DATACRIACAO,
		Li.Status
	FROM 
		INT_LOGINTEGRACAO li
	WHERE 
		li.IntegracaoID = @p_IntegracaoID 
		AND li.qtdregistros > 0 /*AND length(conteudo) > 500*/
        AND li.ID in (82236, 82929)
	ORDER BY DataCriacao DESC
END ;

/*!50003 SET sql_mode              = @saved_sql_mode */
/*!50003 SET character_set_client  = @saved_cs_client */
/*!50003 SET character_set_results = @saved_cs_results */
/*!50003 SET collation_connection  = @saved_col_connection */
/*!50003 DROP PROCEDURE IF EXISTS SP_INT_SEL_MAPBYFILHOID */
/*!50003 SET @saved_cs_client      = @@character_set_client */
/*!50003 SET @saved_cs_results     = @@character_set_results */
/*!50003 SET @saved_col_connection = @@collation_connection */
/*!50003 SET character_set_client  = utf8 */
/*!50003 SET character_set_results = utf8 */
/*!50003 SET collation_connection  = utf8_general_ci */
/*!50003 SET @saved_sql_mode       = @@sql_mode */
/*!50003 SET sql_mode              = 'STRICT_TRANS_TABLES,NO_AUTO_CREATE_USER,NO_ENGINE_SUBSTITUTION' */


GO
/****** Object:  StoredProcedure [dbo].[SP_INT_SEL_MAPBYFILHOID]    Script Date: 20/02/2018 19:01:09 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[SP_INT_SEL_MAPBYFILHOID]( @p_PaiID INT)
AS BEGIN
SELECT
		ID,
		INTEGRACAOID,
		DE,
		PARA,
		VALOR,
		MULTI,
		PAIID,
		CONFIGURACAO,
		TIPOVALOR,
		ACAO,
        VALORDEPARA,
        BitQueryString,
        BitMapRetorno,
        ValorDePara,
        BITXMLENTRADA,
        BITEXCLUIRBRANCO
	FROM
		INT_Mapeamento
	WHERE
		PaiID = @p_PaiID;
END ;

/*!50003 SET sql_mode              = @saved_sql_mode */
/*!50003 SET character_set_client  = @saved_cs_client */
/*!50003 SET character_set_results = @saved_cs_results */
/*!50003 SET collation_connection  = @saved_col_connection */
/*!50003 DROP PROCEDURE IF EXISTS SP_INT_SEL_MAPBYINTEGRACAOID */
/*!50003 SET @saved_cs_client      = @@character_set_client */
/*!50003 SET @saved_cs_results     = @@character_set_results */
/*!50003 SET @saved_col_connection = @@collation_connection */
/*!50003 SET character_set_client  = utf8 */
/*!50003 SET character_set_results = utf8 */
/*!50003 SET collation_connection  = utf8_general_ci */
/*!50003 SET @saved_sql_mode       = @@sql_mode */
/*!50003 SET sql_mode              = 'STRICT_TRANS_TABLES,NO_AUTO_CREATE_USER,NO_ENGINE_SUBSTITUTION' */


GO
/****** Object:  StoredProcedure [dbo].[SP_INT_SEL_MAPBYINTEGRACAOID]    Script Date: 20/02/2018 19:01:09 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[SP_INT_SEL_MAPBYINTEGRACAOID]( @p_integracaoID INT)
AS BEGIN
SELECT
		ID,
		INTEGRACAOID,
		DE,
		PARA,
		VALOR,
		MULTI,
		PAIID,
		CONFIGURACAO,
		TIPOVALOR,
		ACAO,
		VALORDEPARA,
        BitQueryString,
        BitMapRetorno,
        ValorDePara,
        BITXMLENTRADA,
        BITEXCLUIRBRANCO,
		ELEMENTOMULT
	FROM
		INT_Mapeamento
	WHERE
		INTEGRACAOID = @p_integracaoID;
END ;

/*!50003 SET sql_mode              = @saved_sql_mode */
/*!50003 SET character_set_client  = @saved_cs_client */
/*!50003 SET character_set_results = @saved_cs_results */
/*!50003 SET collation_connection  = @saved_col_connection */
/*!50003 DROP PROCEDURE IF EXISTS SP_INT_SEL_MAPEAMENTODEPARA */
/*!50003 SET @saved_cs_client      = @@character_set_client */
/*!50003 SET @saved_cs_results     = @@character_set_results */
/*!50003 SET @saved_col_connection = @@collation_connection */
/*!50003 SET character_set_client  = utf8 */
/*!50003 SET character_set_results = utf8 */
/*!50003 SET collation_connection  = utf8_general_ci */
/*!50003 SET @saved_sql_mode       = @@sql_mode */
/*!50003 SET sql_mode              = 'STRICT_TRANS_TABLES,NO_AUTO_CREATE_USER,NO_ENGINE_SUBSTITUTION' */



GO
/****** Object:  StoredProcedure [dbo].[SP_INT_SEL_MAPEAMENTODEPARA]    Script Date: 20/02/2018 19:01:09 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[SP_INT_SEL_MAPEAMENTODEPARA](@p_MapeamentoID INT )
AS BEGIN
SELECT 
		ID, DE, PARA, MAPEAMENTOID, INFOS_ADICIONAIS, INTEGRACAOID 
	FROM 
		INT_MAPEAMENTODEPARA 
	WHERE 
		mapeamentoid = @p_MapeamentoID ;
END ;

/*!50003 SET sql_mode              = @saved_sql_mode */
/*!50003 SET character_set_client  = @saved_cs_client */
/*!50003 SET character_set_results = @saved_cs_results */
/*!50003 SET collation_connection  = @saved_col_connection */
/*!50003 DROP PROCEDURE IF EXISTS SP_INT_SEL_MAPEAMENTODEPARAINT */
/*!50003 SET @saved_cs_client      = @@character_set_client */
/*!50003 SET @saved_cs_results     = @@character_set_results */
/*!50003 SET @saved_col_connection = @@collation_connection */
/*!50003 SET character_set_client  = utf8 */
/*!50003 SET character_set_results = utf8 */
/*!50003 SET collation_connection  = utf8_general_ci */
/*!50003 SET @saved_sql_mode       = @@sql_mode */
/*!50003 SET sql_mode              = 'STRICT_TRANS_TABLES,NO_AUTO_CREATE_USER,NO_ENGINE_SUBSTITUTION' */


GO
/****** Object:  StoredProcedure [dbo].[SP_INT_SEL_MAPEAMENTODEPARAINT]    Script Date: 20/02/2018 19:01:09 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[SP_INT_SEL_MAPEAMENTODEPARAINT]( @p_IntegracaoId INT )
AS BEGIN
	SELECT 
		ID, DE, PARA, MAPEAMENTOID, INFOS_ADICIONAIS, INTEGRACAOID 
	FROM 
		INT_MAPEAMENTODEPARA 
	WHERE 
		integracaoid = @p_IntegracaoID ;
END ;

/*!50003 SET sql_mode              = @saved_sql_mode */
/*!50003 SET character_set_client  = @saved_cs_client */
/*!50003 SET character_set_results = @saved_cs_results */
/*!50003 SET collation_connection  = @saved_col_connection */
/*!50003 DROP PROCEDURE IF EXISTS SP_INT_SEL_PARADBBYINTERID */
/*!50003 SET @saved_cs_client      = @@character_set_client */
/*!50003 SET @saved_cs_results     = @@character_set_results */
/*!50003 SET @saved_col_connection = @@collation_connection */
/*!50003 SET character_set_client  = utf8 */
/*!50003 SET character_set_results = utf8 */
/*!50003 SET collation_connection  = utf8_general_ci */
/*!50003 SET @saved_sql_mode       = @@sql_mode */
/*!50003 SET sql_mode              = 'STRICT_TRANS_TABLES,NO_AUTO_CREATE_USER,NO_ENGINE_SUBSTITUTION' */


GO
/****** Object:  StoredProcedure [dbo].[SP_INT_SEL_PARADBBYINTERID]    Script Date: 20/02/2018 19:01:09 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[SP_INT_SEL_PARADBBYINTERID](@p_interfaceID INT )
AS BEGIN
SELECT
		ID,
		INTERFACEDBID,
		DE,
		PARA,
		RETORNO,
		PAIID
	FROM
		INT_PARAMETRODB
	WHERE
		INTERFACEDBID = @p_interfaceID;
END ;

/*!50003 SET sql_mode              = @saved_sql_mode */
/*!50003 SET character_set_client  = @saved_cs_client */
/*!50003 SET character_set_results = @saved_cs_results */
/*!50003 SET collation_connection  = @saved_col_connection */
/*!50003 DROP PROCEDURE IF EXISTS SP_INT_SEL_PARAWSBYINTERID */
/*!50003 SET @saved_cs_client      = @@character_set_client */
/*!50003 SET @saved_cs_results     = @@character_set_results */
/*!50003 SET @saved_col_connection = @@collation_connection */
/*!50003 SET character_set_client  = utf8 */
/*!50003 SET character_set_results = utf8 */
/*!50003 SET collation_connection  = utf8_general_ci */
/*!50003 SET @saved_sql_mode       = @@sql_mode */
/*!50003 SET sql_mode              = 'STRICT_TRANS_TABLES,NO_AUTO_CREATE_USER,NO_ENGINE_SUBSTITUTION' */


GO
/****** Object:  StoredProcedure [dbo].[SP_INT_SEL_PARAWSBYINTERID]    Script Date: 20/02/2018 19:01:09 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[SP_INT_SEL_PARAWSBYINTERID](@p_interfaceID INT )
AS BEGIN
SELECT
		ID,
		INTERFACEWEBSERVICEID,
		DE,
		PARA,
		RETORNO,
		PAIID
	FROM
		INT_PARAMETROWEBSERVICE
	WHERE
		INTERFACEWEBSERVICEID = @p_interfaceID;
END ;

/*!50003 SET sql_mode              = @saved_sql_mode */
/*!50003 SET character_set_client  = @saved_cs_client */
/*!50003 SET character_set_results = @saved_cs_results */
/*!50003 SET collation_connection  = @saved_col_connection */
/*!50003 DROP PROCEDURE IF EXISTS SP_INT_SEL_QTDERROS */
/*!50003 SET @saved_cs_client      = @@character_set_client */
/*!50003 SET @saved_cs_results     = @@character_set_results */
/*!50003 SET @saved_col_connection = @@collation_connection */
/*!50003 SET character_set_client  = utf8 */
/*!50003 SET character_set_results = utf8 */
/*!50003 SET collation_connection  = utf8_general_ci */
/*!50003 SET @saved_sql_mode       = @@sql_mode */
/*!50003 SET sql_mode              = 'STRICT_TRANS_TABLES,NO_AUTO_CREATE_USER,NO_ENGINE_SUBSTITUTION' */


GO
/****** Object:  StoredProcedure [dbo].[SP_INT_SEL_QTDERROS]    Script Date: 20/02/2018 19:01:09 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[SP_INT_SEL_QTDERROS](@p_IntegracaoID INT  )
AS BEGIN
SELECT 
		F.FILAID  LOGINTEGRACAO
	FROM 
		INT_LOGFILA f
		INNER JOIN INT_FILA fi on fi.id = f.filaid
	WHERE 
		fi.INTEGRACAOID = @p_IntegracaoID and fi.statusid = 2
		AND (f.CONTEUDO IS NOT NULL or f.CONTEUDOFILA IS NOT NULL or f.CONTEUDORETORNO IS NOT NULL)
	GROUP BY f.filaid;
END ;

/*!50003 SET sql_mode              = @saved_sql_mode */
/*!50003 SET character_set_client  = @saved_cs_client */
/*!50003 SET character_set_results = @saved_cs_results */
/*!50003 SET collation_connection  = @saved_col_connection */
/*!50003 DROP PROCEDURE IF EXISTS SP_INT_UP_EMUSOBYINTEGRACAOID */
/*!50003 SET @saved_cs_client      = @@character_set_client */
/*!50003 SET @saved_cs_results     = @@character_set_results */
/*!50003 SET @saved_col_connection = @@collation_connection */
/*!50003 SET character_set_client  = utf8 */
/*!50003 SET character_set_results = utf8 */
/*!50003 SET collation_connection  = utf8_general_ci */
/*!50003 SET @saved_sql_mode       = @@sql_mode */
/*!50003 SET sql_mode              = 'STRICT_TRANS_TABLES,NO_AUTO_CREATE_USER,NO_ENGINE_SUBSTITUTION' */


GO
/****** Object:  StoredProcedure [dbo].[SP_INT_UP_EMUSOBYINTEGRACAOID]    Script Date: 20/02/2018 19:01:09 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[SP_INT_UP_EMUSOBYINTEGRACAOID]( @p_EmUso INT,
													@p_integracaoID INT)
AS BEGIN
UPDATE
		INT_Integracao
		SET EmUso = @p_EmUso
	WHERE
		ID = @p_integracaoID;
END ;

/*!50003 SET sql_mode              = @saved_sql_mode */
/*!50003 SET character_set_client  = @saved_cs_client */
/*!50003 SET character_set_results = @saved_cs_results */
/*!50003 SET collation_connection  = @saved_col_connection */
/*!50003 DROP PROCEDURE IF EXISTS SP_INT_UP_FILABYSTATUSID */
/*!50003 SET @saved_cs_client      = @@character_set_client */
/*!50003 SET @saved_cs_results     = @@character_set_results */
/*!50003 SET @saved_col_connection = @@collation_connection */
/*!50003 SET character_set_client  = utf8 */
/*!50003 SET character_set_results = utf8 */
/*!50003 SET collation_connection  = utf8_general_ci */
/*!50003 SET @saved_sql_mode       = @@sql_mode */
/*!50003 SET sql_mode              = 'STRICT_TRANS_TABLES,NO_AUTO_CREATE_USER,NO_ENGINE_SUBSTITUTION' */


GO
/****** Object:  StoredProcedure [dbo].[SP_INT_UP_FILABYDESTINOID]    Script Date: 20/02/2018 19:01:09 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[SP_INT_UP_FILABYDESTINOID]( @p_destinoID INT,
  @p_filaID INT)
AS BEGIN
UPDATE
		INT_Fila
		SET DestinoId = @p_destinoID, StatusId = 1
	WHERE
		ID = @p_filaID;
END ;

/*!50003 SET sql_mode              = @saved_sql_mode */
/*!50003 SET character_set_client  = @saved_cs_client */
/*!50003 SET character_set_results = @saved_cs_results */
/*!50003 SET collation_connection  = @saved_col_connection */
/*!50003 DROP PROCEDURE IF EXISTS SP_INT_UP_HORABYINTEGRACAOID */
/*!50003 SET @saved_cs_client      = @@character_set_client */
/*!50003 SET @saved_cs_results     = @@character_set_results */
/*!50003 SET @saved_col_connection = @@collation_connection */
/*!50003 SET character_set_client  = utf8 */
/*!50003 SET character_set_results = utf8 */
/*!50003 SET collation_connection  = utf8_general_ci */
/*!50003 SET @saved_sql_mode       = @@sql_mode */
/*!50003 SET sql_mode              = 'STRICT_TRANS_TABLES,NO_AUTO_CREATE_USER,NO_ENGINE_SUBSTITUTION' */


GO
/****** Object:  StoredProcedure [dbo].[SP_INT_UP_FILABYSTATUSID]    Script Date: 20/02/2018 19:01:09 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[SP_INT_UP_FILABYSTATUSID]( @p_statusID INT,
  @p_filaID INT)
AS BEGIN
	UPDATE INT_Fila
	SET StatusID = @p_statusID,
		ContagemTentativa = ContagemTentativa + 1
	WHERE ID = @p_filaID;
END;


GO
/****** Object:  StoredProcedure [dbo].[SP_INT_UP_HORABYINTEGRACAOID]    Script Date: 20/02/2018 19:01:09 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[SP_INT_UP_HORABYINTEGRACAOID]( @p_integracaoID INT,
  @p_hora DATETIME)
AS BEGIN
UPDATE
		INT_INTEGRACAO
		SET datahoraultimaexecucao = @p_hora
	WHERE
		ID = @p_integracaoID;
END ;

/*!50003 SET sql_mode              = @saved_sql_mode */
/*!50003 SET character_set_client  = @saved_cs_client */
/*!50003 SET character_set_results = @saved_cs_results */
/*!50003 SET collation_connection  = @saved_col_connection */
/*!50003 DROP PROCEDURE IF EXISTS SP_INT_UP_MAPEAMENTOVALORRETORNO */
/*!50003 SET @saved_cs_client      = @@character_set_client */
/*!50003 SET @saved_cs_results     = @@character_set_results */
/*!50003 SET @saved_col_connection = @@collation_connection */
/*!50003 SET character_set_client  = utf8 */
/*!50003 SET character_set_results = utf8 */
/*!50003 SET collation_connection  = utf8_general_ci */
/*!50003 SET @saved_sql_mode       = @@sql_mode */
/*!50003 SET sql_mode              = 'STRICT_TRANS_TABLES,NO_AUTO_CREATE_USER,NO_ENGINE_SUBSTITUTION' */


GO
/****** Object:  StoredProcedure [dbo].[SP_INT_UP_MAPEAMENTOVALORRETORNO]    Script Date: 20/02/2018 19:01:09 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[SP_INT_UP_MAPEAMENTOVALORRETORNO](@p_ID int, @p_VALOR Text)
AS BEGIN

update int_mapeamento set valor = @p_VALOR where id = @p_ID;

END ;


GO
/****** Object:  StoredProcedure [dbo].[SP_INT_UPD_ZerarFlagsEmUso]    Script Date: 20/02/2018 19:01:09 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[SP_INT_UPD_ZerarFlagsEmUso]
AS
BEGIN

	UPDATE int_integracao
	SET emUso = 0
	WHERE status = 1

END

GO
USE [master]
GO
ALTER DATABASE [SeliaIntegradorProfitHomolog] SET  READ_WRITE 
GO


