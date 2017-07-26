--1.1 Выбрать в таблице Orders заказы,
--которые были доставлены после 6 мая 1998 года (колонка ShippedDate)
--включительно и которые доставлены с ShipVia >= 2.
--Формат указания даты должен быть верным при любых региональных настройках,
--согласно требованиям статьи “Writing International Transact-SQL Statements”
-- в Books Online раздел “Accessing and Changing Relational Data Overview”.
--Этот метод использовать далее для всех заданий.
--Запрос должен высвечивать только колонки OrderID, ShippedDate и ShipVia.
--	Запрос не возвращает ShippedDate со значением NULL потому, 
--	что по стандарту ISO операторы сравнения не возвращают ничего,
-- если хотя бы один из операторов сравнения имеет значение NULL
SELECT  OrderID, ShippedDate, ShipVia 
  FROM Northwind.Orders
 WHERE ShippedDate >= {d'1998-05-06'} 
   AND ShipVia >= 2;

--1.2 Написать запрос, который выводит только недоставленные заказы из таблицы Orders.
--В результатах запроса высвечивать для колонки ShippedDate вместо значений NULL 
--строку ‘Not Shipped’ – использовать системную функцию CASЕ. 
--Запрос должен высвечивать только колонки OrderID и ShippedDate.
SELECT OrderID, ShippedDate =
	   CASE
	   WHEN ShippedDate IS  NULL THEN 'Not Shipped'
	    END
  FROM Northwind.Orders
 WHERE ShippedDate IS NULL

--1.3Выбрать в таблице Orders заказы, 
--которые были доставлены после 6 мая 1998 года (ShippedDate)
--не включая эту дату или которые еще не доставлены.
--В запросе должны высвечиваться только колонки OrderID (переименовать в Order Number)
--и ShippedDate (переименовать в Shipped Date). 
--В результатах запроса высвечивать для колонки ShippedDate 
--вместо значений NULL строку ‘Not Shipped’,
--для остальных значений высвечивать дату в формате по умолчанию.
SELECT OrderID AS 'Order Number' , 'Shipped Date' = 
	   CASE
	   WHEN ShippedDate IS NULL THEN 'Not Shipped'
	   ELSE CONVERT (nvarchar(30), ShippedDate, 102)
	   END
  FROM Northwind.Orders
 WHERE ShippedDate > {d'1998-05-06'} OR ShippedDate IS NULL;


--2.1 Выбрать из таблицы Customers всех заказчиков, проживающих в USA и Canada.
--Запрос сделать с только помощью оператора IN.
--Высвечивать колонки с именем пользователя и названием страны в результатах запроса.
--Упорядочить результаты запроса по имени заказчиков и по месту проживания.
SELECT ContactName, Country
  FROM Northwind.Customers
 WHERE Country IN ('USA','CANADA')
ORDER BY ContactName, Country

--2.2 Выбрать из таблицы Customers всех заказчиков, не проживающих в USA и Canada.
--Запрос сделать с помощью оператора IN.
--Высвечивать колонки с именем пользователя и названием страны в результатах запроса.
--Упорядочить результаты запроса по имени заказчиков. 
SELECT ContactName, Country
  FROM Northwind.Customers
 WHERE Country NOT IN ('USA', 'CANADA')
ORDER BY ContactName

--2.3 Выбрать из таблицы Customers все страны, в которых проживают заказчики.
--Страна должна быть упомянута только один раз и список отсортирован по убыванию.
--Не использовать предложение GROUP BY.
--Высвечивать только одну колонку в результатах запроса
SELECT DISTINCT Country
  FROM Northwind.Customers
 WHERE Country IS NOT NULL
ORDER BY Country DESC


--3.1 Выбрать все заказы (OrderID) из таблицы Order Details
-- (заказы не должны повторяться),
--где встречаются продукты с количеством от 3 до 10 включительно – 
--это колонка Quantity в таблице Order Details.
--Использовать оператор BETWEEN. Запрос должен высвечивать только колонку OrderID.
SELECT DISTINCT OrderID
  FROM Northwind.[Order Details]
 WHERE Quantity BETWEEN 3 AND 10

