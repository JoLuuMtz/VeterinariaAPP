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
IF NOT EXISTS (
    SELECT * FROM [__EFMigrationsHistory]
    WHERE [MigrationId] = N'20251031045258_InitialCreate'
)
BEGIN
    CREATE TABLE [Clientes] (
        [Id] int NOT NULL IDENTITY,
        [Direccion] nvarchar(200) NOT NULL,
        [FechaRegistro] datetime2 NOT NULL,
        [Nombre] nvarchar(100) NOT NULL,
        [Apellido] nvarchar(100) NOT NULL,
        [Telefono] nvarchar(20) NOT NULL,
        [Email] nvarchar(100) NOT NULL,
        [DocumentoIdentidad] nvarchar(20) NOT NULL,
        [Activo] bit NOT NULL,
        CONSTRAINT [PK_Clientes] PRIMARY KEY ([Id])
    );
END;

IF NOT EXISTS (
    SELECT * FROM [__EFMigrationsHistory]
    WHERE [MigrationId] = N'20251031045258_InitialCreate'
)
BEGIN
    CREATE TABLE [Veterinarios] (
        [Id] int NOT NULL IDENTITY,
        [NumeroLicencia] nvarchar(50) NOT NULL,
        [Especialidad] nvarchar(100) NOT NULL,
        [FechaContratacion] datetime2 NOT NULL,
        [Nombre] nvarchar(100) NOT NULL,
        [Apellido] nvarchar(100) NOT NULL,
        [Telefono] nvarchar(20) NOT NULL,
        [Email] nvarchar(100) NOT NULL,
        [DocumentoIdentidad] nvarchar(20) NOT NULL,
        [Activo] bit NOT NULL,
        CONSTRAINT [PK_Veterinarios] PRIMARY KEY ([Id])
    );
END;

IF NOT EXISTS (
    SELECT * FROM [__EFMigrationsHistory]
    WHERE [MigrationId] = N'20251031045258_InitialCreate'
)
BEGIN
    CREATE TABLE [Mascotas] (
        [Id] int NOT NULL IDENTITY,
        [Nombre] nvarchar(100) NOT NULL,
        [Especie] nvarchar(50) NOT NULL,
        [Raza] nvarchar(100) NOT NULL,
        [FechaNacimiento] datetime2 NOT NULL,
        [Sexo] nvarchar(10) NOT NULL,
        [Color] nvarchar(50) NOT NULL,
        [Peso] decimal(18,2) NOT NULL,
        [Observaciones] nvarchar(500) NOT NULL,
        [Activo] bit NOT NULL,
        [ClienteId] int NOT NULL,
        CONSTRAINT [PK_Mascotas] PRIMARY KEY ([Id]),
        CONSTRAINT [FK_Mascotas_Clientes_ClienteId] FOREIGN KEY ([ClienteId]) REFERENCES [Clientes] ([Id]) ON DELETE CASCADE
    );
END;

IF NOT EXISTS (
    SELECT * FROM [__EFMigrationsHistory]
    WHERE [MigrationId] = N'20251031045258_InitialCreate'
)
BEGIN
    CREATE TABLE [Citas] (
        [Id] int NOT NULL IDENTITY,
        [FechaHora] datetime2 NOT NULL,
        [Estado] nvarchar(50) NOT NULL,
        [Motivo] nvarchar(500) NOT NULL,
        [Observaciones] nvarchar(1000) NOT NULL,
        [MascotaId] int NOT NULL,
        [VeterinarioId] int NOT NULL,
        CONSTRAINT [PK_Citas] PRIMARY KEY ([Id]),
        CONSTRAINT [FK_Citas_Mascotas_MascotaId] FOREIGN KEY ([MascotaId]) REFERENCES [Mascotas] ([Id]) ON DELETE CASCADE,
        CONSTRAINT [FK_Citas_Veterinarios_VeterinarioId] FOREIGN KEY ([VeterinarioId]) REFERENCES [Veterinarios] ([Id]) ON DELETE CASCADE
    );
