using MySqlConnector;
using System.Diagnostics;
using System.Configuration;
using System.Collections.Specialized;
using System.Security.Cryptography;

namespace DealershipSoftware
{
    public class Database
    {
        private static readonly string ServerName = ConfigurationManager.AppSettings["ServerName"];
        private static readonly string User = ConfigurationManager.AppSettings["User"];
        private static readonly string FullPassword = ConfigurationManager.AppSettings["Password"];
        private static readonly uint ServerPort = uint.Parse(ConfigurationManager.AppSettings["ServerPort"]);
        private static readonly string DatabaseName = ConfigurationManager.AppSettings["DatabaseName"];

        private static List<Manufacturer> mManufacturers = new List<Manufacturer>();
        private static List<VehicleType> mVehicleTypes = new List<VehicleType>();
        private static List<PaymentType> mPaymentTypes = new List<PaymentType>();
        private static List<Vehicle> mVehicles = new List<Vehicle>();
        private static List<Employee> mEmployees = new List<Employee>();
        private static List<EmployeeType> mEmployeeTypes = new List<EmployeeType>();
        private static List<Client> mClients = new List<Client>();
        private static List<Purchase> mPurchase = new List<Purchase>();        

        public static List<Manufacturer> Manufacturers
        {
            get { return mManufacturers; }
            set { mManufacturers = value; }
        }
        
        public static List<VehicleType> VehicleTypes
        {
            get { return mVehicleTypes; }
            set { mVehicleTypes = value; }
        }

        public static List<PaymentType> PaymentTypes
        {
            get { return mPaymentTypes; }
            set { mPaymentTypes = value; }
        }
        public static List<Vehicle> Vehicles
        {
            get { return mVehicles; }
            set { mVehicles = value; }
        }
        public static List<Employee> Employees
        {
            get { return mEmployees; }
            set { mEmployees = value; }
        }
        public static List<EmployeeType> EmployeeTypes
        {
            get { return mEmployeeTypes; }
            set { mEmployeeTypes = value; }
        }
        public static List<Client> Clients
        {
            get { return mClients; }
            set { mClients = value; }
        }
        public static List<Purchase> Purchase
        {
            get { return mPurchase; }
            set { mPurchase = value; }
        }
        public static bool CheckConnection(ref int errorCode)
        {
            var builder = new MySqlConnectionStringBuilder();
            bool result;
            try
            {
                builder = new MySqlConnectionStringBuilder
                {
                    Server = ServerName,
                    Port = ServerPort,
                    UserID = User,
                    Password = FullPassword,
                    Database = DatabaseName,
                };                                 
            }
            catch
            {
                errorCode = 3;
                return false;
            }
            using var connection = new MySqlConnection(builder.ConnectionString);
            try
            {
                
                connection.Open();
                result = true;
                connection.Close();
            }
            catch (Exception ex)
            {

                result = false;
                string message = ex.Message;
                LogWriter logWriter = new(message);
                if (message.StartsWith("Unable to connect"))
                {
                    errorCode = 0;
                }
                else if (message.StartsWith("Unknown database"))
                {
                    errorCode = 1;
                }
                else if (message.StartsWith("Access denied"))
                {
                    errorCode = 2;
                }
                else
                {
                    errorCode = -1;
                }
            }
            return result;
        }
        public static void LoadDBTables(bool loadManufacturers = false, bool loadVehicleTypes = false, bool loadPaymentTypes = false,
            bool loadClients = false, bool loadVehicles = false, bool loadEmployees = false, bool loadPurchases = false, bool loadManufacturerVehicleTypes = false)
        {
            if (loadManufacturers)
            {
                List<Manufacturer> manufacturers = new List<Manufacturer>();
                Database.SelectManufacturers(ref manufacturers);
                Database.Manufacturers = manufacturers;
            }
            if (loadVehicleTypes)
            {
                List<VehicleType> vehicleTypes = new List<VehicleType>();
                Database.SelectVehicleType(ref vehicleTypes);
                Database.VehicleTypes = vehicleTypes;
            }
            if (loadPaymentTypes)
            {
                List<PaymentType> paymentTypes = new List<PaymentType>();
                Database.SelectPaymentType(ref paymentTypes);
                Database.PaymentTypes = paymentTypes;
            }
            if (loadManufacturerVehicleTypes)
            {                
                foreach(var item in Database.Manufacturers)
                {
                    item.VehicleTypes.Clear();
                }
                Database.SelectManufacturerVehicleType();                

            }
            if (loadClients)
            {
                List<Client> clients = new List<Client>();
                Database.SelectClients(ref clients);
                Database.Clients = clients;
            }
            if (loadVehicles)
            {
                List<Vehicle> vehicles = new List<Vehicle>();
                Database.SelectVehicle(ref vehicles);
                Database.Vehicles = vehicles;
            }
            if (loadEmployees)
            {
                List<Employee> employees = new List<Employee>();
                Database.SelectEmployee(ref employees);
                Database.Employees = employees;
            }
            if (loadPurchases)
            {
                List<Purchase> purchases = new List<Purchase>();
                Database.SelectPurchase(ref purchases);
                Database.Purchase = purchases;
            }

        }
        //Временно решение, в противен случай ще забави адски много програмата
        public static void LoadAllDBTables()
        {
            LoadDBTables(loadManufacturers: true, loadPaymentTypes: true, loadVehicleTypes: true,
                loadClients: true, loadVehicles: true, loadEmployees: true, loadPurchases: true, loadManufacturerVehicleTypes: true);
        }


        public static void SelectVehicleType(ref List<VehicleType> types)
        {
            var builder = new MySqlConnectionStringBuilder
            {
                Server = ServerName,
                Port = ServerPort,
                UserID = User,
                Password = FullPassword,
                Database = DatabaseName,
            };

            using var connection = new MySqlConnection(builder.ConnectionString);
            connection.Open();

            using var command = connection.CreateCommand();
            command.CommandText = @"SELECT * FROM Vehicle_Type";

            var reader = command.ExecuteReader();
            while (reader.Read())
            {
                VehicleType type = new VehicleType();
                type.ID = reader.GetInt32("ID");
                type.TypeEN = reader.GetString("type_EN");
                type.TypeBG = reader.GetString("type_BG");
                types.Add(type);

            }
            reader.Close();
            connection.Close();
        }
        public static void SelectEmployeeType(ref List<EmployeeType> types)
        {
            var builder = new MySqlConnectionStringBuilder
            {
                Server = ServerName,
                Port = ServerPort,
                UserID = User,
                Password = FullPassword,
                Database = DatabaseName,
            };

            using var connection = new MySqlConnection(builder.ConnectionString);
            connection.Open();

            using var command = connection.CreateCommand();
            command.CommandText = @"SELECT * FROM Employee_Type";

            var reader = command.ExecuteReader();
            while (reader.Read())
            {
                EmployeeType type = new EmployeeType();
                type.ID = reader.GetInt32("ID");
                type.TypeEN = reader.GetString("type_EN");
                type.TypeBG = reader.GetString("type_BG");
                types.Add(type);

            }
            reader.Close();
            connection.Close();
        }
        public static void SelectManufacturers(ref List<Manufacturer> manufacturers)
        {
            var builder = new MySqlConnectionStringBuilder
            {
                Server = ServerName,
                Port = ServerPort,
                UserID = User,
                Password = FullPassword,
                Database = DatabaseName,
            };

            using var connection = new MySqlConnection(builder.ConnectionString);
            connection.Open();

            using var command = connection.CreateCommand();
            command.CommandText = @"SELECT * FROM Manufacturer";

            var reader = command.ExecuteReader();
            while (reader.Read())
            {
                Manufacturer manufacturer = new Manufacturer();
                manufacturer.ID = reader.GetInt32("ID");
                manufacturer.Name = reader.GetString("name");
                manufacturer.VehicleTypes = new List<VehicleType>();
                manufacturers.Add(manufacturer);

            }
            reader.Close();
            connection.Close();
        }

