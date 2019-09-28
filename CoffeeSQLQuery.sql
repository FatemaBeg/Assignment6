CREATE TABLE Customers(
CustomerId INT IDENTITY(1,1),
Name VARCHAR(50),
[Address] VARCHAR(50),
Contact VARCHAR(50)
)


CREATE TABLE Items(
Id INT IDENTITY(1,1),
ItemsName VARCHAR(50),
Price FLOAT
)



CREATE TABLE Orders(
Id INT IDENTITY(1,1),
ItemsName VARCHAR(50),
Quantity VARCHAR ,
TotalPrice INT

)