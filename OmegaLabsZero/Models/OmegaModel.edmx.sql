
-- Warning: There were errors validating the existing SSDL. Drop statements
-- will not be generated.
-- --------------------------------------------------
-- Entity Designer DDL Script for SQL Server 2005, 2008, and Azure
-- --------------------------------------------------
-- Date Created: 02/12/2014 23:40:21
-- Generated from EDMX file: C:\Users\MárioEugênio\Desktop\OmegaLabsZero\OmegaLabsZero\Models\OmegaModel.edmx
-- --------------------------------------------------

SET QUOTED_IDENTIFIER OFF;
GO
USE [Omegalabs];
GO
IF SCHEMA_ID(N'dbo') IS NULL EXECUTE(N'CREATE SCHEMA [dbo]');
GO

-- --------------------------------------------------
-- Dropping existing FOREIGN KEY constraints
-- --------------------------------------------------


-- --------------------------------------------------
-- Dropping existing tables
-- --------------------------------------------------


-- --------------------------------------------------
-- Creating all tables
-- --------------------------------------------------

-- Creating table 'CID_CIDADE'
CREATE TABLE [dbo].[CID_CIDADE] (
    [CID_ID] int IDENTITY(1,1) NOT NULL,
    [CID_NOME] varchar(150)  NOT NULL
);
GO

-- Creating table 'CON_CONCURSO'
CREATE TABLE [dbo].[CON_CONCURSO] (
    [CON_ID] int IDENTITY(1,1) NOT NULL,
    [CON_NOME] varchar(255)  NOT NULL,
    [STA_ID] int  NOT NULL,
    [CID_ID] int  NOT NULL,
    [EST_ID] int  NOT NULL
);
GO

-- Creating table 'EST_ESTADO'
CREATE TABLE [dbo].[EST_ESTADO] (
    [EST_ID] int IDENTITY(1,1) NOT NULL,
    [EST_NOME] varchar(150)  NOT NULL
);
GO

-- Creating table 'FAQ_PERGUNTAS'
CREATE TABLE [dbo].[FAQ_PERGUNTAS] (
    [FAQ_ID] int IDENTITY(1,1) NOT NULL,
    [FAQ_TITULO] varchar(255)  NOT NULL,
    [FAQ_PERGUNTA] varchar(max)  NOT NULL,
    [FAQ_RESPOSTA] varchar(max)  NOT NULL,
    [STA_ID] int  NOT NULL
);
GO

-- Creating table 'NOT_NOTICIA'
CREATE TABLE [dbo].[NOT_NOTICIA] (
    [NOT_ID] int IDENTITY(1,1) NOT NULL,
    [NOT_TITULO] varchar(255)  NOT NULL,
    [NOT_PREVIA] varchar(255)  NOT NULL,
    [NOT_TEXTO] varchar(max)  NOT NULL,
    [NOT_INCLUSAO] datetime  NOT NULL,
    [NOT_ALTERACAO] datetime  NULL,
    [NOT_PUBICACAO] datetime  NULL,
    [STA_ID] int  NOT NULL
);
GO

-- Creating table 'STA_STATUS'
CREATE TABLE [dbo].[STA_STATUS] (
    [STA_ID] int IDENTITY(1,1) NOT NULL,
    [STA_NOME] varchar(150)  NOT NULL
);
GO

-- Creating table 'SUB_SUBSTANCIA'
CREATE TABLE [dbo].[SUB_SUBSTANCIA] (
    [SUB_ID] int IDENTITY(1,1) NOT NULL,
    [STA_ID] int  NOT NULL,
    [SUB_NOME] varchar(255)  NOT NULL,
    [DER_ID] int  NULL,
    [SUB_DETALHES] varchar(max)  NULL
);
GO

-- Creating table 'USR_USUARIO'
CREATE TABLE [dbo].[USR_USUARIO] (
    [USR_ID] int IDENTITY(1,1) NOT NULL,
    [USR_NOME] varchar(150)  NOT NULL,
    [USR_EMAIL] varchar(200)  NOT NULL,
    [USR_SENHA] varchar(100)  NOT NULL,
    [STA_ID] int  NOT NULL
);
GO

