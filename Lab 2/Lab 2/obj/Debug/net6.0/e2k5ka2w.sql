IF OBJECT_ID(N'[__EFMigrationsHistory]') IS NULL
BEGIN
    CREATE TABLE [__EFMigrationsHistory] (
        [MigrationId] nvarchar(150) NOT NULL,
        [ProductVersion] nvarchar(32) NOT NULL,
        CONSTRAINT [PK___EFMigrationsHistory] PRIMARY KEY ([MigrationId])
    );
END;
GO

BEGIN TRANSACTION;
GO

CREATE TABLE [departments] (
    [Id] int NOT NULL IDENTITY,
    [Name] nvarchar(max) NOT NULL,
    CONSTRAINT [PK_departments] PRIMARY KEY ([Id])
);
GO

CREATE TABLE [developers] (
    [Id] int NOT NULL IDENTITY,
    [Name] nvarchar(max) NOT NULL,
    CONSTRAINT [PK_developers] PRIMARY KEY ([Id])
);
GO

CREATE TABLE [Tickets] (
    [Id] int NOT NULL IDENTITY,
    [Description] nvarchar(max) NOT NULL,
    [Title] nvarchar(max) NOT NULL,
    [DepartmentId] int NOT NULL,
    CONSTRAINT [PK_Tickets] PRIMARY KEY ([Id]),
    CONSTRAINT [FK_Tickets_departments_DepartmentId] FOREIGN KEY ([DepartmentId]) REFERENCES [departments] ([Id]) ON DELETE CASCADE
);
GO

CREATE TABLE [DeveloperTicket] (
    [DevelopersId] int NOT NULL,
    [TicketsId] int NOT NULL,
    CONSTRAINT [PK_DeveloperTicket] PRIMARY KEY ([DevelopersId], [TicketsId]),
    CONSTRAINT [FK_DeveloperTicket_Tickets_TicketsId] FOREIGN KEY ([TicketsId]) REFERENCES [Tickets] ([Id]) ON DELETE CASCADE,
    CONSTRAINT [FK_DeveloperTicket_developers_DevelopersId] FOREIGN KEY ([DevelopersId]) REFERENCES [developers] ([Id]) ON DELETE CASCADE
);
GO

CREATE INDEX [IX_DeveloperTicket_TicketsId] ON [DeveloperTicket] ([TicketsId]);
GO

CREATE INDEX [IX_Tickets_DepartmentId] ON [Tickets] ([DepartmentId]);
GO

INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
VALUES (N'20230522011805_InitialCreate', N'7.0.5');
GO

COMMIT;
GO

