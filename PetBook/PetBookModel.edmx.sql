
-- --------------------------------------------------
-- Entity Designer DDL Script for SQL Server 2005, 2008, 2012 and Azure
-- --------------------------------------------------
-- Date Created: 12/08/2016 15:35:24
-- Generated from EDMX file: C:\Users\Chris\documents\visual studio 2015\Projects\PetBook\PetBook\PetBookModel.edmx
-- --------------------------------------------------

SET QUOTED_IDENTIFIER OFF;
GO
USE [PetBookDatabase];
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

-- Creating table 'Veterinarians'
CREATE TABLE [dbo].[Veterinarians] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [Name] nvarchar(max)  NOT NULL,
    [Address] nvarchar(max)  NOT NULL,
    [Age] int  NOT NULL,
    [Gender] bit  NOT NULL,
    [Location] nvarchar(max)  NOT NULL,
    [Email] nvarchar(max)  NOT NULL,
    [PhoneNumber] int  NOT NULL,
    [Username] nvarchar(max)  NOT NULL,
    [Password] nvarchar(max)  NOT NULL,
    [NameOfBusiness] nvarchar(max)  NOT NULL
);
GO

-- Creating table 'Customers'
CREATE TABLE [dbo].[Customers] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [Name] nvarchar(max)  NOT NULL,
    [VeterinarianId] int  NOT NULL,
    [Address] nvarchar(max)  NOT NULL,
    [Age] int  NOT NULL,
    [PhoneNumber] nvarchar(max)  NOT NULL,
    [Email] nvarchar(max)  NOT NULL,
    [Gender] bit  NOT NULL
);
GO

-- Creating table 'Pets'
CREATE TABLE [dbo].[Pets] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [Name] nvarchar(max)  NOT NULL,
    [Type] nvarchar(max)  NOT NULL,
    [Breed] nvarchar(max)  NOT NULL,
    [Age] int  NOT NULL,
    [Size] int  NOT NULL,
    [Weight] int  NOT NULL,
    [IsAggressive] bit  NOT NULL,
    [OnMed] bit  NOT NULL,
    [StartDate] datetime  NOT NULL,
    [VisitsPerYear] int  NOT NULL,
    [IsHealthy] bit  NOT NULL,
    [CustomerId] int  NOT NULL,
    [Gender] bit  NOT NULL
);
GO

-- Creating table 'Profiles'
CREATE TABLE [dbo].[Profiles] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [NotesOfVisit] nvarchar(max)  NOT NULL,
    [PetId] int  NOT NULL
);
GO

-- Creating table 'Appointments'
CREATE TABLE [dbo].[Appointments] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [Date] datetime  NOT NULL,
    [IsFirstVisit] bit  NOT NULL,
    [VeterinarianId] int  NOT NULL,
    [CustomerId] int  NOT NULL
);
GO

-- --------------------------------------------------
-- Creating all PRIMARY KEY constraints
-- --------------------------------------------------

-- Creating primary key on [Id] in table 'Veterinarians'
ALTER TABLE [dbo].[Veterinarians]
ADD CONSTRAINT [PK_Veterinarians]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'Customers'
ALTER TABLE [dbo].[Customers]
ADD CONSTRAINT [PK_Customers]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'Pets'
ALTER TABLE [dbo].[Pets]
ADD CONSTRAINT [PK_Pets]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'Profiles'
ALTER TABLE [dbo].[Profiles]
ADD CONSTRAINT [PK_Profiles]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'Appointments'
ALTER TABLE [dbo].[Appointments]
ADD CONSTRAINT [PK_Appointments]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- --------------------------------------------------
-- Creating all FOREIGN KEY constraints
-- --------------------------------------------------

-- Creating foreign key on [VeterinarianId] in table 'Customers'
ALTER TABLE [dbo].[Customers]
ADD CONSTRAINT [FK_VeterinarianCustomer]
    FOREIGN KEY ([VeterinarianId])
    REFERENCES [dbo].[Veterinarians]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_VeterinarianCustomer'
CREATE INDEX [IX_FK_VeterinarianCustomer]
ON [dbo].[Customers]
    ([VeterinarianId]);
GO

-- Creating foreign key on [VeterinarianId] in table 'Appointments'
ALTER TABLE [dbo].[Appointments]
ADD CONSTRAINT [FK_VeterinarianAppointment]
    FOREIGN KEY ([VeterinarianId])
    REFERENCES [dbo].[Veterinarians]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_VeterinarianAppointment'
CREATE INDEX [IX_FK_VeterinarianAppointment]
ON [dbo].[Appointments]
    ([VeterinarianId]);
GO

-- Creating foreign key on [CustomerId] in table 'Appointments'
ALTER TABLE [dbo].[Appointments]
ADD CONSTRAINT [FK_CustomerAppointment]
    FOREIGN KEY ([CustomerId])
    REFERENCES [dbo].[Customers]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_CustomerAppointment'
CREATE INDEX [IX_FK_CustomerAppointment]
ON [dbo].[Appointments]
    ([CustomerId]);
GO

-- Creating foreign key on [CustomerId] in table 'Pets'
ALTER TABLE [dbo].[Pets]
ADD CONSTRAINT [FK_CustomerPet]
    FOREIGN KEY ([CustomerId])
    REFERENCES [dbo].[Customers]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_CustomerPet'
CREATE INDEX [IX_FK_CustomerPet]
ON [dbo].[Pets]
    ([CustomerId]);
GO

-- Creating foreign key on [PetId] in table 'Profiles'
ALTER TABLE [dbo].[Profiles]
ADD CONSTRAINT [FK_PetProfile]
    FOREIGN KEY ([PetId])
    REFERENCES [dbo].[Pets]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_PetProfile'
CREATE INDEX [IX_FK_PetProfile]
ON [dbo].[Profiles]
    ([PetId]);
GO

-- --------------------------------------------------
-- Script has ended
-- --------------------------------------------------