        //Alternative for SelectVehicle:
        //Use Left Join Manufacturers & VehicleType
        public static void SelectVehicle(ref List<Vehicle> vehicles)
        {
            var builder = new MySqlConnectionStringBuilder
            {
                Server = ServerName,
                Port = ServerPort,
                UserID = User,
                Password = FullPassword,
                Database = DatabaseName,
            };

            using var connection = new MySqlConnection(builder.ConnectionString);
            connection.Open();

            using var command = connection.CreateCommand();
            command.CommandText = @"SELECT * FROM Vehicle";

            var reader = command.ExecuteReader();
            while (reader.Read())
            {
                Vehicle vehicle = new Vehicle();
                vehicle.ID = reader.GetInt32("ID");
                vehicle.Price = reader.GetDecimal("price");
                foreach (var type in VehicleTypes)
                {
                    if (type.ID == reader.GetInt32("vehicle_TypeID"))
                    {
                        vehicle.VehicleType = type;
                        break;
                    }
                }
                foreach (var manufacturer in Manufacturers)
                {
                    if (manufacturer.ID == reader.GetInt32("manufacturerID"))
                    {
                        vehicle.Manufacturer = manufacturer;
                        break;
                    }
                }
                vehicle.Model = reader.GetString("model");
                vehicle.MakeYear = reader.GetInt32("make_Year");

                if (!reader.IsDBNull(6))
                {
                    long n = reader.GetBytes(ordinal: 6, dataOffset: 0, buffer: null, bufferOffset: 0, length: 0);
                    if (n > vehicle.Image.Length)
                    {
                        vehicle.Image = new byte[n];
                    }
                    n = reader.GetBytes(ordinal: 6, dataOffset: 0, buffer: vehicle.Image, bufferOffset: 0, length: vehicle.Image.Length);
                }
                vehicle.IsSold = reader.GetBoolean("is_Sold");
                vehicles.Add(vehicle);

            }
            reader.Close();
            connection.Close();
        }
        public static void SelectPaymentType(ref List<PaymentType> types)
        {
            var builder = new MySqlConnectionStringBuilder
            {
                Server = ServerName,
                Port = ServerPort,
                UserID = User,
                Password = FullPassword,
                Database = DatabaseName,
            };

            using var connection = new MySqlConnection(builder.ConnectionString);
            connection.Open();

            using var command = connection.CreateCommand();
            command.CommandText = @"SELECT * FROM Payment_Type";

            var reader = command.ExecuteReader();
            while (reader.Read())
            {
                PaymentType type = new PaymentType();
                type.ID = reader.GetInt32("ID");
                type.TypeEN = reader.GetString("type_EN");
                type.TypeBG = reader.GetString("type_BG");
                types.Add(type);

            }
            reader.Close();
            connection.Close();
        }
        //Use this method only after "Manufacturer" and "Vehicle Type" have been read!!!
        public static void SelectManufacturerVehicleType()
        {
            var builder = new MySqlConnectionStringBuilder
            {
                Server = ServerName,
                Port = ServerPort,
                UserID = User,
                Password = FullPassword,
                Database = DatabaseName,
            };

            using var connection = new MySqlConnection(builder.ConnectionString);
            connection.Open();

            using var command = connection.CreateCommand();
            command.CommandText = @"SELECT * FROM Manufacturer_Vehicle_Type";

            var reader = command.ExecuteReader();
            while (reader.Read())
            {
                int manufacturerID = reader.GetInt32("manufacturerID");
                int manufacturerIndex = Database.Manufacturers.FindIndex(x => x.ID == manufacturerID);

                int vehicleTypeID = reader.GetInt32("vehicle_TypeID");
                Database.Manufacturers[manufacturerIndex].VehicleTypes.Add(Database.VehicleTypes.Find(x => x.ID == vehicleTypeID));
            }

            reader.Close();
            connection.Close();
        }        
        
        //Only use if lists in Database class are full and fresh!!!
        public static void SelectPurchase(ref List<Purchase> purchases)
        {
            var builder = new MySqlConnectionStringBuilder
            {
                Server = ServerName,
                Port = ServerPort,
                UserID = User,
                Password = FullPassword,
                Database = DatabaseName,
            };

            using var connection = new MySqlConnection(builder.ConnectionString);
            connection.Open();

            using var command = connection.CreateCommand();
            command.CommandText = @"SELECT * FROM purchase";

            var reader = command.ExecuteReader();
            while (reader.Read())
            {
                Purchase purchase = new Purchase();
                purchase.ID = reader.GetInt32("ID");
                int clientID = reader.GetInt32("clientID");
                purchase.Client = Clients.Find(x => x.ID == clientID);
                int vehicleID = reader.GetInt32("vehicleID");
                purchase.Vehicle = Vehicles.Find(x => x.ID == vehicleID);
                int employeeID = reader.GetInt32("employeeID");
                purchase.Employee = Employees.Find(x => x.ID == employeeID);
                purchase.DateOfPurchase = reader.GetDateTime("date_Of_Purchase").ToLocalTime();                
                purchase.FinalPrice = reader.GetDecimal("final_Price");
                int paymentTypeID = reader.GetInt32("payment_TypeID"); 
                purchase.PaymentType = PaymentTypes.Find(x => x.ID == paymentTypeID);
                purchase.IsValid = reader.GetBoolean("is_Valid");
                purchases.Add(purchase);

            }
            reader.Close();
            connection.Close();
        }

