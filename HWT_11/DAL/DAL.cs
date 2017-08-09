// Реализуйте возможность через DAL управлять заказами

namespace ClassLibrary
{
    using System;
    using System.Collections.Generic;
    using System.Data;
    using System.Data.SqlClient;

    public class DAL
    {
        public string connectionString = "Data Source=(local);Initial Catalog=Northwind;Integrated Security=True";//todo pn не прокатит. Нужно, во-первых, в конфиг вынести (у проекта тестов). Во-вторых, provider independent стиль использовать (в презентации есть слайд об этом, копипастни оттуда)

        public List<Order> GetOrders(int countOrders)
        {
            var orders = new List<Order>(countOrders);
         
            using (var connection = new SqlConnection(this.connectionString))
            {
                var command = connection.CreateCommand();
                command.CommandText = "SELECT TOP 1 OrderID, CustomerID, ShippedDate, " +
                    "OrderDate FROM Northwind.Orders";
                command.CommandType = CommandType.Text;
                //command.Parameters.AddWithValue("@countOrders", countOrders);
                connection.Open();
                using (var reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        orders.Add(new Order
                        {
                            OrderID = (int)reader["OrderID"],
                            CustomerID = (string)reader["CustomerID"],
                            ShippedDate = (DateTime)reader["ShippedDate"],
                            OrderDate = (DateTime)reader["OrderDate"],
                        });

                        StateOrder stateOrder = orders[orders.Count - 1].GetStateOrder();
                    }
                }
            }

            return orders;
        }

        public List<Order> GetInfoOrder(int orderID)
        {
            var orders = new List<Order>();
            using (var connection = new SqlConnection(this.connectionString))
            {
                var command = connection.CreateCommand();
                command.CommandText = "SELECT ord.OrderID, ord.ShippedDate, ord.OrderDate, " +
                    "orddet.ProductID, prod.ProductName FROM Northwind.Orders " +
                    "AS ord INNER JOIN Northwind.[Order Details] AS ordDet " +
                    "ON ord.OrderID = ordDet.OrderID AND ord.OrderID = @orderID " +
                    "INNER JOIN Northwind.Products " +
                    "AS prod ON ordDet.ProductID = prod.ProductID";
                command.CommandType = CommandType.Text;
                command.Parameters.AddWithValue("@orderID", orderID);

                connection.Open();
                using (var reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        orders.Add(new Order
                        {
                            OrderID = (int)reader["OrderID"],
                            ProductID = (int)reader["ProductID"],
                            ProductName = (string)reader["ProductName"],
                            ShippedDate = (DateTime)reader["ShippedDate"],
                            OrderDate = (DateTime)reader["OrderDate"]
                        });
                    }
                }
            }

            return orders;
        }

        public int AddOrder(
            int orderID, 
            string customerID, 
            int? employeeID,
            DateTime orderDate, 
            DateTime requiredDate, 
            DateTime shippedDate,
            int? shipVia, 
            double? freight, 
            string shipName, 
            string shipAddress,
            string shipCity, 
            string shipRegion, 
            string shipPostalCode,
            string shipCountry)
        {
            using (var connection = new SqlConnection(this.connectionString))
            {
                var command = connection.CreateCommand();
                command.CommandText = "INSERT INTO [Northwind].[Orders]([CustomerID], [EmployeeID], [OrderDate], [RequiredDate], " +
                    "[ShippedDate], [ShipVia], [Freight], [ShipName], " +
                    "[ShipAddress], [ShipCity], [ShipRegion], [ShipPostalCode], " +
                    "[ShipCountry]) VALUES ( 'N@customerID', '@employeeID', " +
                    "'@orderDate', '@requireDate', '@shippedDate', '@ShipVia', " +
                    "'@freight', 'N@shipName', 'N@shipAddress', 'N@shipCity', " +
                    "'N@shipRegion', 'N@shipPostalCode', 'N@shipCountry')";
                command.CommandType = CommandType.Text;

                command.Parameters.AddWithValue("@customerID", customerID);
                command.Parameters.AddWithValue("@employeeID", employeeID);
                command.Parameters.AddWithValue("@orderDate", orderDate);
                command.Parameters.AddWithValue("@requiredDate", requiredDate);
                command.Parameters.AddWithValue("@shippedDate", shippedDate);
                command.Parameters.AddWithValue("@freight", freight);
                command.Parameters.AddWithValue("@shipName", shipName);
                command.Parameters.AddWithValue("@shipAddress", shipAddress);
                command.Parameters.AddWithValue("@shipRegion", shipRegion);
                command.Parameters.AddWithValue("@shipCity", shipCity);
                command.Parameters.AddWithValue("@shipPostalCode", shipPostalCode);
                command.Parameters.AddWithValue("@shipCountry", shipCountry);

                connection.Open();
                return command.ExecuteNonQuery();
            }
        }

        public int SetOrderDate(DateTime orderDate, int orderID)
        {
            using (var connection = new SqlConnection(this.connectionString))
            {
                var command = connection.CreateCommand();
                command.CommandText = "UPDATE Northwind.Orders " +
                "SET orderDate =  @orderDate WHERE orderID = @orderID";
                command.CommandType = CommandType.Text;

                command.Parameters.AddWithValue("@orderDate", orderDate);
                command.Parameters.AddWithValue("@orderID", orderID);

                connection.Open();
                return command.ExecuteNonQuery();
            }
        }

        public int SetShippedDate(DateTime shippedDate, int orderID)
        {
            using (var connection = new SqlConnection(this.connectionString))
            {
                var command = connection.CreateCommand();
                command.CommandText = "UPDATE Northwind.Orders" +
                "SET shippedDate =  @shippedDate WHERE orderID = @orderID";
                command.CommandType = CommandType.Text;

                command.Parameters.AddWithValue("@shippedDate", shippedDate);
                command.Parameters.AddWithValue("@orderID", orderID);

                connection.Open();
                return command.ExecuteNonQuery();
            }
        }

        public List<Product> GetOrderHistory(string customerID)
        {
            var products = new List<Product>();
            using (var connection = new SqlConnection(this.connectionString))
            {
                var command = connection.CreateCommand();
                command.CommandText = "CustOrdersHist @customerID";
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.AddWithValue("@customerID", customerID);

                connection.Open();
                using (var reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        products.Add(new Product
                        {
                            ProductName = (string)reader["@ProductName"],
                            Total = (int)reader["@Total"]
                        });
                    }
                }
            }

            return products;
        }

        public List<Product> GetOrderDetails(int orderID)
        {
            var products = new List<Product>();
            using (var connection = new SqlConnection(this.connectionString))
            {
                var command = connection.CreateCommand();
                command.CommandText = "Northwind.CustOrdersDetail @orderID";
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.AddWithValue("@orderID", orderID);

                connection.Open();
                using (var reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        products.Add(new Product
                        {
                            ProductName = (string)reader["ProductName"],
                            UnitPrice = (double)reader["UnitPrice"],
                            Quantity = (int)reader["UnitPrice"],
                            Discount = (int)reader["Discount"],
                            ExtendedPrice = (double)reader["ExtendedPrice"],
                        });
                    }
                }
            }

            return products;
        }
    }
}