END;

IF NOT EXISTS (
    SELECT * FROM [__EFMigrationsHistory]
    WHERE [MigrationId] = N'20251031045258_InitialCreate'
)
BEGIN
    CREATE TABLE [HistorialesMedicos] (
        [Id] int NOT NULL IDENTITY,
        [Fecha] datetime2 NOT NULL,
        [TipoConsulta] nvarchar(100) NOT NULL,
        [Diagnostico] nvarchar(2000) NOT NULL,
        [Tratamiento] nvarchar(2000) NOT NULL,
        [Observaciones] nvarchar(1000) NOT NULL,
        [PesoRegistrado] decimal(18,2) NOT NULL,
        [Temperatura] nvarchar(100) NOT NULL,
        [MascotaId] int NOT NULL,
        [VeterinarioId] int NOT NULL,
        CONSTRAINT [PK_HistorialesMedicos] PRIMARY KEY ([Id]),
        CONSTRAINT [FK_HistorialesMedicos_Mascotas_MascotaId] FOREIGN KEY ([MascotaId]) REFERENCES [Mascotas] ([Id]) ON DELETE CASCADE,
        CONSTRAINT [FK_HistorialesMedicos_Veterinarios_VeterinarioId] FOREIGN KEY ([VeterinarioId]) REFERENCES [Veterinarios] ([Id]) ON DELETE CASCADE
    );
END;

IF NOT EXISTS (
    SELECT * FROM [__EFMigrationsHistory]
    WHERE [MigrationId] = N'20251031045258_InitialCreate'
)
BEGIN
    CREATE TABLE [Medicamentos] (
        [Id] int NOT NULL IDENTITY,
        [Nombre] nvarchar(200) NOT NULL,
        [Descripcion] nvarchar(500) NOT NULL,
        [Dosis] nvarchar(100) NOT NULL,
        [Frecuencia] nvarchar(100) NOT NULL,
        [DuracionDias] int NOT NULL,
        [HistorialMedicoId] int NOT NULL,
        CONSTRAINT [PK_Medicamentos] PRIMARY KEY ([Id]),
        CONSTRAINT [FK_Medicamentos_HistorialesMedicos_HistorialMedicoId] FOREIGN KEY ([HistorialMedicoId]) REFERENCES [HistorialesMedicos] ([Id]) ON DELETE CASCADE
    );
END;

IF NOT EXISTS (
    SELECT * FROM [__EFMigrationsHistory]
    WHERE [MigrationId] = N'20251031045258_InitialCreate'
)
BEGIN
    CREATE INDEX [IX_Citas_MascotaId] ON [Citas] ([MascotaId]);
END;

IF NOT EXISTS (
    SELECT * FROM [__EFMigrationsHistory]
    WHERE [MigrationId] = N'20251031045258_InitialCreate'
)
BEGIN
    CREATE INDEX [IX_Citas_VeterinarioId] ON [Citas] ([VeterinarioId]);
END;

IF NOT EXISTS (
    SELECT * FROM [__EFMigrationsHistory]
    WHERE [MigrationId] = N'20251031045258_InitialCreate'
)
BEGIN
    CREATE INDEX [IX_HistorialesMedicos_MascotaId] ON [HistorialesMedicos] ([MascotaId]);
END;

IF NOT EXISTS (
    SELECT * FROM [__EFMigrationsHistory]
    WHERE [MigrationId] = N'20251031045258_InitialCreate'
)
BEGIN
    CREATE INDEX [IX_HistorialesMedicos_VeterinarioId] ON [HistorialesMedicos] ([VeterinarioId]);
END;

IF NOT EXISTS (
    SELECT * FROM [__EFMigrationsHistory]
    WHERE [MigrationId] = N'20251031045258_InitialCreate'
)
BEGIN
    CREATE INDEX [IX_Mascotas_ClienteId] ON [Mascotas] ([ClienteId]);
