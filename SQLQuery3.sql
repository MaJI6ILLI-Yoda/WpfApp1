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
VALUES ('Администратор'),('Модератор'),('Пользователь');

INSERT INTO Account (UserName, Password, PhoneNumber, EmailAdress, id_role)
VALUES ('Администратор','123','88005553535','admin@yandex.ru', 001), ('Модератор','456','71234567890','moder@yandex.ru',002),('Пользователь','789','70987654321','user@yandex.ru',003);

INSERT INTO RequestStatus (status_name)
VALUES ('На рассмотрении'),('В процессе оформления'),('Передаем доставке'),('Уже в пути'),('Товар получен'),('нет в наличии');

INSERT INTO Clients (client_name)
VALUES ('Иванов Иван'),('Петров Петр'),('Сидоров Сидр'),
	   ('Смирнов Алексей'),('Козлова Екатерина'),('Васильевна Анна'),
	   ('Николаев Николай'),('Кузнецова Ольгая'),('Морозов Дмитрий'),
	   ('Павлова Мария'),('Авдеева Василиса'),('Королева Анна');

INSERT INTO Product (product_name)
VALUES ('Планкен прямой ООО «Ларикс»'),('Шпунт ООО «Ларикс»'),('Планкен скошенный ООО «Ларикс»'),
	   ('Дубовый брус MW, люкс'),('Клееный брус ТД, сорт AB'),('Брус MW лиственница, люкс'),
	   ('Вагонка СимаЛенд Евро Флора липа'),('Вагонка штиль ТД Крона'),('Вагонка Добропаровъ Лесопилка липа'),
	   ('Блок-хаус ТД Крона'),('Блок-хаус ТД Крона'),('Блок-хаус ТД Крона');

INSERT INTO ProductTypes (product_type_name)
VALUES ('Доска'),('Брусок'),('Вагонка'),('Блок-хаус'),
	   ('Отделочные материалы'),('Напольные покрытия'),('Окна'),('Двери'),
	   ('Теплоизоляция'),('Ветроизоляция'),('Звукоизоляция'),('Виброизоляция'),
	   ('Пластиковый штакетник'),('Металлический штакетник'),('Секционные заборы'),('Ворота и калитки'),
	   ('Водосточные системы'),('Соффиты'),('Профиль соффитов'),('Монтаж кровли'),
	   ('Резиновые покрытия'),('Тротуарная плитка'),('Бордюр'),
	   ('Трубы'),('Алюминиевый лист'),('Компазитная арматура'),('Армирующая сетка'),
	   ('Декоративные обои'),('Фотообои'),('Жидкие обои'),('Фрески');

INSERT INTO Workers (worker_name)
VALUES ('Иванов Алексей'),('Петров Дмитрий'),('Сидоров Иван'),
	   ('Смирнов Андрей'),('Козлова Елена'),('Васильев Александр'),
	   ('Николаева Ольга'),('Кузнецов Денис'),('Морозова Анна'),
	   ('Павлов Никита'),('Фролов Евгений'),('Кочетков Тимофей');

INSERT INTO Requests (application_number, request_date, product_id,
product_type_id, product_description, client_id, status_id, worker_id)
VALUES (100, '2024-11-15', 1, 1, '20х95х2000мм', 1, 1, 1),
	   (101, '2024-11-16', 2, 1, '28x95x2000мм', 2, 2, 2),
	   (102, '2024-11-17', 3, 1, '20x95x3000мм', 3, 3, 3),
	   (103, '2024-11-18', 4, 2, '80х1125х3000мм', 4, 4, 4),
	   (104, '2024-11-19', 5, 2, '80x80x3000мм', 5, 5, 5),
	   (105, '2024-11-20', 6, 2, '80x112x2600мм', 6, 6, 6),
	   (106, '2024-11-15', 7, 3, '15х85х2000мм', 1, 1, 1),
	   (107, '2024-11-16', 8, 3, '14x96x2000мм', 2, 2, 2),
	   (108, '2024-11-17', 9, 3, '15x85x2000мм', 3, 3, 3),
	   (109, '2024-11-18', 10, 4, '36х185х2000мм', 4, 4, 4),
	   (110, '2024-11-19', 11, 4, '36x185x2500мм', 5, 5, 5),
	   (111, '2024-11-20', 12, 4, '36x185x3000мм', 6, 6, 6);   

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