        public static void SelectEmployee(ref List<Employee> employees)
        {

            var builder = new MySqlConnectionStringBuilder
            {
                Server = ServerName,
                Port = ServerPort,
                UserID = User,
                Password = FullPassword,
                Database = DatabaseName,
            };

            using var connection = new MySqlConnection(builder.ConnectionString);
            connection.Open();

            using var command = connection.CreateCommand();
            command.CommandText = @"SELECT * FROM employee";

            var reader = command.ExecuteReader();
            while (reader.Read())
            {
                Employee employee = new Employee();
                employee.ID = reader.GetInt32("ID");
                employee.FirstName = reader.GetString("first_Name");
                employee.LastName = reader.GetString("last_Name");
                employee.Email = reader.GetString("email");
                employee.DateOfBirth = reader.GetDateTime("date_Of_Birth");
                employee.Telephone = reader.GetString("telephone_Number");
                /*if(employee.ID == 9)
                {
                    System.Diagnostics.Debugger.Break();
                }*/
                
                if (reader["password"] != System.DBNull.Value && ((byte[])reader["password"]).Length > 0)
                {
                    employee.Password = (byte[])reader["password"];
                }
                employee.Salt = reader.GetString("salt");
                employee.EmployeeTypeID = reader.GetInt32("employee_Type_ID");                

                employees.Add(employee);
            }
            reader.Close();
            connection.Close();
        }

        public static bool InsertEmployee(Employee employee)
        {

            var builder = new MySqlConnectionStringBuilder
            {
                Server = ServerName,
                Port = ServerPort,
                UserID = User,
                Password = FullPassword,
                Database = DatabaseName,
            };

            string query = @"INSERT INTO Employee
                                    (first_Name, last_Name, telephone_Number, email, date_Of_Birth, password, salt, employee_Type_ID)
                                    VALUES
                                    (@first_Name, @last_Name, @telephone_Number, @email, @date_Of_Birth, @password, @salt, @employee_Type_ID);";

            using var connection = new MySqlConnection(builder.ConnectionString);


            using (MySqlCommand command = new MySqlCommand(query, connection))
            {
                MySqlParameter paramFirstName = new MySqlParameter("@first_Name", System.Data.DbType.String);
                paramFirstName.Value = employee.FirstName;
                command.Parameters.Add(paramFirstName);

                MySqlParameter paramLastName = new MySqlParameter("@last_Name", System.Data.DbType.String);
                paramLastName.Value = employee.LastName;
                command.Parameters.Add(paramLastName);

                MySqlParameter paramNumber = new MySqlParameter("@telephone_Number", System.Data.DbType.String);
                paramNumber.Value = employee.Telephone;
                command.Parameters.Add(paramNumber);

                MySqlParameter paramEmail = new MySqlParameter("@email", System.Data.DbType.String);
                paramEmail.Value = employee.Email;
                command.Parameters.Add(paramEmail);

                MySqlParameter paramDOB = new MySqlParameter("@date_Of_Birth", System.Data.DbType.Date);
                paramDOB.Value = employee.DateOfBirth.Date;
                command.Parameters.Add(paramDOB);

                MySqlParameter paramPassword = new MySqlParameter("@password", System.Data.DbType.Binary);
                paramPassword.Value = employee.Password;
                command.Parameters.Add(paramPassword);

                MySqlParameter paramSalt = new MySqlParameter("@salt", System.Data.DbType.String);
                paramSalt.Value = employee.Salt;
                command.Parameters.Add(paramSalt);

                MySqlParameter paramEmployeeTypeID = new MySqlParameter("@employee_Type_ID", System.Data.DbType.Int32);
                paramEmployeeTypeID.Value = employee.EmployeeTypeID;
                command.Parameters.Add(paramEmployeeTypeID);

                try
                {
                    connection.Open();
                    command.ExecuteNonQuery();
                    return true;
                }
                catch (Exception ex)
                {
                    Debug.WriteLine("New exception: {0}", ex.Message);
                    LogWriter logWriter = new(ex.Message);
                    return false;
                }
            }
        }

        public static bool InsertManufacturer(string manufacturer)
        {

            var builder = new MySqlConnectionStringBuilder
            {
                Server = ServerName,
                Port = ServerPort,
                UserID = User,
                Password = FullPassword,
                Database = DatabaseName,
            };

            string query = @"INSERT INTO Manufacturer
                                    (name)
                                    VALUES
                                    (@name);";

            using var connection = new MySqlConnection(builder.ConnectionString);


            using (MySqlCommand command = new MySqlCommand(query, connection))
            {
                MySqlParameter paramName = new MySqlParameter("@name", System.Data.DbType.String);
                paramName.Value = manufacturer;
                command.Parameters.Add(paramName);

                try
                {
                    connection.Open();
                    command.ExecuteNonQuery();
                    return true;
                }
                catch (Exception ex)
                {
                    Debug.WriteLine("New exception: {0}", ex.Message);
                    LogWriter logWriter = new(ex.Message);
                    return false;
                }
            }
        }

        public static bool InsertPaymentType(string paymentTypeEN, string paymentTypeBG)
        {

            var builder = new MySqlConnectionStringBuilder
            {
                Server = ServerName,
                Port = ServerPort,
                UserID = User,
                Password = FullPassword,
                Database = DatabaseName,
            };

            string query = @"INSERT INTO Payment_Type
                                    (type_EN, type_BG)
                                    VALUES
                                    (@type_EN, @type_BG);";

            using var connection = new MySqlConnection(builder.ConnectionString);


            using (MySqlCommand command = new MySqlCommand(query, connection))
            {
                MySqlParameter paramTypeEN = new MySqlParameter("@type_EN", System.Data.DbType.String);
                paramTypeEN.Value = paymentTypeEN;
                command.Parameters.Add(paramTypeEN);

                MySqlParameter paramTypeBG = new MySqlParameter("@type_BG", System.Data.DbType.String);
                paramTypeBG.Value = paymentTypeBG;
                command.Parameters.Add(paramTypeBG);

                try
                {
                    connection.Open();
                    command.ExecuteNonQuery();
                    return true;
                }
                catch (Exception ex)
                {
                    Debug.WriteLine("New exception: {0}", ex.Message);
                    LogWriter logWriter = new(ex.Message);
                    return false;
                }
            }
        }