END;

IF NOT EXISTS (
    SELECT * FROM [__EFMigrationsHistory]
    WHERE [MigrationId] = N'20251031045258_InitialCreate'
)
BEGIN
    CREATE INDEX [IX_Medicamentos_HistorialMedicoId] ON [Medicamentos] ([HistorialMedicoId]);
END;

IF NOT EXISTS (
    SELECT * FROM [__EFMigrationsHistory]
    WHERE [MigrationId] = N'20251031045258_InitialCreate'
)
BEGIN
    INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
    VALUES (N'20251031045258_InitialCreate', N'9.0.10');
END;

IF NOT EXISTS (
    SELECT * FROM [__EFMigrationsHistory]
    WHERE [MigrationId] = N'20251031050703_Migration2'
)
BEGIN
    DECLARE @var sysname;
    SELECT @var = [d].[name]
    FROM [sys].[default_constraints] [d]
    INNER JOIN [sys].[columns] [c] ON [d].[parent_column_id] = [c].[column_id] AND [d].[parent_object_id] = [c].[object_id]
    WHERE ([d].[parent_object_id] = OBJECT_ID(N'[Mascotas]') AND [c].[name] = N'Peso');
    IF @var IS NOT NULL EXEC(N'ALTER TABLE [Mascotas] DROP CONSTRAINT [' + @var + '];');
    ALTER TABLE [Mascotas] ALTER COLUMN [Peso] decimal(10,2) NOT NULL;
END;

IF NOT EXISTS (
    SELECT * FROM [__EFMigrationsHistory]
    WHERE [MigrationId] = N'20251031050703_Migration2'
)
BEGIN
    DECLARE @var1 sysname;
    SELECT @var1 = [d].[name]
    FROM [sys].[default_constraints] [d]
    INNER JOIN [sys].[columns] [c] ON [d].[parent_column_id] = [c].[column_id] AND [d].[parent_object_id] = [c].[object_id]
    WHERE ([d].[parent_object_id] = OBJECT_ID(N'[HistorialesMedicos]') AND [c].[name] = N'PesoRegistrado');
    IF @var1 IS NOT NULL EXEC(N'ALTER TABLE [HistorialesMedicos] DROP CONSTRAINT [' + @var1 + '];');
    ALTER TABLE [HistorialesMedicos] ALTER COLUMN [PesoRegistrado] decimal(10,2) NOT NULL;
END;

IF NOT EXISTS (
    SELECT * FROM [__EFMigrationsHistory]
    WHERE [MigrationId] = N'20251031050703_Migration2'
)
BEGIN
    INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
    VALUES (N'20251031050703_Migration2', N'9.0.10');
END;

IF NOT EXISTS (
    SELECT * FROM [__EFMigrationsHistory]
    WHERE [MigrationId] = N'20251104023013_OpcionalClientInMascota'
)
BEGIN
    ALTER TABLE [Mascotas] DROP CONSTRAINT [FK_Mascotas_Clientes_ClienteId];
END;

IF NOT EXISTS (
    SELECT * FROM [__EFMigrationsHistory]
    WHERE [MigrationId] = N'20251104023013_OpcionalClientInMascota'
)
BEGIN
    DECLARE @var2 sysname;
    SELECT @var2 = [d].[name]
    FROM [sys].[default_constraints] [d]
    INNER JOIN [sys].[columns] [c] ON [d].[parent_column_id] = [c].[column_id] AND [d].[parent_object_id] = [c].[object_id]
    WHERE ([d].[parent_object_id] = OBJECT_ID(N'[Mascotas]') AND [c].[name] = N'ClienteId');
    IF @var2 IS NOT NULL EXEC(N'ALTER TABLE [Mascotas] DROP CONSTRAINT [' + @var2 + '];');
    ALTER TABLE [Mascotas] ALTER COLUMN [ClienteId] int NULL;
