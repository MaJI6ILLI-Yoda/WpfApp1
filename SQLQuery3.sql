IF NOT EXISTS (SELECT * FROM INFORMATION_SCHEMA.TABLES 
WHERE TABLE_NAME=N'Role')
BEGIN
CREATE TABLE Role (
id_role INT IDENTITY(1,1) PRIMARY KEY,
name_role NVARCHAR(45) NULL
);
END

IF NOT EXISTS (SELECT * FROM INFORMATION_SCHEMA.TABLES 
WHERE TABLE_NAME=N'Account')
BEGIN
CREATE TABLE Account (
id_account INT IDENTITY(1,1) PRIMARY KEY,
UserName NVARCHAR(45),
Password NVARCHAR(100),
PhoneNumber NVARCHAR(100),
EmailAdress NVARCHAR(100),
id_role INT,
FOREIGN KEY (id_role) REFERENCES Role(id_role)
);
END

IF NOT EXISTS (SELECT * FROM INFORMATION_SCHEMA.TABLES 
WHERE TABLE_NAME=N'Clients')
BEGIN
CREATE TABLE Clients (
client_id INT IDENTITY(1,1) PRIMARY KEY,
client_name VARCHAR(255)
);
END

IF NOT EXISTS (SELECT * FROM INFORMATION_SCHEMA.TABLES 
WHERE TABLE_NAME=N'Product')
BEGIN
CREATE TABLE Product (
product_id INT IDENTITY(1,1) PRIMARY KEY,
product_name VARCHAR(255)
);
END

IF NOT EXISTS (SELECT * FROM INFORMATION_SCHEMA.TABLES 
WHERE TABLE_NAME=N'ProductTypes')
BEGIN
CREATE TABLE ProductTypes (
product_type_id INT IDENTITY(1,1) PRIMARY KEY,
product_type_name VARCHAR(255)
);
END

IF NOT EXISTS (SELECT * FROM INFORMATION_SCHEMA.TABLES 
WHERE TABLE_NAME=N'Workers')
BEGIN
CREATE TABLE Workers (
worker_id INT IDENTITY(1,1) PRIMARY KEY,
worker_name VARCHAR(255)
);
END

IF NOT EXISTS (SELECT * FROM INFORMATION_SCHEMA.TABLES 
WHERE TABLE_NAME=N'RequestStatus')
BEGIN
CREATE TABLE RequestStatus (
status_id INT IDENTITY(1,1) PRIMARY KEY,
status_name VARCHAR(255)
);
END

IF NOT EXISTS (SELECT * FROM INFORMATION_SCHEMA.TABLES 
WHERE TABLE_NAME=N'Requests')
BEGIN
CREATE TABLE Requests (
request_id INT IDENTITY(1,1) PRIMARY KEY,
application_number INT,
request_date DATE,
product_id INT,
product_type_id INT,
product_description TEXT,
client_id INT,
status_id INT,
worker_id INT, 
FOREIGN KEY(product_id) REFERENCES Product(product_id),
FOREIGN KEY(product_type_id) REFERENCES ProductTypes(product_type_id),
FOREIGN KEY(client_id) REFERENCES Clients(client_id),
FOREIGN KEY(status_id) REFERENCES RequestStatus(status_id),
FOREIGN KEY(worker_id) REFERENCES Workers(worker_id)
);
END

INSERT INTO Role (name_Role)
VALUES ('�������������'),('���������'),('������������');

INSERT INTO Account (UserName, Password, PhoneNumber, EmailAdress, id_role)
VALUES ('�������������','123','88005553535','admin@yandex.ru', 001), ('���������','456','71234567890','moder@yandex.ru',002),('������������','789','70987654321','user@yandex.ru',003);

INSERT INTO RequestStatus (status_name)
VALUES ('�� ������������'),('� �������� ����������'),('�������� ��������'),('��� � ����'),('����� �������'),('��� � �������');

INSERT INTO Clients (client_name)
VALUES ('������ ����'),('������ ����'),('������� ����'),
	   ('������� �������'),('������� ���������'),('���������� ����'),
	   ('�������� �������'),('��������� ������'),('������� �������'),
	   ('������� �����'),('������� ��������'),('�������� ����');

INSERT INTO Product (product_name)
VALUES ('������� ������ ��� �������'),('����� ��� �������'),('������� ��������� ��� �������'),
	   ('������� ���� MW, ����'),('������� ���� ��, ���� AB'),('���� MW �����������, ����'),
	   ('������� �������� ���� ����� ����'),('������� ����� �� �����'),('������� ����������� ��������� ����'),
	   ('����-���� �� �����'),('����-���� �� �����'),('����-���� �� �����');

INSERT INTO ProductTypes (product_type_name)
VALUES ('�����'),('������'),('�������'),('����-����'),
	   ('���������� ���������'),('��������� ��������'),('����'),('�����'),
	   ('�������������'),('�������������'),('�������������'),('�������������'),
	   ('����������� ���������'),('������������� ���������'),('���������� ������'),('������ � �������'),
	   ('����������� �������'),('�������'),('������� ��������'),('������ ������'),
	   ('��������� ��������'),('���������� ������'),('������'),
	   ('�����'),('����������� ����'),('����������� ��������'),('���������� �����'),
	   ('������������ ����'),('��������'),('������ ����'),('������');

INSERT INTO Workers (worker_name)
VALUES ('������ �������'),('������ �������'),('������� ����'),
	   ('������� ������'),('������� �����'),('�������� ���������'),
	   ('��������� �����'),('�������� �����'),('�������� ����'),
	   ('������ ������'),('������ �������'),('�������� �������');

INSERT INTO Requests (application_number, request_date, product_id,
product_type_id, product_description, client_id, status_id, worker_id)
VALUES (100, '2024-11-15', 1, 1, '20�95�2000��', 1, 1, 1),
	   (101, '2024-11-16', 2, 1, '28x95x2000��', 2, 2, 2),
	   (102, '2024-11-17', 3, 1, '20x95x3000��', 3, 3, 3),
	   (103, '2024-11-18', 4, 2, '80�1125�3000��', 4, 4, 4),
	   (104, '2024-11-19', 5, 2, '80x80x3000��', 5, 5, 5),
	   (105, '2024-11-20', 6, 2, '80x112x2600��', 6, 6, 6),
	   (106, '2024-11-15', 7, 3, '15�85�2000��', 1, 1, 1),
	   (107, '2024-11-16', 8, 3, '14x96x2000��', 2, 2, 2),
	   (108, '2024-11-17', 9, 3, '15x85x2000��', 3, 3, 3),
	   (109, '2024-11-18', 10, 4, '36�185�2000��', 4, 4, 4),
	   (110, '2024-11-19', 11, 4, '36x185x2500��', 5, 5, 5),
	   (111, '2024-11-20', 12, 4, '36x185x3000��', 6, 6, 6);   

SELECT * FROM Role
SELECT * FROM Account
SELECT * FROM RequestStatus
SELECT * FROM Clients
SELECT * FROM Product
SELECT * FROM ProductTypes
SELECT * FROM Workers
SELECT * FROM Requests

DELETE Role
DELETE Account
DELETE RequestStatus
DELETE Clients
DELETE Product
DELETE ProductTypes
DELETE Workers
DELETE Requests