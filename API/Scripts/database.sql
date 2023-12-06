CREATE TABLE ProductType (
    Id INT IDENTITY(1,1) PRIMARY KEY,
    TypeName NVARCHAR(30) NOT NULL UNIQUE
);

CREATE TABLE Client (
    Id INT IDENTITY(1,1) PRIMARY KEY,
    Identification NVARCHAR(15) NOT NULL,
    IdentificationType NVARCHAR(30) NOT NULL,
    Name NVARCHAR(50) NOT NULL,
    LastName NVARCHAR(50) NOT NULL,
    Address NVARCHAR(60) NOT NULL,
    PhoneNumber NVARCHAR(15) NOT NULL
);

CREATE TABLE Product (
    Id INT IDENTITY(1,1) PRIMARY KEY,
    Name NVARCHAR(50) NOT NULL,
    ProductTypeId INT NOT NULL,
    Status INT NOT NULL,
    ClientId INT NOT NULL,
    FOREIGN KEY (ProductTypeId) REFERENCES ProductType(Id),
    FOREIGN KEY (ClientId) REFERENCES Client(Id)
);

INSERT INTO ProductType VALUES ('Cuenta de ahorro')
INSERT INTO ProductType VALUES ('Cuenta corriente')
INSERT INTO ProductType VALUES ('Tarjeta de credito')
INSERT INTO ProductType VALUES ('Tarjeta de debito')
