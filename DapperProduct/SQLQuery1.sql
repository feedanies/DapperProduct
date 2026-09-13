CREATE DATABASE ProductDB
GO
USE ProductDB
GO

CREATE TABLE Products(
[Id] INT PRIMARY KEY IDENTITY(1,1),
[Name] NVARCHAR(100) NOT NULL,
[Price] DECIMAL(18,2) NOT NULL,
[Quantity] INT NOT NULL,
[Description] NVARCHAR(500)
)

GO

INSERT INTO Products([Name],[Price],[Quantity],[Description])
VALUES	('Wireless Mouse', 15.99, 120, 'Ergonomic wireless mouse with USB receiver'),
		('Mechanical Keyboard', 49.50, 60, 'RGB backlit mechanical keyboard with blue switches'),
		('USB-C Charger', 12.75, 200, '20W fast charging USB-C wall adapter'),
		('Bluetooth Headphones', 34.99, 80, 'Over-ear headphones with noise cancellation'),
		('27-inch Monitor', 189.00, 25, 'Full HD IPS monitor with HDMI and DisplayPort'),
		('Laptop Stand', 22.40, 95, 'Adjustable aluminum laptop stand'),
		('Webcam 1080p', 27.99, 70, 'Full HD webcam with built-in microphone'),
		('External SSD 1TB', 89.90, 40, 'Portable solid state drive, USB 3.2'),
		('Gaming Mouse Pad', 9.99, 150, 'Large extended mouse pad with stitched		edges'),
		('Smartphone Stand', 6.50, 300, 'Foldable desktop stand for phones and tablets')


GO

SELECT * FROM Products