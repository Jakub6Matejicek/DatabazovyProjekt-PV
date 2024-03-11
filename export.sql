-- Vytvoření tabulky Produkty
CREATE TABLE Product (
    id INT PRIMARY KEY,
    name VARCHAR(255),
    price FLOAT,
    isStocked INTEGER
);

-- Vytvoření tabulky Zakaznici
CREATE TABLE Customer (
    id INT PRIMARY KEY,
    firstName VARCHAR(255),
    lastName VARCHAR(255),
    email VARCHAR(255),
    registrationDate DATETIME
);

-- Vytvoření tabulky Objednavky
CREATE TABLE Order (
    id INT PRIMARY KEY,
    date DATETIME,
    customerID INT,
    totalPrice FLOAT,
    FOREIGN KEY (ID_Zakaznika) REFERENCES Customers(id)
);

-- Vytvoření tabulky Doprava
CREATE TABLE Shipping (
    id INT PRIMARY KEY,
    Datum_Doruceni DATETIME,
    Adresa VARCHAR(255),
    Stav VARCHAR(255),
    ID_Objednavky INT,
    FOREIGN KEY (ID_Objednavky) REFERENCES Orders(id)
);

-- Vytvoření tabulky Mapovani_Produktu_na_Objednavky
CREATE TABLE ProductToOrder (
	id INT primary key,
    productID INT,
    orderID INT,
    quantity INT,
    FOREIGN KEY (productID) REFERENCES Product(id),
    FOREIGN KEY (orderID) REFERENCES Order(id),
);