--3.2 Выбрать всех заказчиков из таблицы Customers,
--у которых название страны начинается на буквы из диапазона b и g.
--Использовать оператор BETWEEN. Проверить, что в результаты запроса попадает Germany.
--Запрос должен высвечивать только колонки CustomerID и Country и отсортирован по Country.
SELECT CustomerID, Country
  FROM Northwind.Customers
 WHERE Country BETWEEN 'b*' AND 'h*'
ORDER BY Country

--3.3 Выбрать всех заказчиков из таблицы Customers,
--у которых название страны начинается на буквы из диапазона b и g,
-- не используя оператор BETWEEN.
--Запрос должен высвечивать только колонки CustomerID и Country и отсортирован по Country.
SELECT CustomerID, Country
  FROM Northwind.Customers
 WHERE Country > 'b*' AND Country < 'h*'
ORDER BY Country


--4.1 В таблице Products найти все продукты (колонка ProductName), 
--где встречается подстрока 'chocolade'.
--Известно, что в подстроке 'chocolade' может быть изменена одна буква 'c' в середине 
--- найти все продукты, которые удовлетворяют этому условию. 
--Подсказка: результаты запроса должны высвечивать 2 строки.
SELECT ProductName
  FROM Northwind.Products
 WHERE ProductName LIKE 'cho_olade'


--5.1 Найти общую сумму всех заказов из таблицы Order Details
--с учетом количества закупленных товаров и скидок по ним.
--Результат округлить до сотых и высветить в стиле 1 для типа данных money.
--Скидка (колонка Discount) составляет процент из стоимости для данного товара.
--Для определения действительной цены на
--проданный продукт надо вычесть скидку из указанной в колонке UnitPrice цены.
--Результатом запроса должна быть одна запись
-- с одной колонкой с названием колонки 'Totals'.
SELECT CONVERT(MONEY, ROUND(SUM(UnitPrice * (1 - Discount)), 2), 1) AS Totals
  FROM Northwind.[Order Details]

--5.2 По таблице Orders найти количество заказов, которые еще не были доставлены 
--(т.е. в колонке ShippedDate нет значения даты доставки).
--Использовать при этом запросе только оператор COUNT. 
--Не использовать предложения WHERE и GROUP.
SELECT COUNT(*) - COUNT(ShippedDate) AS 'Not Shipped'
  FROM Northwind.Orders

--5.3 По таблице Orders найти количество различных покупателей 
--(CustomerID), сделавших заказы.
--Использовать функцию COUNT и не использовать предложения WHERE и GROUP.
SELECT COUNT(CustomerID) AS 'Customers'
  FROM Northwind.Orders

--6.1 По таблице Orders найти количество заказов с группировкой по годам.
--В результатах запроса надо высвечивать две колонки c названиями Year и Total.
--Написать проверочный запрос, который вычисляет количество всех заказов.
SELECT YEAR(OrderDate) AS 'Year', COUNT(CustomerID) AS 'Total'
  FROM Northwind.Orders
GROUP BY YEAR(OrderDate)

SELECT COUNT(CustomerID) AS 'Total Orders'
  FROM Northwind.Orders

--6.2 По таблице Orders найти количество заказов, cделанных каждым продавцом.
--Заказ для указанного продавца – это любая запись в таблице Orders,
--где в колонке EmployeeID задано значение для данного продавца.
--В результатах запроса надо высвечивать колонку с именем продавца
--(Должно высвечиваться имя полученное конкатенацией LastName & FirstName.
--Эта строка LastName & FirstName должна быть получена
--отдельным запросом в колонке основного запроса.
--Также основной запрос должен использовать группировку по EmployeeID.)
--с названием колонки ‘Seller’ и колонку c количеством заказов
--высвечивать с названием 'Amount'.
--Результаты запроса должны быть упорядочены по убыванию количества заказов.
SELECT COUNT(CustomerID) AS 'Amount',
 (SELECT LastName + FirstName
  FROM Northwind.Employees
  WHERE Employees.EmployeeID = Orders.EmployeeID) AS 'Seller'
FROM Northwind.Orders
GROUP BY EmployeeID
ORDER BY COUNT(CustomerID) DESC