END;

IF NOT EXISTS (
    SELECT * FROM [__EFMigrationsHistory]
    WHERE [MigrationId] = N'20251104023013_OpcionalClientInMascota'
)
BEGIN
    ALTER TABLE [Mascotas] ADD CONSTRAINT [FK_Mascotas_Clientes_ClienteId] FOREIGN KEY ([ClienteId]) REFERENCES [Clientes] ([Id]);
END;

IF NOT EXISTS (
    SELECT * FROM [__EFMigrationsHistory]
    WHERE [MigrationId] = N'20251104023013_OpcionalClientInMascota'
)
BEGIN
    INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
    VALUES (N'20251104023013_OpcionalClientInMascota', N'9.0.10');
END;

IF NOT EXISTS (
    SELECT * FROM [__EFMigrationsHistory]
    WHERE [MigrationId] = N'20251107042339_LastOneMigrations'
)
BEGIN
    CREATE UNIQUE INDEX [IX_Veterinarios_DocumentoIdentidad_Unique] ON [Veterinarios] ([DocumentoIdentidad]);
END;

IF NOT EXISTS (
    SELECT * FROM [__EFMigrationsHistory]
    WHERE [MigrationId] = N'20251107042339_LastOneMigrations'
)
BEGIN
    EXEC(N'CREATE UNIQUE INDEX [IX_Veterinarios_Email_Unique] ON [Veterinarios] ([Email]) WHERE [Email] IS NOT NULL AND [Email] != ''''');
END;

IF NOT EXISTS (
    SELECT * FROM [__EFMigrationsHistory]
    WHERE [MigrationId] = N'20251107042339_LastOneMigrations'
)
BEGIN
    EXEC(N'CREATE UNIQUE INDEX [IX_Veterinarios_NumeroLicencia_Unique] ON [Veterinarios] ([NumeroLicencia]) WHERE [NumeroLicencia] IS NOT NULL AND [NumeroLicencia] != ''''');
END;

IF NOT EXISTS (
    SELECT * FROM [__EFMigrationsHistory]
    WHERE [MigrationId] = N'20251107042339_LastOneMigrations'
)
BEGIN
    EXEC(N'CREATE UNIQUE INDEX [IX_Veterinarios_Telefono_Unique] ON [Veterinarios] ([Telefono]) WHERE [Telefono] IS NOT NULL AND [Telefono] != ''''');
END;

IF NOT EXISTS (
    SELECT * FROM [__EFMigrationsHistory]
    WHERE [MigrationId] = N'20251107042339_LastOneMigrations'
)
BEGIN
    CREATE UNIQUE INDEX [IX_Clientes_DocumentoIdentidad_Unique] ON [Clientes] ([DocumentoIdentidad]);
END;

IF NOT EXISTS (
    SELECT * FROM [__EFMigrationsHistory]
    WHERE [MigrationId] = N'20251107042339_LastOneMigrations'
)
BEGIN
    EXEC(N'CREATE UNIQUE INDEX [IX_Clientes_Email_Unique] ON [Clientes] ([Email]) WHERE [Email] IS NOT NULL AND [Email] != ''''');
END;

IF NOT EXISTS (
    SELECT * FROM [__EFMigrationsHistory]
    WHERE [MigrationId] = N'20251107042339_LastOneMigrations'
)
BEGIN
    EXEC(N'CREATE UNIQUE INDEX [IX_Clientes_Telefono_Unique] ON [Clientes] ([Telefono]) WHERE [Telefono] IS NOT NULL AND [Telefono] != ''''');
END;

IF NOT EXISTS (
    SELECT * FROM [__EFMigrationsHistory]
    WHERE [MigrationId] = N'20251107042339_LastOneMigrations'
)
BEGIN
    INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
    VALUES (N'20251107042339_LastOneMigrations', N'9.0.10');
END;

COMMIT;
GO

