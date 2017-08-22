// Реализуйте возможность через DAL управлять заказами

namespace ClassLibrary
{
    using System;
    using System.Collections.Generic;
    using System.Configuration;
    using System.Data;
    using System.Data.Common;
    using System.Data.SqlClient;

    public class DAL
    {
        private DbProviderFactory providerFactory;
        private string connectionString;

        public DAL()
        {
            var connectionStringItem = ConfigurationManager.ConnectionStrings["Northwind Connection"];
            connectionString = connectionStringItem.ConnectionString;
            var providerName = connectionStringItem.ProviderName;
            providerFactory = DbProviderFactories.GetFactory(providerName);
        }

        public List<Order> GetOrders(int countOrders)
        {
            var orders = new List<Order>(countOrders);
            
            using (var connection = providerFactory.CreateConnection())
            {
                connection.ConnectionString = connectionString;
                var command = connection.CreateCommand();
                command.CommandText = "SELECT TOP 1 OrderID, CustomerID, ShippedDate, " +
                    "OrderDate FROM Northwind.Orders";
                command.CommandType = CommandType.Text;
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
            using (var connection = providerFactory.CreateConnection())
            {
                connection.ConnectionString = connectionString;
                var command = connection.CreateCommand();
                command.CommandText = "SELECT ord.OrderID, ord.ShippedDate, ord.OrderDate, " +
                    "orddet.ProductID, prod.ProductName FROM Northwind.Orders " +
                    "AS ord INNER JOIN Northwind.[Order Details] AS ordDet " +
                    "ON ord.OrderID = ordDet.OrderID AND ord.OrderID = @orderID " +
                    "INNER JOIN Northwind.Products " +
                    "AS prod ON ordDet.ProductID = prod.ProductID";
                command.CommandType = CommandType.Text;
                command.AddParameterWithValue("OrderID", orderID);

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
            using (var connection = providerFactory.CreateConnection())
            {
                connection.ConnectionString = connectionString;
                var command = connection.CreateCommand();
                command.CommandText = "INSERT INTO [Northwind].[Orders]([CustomerID], [EmployeeID], [OrderDate], [RequiredDate], " +
                    "[ShippedDate], [ShipVia], [Freight], [ShipName], " +
                    "[ShipAddress], [ShipCity], [ShipRegion], [ShipPostalCode], " +
                    "[ShipCountry]) VALUES (@customerID, @employeeID, " +
                    "@orderDate, @requiredDate, @shippedDate, @shipVia, " +
                    "@freight, @shipName, @shipAddress, @shipCity, " +
                    "@shipRegion, @shipPostalCode, @shipCountry)";
                command.CommandType = CommandType.Text;

                command.AddParameterWithValue("@customerID", customerID);
                command.AddParameterWithValue("@employeeID", employeeID);
                command.AddParameterWithValue("@orderDate", orderDate);
                command.AddParameterWithValue("@requiredDate", requiredDate);
                command.AddParameterWithValue("@shippedDate", shippedDate);
                command.AddParameterWithValue("@shipVia", shipVia);
                command.AddParameterWithValue("@freight", freight);
                command.AddParameterWithValue("@shipName", shipName);
                command.AddParameterWithValue("@shipAddress", shipAddress);
                command.AddParameterWithValue("@shipRegion", shipRegion);
                command.AddParameterWithValue("@shipCity", shipCity);
                command.AddParameterWithValue("@shipPostalCode", shipPostalCode);
                command.AddParameterWithValue("@shipCountry", shipCountry);

                connection.Open();
                return command.ExecuteNonQuery();
            }
        }

        public int SetOrderDate(DateTime orderDate, int orderID)
        {
            using (var connection = providerFactory.CreateConnection())
            {
                connection.ConnectionString = connectionString;
                var command = connection.CreateCommand();
                command.CommandText = "UPDATE Northwind.Orders " +
                "SET orderDate =  @orderDate WHERE orderID = @orderID";
                command.CommandType = CommandType.Text;

                command.AddParameterWithValue("@orderDate", orderDate);
                command.AddParameterWithValue("@orderID", orderID);

                connection.Open();
                return command.ExecuteNonQuery();
            }
        }

        public int SetShippedDate(DateTime shippedDate, int orderID)
        {
            using (var connection = providerFactory.CreateConnection())
            {
                connection.ConnectionString = connectionString;
                var command = connection.CreateCommand();
                command.CommandText = "UPDATE Northwind.Orders" +
                "SET shippedDate =  @shippedDate WHERE orderID = @orderID";
                command.CommandType = CommandType.Text;

                command.AddParameterWithValue("@shippedDate", shippedDate);
                command.AddParameterWithValue("@orderID", orderID);

                connection.Open();
                return command.ExecuteNonQuery();
            }
        }

        public List<Product> GetOrderHistory(string customerID)
        {
            var products = new List<Product>();
            using (var connection = providerFactory.CreateConnection())
            {
                connection.ConnectionString = connectionString;
                var command = connection.CreateCommand();
                command.CommandText = "Northwind.CustOrderHist";
                command.CommandType = CommandType.StoredProcedure;
                command.AddParameterWithValue("@CustomerID", customerID);

                connection.Open();
                using (var reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        products.Add(new Product
                        {
                            ProductName = (string)reader["ProductName"],
                            Total = (int)reader["Total"]
                        });
                    }
                }
            }

            return products;
        }

        public List<Product> GetOrderDetails(int orderID)
        {
            var products = new List<Product>();
            using (var connection = providerFactory.CreateConnection())
            {
                connection.ConnectionString = connectionString;
                var command = connection.CreateCommand();
                command.CommandText = "Northwind.CustOrdersDetail";
                command.CommandType = CommandType.StoredProcedure;
                command.AddParameterWithValue("@orderID", orderID);

                connection.Open();
                using (var reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        products.Add(new Product
                        {
                            ProductName = (string)reader["ProductName"],
                            UnitPrice = (decimal)reader["UnitPrice"],
                            Quantity = (Int16)reader["Quantity"],
                            Discount = (int)reader["Discount"],
                            ExtendedPrice = (decimal)reader["ExtendedPrice"],
                        });
                    }
                }
            }

            return products;
        }
    }
}