--6.3 По таблице Orders найти количество заказов, 
--cделанных каждым продавцом и для каждого покупателя.
--Необходимо определить это только для заказов сделанных в 1998 году.
--В результатах запроса надо высвечивать колонку с именем продавца
--(название колонки ‘Seller’), колонку с именем покупателя (название колонки
--‘Customer’)  и колонку c количеством заказов высвечивать с названием 'Amount'.
--В запросе необходимо использовать специальный оператор языка T-SQL
--для работы с выражением GROUP
--(Этот же оператор поможет выводить строку “ALL” в результатах запроса).
--Группировки должны быть сделаны по ID продавца и покупателя.
--Результаты запроса должны быть упорядочены по продавцу,
-- покупателю и по убыванию количества продаж. 
-- В результатах должна быть сводная информация по продажам.
SELECT CASE
	   WHEN EmployeeID IS NULL
	   THEN 'ALL'
	   ELSE (SELECT LastName + ' ' + FirstName
	           FROM Northwind.Employees
			  WHERE Employees.EmployeeID = OrderTable.EmployeeID)
		END AS 'Seller',
	   CASE 
	   WHEN CustomerID IS NULL
	   THEN 'All'
	   ELSE (SELECT ContactName
	           FROM Northwind.Customers
			  WHERE Customers.CustomerID = OrderTable.CustomerID)
		END AS 'Customer',
		    Amount
  FROM (SELECT EmployeeID, CustomerID, COUNT(*) AS Amount
		FROM Northwind.Orders
		WHERE YEAR(ShippedDate) = 1998
	   GROUP BY EmployeeID, CustomerID) AS OrderTable
 ORDER BY Seller, Customer, Amount DESC


		


--6.4 Найти покупателей и продавцов, которые живут в одном городе.
--Если в городе живут только один или несколько продавцов или только один
--или несколько покупателей, то информация о таких покупателя и продавцах
--не должна попадать в результирующий набор.Не использовать конструкцию JOIN.
--В результатах запроса необходимо вывести следующие заголовки для результатов запроса:
--‘Person’, ‘Type’ (здесь надо выводить строку ‘Customer’ или  ‘Seller’ в завимости
--от типа записи), ‘City’. Отсортировать результаты запроса по колонке ‘City’ и по ‘Person’.

(SELECT ContactName AS Person, 'Customer' AS 'Type', City
   FROM Northwind.Customers
  WHERE City IN
		(SELECT City
		   FROM Northwind.Customers
		  GROUP BY City
		 HAVING COUNT(*) > 2))
  UNION ALL 
(SELECT FirstName + ' ' + LastName AS Person,
		'Seller' AS 'Type', City
   FROM Northwind.Employees
  WHERE City IN
(SELECT City
   FROM Northwind.Employees
  GROUP BY City
 HAVING COUNT(*) > 2))
  ORDER BY City, Person
		
--6.5 Найти всех покупателей, которые живут в одном городе.
--В запросе использовать соединение таблицы Customers c собой - самосоединение.
--Высветить колонки CustomerID и City.
--Запрос не должен высвечивать дублируемые записи.
SELECT DISTINCT A.CustomerID, A.City
  FROM Northwind.Customers AS A
       INNER JOIN Northwind.Customers AS B
	   ON A.City = B.City
	   AND A.City = 'London'
--Для проверки написать запрос, который высвечивает города,
--которые встречаются более одного раза в таблице Customers.
--Это позволит проверить правильность запроса.
SELECT City
  FROM Northwind.Customers
 GROUP BY City
HAVING COUNT(*) > 2

--6.6 По таблице Employees найти для каждого продавца его руководителя,
--т.е. кому он делает репорты. Высветить колонки с именами 'User Name' (LastName)
--и 'Boss'. В колонках должны быть высвечены имена из колонки LastName.
SELECT Worker.LastName AS 'User Name', Boss.LastName AS 'Boss'
  FROM Northwind.Employees AS Worker
	   LEFT OUTER JOIN Northwind.Employees AS Boss
	   ON Worker.ReportsTo = Boss.EmployeeID
	WHERE Worker.ReportsTo IS NOT NULL


