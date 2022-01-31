using HT_DAL.Entities;
using HT_DAL.Interfaces;
using HT_DAL.Services;
using Microsoft.Extensions.Configuration;
using MyADOLibrary;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HT_DAL.Repositories
{
    public class CustomerRepository : BaseRepository<Customer>, ICustomerRepository
    {
        #region Constructor
        public CustomerRepository(IConfiguration config) : base(config)
        {
        }
        #endregion

        #region Delete method
        public void Delete(int id)
        {
            string query = "UPDATE Customer SET Deleted = 'd' WHERE Id_Customer = @id";
            Command cmd = new Command(query);
            cmd.AddParameter(nameof(Customer.Id_Customer), id);

            Connect().ExecuteNonQuery(cmd);
        }
        #endregion

        #region GetAll method
        public IEnumerable<Customer> GetAll()
        {
            string query = "SELECT * FROM Customer WHERE Deleted = null";
            Command cmd = new Command(query);

            return Connect().ExecuteReader(cmd, Convert);
        }
        #endregion

        #region GetByEmail method
        public Customer GetByEmail(string email)
        {
            string query = "SELECT * FROM Customer WHERE Email = @email AND Deleted = null";
            Command cmd = new Command(query);
            cmd.AddParameter(nameof(Customer.Email), email);

            Connection connection = new Connection(_connectionString);
            return connection.ExecuteReader(cmd, Convert).FirstOrDefault();
        }
        #endregion

        #region GetById method
        public Customer GetById(int id)
        {
            string query = "SELECT * FROM Customer WHERE Id_Customer = @id AND Deleted = null";
            Command cmd = new Command(query);
            cmd.AddParameter(nameof(Customer.Id_Customer), id);

            Connection connection = new Connection(_connectionString);
            return connection.ExecuteReader(cmd, Convert).FirstOrDefault();
        }
        #endregion

        #region Insert method
        public bool Insert(Customer c)
        {
            string query = "INSERT INTO Customer (" +
                            "LastName, " +
                            "FirstName," +
                            "Phone," +
                            "Email," +
                            "Password," +
                            "Salt," +
                            "IsAdmin," +
                            "Id_Country," +
                            "Id_WebApp," +
                            "Deleted) " +
                    "VALUES(" +
                            "@ln, " +
                            "@fn, " +
                            "@phone, " +
                            "@mail, " +
                            "@pw, " +
                            "@salt, " +
                            "@isa, " +
                            "@id_c, " +
                            "@id_w, " +
                            "@deleted)";
            Command cmd = new Command(query);
            cmd.AddParameter("ln", c.LastName);
            cmd.AddParameter("fn", c.FirstName);
            cmd.AddParameter("phone", c.Phone);
            cmd.AddParameter("mail", c.Email);
            cmd.AddParameter("pw", c.Password);
            cmd.AddParameter("salt", c.Salt);
            cmd.AddParameter("isa", c.IsAdmin);
            cmd.AddParameter("id_c", c.Id_Country);
            cmd.AddParameter("id_w", c.Id_WebApp);
            cmd.AddParameter("deleted", c.Deleted);

            Connection connection = new Connection(_connectionString);
            return connection.ExecuteNonQuery(cmd) == 1;
        }
        #endregion

        #region Update method
        public bool Update(Customer c)
        {
            string query = "UPDATE Customer SET " +
                            "LastName = @ln," +
                            "FirstName = @fn," +
                            "Phone = @phone," +
                            "Email = @mail," +
                            "Password = @pw," +
                            "WHERE Id_Customer = @id_cust";

            Command cmd = new Command(query);
            cmd.AddParameter("ln", c.LastName);
            cmd.AddParameter("fn", c.FirstName);
            cmd.AddParameter("phone", c.Phone);
            cmd.AddParameter("mail", c.Email);
            cmd.AddParameter("pw", c.Password);
            cmd.AddParameter("id_cust", c.Id_Customer);

            Connection connection = new Connection(_connectionString);
            return connection.ExecuteNonQuery(cmd) == 1;
        } 
        #endregion
    }
}