-- --------------------------------------------------
-- Creating all PRIMARY KEY constraints
-- --------------------------------------------------

-- Creating primary key on [CID_ID] in table 'CID_CIDADE'
ALTER TABLE [dbo].[CID_CIDADE]
ADD CONSTRAINT [PK_CID_CIDADE]
    PRIMARY KEY CLUSTERED ([CID_ID] ASC);
GO

-- Creating primary key on [CON_ID] in table 'CON_CONCURSO'
ALTER TABLE [dbo].[CON_CONCURSO]
ADD CONSTRAINT [PK_CON_CONCURSO]
    PRIMARY KEY CLUSTERED ([CON_ID] ASC);
GO

-- Creating primary key on [EST_ID] in table 'EST_ESTADO'
ALTER TABLE [dbo].[EST_ESTADO]
ADD CONSTRAINT [PK_EST_ESTADO]
    PRIMARY KEY CLUSTERED ([EST_ID] ASC);
GO

-- Creating primary key on [FAQ_ID] in table 'FAQ_PERGUNTAS'
ALTER TABLE [dbo].[FAQ_PERGUNTAS]
ADD CONSTRAINT [PK_FAQ_PERGUNTAS]
    PRIMARY KEY CLUSTERED ([FAQ_ID] ASC);
GO

-- Creating primary key on [NOT_ID] in table 'NOT_NOTICIA'
ALTER TABLE [dbo].[NOT_NOTICIA]
ADD CONSTRAINT [PK_NOT_NOTICIA]
    PRIMARY KEY CLUSTERED ([NOT_ID] ASC);
GO

-- Creating primary key on [STA_ID] in table 'STA_STATUS'
ALTER TABLE [dbo].[STA_STATUS]
ADD CONSTRAINT [PK_STA_STATUS]
    PRIMARY KEY CLUSTERED ([STA_ID] ASC);
GO

-- Creating primary key on [SUB_ID] in table 'SUB_SUBSTANCIA'
ALTER TABLE [dbo].[SUB_SUBSTANCIA]
ADD CONSTRAINT [PK_SUB_SUBSTANCIA]
    PRIMARY KEY CLUSTERED ([SUB_ID] ASC);
GO

-- Creating primary key on [USR_ID] in table 'USR_USUARIO'
ALTER TABLE [dbo].[USR_USUARIO]
ADD CONSTRAINT [PK_USR_USUARIO]
    PRIMARY KEY CLUSTERED ([USR_ID] ASC);
GO

-- --------------------------------------------------
-- Creating all FOREIGN KEY constraints
-- --------------------------------------------------

-- Creating foreign key on [CID_ID] in table 'CON_CONCURSO'
ALTER TABLE [dbo].[CON_CONCURSO]
ADD CONSTRAINT [FK_CON_CONC_REFERENCE_CID_CIDA]
    FOREIGN KEY ([CID_ID])
    REFERENCES [dbo].[CID_CIDADE]
        ([CID_ID])
    ON DELETE NO ACTION ON UPDATE NO ACTION;

-- Creating non-clustered index for FOREIGN KEY 'FK_CON_CONC_REFERENCE_CID_CIDA'
CREATE INDEX [IX_FK_CON_CONC_REFERENCE_CID_CIDA]
ON [dbo].[CON_CONCURSO]
    ([CID_ID]);
GO

-- Creating foreign key on [EST_ID] in table 'CON_CONCURSO'
ALTER TABLE [dbo].[CON_CONCURSO]
ADD CONSTRAINT [FK_CON_CONC_REFERENCE_EST_ESTA]
    FOREIGN KEY ([EST_ID])
    REFERENCES [dbo].[EST_ESTADO]
        ([EST_ID])
    ON DELETE NO ACTION ON UPDATE NO ACTION;

