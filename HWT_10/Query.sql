--1.1 ������� � ������� Orders ������,
--������� ���� ���������� ����� 6 ��� 1998 ���� (������� ShippedDate)
--������������ � ������� ���������� � ShipVia >= 2.
--������ �������� ���� ������ ���� ������ ��� ����� ������������ ����������,
--�������� ����������� ������ �Writing International Transact-SQL Statements�
-- � Books Online ������ �Accessing and Changing Relational Data Overview�.
--���� ����� ������������ ����� ��� ���� �������.
--������ ������ ����������� ������ ������� OrderID, ShippedDate � ShipVia.
--	������ �� ���������� ShippedDate �� ��������� NULL ������, 
--	��� �� ��������� ISO ��������� ��������� �� ���������� ������,
-- ���� ���� �� ���� �� ���������� ��������� ����� �������� NULL
SELECT  OrderID, ShippedDate, ShipVia 
  FROM Northwind.Orders
 WHERE ShippedDate >= {d'1998-05-06'} 
   AND ShipVia >= 2;

--1.2 �������� ������, ������� ������� ������ �������������� ������ �� ������� Orders.
--� ����������� ������� ����������� ��� ������� ShippedDate ������ �������� NULL 
--������ �Not Shipped� � ������������ ��������� ������� CAS�. 
--������ ������ ����������� ������ ������� OrderID � ShippedDate.
SELECT OrderID, ShippedDate =
	   CASE
	   WHEN ShippedDate IS  NULL THEN 'Not Shipped'
	    END
  FROM Northwind.Orders
 WHERE ShippedDate IS NULL

--1.3������� � ������� Orders ������, 
--������� ���� ���������� ����� 6 ��� 1998 ���� (ShippedDate)
--�� ������� ��� ���� ��� ������� ��� �� ����������.
--� ������� ������ ������������� ������ ������� OrderID (������������� � Order Number)
--� ShippedDate (������������� � Shipped Date). 
--� ����������� ������� ����������� ��� ������� ShippedDate 
--������ �������� NULL ������ �Not Shipped�,
--��� ��������� �������� ����������� ���� � ������� �� ���������.
SELECT OrderID AS 'Order Number' , 'Shipped Date' = 
	   CASE
	   WHEN ShippedDate IS NULL THEN 'Not Shipped'
	   ELSE CONVERT (nvarchar(30), ShippedDate, 102)
	   END
  FROM Northwind.Orders
 WHERE ShippedDate > {d'1998-05-06'} OR ShippedDate IS NULL;


--2.1 ������� �� ������� Customers ���� ����������, ����������� � USA � Canada.
--������ ������� � ������ ������� ��������� IN.
--����������� ������� � ������ ������������ � ��������� ������ � ����������� �������.
--����������� ���������� ������� �� ����� ���������� � �� ����� ����������.
SELECT ContactName, Country
  FROM Northwind.Customers
 WHERE Country IN ('USA','CANADA')
ORDER BY ContactName, Country

--2.2 ������� �� ������� Customers ���� ����������, �� ����������� � USA � Canada.
--������ ������� � ������� ��������� IN.
--����������� ������� � ������ ������������ � ��������� ������ � ����������� �������.
--����������� ���������� ������� �� ����� ����������. 
SELECT ContactName, Country
  FROM Northwind.Customers
 WHERE Country NOT IN ('USA', 'CANADA')
ORDER BY ContactName

--2.3 ������� �� ������� Customers ��� ������, � ������� ��������� ���������.
--������ ������ ���� ��������� ������ ���� ��� � ������ ������������ �� ��������.
--�� ������������ ����������� GROUP BY.
--����������� ������ ���� ������� � ����������� �������
SELECT DISTINCT Country
  FROM Northwind.Customers
 WHERE Country IS NOT NULL
ORDER BY Country DESC