        public static bool InsertVehicleType(string vehicleTypeEN, string vehicleTypeBG)
        {

            var builder = new MySqlConnectionStringBuilder
            {
                Server = ServerName,
                Port = ServerPort,
                UserID = User,
                Password = FullPassword,
                Database = DatabaseName,
            };

            string query = @"INSERT INTO Vehicle_Type
                                    (type_EN, type_BG)
                                    VALUES
                                    (@type_EN, @type_BG);";

            using var connection = new MySqlConnection(builder.ConnectionString);


            using (MySqlCommand command = new MySqlCommand(query, connection))
            {
                MySqlParameter paramTypeEN = new MySqlParameter("@type_EN", System.Data.DbType.String);
                paramTypeEN.Value = vehicleTypeEN;
                command.Parameters.Add(paramTypeEN);

                MySqlParameter paramTypeBG = new MySqlParameter("@type_BG", System.Data.DbType.String);
                paramTypeBG.Value = vehicleTypeBG;
                command.Parameters.Add(paramTypeBG);
                try
                {
                    connection.Open();
                    command.ExecuteNonQuery();
                    return true;
                }
                catch (Exception ex)
                {
                    Debug.WriteLine("New exception: {0}", ex.Message);
                    LogWriter logWriter = new(ex.Message);
                    return false;
                }
            }
        }
        public static bool InsertManufacturerVehicleType(int manufacturerID, int vehicleTypeID)
        {

            var builder = new MySqlConnectionStringBuilder
            {
                Server = ServerName,
                Port = ServerPort,
                UserID = User,
                Password = FullPassword,
                Database = DatabaseName,
            };

            string query = @"INSERT INTO manufacturer_Vehicle_Type 
                            (manufacturerID, vehicle_TypeID)
	                        VALUES 
                            (@param_ManufacturerID, @param_Vehicle_TypeID);";

            using var connection = new MySqlConnection(builder.ConnectionString);


            using (MySqlCommand command = new MySqlCommand(query, connection))
            {
                MySqlParameter paramManufacturerID = new MySqlParameter("@param_ManufacturerID", System.Data.DbType.String);
                paramManufacturerID.Value = manufacturerID;
                command.Parameters.Add(paramManufacturerID);

                MySqlParameter paramVehicleTypeID = new MySqlParameter("@param_Vehicle_TypeID", System.Data.DbType.String);
                paramVehicleTypeID.Value = vehicleTypeID;
                command.Parameters.Add(paramVehicleTypeID);
                try
                {
                    connection.Open();
                    command.ExecuteNonQuery();
                    return true;
                }
                catch (Exception ex)
                {
                    Debug.WriteLine("New exception: {0}", ex.Message);
                    LogWriter logWriter = new(ex.Message);
                    return false;
                }
            }
        }

        public static bool InsertClient(Client client)
        {
            var builder = new MySqlConnectionStringBuilder
            {
                Server = ServerName,
                Port = ServerPort,
                UserID = User,
                Password = FullPassword,
                Database = DatabaseName,
            };
            string query = @"INSERT INTO Client
                                    (first_Name, last_Name, telephone_Number)
                                    VALUES
                                    (@first_Name, @last_Name, @telephone_Number);";

            using var connection = new MySqlConnection(builder.ConnectionString);

            using (MySqlCommand command = new MySqlCommand(query, connection))
            {
                MySqlParameter paramFirstName = new MySqlParameter("@first_Name", System.Data.DbType.String);
                paramFirstName.Value = client.FirstName;
                command.Parameters.Add(paramFirstName);

                MySqlParameter paramLastName = new MySqlParameter("@last_Name", System.Data.DbType.String);
                paramLastName.Value = client.LastName;
                command.Parameters.Add(paramLastName);

                MySqlParameter paramTelephoneNumber = new MySqlParameter("@telephone_Number", System.Data.DbType.String);
                paramTelephoneNumber.Value = client.Telephone;
                command.Parameters.Add(paramTelephoneNumber);

                try
                {
                    connection.Open();
                    command.ExecuteNonQuery();
                    return true;
                }
                catch (Exception ex)
                {
                    Debug.WriteLine("New exception: {0}", ex.Message);
                    LogWriter logWriter = new(ex.Message);
                    return false;
                }
            }
        }
        public static bool DeleteVehicle(int ID, ref bool fkViolation)
        {
            var builder = new MySqlConnectionStringBuilder
            {
                Server = ServerName,
                Port = ServerPort,
                UserID = User,
                Password = FullPassword,
                Database = DatabaseName,
            };
            string query = @"DELETE FROM Vehicle WHERE ID = @ID;";

            using var connection = new MySqlConnection(builder.ConnectionString);

            using (MySqlCommand command = new MySqlCommand(query, connection))
            {

                MySqlParameter paramID = new MySqlParameter("@ID", System.Data.DbType.Int32);
                paramID.Value = ID;
                command.Parameters.Add(paramID);

                try
                {
                    connection.Open();
                    command.ExecuteNonQuery();
                    return true;
                }
                catch (MySqlException ex)
                {
                    if (ex.ErrorCode == MySqlErrorCode.RowIsReferenced || 
                        ex.ErrorCode == MySqlErrorCode.RowIsReferenced2)
                    {
                        fkViolation = true;
                    }
                    Debug.WriteLine("New MySqlException: {0}", ex.Message);
                    LogWriter logWriter = new(ex.Message);
                    return false;
                }
                catch (Exception ex)
                {
                    Debug.WriteLine("New exception: {0}", ex.Message);
                    LogWriter logWriter = new(ex.Message);
                    return false;
                }
            }
        }
        public static bool DeleteEmployee(int ID, ref bool fkViolation)
        {
            var builder = new MySqlConnectionStringBuilder
            {
                Server = ServerName,
                Port = ServerPort,
                UserID = User,
                Password = FullPassword,
                Database = DatabaseName,
            };
            string query = @"DELETE FROM Employee WHERE ID = @ID;";

            using var connection = new MySqlConnection(builder.ConnectionString);

            using (MySqlCommand command = new MySqlCommand(query, connection))
            {
                MySqlParameter paramID = new MySqlParameter("@ID", System.Data.DbType.Int32);
                paramID.Value = ID;
                command.Parameters.Add(paramID);

                try
                {
                    connection.Open();
                    command.ExecuteNonQuery();
                    return true;
                }
                catch (MySqlException ex)
                {
                    if (ex.ErrorCode == MySqlErrorCode.RowIsReferenced ||
                        ex.ErrorCode == MySqlErrorCode.RowIsReferenced2)
                    {
                        fkViolation = true;
                    }
                    Debug.WriteLine("New MySqlException: {0}", ex.Message);
                    LogWriter logWriter = new(ex.Message);
                    return false;
                }
                catch (Exception ex)
                {
                    Debug.WriteLine("New exception: {0}", ex.Message);
                    LogWriter logWriter = new(ex.Message);
                    return false;
                }
            }
        }

        public static void SelectClients(ref List<Client> clients)
        {
            var builder = new MySqlConnectionStringBuilder
            {
                Server = ServerName,
                Port = ServerPort,
                UserID = User,
                Password = FullPassword,
                Database = DatabaseName,
            };

            using var connection = new MySqlConnection(builder.ConnectionString);
            connection.Open();

            using var command = connection.CreateCommand();
            command.CommandText = @"SELECT * FROM client";

            var reader = command.ExecuteReader();
            while (reader.Read())
            {
                Client client = new Client();
                client.ID = reader.GetInt32("ID");
                client.FirstName = reader.GetString("first_Name");
                client.LastName = reader.GetString("last_Name");
                client.Telephone = reader.GetString("telephone_Number");
                clients.Add(client);
            }
            reader.Close();
            connection.Close();
        }