--7.1 Определить продавцов, которые обслуживают регион 'Western' (таблица Region).
--Результаты запроса должны высвечивать два поля:
--'LastName' продавца и название обслуживаемой территории 
--('TerritoryDescription' из таблицы Territories). Запрос должен использовать JOIN 
--в предложении FROM. Для определения связей между таблицами Employees и Territories
--надо использовать графические диаграммы для базы Northwind.
SELECT LastName, TerritoryDescription
  FROM Northwind.Employees AS Empl
       INNER JOIN Northwind.EmployeeTerritories AS EmplTerr
	   ON Empl.EmployeeID = EmplTerr.EmployeeID
	   INNER JOIN Northwind.Territories AS Terr
	   ON EmplTerr.TerritoryID = Terr.TerritoryID
	   INNER JOIN Northwind.Region
	   ON Terr.RegionID = Region.RegionID
	   WHERE Region.RegionDescription = 'Western'


--8.1 Высветить в результатах запроса имена всех заказчиков из таблицы Customers
--и суммарное количество их заказов из таблицы Orders. Принять во внимание,
--что у некоторых заказчиков нет заказов,
--но они также должны быть выведены в результатах запроса.
--Упорядочить результаты запроса по возрастанию количества заказов. 
SELECT A.ContactName, B.Amount AS 'Customers Count'
  FROM
       (SELECT ContactName, CustomerID
          FROM Northwind.Customers
         GROUP BY CustomerID, ContactName) AS A
	   LEFT JOIN
	   (SELECT COUNT(CustomerID) AS Amount, CustomerID
	      FROM Northwind.Orders
		 GROUP BY CustomerID) AS B
	   ON A.CustomerID = B.CustomerID

--9.1 Высветить всех поставщиков колонка CompanyName в таблице Suppliers,
--у которых нет хотя бы одного продукта на складе 
--(UnitsInStock в таблице Products равно 0). 
--Использовать вложенный SELECT для этого запроса с использованием оператора IN.
--Можно ли использовать вместо оператора IN оператор '=' ?
 SELECT CompanyName
   FROM Northwind.Suppliers
  WHERE SupplierID IN
		(SELECT SupplierID
		   FROM Northwind.Products
		   WHERE UnitsInStock = 0)


--10.1 Высветить всех продавцов, которые имеют более 150 заказов.
--Использовать вложенный коррелированный SELECT.
SELECT LastName + ' ' + FirstName AS Seller
  FROM Northwind.Employees
 WHERE EmployeeID IN
	   (SELECT EmployeeID
	      FROM Northwind.Orders
		 WHERE EmployeeID IN
			   (SELECT EmployeeID
			      FROM Northwind.Orders
				 GROUP BY EmployeeID
				 HAVING COUNT(EmployeeID) >= 150))


--11.1 Высветить всех заказчиков (таблица Customers),
--которые не имеют ни одного заказа (подзапрос по таблице Orders).
--Использовать коррелированный SELECT и оператор EXISTS.
SELECT ContactName
  FROM Northwind.Customers
 WHERE NOT EXISTS
	   (SELECT CustomerID
	      FROM Northwind.Orders
	     WHERE Customers.CustomerID = Orders.CustomerID)


--12.1 Для формирования алфавитного указателя Employees
--высветить из таблицы Employees список только тех букв алфавита,
--с которых начинаются фамилии Employees (колонка LastName ) из этой таблицы.
--Алфавитный список должен быть отсортирован по возрастанию.
SELECT LEFT(LastName, 1) AS EmployeesAlphabet
  FROM Northwind.Employees
 ORDER BY LastName