--3.1 ������� ��� ������ (OrderID) �� ������� Order Details
-- (������ �� ������ �����������),
--��� ����������� �������� � ����������� �� 3 �� 10 ������������ � 
--��� ������� Quantity � ������� Order Details.
--������������ �������� BETWEEN. ������ ������ ����������� ������ ������� OrderID.
SELECT DISTINCT OrderID
  FROM Northwind.[Order Details]
 WHERE Quantity BETWEEN 3 AND 10

--3.2 ������� ���� ���������� �� ������� Customers,
--� ������� �������� ������ ���������� �� ����� �� ��������� b � g.
--������������ �������� BETWEEN. ���������, ��� � ���������� ������� �������� Germany.
--������ ������ ����������� ������ ������� CustomerID � Country � ������������ �� Country.
SELECT CustomerID, Country
  FROM Northwind.Customers
 WHERE Country BETWEEN 'b*' AND 'h*'
ORDER BY Country

--3.3 ������� ���� ���������� �� ������� Customers,
--� ������� �������� ������ ���������� �� ����� �� ��������� b � g,
-- �� ��������� �������� BETWEEN.
--������ ������ ����������� ������ ������� CustomerID � Country � ������������ �� Country.
SELECT CustomerID, Country
  FROM Northwind.Customers
 WHERE Country > 'b*' AND Country < 'h*'
ORDER BY Country


--4.1 � ������� Products ����� ��� �������� (������� ProductName), 
--��� ����������� ��������� 'chocolade'.
--��������, ��� � ��������� 'chocolade' ����� ���� �������� ���� ����� 'c' � �������� 
--- ����� ��� ��������, ������� ������������� ����� �������. 
--���������: ���������� ������� ������ ����������� 2 ������.
SELECT ProductName
  FROM Northwind.Products
 WHERE ProductName LIKE 'cho_olade'


--5.1 ����� ����� ����� ���� ������� �� ������� Order Details
--� ������ ���������� ����������� ������� � ������ �� ���.
--��������� ��������� �� ����� � ��������� � ����� 1 ��� ���� ������ money.
--������ (������� Discount) ���������� ������� �� ��������� ��� ������� ������.
--��� ����������� �������������� ���� ��
--��������� ������� ���� ������� ������ �� ��������� � ������� UnitPrice ����.
--����������� ������� ������ ���� ���� ������
-- � ����� �������� � ��������� ������� 'Totals'.
SELECT CONVERT(MONEY, ROUND(SUM(UnitPrice * (1 - Discount)), 2), 1) AS Totals
  FROM Northwind.[Order Details]

--5.2 �� ������� Orders ����� ���������� �������, ������� ��� �� ���� ���������� 
--(�.�. � ������� ShippedDate ��� �������� ���� ��������).
--������������ ��� ���� ������� ������ �������� COUNT. 
--�� ������������ ����������� WHERE � GROUP.
SELECT COUNT(*) - COUNT(ShippedDate) AS 'Not Shipped'
  FROM Northwind.Orders

--5.3 �� ������� Orders ����� ���������� ��������� ����������� 
--(CustomerID), ��������� ������.
--������������ ������� COUNT � �� ������������ ����������� WHERE � GROUP.
SELECT COUNT(CustomerID) AS 'Customers'
  FROM Northwind.Orders

--6.1 �� ������� Orders ����� ���������� ������� � ������������ �� �����.
--� ����������� ������� ���� ����������� ��� ������� c ���������� Year � Total.
--�������� ����������� ������, ������� ��������� ���������� ���� �������.
SELECT YEAR(OrderDate) AS 'Year', COUNT(CustomerID) AS 'Total'
  FROM Northwind.Orders
GROUP BY YEAR(OrderDate)

SELECT COUNT(CustomerID) AS 'Total Orders'
  FROM Northwind.Orders

