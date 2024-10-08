USE [Problema15]
GO
/****** Object:  Table [dbo].[Articulos]    Script Date: 10/09/2024 20:30:48 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Articulos](
	[id_articulo] [int] IDENTITY(1,1) NOT NULL,
	[nombre] [varchar](50) NULL,
	[precio] [money] NULL,
 CONSTRAINT [pk_id_articulo] PRIMARY KEY CLUSTERED 
(
	[id_articulo] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Detalles]    Script Date: 10/09/2024 20:30:48 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Detalles](
	[id_detalle] [int] IDENTITY(1,1) NOT NULL,
	[id_articulo] [int] NULL,
	[cantidad] [int] NULL,
 CONSTRAINT [pk] PRIMARY KEY CLUSTERED 
(
	[id_detalle] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Facturas]    Script Date: 10/09/2024 20:30:48 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Facturas](
	[id_factura] [int] IDENTITY(1,1) NOT NULL,
	[fecha] [datetime] NULL,
	[id_forma_pago] [int] NULL,
	[cliente] [varchar](50) NULL,
 CONSTRAINT [pk_id_factura] PRIMARY KEY CLUSTERED 
(
	[id_factura] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Forma_Pago]    Script Date: 10/09/2024 20:30:48 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Forma_Pago](
	[id_forma_pago] [int] IDENTITY(1,1) NOT NULL,
	[tipo] [varchar](50) NULL,
 CONSTRAINT [pk_id_forma_pago] PRIMARY KEY CLUSTERED 
(
	[id_forma_pago] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
ALTER TABLE [dbo].[Detalles]  WITH CHECK ADD  CONSTRAINT [fk_id_articulo] FOREIGN KEY([id_articulo])
REFERENCES [dbo].[Articulos] ([id_articulo])
GO
ALTER TABLE [dbo].[Detalles] CHECK CONSTRAINT [fk_id_articulo]
GO
ALTER TABLE [dbo].[Facturas]  WITH CHECK ADD  CONSTRAINT [fk_id_forma_pago] FOREIGN KEY([id_forma_pago])
REFERENCES [dbo].[Forma_Pago] ([id_forma_pago])
GO
ALTER TABLE [dbo].[Facturas] CHECK CONSTRAINT [fk_id_forma_pago]
GO
/****** Object:  StoredProcedure [dbo].[borrar_articulo]    Script Date: 10/09/2024 20:30:48 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create procedure [dbo].[borrar_articulo]
@id_articulo int
as 
begin
delete from Articulos
where id_articulo= @id_articulo;
end
GO
/****** Object:  StoredProcedure [dbo].[Crear_articulo]    Script Date: 10/09/2024 20:30:48 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create procedure [dbo].[Crear_articulo]
@id_articulo int output,
@nombre varchar(50),
@precio money
as 
begin
insert into Articulos(nombre,precio)values(@nombre,@precio);set @id_articulo=scope_identity();
end
GO
/****** Object:  StoredProcedure [dbo].[Crear_Factura]    Script Date: 10/09/2024 20:30:48 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[Crear_Factura]
@id_factura int,
@fecha datetime,
@id_forma_pago int,
@cliente varchar (50)
as 
begin
insert into Facturas(fecha,cliente)values(@fecha,@cliente);set @id_factura=scope_identity();
end
GO
/****** Object:  StoredProcedure [dbo].[Obtener_articulos]    Script Date: 10/09/2024 20:30:48 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create procedure [dbo].[Obtener_articulos]
as
begin
select id_articulo,nombre,precio
from Articulos
end
GO
/****** Object:  StoredProcedure [dbo].[Obtener_Facturas]    Script Date: 10/09/2024 20:30:48 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create procedure [dbo].[Obtener_Facturas]
as
begin
select id_factura,fecha,id_forma_pago,cliente
from Facturas
end
GO
