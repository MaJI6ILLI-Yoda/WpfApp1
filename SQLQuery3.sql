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
WHERE TABLE_NAME=N'Workers')
BEGIN
CREATE TABLE Workers (
worker_id INT IDENTITY(1,1) PRIMARY KEY,
worker_name VARCHAR(255)
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
WHERE TABLE_NAME=N'RequestStatus')
BEGIN
CREATE TABLE RequestStatus (
status_id INT IDENTITY(1,1) PRIMARY KEY,
status_name VARCHAR(255)
);
END

IF NOT EXISTS (SELECT * FROM INFORMATION_SCHEMA.TABLES 
WHERE TABLE_NAME=N'ProductTypes')
BEGIN
CREATE TABLE ProductTypes (
product_type_id INT IDENTITY(1,1) PRIMARY KEY,
product_type_name NVARCHAR(100)
);
END

IF NOT EXISTS (SELECT * FROM INFORMATION_SCHEMA.TABLES 
WHERE TABLE_NAME=N'Prices')
BEGIN
CREATE TABLE Prices (
price_id INT IDENTITY(1,1) PRIMARY KEY,
price NVARCHAR(100)
);
END

IF NOT EXISTS (SELECT * FROM INFORMATION_SCHEMA.TABLES 
WHERE TABLE_NAME=N'Characteristics')
BEGIN
CREATE TABLE Characteristics (
characteristic_id INT IDENTITY(1,1) PRIMARY KEY,
characteristic_name VARCHAR(255)
);
END

IF NOT EXISTS (SELECT * FROM INFORMATION_SCHEMA.TABLES 
WHERE TABLE_NAME=N'Products')
BEGIN
CREATE TABLE Products (
product_id INT IDENTITY(1,1) PRIMARY KEY,
product_name NVARCHAR(45) NULL,
product_type_id INT,
characteristic_id INT,
price_id INT,
FOREIGN KEY (product_type_id) REFERENCES ProductTypes(product_type_id),
FOREIGN KEY (characteristic_id) REFERENCES Characteristics(characteristic_id),
FOREIGN KEY(price_id) REFERENCES Prices(price_id)
);
END

IF NOT EXISTS (SELECT * FROM INFORMATION_SCHEMA.TABLES 
WHERE TABLE_NAME=N'Requests')
BEGIN
CREATE TABLE Requests (
request_id INT IDENTITY(1,1) PRIMARY KEY,
application_number INT,
request_date DATE,
product_type_id INT,
product_id INT,
characteristic_id INT,
price_id INT,
worker_id INT,
status_id INT,
client_id INT, 
FOREIGN KEY(product_type_id) REFERENCES ProductTypes(product_type_id),
FOREIGN KEY(product_id) REFERENCES Products(product_id),
FOREIGN KEY(characteristic_id) REFERENCES Characteristics(characteristic_id),
FOREIGN KEY(price_id) REFERENCES Prices(price_id),
FOREIGN KEY(worker_id) REFERENCES Workers(worker_id),
FOREIGN KEY(status_id) REFERENCES RequestStatus(status_id),
FOREIGN KEY(client_id) REFERENCES Clients(client_id)
);
END


INSERT INTO Role(name_Role)
VALUES ('�������������'),('���������'),('������������');

INSERT INTO Account(UserName, Password, PhoneNumber, EmailAdress, id_role)
VALUES ('�������������','123','88005553535','admin@yandex.ru', 001), ('���������','456','71234567890','moder@yandex.ru',002),('������������','789','70987654321','user@yandex.ru',003);

INSERT INTO ProductTypes (product_type_name)
VALUES ('�����'),('������'),('�������'),('����-����'),
	   ('���������� ���������'),('��������� ��������'),('����'),('�����'),
	   ('�������������'),('�������������'),('�������������'),('�������������'),
	   ('����������� ���������'),('������������� ���������'),('���������� ������'),('������ � �������'),
	   ('����������� �������'),('�������'),('������� ��������'),('������ ������'),
	   ('��������� ��������'),('���������� ������'),('������'),
	   ('�����'),('����������� ����'),('����������� ��������'),('���������� �����'),
	   ('������������ ����'),('��������'),('������ ����'),('������');