--6.2 �� ������� Orders ����� ���������� �������, c�������� ������ ���������.
--����� ��� ���������� �������� � ��� ����� ������ � ������� Orders,
--��� � ������� EmployeeID ������ �������� ��� ������� ��������.
--� ����������� ������� ���� ����������� ������� � ������ ��������
--(������ ������������� ��� ���������� ������������� LastName & FirstName.
--��� ������ LastName & FirstName ������ ���� ��������
--��������� �������� � ������� ��������� �������.
--����� �������� ������ ������ ������������ ����������� �� EmployeeID.)
--� ��������� ������� �Seller� � ������� c ����������� �������
--����������� � ��������� 'Amount'.
--���������� ������� ������ ���� ����������� �� �������� ���������� �������.
SELECT COUNT(CustomerID) AS 'Amount',
 (SELECT LastName + FirstName
  FROM Northwind.Employees
  WHERE Employees.EmployeeID = Orders.EmployeeID) AS 'Seller'
FROM Northwind.Orders
GROUP BY EmployeeID
ORDER BY COUNT(CustomerID) DESC

--6.3 �� ������� Orders ����� ���������� �������, 
--c�������� ������ ��������� � ��� ������� ����������.
--���������� ���������� ��� ������ ��� ������� ��������� � 1998 ����.
--� ����������� ������� ���� ����������� ������� � ������ ��������
--(�������� ������� �Seller�), ������� � ������ ���������� (�������� �������
--�Customer�)  � ������� c ����������� ������� ����������� � ��������� 'Amount'.
--� ������� ���������� ������������ ����������� �������� ����� T-SQL
--��� ������ � ���������� GROUP
--(���� �� �������� ������� �������� ������ �ALL� � ����������� �������).
--����������� ������ ���� ������� �� ID �������� � ����������.
--���������� ������� ������ ���� ����������� �� ��������,
-- ���������� � �� �������� ���������� ������. 
-- � ����������� ������ ���� ������� ���������� �� ��������.
--SELECT
-- (SELECT LastName + FirstName
--  WHERE Employees.EmployeeID = Orders.EmployeeID) AS Seller,
--  (SELECT ContactName
--   WHERE Customers.CustomerID = Orders.CustomerID) AS Customer,
-- COUNT()
--FROM Northwind.Orders, Northwind.Employees, Northwind.Customers
--GROUP BY Orders.CustomerID, Orders.EmployeeID
--HAVING YEAR(ShippedDate) = 1998
--ORDER BY Seller, Customer, Amount

--6.4 ����� ����������� � ���������, ������� ����� � ����� ������.
--���� � ������ ����� ������ ���� ��� ��������� ��������� ��� ������ ����
--��� ��������� �����������, �� ���������� � ����� ���������� � ���������
--�� ������ �������� � �������������� �����.�� ������������ ����������� JOIN.
--� ����������� ������� ���������� ������� ��������� ��������� ��� ����������� �������:
--�Person�, �Type� (����� ���� �������� ������ �Customer� ���  �Seller� � ���������
--�� ���� ������), �City�. ������������� ���������� ������� �� ������� �City� � �� �Person�.

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
		
--6.5 ����� ���� �����������, ������� ����� � ����� ������.
--� ������� ������������ ���������� ������� Customers c ����� - ��������������.
--��������� ������� CustomerID � City.
--������ �� ������ ����������� ����������� ������.
SELECT DISTINCT A.CustomerID, A.City
  FROM Northwind.Customers AS A
       INNER JOIN Northwind.Customers AS B
	   ON A.City = B.City
	   AND A.City = 'London'
--��� �������� �������� ������, ������� ����������� ������,
--������� ����������� ����� ������ ���� � ������� Customers.
--��� �������� ��������� ������������ �������.
SELECT City
  FROM Northwind.Customers
 GROUP BY City
HAVING COUNT(*) > 2

--6.6 �� ������� Employees ����� ��� ������� �������� ��� ������������,
--�.�. ���� �� ������ �������. ��������� ������� � ������� 'User Name' (LastName)
--� 'Boss'. � �������� ������ ���� ��������� ����� �� ������� LastName.
SELECT Worker.LastName AS 'User Name', Boss.LastName AS 'Boss'
  FROM Northwind.Employees AS Worker
	   LEFT OUTER JOIN Northwind.Employees AS Boss
	   ON Worker.ReportsTo = Boss.EmployeeID
	WHERE Worker.ReportsTo IS NOT NULL