        public static bool InsertVehicle(Vehicle vehicle)
        {

            var builder = new MySqlConnectionStringBuilder
            {
                Server = ServerName,
                Port = ServerPort,
                UserID = User,
                Password = FullPassword,
                Database = DatabaseName,
            };

            string query = @"INSERT INTO Vehicle
                                    (model, make_Year, price, vehicle_TypeID, manufacturerID, image, is_Sold)
                                    VALUES
                                    (@model, @make_Year, @price, @vehicle_TypeID, @manufacturerID, @image, @is_Sold);";

            using var connection = new MySqlConnection(builder.ConnectionString);
            using (MySqlCommand command = new MySqlCommand(query, connection))
            {
                MySqlParameter paramModel = new MySqlParameter("@model", System.Data.DbType.String);
                paramModel.Value = vehicle.Model;
                command.Parameters.Add(paramModel);

                MySqlParameter paramMakeYear = new MySqlParameter("@make_Year", System.Data.DbType.Int32);
                paramMakeYear.Value = vehicle.MakeYear;
                command.Parameters.Add(paramMakeYear);

                MySqlParameter paramPrice = new MySqlParameter("@price", System.Data.DbType.Decimal);
                paramPrice.Value = vehicle.Price;
                command.Parameters.Add(paramPrice);

                MySqlParameter paramVehicleTypeID = new MySqlParameter("@vehicle_TypeID", System.Data.DbType.Int32);
                paramVehicleTypeID.Value = vehicle.VehicleType.ID;
                command.Parameters.Add(paramVehicleTypeID);

                MySqlParameter paramManufacturerID = new MySqlParameter("@manufacturerID", System.Data.DbType.Int32);
                paramManufacturerID.Value = vehicle.Manufacturer.ID;
                command.Parameters.Add(paramManufacturerID);

                MySqlParameter paramImage = new MySqlParameter("@image", System.Data.DbType.Binary);
                paramImage.Value = vehicle.Image;
                command.Parameters.Add(paramImage);

                MySqlParameter paramIsSold = new MySqlParameter("@is_Sold", System.Data.DbType.Boolean);
                paramIsSold.Value = vehicle.IsSold;
                command.Parameters.Add(paramIsSold);

                try
                {
                    connection.Open();
                    command.ExecuteNonQuery();
                    return true;
                }
                catch (Exception ex)
                {
                    Debug.WriteLine("New exception: {0}", ex.Message);
                    LogWriter logWriter = new(ex.Message);
                    return false;
                }
            }
        }

        public static bool UpdateVehicle(Vehicle vehicle)
        {
            var builder = new MySqlConnectionStringBuilder
            {
                Server = ServerName,
                Port = ServerPort,
                UserID = User,
                Password = FullPassword,
                Database = DatabaseName,
            };

            string query = @"UPDATE Vehicle
                             SET model = @model, make_Year = @make_Year, price = @price, vehicle_TypeID = @vehicle_TypeID,
                             manufacturerID = @manufacturerID, image = @image
                             WHERE ID = @ID;";

            using var connection = new MySqlConnection(builder.ConnectionString);
            using (MySqlCommand command = new MySqlCommand(query, connection))
            {

                MySqlParameter paramID = new MySqlParameter("@ID", System.Data.DbType.Int32);
                paramID.Value = vehicle.ID;
                command.Parameters.Add(paramID);

                MySqlParameter paramModel = new MySqlParameter("@model", System.Data.DbType.String);
                paramModel.Value = vehicle.Model;
                command.Parameters.Add(paramModel);

                MySqlParameter paramMakeYear = new MySqlParameter("@make_Year", System.Data.DbType.Int32);
                paramMakeYear.Value = vehicle.MakeYear;
                command.Parameters.Add(paramMakeYear);

                MySqlParameter paramPrice = new MySqlParameter("@price", System.Data.DbType.Decimal);
                paramPrice.Value = vehicle.Price;
                command.Parameters.Add(paramPrice);

                MySqlParameter paramVehicleTypeID = new MySqlParameter("@vehicle_TypeID", System.Data.DbType.Int32);
                paramVehicleTypeID.Value = vehicle.VehicleType.ID;
                command.Parameters.Add(paramVehicleTypeID);

                MySqlParameter paramManufacturerID = new MySqlParameter("@manufacturerID", System.Data.DbType.Int32);
                paramManufacturerID.Value = vehicle.Manufacturer.ID;
                command.Parameters.Add(paramManufacturerID);

                MySqlParameter paramImage = new MySqlParameter("@image", System.Data.DbType.Binary);
                paramImage.Value = vehicle.Image;
                command.Parameters.Add(paramImage);

                try
                {
                    connection.Open();
                    command.ExecuteNonQuery();
                    return true;
                }
                catch (Exception ex)
                {
                    Debug.WriteLine("New exception: {0}", ex.Message);
                    LogWriter logWriter = new(ex.Message);
                    return false;
                }
            }
        }
        public static bool UpdatePurchase(Purchase purchase)
        {
            var builder = new MySqlConnectionStringBuilder
            {
                Server = ServerName,
                Port = ServerPort,
                UserID = User,
                Password = FullPassword,
                Database = DatabaseName,
            };

            string query = @"UPDATE Purchase
                             SET clientID = @clientID, vehicleID = @vehicleID, date_Of_Purchase = @date_Of_Purchase, 
                             final_Price = @final_Price, payment_TypeID = @payment_TypeID, employee_ID = @employee_ID                         
                             WHERE ID = @ID;";

            using var connection = new MySqlConnection(builder.ConnectionString);
            using (MySqlCommand command = new MySqlCommand(query, connection))
            {
                MySqlParameter paramID = new MySqlParameter("@ID", System.Data.DbType.Int32);
                paramID.Value = purchase.ID;
                command.Parameters.Add(paramID);

                MySqlParameter paramClientID = new MySqlParameter("@clientID", System.Data.DbType.Int32);
                paramClientID.Value = purchase.Client.ID;
                command.Parameters.Add(paramClientID);

                MySqlParameter paramVehicleID = new MySqlParameter("@vehicleID", System.Data.DbType.Int32);
                paramVehicleID.Value = purchase.Vehicle.ID;
                command.Parameters.Add(paramVehicleID);

                MySqlParameter paramDateOfPurchase = new MySqlParameter("@date_Of_Purchase", System.Data.DbType.DateTime);
                paramDateOfPurchase.Value = purchase.DateOfPurchase;
                command.Parameters.Add(paramDateOfPurchase);

                MySqlParameter paramFinalPrice = new MySqlParameter("@final_Price", System.Data.DbType.Decimal);
                paramFinalPrice.Value = purchase.FinalPrice;
                command.Parameters.Add(paramFinalPrice);                

                MySqlParameter paramPaymentTypeID = new MySqlParameter("@payment_TypeID", System.Data.DbType.Int32);
                paramPaymentTypeID.Value = purchase.PaymentType.ID;
                command.Parameters.Add(paramPaymentTypeID);

                MySqlParameter paramEmployeeID = new MySqlParameter("@employee_ID", System.Data.DbType.Int32);
                paramEmployeeID.Value = purchase.Employee.ID;
                command.Parameters.Add(paramEmployeeID);

                try
                {
                    connection.Open();
                    command.ExecuteNonQuery();
                    return true;
                }
                catch (Exception ex)
                {
                    Debug.WriteLine("New exception: {0}", ex.Message);
                    LogWriter logWriter = new(ex.Message);
                    return false;
                }
            }
        }