-- Creating non-clustered index for FOREIGN KEY 'FK_CON_CONC_REFERENCE_EST_ESTA'
CREATE INDEX [IX_FK_CON_CONC_REFERENCE_EST_ESTA]
ON [dbo].[CON_CONCURSO]
    ([EST_ID]);
GO

-- Creating foreign key on [STA_ID] in table 'CON_CONCURSO'
ALTER TABLE [dbo].[CON_CONCURSO]
ADD CONSTRAINT [FK_CON_CONC_REFERENCE_STA_STAT]
    FOREIGN KEY ([STA_ID])
    REFERENCES [dbo].[STA_STATUS]
        ([STA_ID])
    ON DELETE NO ACTION ON UPDATE NO ACTION;

-- Creating non-clustered index for FOREIGN KEY 'FK_CON_CONC_REFERENCE_STA_STAT'
CREATE INDEX [IX_FK_CON_CONC_REFERENCE_STA_STAT]
ON [dbo].[CON_CONCURSO]
    ([STA_ID]);
GO

-- Creating foreign key on [STA_ID] in table 'FAQ_PERGUNTAS'
ALTER TABLE [dbo].[FAQ_PERGUNTAS]
ADD CONSTRAINT [FK_FAQ_PERG_REFERENCE_STA_STAT]
    FOREIGN KEY ([STA_ID])
    REFERENCES [dbo].[STA_STATUS]
        ([STA_ID])
    ON DELETE NO ACTION ON UPDATE NO ACTION;

-- Creating non-clustered index for FOREIGN KEY 'FK_FAQ_PERG_REFERENCE_STA_STAT'
CREATE INDEX [IX_FK_FAQ_PERG_REFERENCE_STA_STAT]
ON [dbo].[FAQ_PERGUNTAS]
    ([STA_ID]);
GO

-- Creating foreign key on [STA_ID] in table 'NOT_NOTICIA'
ALTER TABLE [dbo].[NOT_NOTICIA]
ADD CONSTRAINT [FK_NOT_NOTI_REFERENCE_STA_STAT]
    FOREIGN KEY ([STA_ID])
    REFERENCES [dbo].[STA_STATUS]
        ([STA_ID])
    ON DELETE NO ACTION ON UPDATE NO ACTION;

-- Creating non-clustered index for FOREIGN KEY 'FK_NOT_NOTI_REFERENCE_STA_STAT'
CREATE INDEX [IX_FK_NOT_NOTI_REFERENCE_STA_STAT]
ON [dbo].[NOT_NOTICIA]
    ([STA_ID]);
GO

-- Creating foreign key on [STA_ID] in table 'SUB_SUBSTANCIA'
ALTER TABLE [dbo].[SUB_SUBSTANCIA]
ADD CONSTRAINT [FK_SUB_SUBS_REFERENCE_STA_STAT]
    FOREIGN KEY ([STA_ID])
    REFERENCES [dbo].[STA_STATUS]
        ([STA_ID])
    ON DELETE NO ACTION ON UPDATE NO ACTION;

-- Creating non-clustered index for FOREIGN KEY 'FK_SUB_SUBS_REFERENCE_STA_STAT'
CREATE INDEX [IX_FK_SUB_SUBS_REFERENCE_STA_STAT]
ON [dbo].[SUB_SUBSTANCIA]
    ([STA_ID]);
GO

-- Creating foreign key on [STA_ID] in table 'USR_USUARIO'
ALTER TABLE [dbo].[USR_USUARIO]
ADD CONSTRAINT [FK_USR_USUA_REFERENCE_STA_STAT]
    FOREIGN KEY ([STA_ID])
    REFERENCES [dbo].[STA_STATUS]
        ([STA_ID])
    ON DELETE NO ACTION ON UPDATE NO ACTION;

-- Creating non-clustered index for FOREIGN KEY 'FK_USR_USUA_REFERENCE_STA_STAT'
CREATE INDEX [IX_FK_USR_USUA_REFERENCE_STA_STAT]
ON [dbo].[USR_USUARIO]
    ([STA_ID]);
GO

-- --------------------------------------------------
-- Script has ended
-- --------------------------------------------------