--8.1 ��������� � ����������� ������� ����� ���� ���������� �� ������� Customers
--� ��������� ���������� �� ������� �� ������� Orders. ������� �� ��������,
--��� � ��������� ���������� ��� �������,
--�� ��� ����� ������ ���� �������� � ����������� �������.
--����������� ���������� ������� �� ����������� ���������� �������. 
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

--9.1 ��������� ���� ����������� ������� CompanyName � ������� Suppliers,
--� ������� ��� ���� �� ������ �������� �� ������ 
--(UnitsInStock � ������� Products ����� 0). 
--������������ ��������� SELECT ��� ����� ������� � �������������� ��������� IN.
--����� �� ������������ ������ ��������� IN �������� '=' ?
 SELECT CompanyName
   FROM Northwind.Suppliers
  WHERE SupplierID IN
		(SELECT SupplierID
		   FROM Northwind.Products
		   WHERE UnitsInStock = 0)


--10.1 ��������� ���� ���������, ������� ����� ����� 150 �������.
--������������ ��������� ��������������� SELECT.
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


--11.1 ��������� ���� ���������� (������� Customers),
--������� �� ����� �� ������ ������ (��������� �� ������� Orders).
--������������ ��������������� SELECT � �������� EXISTS.
SELECT ContactName
  FROM Northwind.Customers
 WHERE NOT EXISTS
	   (SELECT CustomerID
	      FROM Northwind.Orders
	     WHERE Customers.CustomerID = Orders.CustomerID)


--12.1 ��� ������������ ����������� ��������� Employees
--��������� �� ������� Employees ������ ������ ��� ���� ��������,
--� ������� ���������� ������� Employees (������� LastName ) �� ���� �������.
--���������� ������ ������ ���� ������������ �� �����������.
SELECT LEFT(LastName, 1) AS EmployeesAlphabet
  FROM Northwind.Employees
 ORDER BY LastName


--13.1 �������� ���������, ������� ���������� ����� ������� �����
--��� ������� �� ��������� �� ������������ ���. 
--� ����������� �� ����� ���� ��������� ������� ������ ��������,
--������ ���� ������ ���� � ����� �������.
--� ����������� ������� ������ ���� �������� ��������� �������:
--������� � ������ � �������� �������� 
--(FirstName � LastName � ������: Nancy Davolio), ����� ������ � ��� ���������.
--� ������� ���� ��������� Discount ��� ������� �������.
--��������� ���������� ���, �� ������� ���� ������� �����, 
--� ���������� ������������ �������.
--���������� ������� ������ ���� ����������� �� �������� ����� ������.
--��������� ������ ���� ����������� � �������������� ��������� SELECT �
--��� ������������� ��������. �������� ������� �������������� GreatestOrders.
--���������� ������������������ ������������� ���� ��������.
--����� ������ ������������ ������� �������� � ������� Query.sql
--���� �������� ��������� �������������� ����������� ������
--��� ������������ ������������ ������ ��������� GreatestOrders.
--����������� ������ ������ �������� � ������� ��� ��������� � ������������
--������ �������� ���� ��� ������������� �������� ��� ���� ��� �������
--�� ������������ ��������� ��� � ����������� ��������� �������:
--��� ��������, ����� ������, ����� ������.
--����������� ������ �� ������ ��������� ������, ���������� � ���������, -
--�� ������ ��������� ������ ��, ��� ������� � ����������� �� ����.
--��� ������� �� ������ �������� ������ ���� �������� � ����� Query.sql �
--��. ��������� ���� � ������� ����������� � �����������.  
--SELECT LastName + ' ' + FirstName AS EmployeeName,
--(select OrderID
--from Orders where OrderID IN
--       (SELECT Orders.OrderID
--	      FROM Northwind.Orders
--	     WHERE EmployeeID = Employees.EmployeeID))
	   
--  FROM Northwind.Employees, 
--       Northwind.Orders, Northwind.[Order Details]