--13.1 Написать процедуру, которая возвращает самый крупный заказ
--для каждого из продавцов за определенный год. 
--В результатах не может быть несколько заказов одного продавца,
--должен быть только один и самый крупный.
--В результатах запроса должны быть выведены следующие колонки:
--колонка с именем и фамилией продавца 
--(FirstName и LastName – пример: Nancy Davolio), номер заказа и его стоимость.
--В запросе надо учитывать Discount при продаже товаров.
--Процедуре передается год, за который надо сделать отчет, 
--и количество возвращаемых записей.
--Результаты запроса должны быть упорядочены по убыванию суммы заказа.
--Процедура должна быть реализована с использованием оператора SELECT и
--БЕЗ ИСПОЛЬЗОВАНИЯ КУРСОРОВ. Название функции соответственно GreatestOrders.
--Необходимо продемонстрировать использование этих процедур.
--Также помимо демонстрации вызовов процедур в скрипте Query.sql
--надо написать отдельный ДОПОЛНИТЕЛЬНЫЙ проверочный запрос
--для тестирования правильности работы процедуры GreatestOrders.
--Проверочный запрос должен выводить в удобном для сравнения с результатами
--работы процедур виде для определенного продавца для всех его заказов
--за определенный указанный год в результатах следующие колонки:
--имя продавца, номер заказа, сумму заказа.
--Проверочный запрос не должен повторять запрос, написанный в процедуре, -
--он должен выполнять только то, что описано в требованиях по нему.
--ВСЕ ЗАПРОСЫ ПО ВЫЗОВУ ПРОЦЕДУР ДОЛЖНЫ БЫТЬ НАПИСАНЫ В ФАЙЛЕ Query.sql –
--см. пояснение ниже в разделе «Требования к оформлению».  
EXEC Northwind.GreatestOrders 1997, 10
EXEC Northwind.GreatestOrders 1998, 3
SELECT Emp.FirstName + ' ' + LastName AS EmployeeName, Orders.OrderID,
	   OrdDet.UnitPrice * (1 - OrdDet.Discount) AS Cost
  FROM Northwind.Employees AS Emp  
       INNER JOIN Northwind.Orders
	   ON Emp.EmployeeID = Orders.EmployeeID
	   INNER JOIN Northwind.[Order Details] AS OrdDet
	   ON Orders.OrderID = OrdDet.OrderID
 WHERE YEAR(Orders.OrderDate) = 1998
	   AND Emp.EmployeeID = 3
 ORDER BY Cost DESC

--13.2 Написать процедуру, которая возвращает заказы в таблице Orders, 
--согласно указанному сроку доставки в днях (разница между OrderDate и ShippedDate).
--В результатах должны быть возвращены заказы,
--срок которых превышает переданное значение или еще недоставленные заказы. 
--Значению по умолчанию для передаваемого срока 35 дней. 
--Название процедуры ShippedOrdersDiff. Процедура должна высвечивать следующие колонки: 
--OrderID, OrderDate, ShippedDate, ShippedDelay
--(разность в днях между ShippedDate и OrderDate),
--SpecifiedDelay (переданное в процедуру значение).
--Необходимо продемонстрировать использование этой процедуры. 
EXEC Northwind.ShippedOrdersDiff 10
EXEC Northwind.ShippedOrdersDiff

--13.3 Написать процедуру, которая высвечивает всех подчиненных заданного продавца, 
--как непосредственных, так и подчиненных его подчиненных.
--В качестве входного параметра функции используется EmployeeID. 
--Необходимо распечатать имена подчиненных и выровнять их в тексте 
--(использовать оператор PRINT) согласно иерархии подчинения. 
--Продавец, для которого надо найти подчиненных также должен быть высвечен. 
--Название процедуры SubordinationInfo. 
--В качестве алгоритма для решения этой задачи надо использовать пример, 
--приведенный в Books Online и рекомендованный Microsoft для 
--решения подобного типа задач. Продемонстрировать использование процедуры. 
EXEC PROC Northwind.SubbordinationInfo 2

--13.4  Написать функцию, которая определяет, есть ли у продавца подчиненные.
--Возвращает тип данных BIT. В качестве входного параметра функции используется
--EmployeeID. Название функции IsBoss. Продемонстрировать использование функции
--для всех продавцов из таблицы Employees.
IF NOT EXISTS
(SELECT *
   FROM dbo.SYSOBJECTS
  WHERE NAME = 'Bosses'
        AND xType = 'U')

CREATE TABLE #Bosses
(EmployeeID int,
   HaveBoss BIT)

SELECT EmployeeID, Northwind.IsBoss(EmployeeID) AS HaveBoss
  FROM Northwind.Employees;

SELECT EmployeeID, HaveBoss
FROM #Bosses
DROP TABLE #Bosses