        public static bool DeleteClient(int ID, ref bool fkViolation)
        {
            var builder = new MySqlConnectionStringBuilder
            {
                Server = ServerName,
                Port = ServerPort,
                UserID = User,
                Password = FullPassword,
                Database = DatabaseName,
            };

            string query = @"DELETE FROM Client WHERE ID = @ID;";

            using var connection = new MySqlConnection(builder.ConnectionString);


            using (MySqlCommand command = new MySqlCommand(query, connection))
            {

                MySqlParameter paramID = new MySqlParameter("@ID", System.Data.DbType.Int32);
                paramID.Value = ID;
                command.Parameters.Add(paramID);

                try
                {
                    connection.Open();
                    command.ExecuteNonQuery();
                    return true;
                }
                catch (MySqlException ex)
                {
                    if (ex.ErrorCode == MySqlErrorCode.RowIsReferenced ||
                        ex.ErrorCode == MySqlErrorCode.RowIsReferenced2)
                    {
                        fkViolation = true;
                    }
                    Debug.WriteLine("New MySqlException: {0}", ex.Message);
                    LogWriter logWriter = new(ex.Message);
                    return false;
                }
                catch (Exception ex)
                {
                    Debug.WriteLine("New exception: {0}", ex.Message);
                    LogWriter logWriter = new(ex.Message);
                    return false;
                }
            }
        }

        public static bool UpdateEmployee(Employee employee)
        {
            var builder = new MySqlConnectionStringBuilder
            {
                Server = ServerName,
                Port = ServerPort,
                UserID = User,
                Password = FullPassword,
                Database = DatabaseName,
            };

            string query = @"UPDATE Employee
                             SET first_Name = @first_Name, last_Name = @last_Name, telephone_Number = @telephone_Number, 
                             email = @email, date_Of_Birth = @date_Of_Birth,
                             password = @password, salt = @salt
                             WHERE ID = @ID;";

            using var connection = new MySqlConnection(builder.ConnectionString);


            using (MySqlCommand command = new MySqlCommand(query, connection))
            {
                MySqlParameter paramID = new MySqlParameter("@ID", System.Data.DbType.Int32);
                paramID.Value = employee.ID;
                command.Parameters.Add(paramID);

                MySqlParameter paramFirstName = new MySqlParameter("@first_Name", System.Data.DbType.String);
                paramFirstName.Value = employee.FirstName;
                command.Parameters.Add(paramFirstName);

                MySqlParameter paramLastName = new MySqlParameter("@last_Name", System.Data.DbType.String);
                paramLastName.Value = employee.LastName;
                command.Parameters.Add(paramLastName);

                MySqlParameter paramNumber = new MySqlParameter("@telephone_Number", System.Data.DbType.String);
                paramNumber.Value = employee.Telephone;
                command.Parameters.Add(paramNumber);

                MySqlParameter paramEmail = new MySqlParameter("@email", System.Data.DbType.String);
                paramEmail.Value = employee.Email;
                command.Parameters.Add(paramEmail);

                MySqlParameter paramDOB = new MySqlParameter("@date_Of_Birth", System.Data.DbType.Date);
                paramDOB.Value = employee.DateOfBirth.Date;
                command.Parameters.Add(paramDOB);

                MySqlParameter paramPassword = new MySqlParameter("@password", System.Data.DbType.Binary);
                paramPassword.Value = employee.Password;
                command.Parameters.Add(paramPassword);

                MySqlParameter paramSalt = new MySqlParameter("@salt", System.Data.DbType.String);
                paramSalt.Value = employee.Salt;
                command.Parameters.Add(paramSalt);


                try
                {
                    connection.Open();
                    command.ExecuteNonQuery();
                    return true;
                }
                catch (Exception ex)
                {
                    Debug.WriteLine("New exception: {0}", ex.Message);
                    LogWriter logWriter = new(ex.Message);
                    return false;
                }
            }

        }
        public static bool UpdateClient(Client client)
        {
            var builder = new MySqlConnectionStringBuilder
            {
                Server = ServerName,
                Port = ServerPort,
                UserID = User,
                Password = FullPassword,
                Database = DatabaseName,
            };

            string query = @"UPDATE Client
                             SET first_Name = @first_Name, last_Name = @last_Name, telephone_Number = @telephone_Number                             
                             WHERE ID = @ID;";

            using var connection = new MySqlConnection(builder.ConnectionString);

            using (MySqlCommand command = new MySqlCommand(query, connection))
            {
                MySqlParameter paramID = new MySqlParameter("@ID", System.Data.DbType.Int32);
                paramID.Value = client.ID;
                command.Parameters.Add(paramID);

                MySqlParameter paramFirstName = new MySqlParameter("@first_Name", System.Data.DbType.String);
                paramFirstName.Value = client.FirstName;
                command.Parameters.Add(paramFirstName);

                MySqlParameter paramLastName = new MySqlParameter("@last_Name", System.Data.DbType.String);
                paramLastName.Value = client.LastName;
                command.Parameters.Add(paramLastName);

                MySqlParameter paramNumber = new MySqlParameter("@telephone_Number", System.Data.DbType.String);
                paramNumber.Value = client.Telephone;
                command.Parameters.Add(paramNumber);

                try
                {
                    connection.Open();
                    command.ExecuteNonQuery();
                    return true;
                }
                catch (Exception ex)
                {
                    Debug.WriteLine("New exception: {0}", ex.Message);
                    LogWriter logWriter = new(ex.Message);
                    return false;
                }
            }
        }

