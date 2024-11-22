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
VALUES ('Администратор'),('Модератор'),('Пользователь');

INSERT INTO Account(UserName, Password, PhoneNumber, EmailAdress, id_role)
VALUES ('Администратор','123','88005553535','admin@yandex.ru', 001), ('Модератор','456','71234567890','moder@yandex.ru',002),('Пользователь','789','70987654321','user@yandex.ru',003);

INSERT INTO ProductTypes (product_type_name)
VALUES ('Доска'),('Брусок'),('Вагонка'),('Блок-хаус'),
	   ('Отделочные материалы'),('Напольные покрытия'),('Окна'),('Двери'),
	   ('Теплоизоляция'),('Ветроизоляция'),('Звукоизоляция'),('Виброизоляция'),
	   ('Пластиковый штакетник'),('Металлический штакетник'),('Секционные заборы'),('Ворота и калитки'),
	   ('Водосточные системы'),('Соффиты'),('Профиль соффитов'),('Монтаж кровли'),
	   ('Резиновые покрытия'),('Тротуарная плитка'),('Бордюр'),
	   ('Трубы'),('Алюминиевый лист'),('Компазитная арматура'),('Армирующая сетка'),
	   ('Декоративные обои'),('Фотообои'),('Жидкие обои'),('Фрески');

INSERT INTO Products (product_name)
VALUES ('Планкен прямой ООО «Ларикс»'),('Шпунт ООО «Ларикс»'),('Планкен скошенный ООО «Ларикс»'),
	   ('Дубовый брус MW, люкс'),('Клееный брус ТД, сорт AB'),('Брус MW лиственница, люкс'),
	   ('Вагонка СимаЛенд Евро Флора липа'),('Вагонка штиль ТД Крона'),('Вагонка Добропаровъ Лесопилка липа'),
	   ('Блок-хаус ТД Крона'),('Блок-хаус ТД Крона'),('Блок-хаус ТД Крона');

INSERT INTO Characteristics (Characteristic_name)
VALUES ('20х95х2000мм'),('28х95х2000мм'),('20х95х3000мм'),
	   ('80x112x3000мм'),('80х80х3000мм'),('80x112x2600мм'),
	   ('15x85x2000мм'),('14х96х3000мм'),('15x88x2000мм'),
	   ('36х185х2000мм'),('36х185х2500мм'),('36х185х3000мм');

INSERT INTO Prices (price)
VALUES ('308'),('682'),('463'),
	   ('1.228'),('2.222'),('7.347'),
	   ('2.700'),('2.320'),('5.000'),
	   ('1.626'),('1.926'),('2.226');
	   
INSERT INTO Workers (worker_name)
VALUES ('Иванов Иван'),('Петров Петр'),('Сидоров Сидр'),
	   ('Смирнов Алексей'),('Козлова Екатерина'),('Васильевна Анна'),
	   ('Николаев Николай'),('Кузнецова Ольгая'),('Морозов Дмитрий'),
	   ('Павлова Мария');

INSERT INTO RequestStatus (status_name)
VALUES ('На рассмотрении'),('В процессе оформления'),('Передаем доставке'),('Уже в пути'),('Товар получен'),('нет в наличии');

INSERT INTO Clients (client_name)
VALUES ('Иванов Алексей'),('Петров Дмитрий'),('Сидоров Иван'),
	   ('Смирнов Андрей'),('Козлова Елена'),('Васильев Александр'),
	   ('Николаева Ольга'),('Кузнецов Денис'),('Морозова Анна'),
	   ('Павлов Никита');

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
VALUES ('Администратор'),('Модератор'),('Пользователь');

INSERT INTO Account(UserName, Password, PhoneNumber, EmailAdress, id_role)
VALUES ('Администратор','123','88005553535','admin@yandex.ru', 001), ('Модератор','456','71234567890','moder@yandex.ru',002),('Пользователь','789','70987654321','user@yandex.ru',003);

INSERT INTO RequestStatus (status_name)
VALUES ('На рассмотрении'),('В процессе оформления'),('Передаем доставке'),('Уже в пути'),('Товар получен'),('нет в наличии');

INSERT INTO Childs (child_name)
VALUES ('Иванов Иван'),('Петров Петр'),('Сидоров Сидр'),
	   ('Смирнов Алексей'),('Козлова Екатерина'),('Васильевна Анна'),
	   ('Николаев Николай'),('Кузнецова Ольгая'),('Морозов Дмитрий'),
	   ('Павлова Мария');

INSERT INTO Subject (subject_name)
VALUES ('Планкен прямой ООО «Ларикс»'),('Шпунт ООО «Ларикс»'),('Планкен скошенный ООО «Ларикс»'),
	   ('Дубовый брус MW, люкс'),('Клееный брус ТД, сорт AB'),('Брус MW лиственница, люкс'),
	   ('Вагонка СимаЛенд Евро Флора липа'),('Вагонка штиль ТД Крона'),('Вагонка Добропаровъ Лесопилка липа'),
	   ('Блок-хаус ТД Крона'),('Блок-хаус ТД Крона'),('Блок-хаус ТД Крона');

INSERT INTO FaultTypes (fault_type_name)
VALUES ('Доска'),('Брусок'),('Вагонка'),('Блок-хаус'),
	   ('Отделочные материалы'),('Напольные покрытия'),('Окна'),('Двери'),
	   ('Теплоизоляция'),('Ветроизоляция'),('Звукоизоляция'),('Виброизоляция'),
	   ('Пластиковый штакетник'),('Металлический штакетник'),('Секционные заборы'),('Ворота и калитки'),
	   ('Водосточные системы'),('Соффиты'),('Профиль соффитов'),('Монтаж кровли'),
	   ('Резиновые покрытия'),('Тротуарная плитка'),('Бордюр'),
	   ('Трубы'),('Алюминиевый лист'),('Компазитная арматура'),('Армирующая сетка'),
	   ('Декоративные обои'),('Фотообои'),('Жидкие обои'),('Фрески');

INSERT INTO Teachers (teacher_name)
VALUES ('Иванов Алексей'),('Петров Дмитрий'),('Сидоров Иван'),
	   ('Смирнов Андрей'),('Козлова Елена'),('Васильев Александр'),
	   ('Николаева Ольга'),('Кузнецов Денис'),('Морозова Анна'),
	   ('Павлов Никита');

INSERT INTO Requests (application_number, request_date, subject_id,
fault_type_id, problem_description, child_id, status_id, teacher_id)
VALUES (100, '2024-01-24', 2, 1, '20х95х2000мм', 1, 1, 1),
	   (101, '2024-01-26', 4, 2, '80x112x3000мм', 2, 2, 2),
	   (102, '2024-01-24', 6, 2, '15x85x2000мм', 3, 3, 3),
	   (103, '2024-01-26', 8, 3, '36х185х2000мм', 4, 4, 4),
	   (104, '2024-01-24', 10, 4, '5x88x2000мм', 5, 5, 5),
	   (105, '2024-01-26', 12, 4, '80x112x2600мм', 6, 6, 6);
