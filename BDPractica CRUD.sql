create database Practica
go
use Practica

create table Productos 
(
Id int identity (1,1) primary key,
Nombre nvarchar (100),
Descripcion nvarchar (100),
Marca nvarchar (100),
Precio float,
Stock int
)

insert into Productos 
values
('Gaseosa','3 litros','marcacola',7.5,24),
('Chocolate','Tableta 100 gramos','iberica',12.5,36),
('Leche','1/2 litro','vacalola',2.3,12),
('Agua','1.5 litros','aguapura',1.0,10),
('Cereal','Caja 500 gramos','crunchy',4.5,30),
('Pan','Bolsa 400 gramos','panadero',2.0,15),
('Jugo','1 litro','frutal',3.5,20),
('Arroz','Paquete 1 kg','arrozdelcampo',2.8,18),
('Galletas','Paquete 200 gramos','dulcinea',3.0,25),
('Yogur','Envase 200 gramos','cremoso',1.8,14),
('Aceite','Botella 1 litro','oleo',5.0,28),
('Sal','Paquete 1 kg','salmarina',0.5,5),
('Pasta','Paquete 500 gramos','pastalinda',1.5,22),
('Zumo','1 litro','natural',4.0,22),
('Mantequilla','Tarrina 250 gramos','cremosita',3.2,16),
('Queso','Cuña 200 gramos','quesodelicioso',5.5,40),
('Sopa','Lata 400 gramos','sopasabrosa',2.0,12),
('Té','Caja 20 bolsas','teverde',3.0,18),
('Café','Paquete 250 gramos','cafetero',6.0,35),
('Frutos secos','Bolsa 200 gramos','nutrimix',8.0,50),
('Gelatina','Paquete 85 gramos','gelatina',1.0,8),
('Mermelada','Tarro 300 gramos','mermelada',3.5,20),
('Puré de tomate','Lata 400 gramos','tomate',1.2,10),
('Pescado','Filete 300 gramos','mariscos',7.0,45),
('Carne','Filete 500 gramos','carniceria',9.0,60),
('Pollo','Pechuga 400 gramos','pollosano',8.5,55),
('Verduras congeladas','Paquete 1 kg','verdurita',3.0,20),
('Fruta','Bolsa 1 kg','frutal',4.5,30),
('Helado','Tarrina 500 gramos','heladito',5.0,25),
('Guiso','Lata 500 gramos','guisosabroso',3.0,15),
('Salsa','Botella 300 gramos','salsita',2.5,14),
('Pimientos','Paquete 500 gramos','pimiento',2.0,12),
('Cebolla','Bolsa 1 kg','cebolla',1.5,10),
('Ajo','Cabeza 200 gramos','ajo',1.2,5),
('Especias','Frasco 100 gramos','especiero',4.0,20),
('Vino','Botella 750 ml','vinotinto',10.0,75),
('Cerveza','Lata 355 ml','cervecita',2.0,12),
('Champú','Botella 400 ml','cuidadocapilar',6.0,30),
('Jabón','Barra 200 gramos','jabonsuave',1.0,8),
('Detergente','Botella 1 litro','limpieza',4.5,25),
('Pañuelos','Paquete 100 unidades','pañuelos',2.0,10),
('Bolsas','Paquete 50 unidades','bolsas',1.5,6),
('Cinta adhesiva','Rollo 25 metros','cinta',2.5,12),
('Cuaderno','Tamaño A4','papeleria',3.0,15),
('Lápiz','Paquete 10 unidades','escritura',1.0,5)


SELECT * FROM Productos



---PROCEDIMIENTOS ALMACENADOS 

----------------------------MOSTRAR 
--create proc MostrarProductos
--as
--select * from Productos
--go

--exec MostrarProductos


----------------------------INSERTAR 
--create proc InsetarProductos
--@nombre nvarchar (100),
--@descrip nvarchar (100),
--@marca nvarchar (100),
--@precio float,
--@stock int
--as
--insert into Productos values (@nombre,@descrip,@marca,@precio,@stock)
--go

--exec MostrarProductos
--exec Insertar

--------------------------ELIMINAR
--create proc EliminarProducto
--@idpro int
--as
--delete from Productos where Id=@idpro
--go

--------------------EDITAR

--create proc EditarProductos
--@nombre nvarchar (100),
--@descrip nvarchar (100),
--@marca nvarchar (100),
--@precio float,
--@stock int,
--@id int
--as
--update Productos set Nombre=@nombre, Descripcion=@descrip, Marca=@marca, Precio=@precio, Stock=@stock where Id=@id
--go

--exec MostrarProductos 
----exec EditarProductos('Gaseosa','3 litros','marcacola',7.5,24),



--------------------BUSCAR

--CREATE PROCEDURE BuscarProductos
--@buscar NVARCHAR(100)
--AS
--BEGIN
--    SELECT * 
--    FROM Productos
--    WHERE Nombre LIKE '%' + @buscar + '%' 
--       OR Descripcion LIKE '%' + @buscar + '%'
--       OR Marca LIKE '%' + @buscar + '%';
--END
--GO




-- Mostrar productos
--MMMMMM? CNProductos
CREATE PROCEDURE MostrarProductos 
AS
BEGIN
    SELECT * FROM Productos;
END
GO

-- Insertar producto
CREATE PROCEDURE InsertarProductos
@nombre NVARCHAR(100),
@descrip NVARCHAR(100),
@marca NVARCHAR(100),
@precio FLOAT,
@stock INT
AS
BEGIN
    INSERT INTO Productos (Nombre, Descripcion, Marca, Precio, Stock)
    VALUES (@nombre, @descrip, @marca, @precio, @stock);
END
GO

-- Editar producto
CREATE PROCEDURE EditarProductos
@nombre NVARCHAR(100),
@descrip NVARCHAR(100),
@marca NVARCHAR(100),
@precio FLOAT,
@stock INT,
@id INT
AS
BEGIN
    UPDATE Productos 
    SET Nombre = @nombre, Descripcion = @descrip, Marca = @marca, Precio = @precio, Stock = @stock 
    WHERE Id = @id;
END
GO

-- Eliminar producto
CREATE PROCEDURE EliminarProducto
@idpro INT
AS
BEGIN
    DELETE FROM Productos WHERE Id = @idpro;
END
GO

--------------------------ELIMINAR
--create proc EliminarProducto
--@idpro int
--as
--delete from Productos where Id=@idpro
--go


-- Buscar productos
CREATE PROCEDURE BuscarProductos
@buscar NVARCHAR(100)
AS
BEGIN
    SELECT * FROM Productos
    WHERE Nombre LIKE '%' + @buscar + '%' 
       OR Descripcion LIKE '%' + @buscar + '%'
       OR Marca LIKE '%' + @buscar + '%';
END
GO