        public static bool UpdateManufacturer(Manufacturer manufacturer)
        {
            var builder = new MySqlConnectionStringBuilder
            {
                Server = ServerName,
                Port = ServerPort,
                UserID = User,
                Password = FullPassword,
                Database = DatabaseName,
            };

            string query = @"UPDATE Manufacturer
                             SET name = @name                         
                             WHERE ID = @ID;";

            using var connection = new MySqlConnection(builder.ConnectionString);

            using (MySqlCommand command = new MySqlCommand(query, connection))
            {
                MySqlParameter paramID = new MySqlParameter("@ID", System.Data.DbType.Int32);
                paramID.Value = manufacturer.ID;
                command.Parameters.Add(paramID);

                MySqlParameter paramName = new MySqlParameter("@name", System.Data.DbType.String);
                paramName.Value = manufacturer.Name;
                command.Parameters.Add(paramName);

                try
                {
                    connection.Open();
                    command.ExecuteNonQuery();
                    return true;
                }
                catch (Exception ex)
                {
                    Debug.WriteLine("New exception: {0}", ex.Message);
                    LogWriter logWriter = new(ex.Message);
                    return false;
                }
            }
        }
        public static bool UpdatePaymentType(PaymentType paymentType)
        {
            var builder = new MySqlConnectionStringBuilder
            {
                Server = ServerName,
                Port = ServerPort,
                UserID = User,
                Password = FullPassword,
                Database = DatabaseName,
            };

            string query = @"UPDATE Payment_Type
                             SET type_EN = @type_EN, type_BG = @type_BG
                             WHERE ID = @ID;";

            using var connection = new MySqlConnection(builder.ConnectionString);

            using (MySqlCommand command = new MySqlCommand(query, connection))
            {
                MySqlParameter paramID = new MySqlParameter("@ID", System.Data.DbType.Int32);
                paramID.Value = paymentType.ID;
                command.Parameters.Add(paramID);

                MySqlParameter paramTypeEN = new MySqlParameter("@type_EN", System.Data.DbType.String);
                paramTypeEN.Value = paymentType.TypeEN;
                command.Parameters.Add(paramTypeEN);

                MySqlParameter paramTypeBG = new MySqlParameter("@type_BG", System.Data.DbType.String);
                paramTypeBG.Value = paymentType.TypeBG;
                command.Parameters.Add(paramTypeBG);

                try
                {
                    connection.Open();
                    command.ExecuteNonQuery();
                    return true;
                }
                catch (Exception ex)
                {
                    Debug.WriteLine("New exception: {0}", ex.Message);
                    LogWriter logWriter = new(ex.Message);
                    return false;
                }
            }
        }
        public static bool UpdateVehicleType(VehicleType vehicleType)
        {
            var builder = new MySqlConnectionStringBuilder
            {
                Server = ServerName,
                Port = ServerPort,
                UserID = User,
                Password = FullPassword,
                Database = DatabaseName,
            };

            string query = @"UPDATE Vehicle_Type
                             SET type_EN = @type_EN, type_BG = @type_BG                          
                             WHERE ID = @ID;";

            using var connection = new MySqlConnection(builder.ConnectionString);

            using (MySqlCommand command = new MySqlCommand(query, connection))
            {
                MySqlParameter paramID = new MySqlParameter("@ID", System.Data.DbType.Int32);
                paramID.Value = vehicleType.ID;
                command.Parameters.Add(paramID);

                MySqlParameter paramTypeEN = new MySqlParameter("@type_EN", System.Data.DbType.String);
                paramTypeEN.Value = vehicleType.TypeEN;
                command.Parameters.Add(paramTypeEN);

                MySqlParameter paramTypeBG = new MySqlParameter("@type_BG", System.Data.DbType.String);
                paramTypeBG.Value = vehicleType.TypeBG;
                command.Parameters.Add(paramTypeBG);

                try
                {
                    connection.Open();
                    command.ExecuteNonQuery();
                    return true;
                }
                catch (Exception ex)
                {
                    Debug.WriteLine("New exception: {0}", ex.Message);
                    LogWriter logWriter = new(ex.Message);
                    return false;
                }
            }
        }

