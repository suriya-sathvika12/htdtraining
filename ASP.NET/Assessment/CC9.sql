CREATE DATABASE FoodOrderDB;
USE FoodOrderDB;

--Creating Table
CREATE TABLE MenuItems
(
    MenuId INT PRIMARY KEY IDENTITY(1,1),
    ItemName VARCHAR(100) NOT NULL,
    Category VARCHAR(50) NOT NULL,
    FoodType VARCHAR(20) NOT NULL,
    Price DECIMAL(10,2) NOT NULL,
    AvailableQuantity INT NOT NULL,
    IsAvailable BIT NOT NULL,
    CreatedDate DATETIME NOT NULL
);

--Inserting Data
INSERT INTO MenuItems
(ItemName, Category, FoodType, Price, AvailableQuantity, IsAvailable, CreatedDate)
VALUES
('Burger','Fast Food','Veg',120,20,1,GETDATE()),
('Pizza','Italian','Non-Veg',350,15,1,GETDATE());

SELECT * FROM MenuItems;

CREATE USER [INFICS\suriyasa]
FOR LOGIN [INFICS\suriyasa];
ALTER ROLE db_owner
ADD MEMBER [INFICS\suriyasa];