INSERT INTO Products (product_name)
VALUES ('������� ������ ��� �������'),('����� ��� �������'),('������� ��������� ��� �������'),
	   ('������� ���� MW, ����'),('������� ���� ��, ���� AB'),('���� MW �����������, ����'),
	   ('������� �������� ���� ����� ����'),('������� ����� �� �����'),('������� ����������� ��������� ����'),
	   ('����-���� �� �����'),('����-���� �� �����'),('����-���� �� �����');

INSERT INTO Characteristics (Characteristic_name)
VALUES ('20�95�2000��'),('28�95�2000��'),('20�95�3000��'),
	   ('80x112x3000��'),('80�80�3000��'),('80x112x2600��'),
	   ('15x85x2000��'),('14�96�3000��'),('15x88x2000��'),
	   ('36�185�2000��'),('36�185�2500��'),('36�185�3000��');

INSERT INTO Prices (price)
VALUES ('308'),('682'),('463'),
	   ('1.228'),('2.222'),('7.347'),
	   ('2.700'),('2.320'),('5.000'),
	   ('1.626'),('1.926'),('2.226');
	   
INSERT INTO Workers (worker_name)
VALUES ('������ ����'),('������ ����'),('������� ����'),
	   ('������� �������'),('������� ���������'),('���������� ����'),
	   ('�������� �������'),('��������� ������'),('������� �������'),
	   ('������� �����');

INSERT INTO RequestStatus (status_name)
VALUES ('�� ������������'),('� �������� ����������'),('�������� ��������'),('��� � ����'),('����� �������'),('��� � �������');

INSERT INTO Clients (client_name)
VALUES ('������ �������'),('������ �������'),('������� ����'),
	   ('������� ������'),('������� �����'),('�������� ���������'),
	   ('��������� �����'),('�������� �����'),('�������� ����'),
	   ('������ ������');

INSERT INTO Requests (application_number, request_date, product_type_id, product_id, characteristic_id, price_id, worker_id, status_id, client_id)
VALUES (100, '2024-01-24', 1, 1, 1, 1, 1, 1, 1),
	   (101, '2024-01-26', 2, 2, 2, 2, 2, 2, 2),
	   (102, '2024-01-28', 3, 3, 3, 3, 3, 3, 3);

SELECT * FROM Role
SELECT * FROM Account
SELECT * FROM ProductTypes
SELECT * FROM Products
SELECT * FROM Characteristics
SELECT * FROM Prices
SELECT * FROM Workers
SELECT * FROM RequestStatus
SELECT * FROM Clients
SELECT * FROM Requests

DELETE Role
DELETE Account
DELETE ProductTypes
DELETE Products
DELETE Characteristics
DELETE Prices
DELETE Workers
DELETE RequestStatus
DELETE Clients
DELETE Requests

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
WHERE TABLE_NAME=N'Childs')
BEGIN
CREATE TABLE Childs (
child_id INT IDENTITY(1,1) PRIMARY KEY,
child_name VARCHAR(255)
);
END

IF NOT EXISTS (SELECT * FROM INFORMATION_SCHEMA.TABLES 
WHERE TABLE_NAME=N'Subject')
BEGIN
CREATE TABLE Subject (
subject_id INT IDENTITY(1,1) PRIMARY KEY,
subject_name VARCHAR(255)
);
END

IF NOT EXISTS (SELECT * FROM INFORMATION_SCHEMA.TABLES 
WHERE TABLE_NAME=N'FaultTypes')
BEGIN
CREATE TABLE FaultTypes (
fault_type_id INT IDENTITY(1,1) PRIMARY KEY,
fault_type_name VARCHAR(255)
);
END