        public static bool DeleteManufacturer(int ID, ref bool fkViolation)
        {
            var builder = new MySqlConnectionStringBuilder
            {
                Server = ServerName,
                Port = ServerPort,
                UserID = User,
                Password = FullPassword,
                Database = DatabaseName,
            };

            string query = @"DELETE FROM Manufacturer WHERE ID = @ID;";

            using var connection = new MySqlConnection(builder.ConnectionString);

            using (MySqlCommand command = new MySqlCommand(query, connection))
            {
                MySqlParameter paramID = new MySqlParameter("@ID", System.Data.DbType.Int32);
                paramID.Value = ID;
                command.Parameters.Add(paramID);

                try
                {
                    connection.Open();
                    command.ExecuteNonQuery();
                    return true;
                }
                catch (MySqlException ex)
                {
                    if (ex.ErrorCode == MySqlErrorCode.RowIsReferenced ||
                        ex.ErrorCode == MySqlErrorCode.RowIsReferenced2)
                    {
                        fkViolation = true;
                    }
                    Debug.WriteLine("New MySqlException: {0}", ex.Message);
                    LogWriter logWriter = new(ex.Message);
                    return false;
                }
                catch (Exception ex)
                {
                    Debug.WriteLine("New exception: {0}", ex.Message);
                    LogWriter logWriter = new(ex.Message);
                    return false;
                }

            }
        }
        public static bool DeleteManufacturerVehicleTypeByManufacturer(int manufacturerID)
        {
            var builder = new MySqlConnectionStringBuilder
            {
                Server = ServerName,
                Port = ServerPort,
                UserID = User,
                Password = FullPassword,
                Database = DatabaseName,
            };

            string query = @"DELETE FROM Manufacturer_Vehicle_Type WHERE manufacturerID = @param_ManufacturerID;";

            using var connection = new MySqlConnection(builder.ConnectionString);

            using (MySqlCommand command = new MySqlCommand(query, connection))
            {
                MySqlParameter paramManufacturerID = new MySqlParameter("@param_ManufacturerID", System.Data.DbType.Int32);
                paramManufacturerID.Value = manufacturerID;
                command.Parameters.Add(paramManufacturerID);

                try
                {
                    connection.Open();
                    command.ExecuteNonQuery();
                    return true;
                }                
                catch (Exception ex)
                {
                    Debug.WriteLine("New exception: {0}", ex.Message);
                    LogWriter logWriter = new(ex.Message);
                    return false;
                }

            }
        }
        public static bool DeletePaymentType(int ID, ref bool fkViolation)
        {
            var builder = new MySqlConnectionStringBuilder
            {
                Server = ServerName,
                Port = ServerPort,
                UserID = User,
                Password = FullPassword,
                Database = DatabaseName,
            };

            string query = @"DELETE FROM Payment_Type WHERE ID = @ID;";

            using var connection = new MySqlConnection(builder.ConnectionString);

            using (MySqlCommand command = new MySqlCommand(query, connection))
            {
                MySqlParameter paramID = new MySqlParameter("@ID", System.Data.DbType.Int32);
                paramID.Value = ID;
                command.Parameters.Add(paramID);

                try
                {
                    connection.Open();
                    command.ExecuteNonQuery();
                    return true;
                }
                catch (MySqlException ex)
                {
                    if (ex.ErrorCode == MySqlErrorCode.RowIsReferenced ||
                        ex.ErrorCode == MySqlErrorCode.RowIsReferenced2)
                    {
                        fkViolation = true;
                    }
                    Debug.WriteLine("New MySqlException: {0}", ex.Message);
                    LogWriter logWriter = new(ex.Message);
                    return false;
                }
                catch (Exception ex)
                {
                    Debug.WriteLine("New exception: {0}", ex.Message);
                    LogWriter logWriter = new(ex.Message);
                    return false;
                }
            }
        }
        public static bool DeleteVehicleType(int ID, ref bool fkViolation)
        {
            var builder = new MySqlConnectionStringBuilder
            {
                Server = ServerName,
                Port = ServerPort,
                UserID = User,
                Password = FullPassword,
                Database = DatabaseName,
            };

            string query = @"DELETE FROM Vehicle_Type WHERE ID = @ID;";

            using var connection = new MySqlConnection(builder.ConnectionString);

            using (MySqlCommand command = new MySqlCommand(query, connection))
            {
                MySqlParameter paramID = new MySqlParameter("@ID", System.Data.DbType.Int32);
                paramID.Value = ID;
                command.Parameters.Add(paramID);

                try
                {
                    connection.Open();
                    command.ExecuteNonQuery();
                    return true;
                }
                catch (MySqlException ex)
                {
                    if (ex.ErrorCode == MySqlErrorCode.RowIsReferenced ||
                        ex.ErrorCode == MySqlErrorCode.RowIsReferenced2)
                    {
                        fkViolation = true;
                    }
                    Debug.WriteLine("New MySqlException: {0}", ex.Message);
                    LogWriter logWriter = new(ex.Message);
                    return false;
                }
                catch (Exception ex)
                {
                    Debug.WriteLine("New exception: {0}", ex.Message);
                    LogWriter logWriter = new(ex.Message);
                    return false;
                }
            }
        }
        public static bool DeletePurchase(int ID)
        {
            var builder = new MySqlConnectionStringBuilder
            {
                Server = ServerName,
                Port = ServerPort,
                UserID = User,
                Password = FullPassword,
                Database = DatabaseName,
            };

            string query = @"DELETE FROM Purchase WHERE ID = @ID;";

            using var connection = new MySqlConnection(builder.ConnectionString);

            using (MySqlCommand command = new MySqlCommand(query, connection))
            {
                MySqlParameter paramID = new MySqlParameter("@ID", System.Data.DbType.Int32);
                paramID.Value = ID;
                command.Parameters.Add(paramID);

                try
                {
                    connection.Open();
                    command.ExecuteNonQuery();
                    return true;
                }
                catch (Exception ex)
                {
                    Debug.WriteLine("New exception: {0}", ex.Message);
                    LogWriter logWriter = new(ex.Message);
                    return false;
                }
            }
        }

        public static bool InsertPurchase(Purchase purchase)
        {
            var builder = new MySqlConnectionStringBuilder
            {
                Server = ServerName,
                Port = ServerPort,
                UserID = User,
                Password = FullPassword,
                Database = DatabaseName,
            };            

            using var connection = new MySqlConnection(builder.ConnectionString);
            
            using (MySqlCommand command = new MySqlCommand("Insert_Purchase_And_Update_Vehicle", connection))
            {
                command.CommandType = System.Data.CommandType.StoredProcedure;
                
                MySqlParameter paramClientID = new MySqlParameter("@param_ClientID", System.Data.DbType.Int32);
                paramClientID.Value = purchase.Client.ID;
                command.Parameters.Add(paramClientID);

                MySqlParameter paramVehicleID = new MySqlParameter("@param_VehicleID", System.Data.DbType.Int32);
                paramVehicleID.Value = purchase.Vehicle.ID;
                command.Parameters.Add(paramVehicleID);

                MySqlParameter paramDateOfPurchase = new MySqlParameter("@param_Date_Of_Purchase", System.Data.DbType.DateTime);
                paramDateOfPurchase.Value = purchase.DateOfPurchase.ToUniversalTime();
                command.Parameters.Add(paramDateOfPurchase);

                MySqlParameter paramFinalPrice = new MySqlParameter("@param_Final_Price", System.Data.DbType.Decimal);
                paramFinalPrice.Value = purchase.FinalPrice;
                command.Parameters.Add(paramFinalPrice);

                MySqlParameter paramPaymentTypeID = new MySqlParameter("@param_Payment_TypeID", System.Data.DbType.Int32);
                paramPaymentTypeID.Value = purchase.PaymentType.ID;
                command.Parameters.Add(paramPaymentTypeID);

                MySqlParameter paramEmployeeID = new MySqlParameter("@param_EmployeeID", System.Data.DbType.Int32);
                paramEmployeeID.Value = purchase.Employee.ID;
                command.Parameters.Add(paramEmployeeID);
                try
                {
                    connection.Open();
                    command.ExecuteNonQuery();
                    return true;
                }
                catch (Exception ex)
                {
                    Debug.WriteLine("New exception: {0}", ex.Message);
                    LogWriter logWriter = new(ex.Message);
                    return false;
                }
            }
        }
        public static bool StornoPurchase(Purchase purchase)
        {
            var builder = new MySqlConnectionStringBuilder
            {
                Server = ServerName,
                Port = ServerPort,
                UserID = User,
                Password = FullPassword,
                Database = DatabaseName,
            };

            using var connection = new MySqlConnection(builder.ConnectionString);

            using (MySqlCommand command = new MySqlCommand("Purchase_Storno_Operation_And_Make_Vehicle_Not_Sold", connection))
            {
                command.CommandType = System.Data.CommandType.StoredProcedure;

                MySqlParameter paramVehicleID = new MySqlParameter("@param_VehicleID", System.Data.DbType.Int32);
                paramVehicleID.Value = purchase.Vehicle.ID;
                command.Parameters.Add(paramVehicleID);

                MySqlParameter paramEmployeeID = new MySqlParameter("@param_PurchaseID", System.Data.DbType.Int32);
                paramEmployeeID.Value = purchase.ID;
                command.Parameters.Add(paramEmployeeID);
                try
                {
                    connection.Open();
                    command.ExecuteNonQuery();
                    return true;
                }
                catch (Exception ex)
                {
                    Debug.WriteLine("New exception: {0}", ex.Message);
                    LogWriter logWriter = new(ex.Message);
                    return false;
                }

            }
        }
    }
}