IF NOT EXISTS (SELECT * FROM INFORMATION_SCHEMA.TABLES 
WHERE TABLE_NAME=N'Teachers')
BEGIN
CREATE TABLE Teachers (
teacher_id INT IDENTITY(1,1) PRIMARY KEY,
teacher_name VARCHAR(255)
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
subject_id INT,
fault_type_id INT,
problem_description TEXT,
child_id INT,
status_id INT,
teacher_id INT, 
FOREIGN KEY(subject_id) REFERENCES Subject(subject_id),
FOREIGN KEY(fault_type_id) REFERENCES FaultTypes(fault_type_id),
FOREIGN KEY(child_id) REFERENCES Childs(child_id),
FOREIGN KEY(status_id) REFERENCES RequestStatus(status_id),
FOREIGN KEY(teacher_id) REFERENCES Teachers(teacher_id)
);
END

INSERT INTO Role(name_Role)
VALUES ('�������������'),('���������'),('������������');

INSERT INTO Account(UserName, Password, PhoneNumber, EmailAdress, id_role)
VALUES ('�������������','123','88005553535','admin@yandex.ru', 001), ('���������','456','71234567890','moder@yandex.ru',002),('������������','789','70987654321','user@yandex.ru',003);

INSERT INTO RequestStatus (status_name)
VALUES ('�� ������������'),('� �������� ����������'),('�������� ��������'),('��� � ����'),('����� �������'),('��� � �������');

INSERT INTO Childs (child_name)
VALUES ('������ ����'),('������ ����'),('������� ����'),
	   ('������� �������'),('������� ���������'),('���������� ����'),
	   ('�������� �������'),('��������� ������'),('������� �������'),
	   ('������� �����');

INSERT INTO Subject (subject_name)
VALUES ('������� ������ ��� �������'),('����� ��� �������'),('������� ��������� ��� �������'),
	   ('������� ���� MW, ����'),('������� ���� ��, ���� AB'),('���� MW �����������, ����'),
	   ('������� �������� ���� ����� ����'),('������� ����� �� �����'),('������� ����������� ��������� ����'),
	   ('����-���� �� �����'),('����-���� �� �����'),('����-���� �� �����');

INSERT INTO FaultTypes (fault_type_name)
VALUES ('�����'),('������'),('�������'),('����-����'),
	   ('���������� ���������'),('��������� ��������'),('����'),('�����'),
	   ('�������������'),('�������������'),('�������������'),('�������������'),
	   ('����������� ���������'),('������������� ���������'),('���������� ������'),('������ � �������'),
	   ('����������� �������'),('�������'),('������� ��������'),('������ ������'),
	   ('��������� ��������'),('���������� ������'),('������'),
	   ('�����'),('����������� ����'),('����������� ��������'),('���������� �����'),
	   ('������������ ����'),('��������'),('������ ����'),('������');

INSERT INTO Teachers (teacher_name)
VALUES ('������ �������'),('������ �������'),('������� ����'),
	   ('������� ������'),('������� �����'),('�������� ���������'),
	   ('��������� �����'),('�������� �����'),('�������� ����'),
	   ('������ ������');

INSERT INTO Requests (application_number, request_date, subject_id,
fault_type_id, problem_description, child_id, status_id, teacher_id)
VALUES (100, '2024-01-24', 2, 1, '20�95�2000��', 1, 1, 1),
	   (101, '2024-01-26', 4, 2, '80x112x3000��', 2, 2, 2),
	   (102, '2024-01-24', 6, 2, '15x85x2000��', 3, 3, 3),
	   (103, '2024-01-26', 8, 3, '36�185�2000��', 4, 4, 4),
	   (104, '2024-01-24', 10, 4, '5x88x2000��', 5, 5, 5),
	   (105, '2024-01-26', 12, 4, '80x112x2600��', 6, 6, 6);
