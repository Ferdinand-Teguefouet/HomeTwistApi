using HT_DAL.Entities;
using HT_DAL.Interfaces;
using HT_DAL.Tools;
using Microsoft.Extensions.Configuration;
using MyADOLibrary;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HT_DAL.Services
{
    public class AvailabilityRepository : BaseRepository<Availability>, IAvailabilityRepository
    {
        #region constructor
        public AvailabilityRepository(IConfiguration config) : base(config)
        {
        } 
        #endregion
        #region Delete method
        public void Delete(int id)
        {
            string query = "UPDATE Availability SET Deleted = 'd' WHERE Id_Availability = @id";
            Command cmd = new Command(query);
            cmd.AddParameter("Id_Availability", id);

            Connect().ExecuteNonQuery(cmd);
        } 
        #endregion

        #region GetAll method
        public IEnumerable<Availability> GetAll()
        {
            string query = "SELECT * FROM Availability WHERE Deleted = null";
            Command cmd = new Command(query);

            return Connect().ExecuteReader(cmd, Convert);
        } 
        #endregion

        #region GetById method
        public Availability GetById(int id)
        {
            string query = "SELECT * FROM Availability WHERE Id_Availability = @id AND Deleted = null";
            Command cmd = new Command(query);
            cmd.AddParameter("Id_Availability", id);

            Connection connection = new Connection(_connectionString);
            return connection.ExecuteReader(cmd, Convert).FirstOrDefault();
        } 
        #endregion

        #region Insert method
        public bool Insert(Availability a)
        {
            string query = "INSERT INTO Availability (StartDate, EndDate, Id_Property) VALUES(@startdate,@enddate, @id_property)";
            Command cmd = new Command(query);
            cmd.AddParameter("startdate", a.StartDate);
            cmd.AddParameter("enddate", a.EndDate);
            cmd.AddParameter("Id_Property", a.Id_Property);

            Connection connection = new Connection(_connectionString);
            return connection.ExecuteNonQuery(cmd) == 1;
        } 
        #endregion

        #region Update method
        public bool Update(Availability a)
        {
            string query = "UPDATE Availability SET StartDate = @sd, EndDate = @ed, Id_Property=@id_prop WHERE Id_Availability = @id";
            Command cmd = new Command(query);
            cmd.AddParameter("sd", a.StartDate);
            cmd.AddParameter("ed", a.EndDate);
            cmd.AddParameter("id", a.Id_Availability);
            cmd.AddParameter("id_prop", a.Id_Property);

            Connection connection = new Connection(_connectionString);
            return connection.ExecuteNonQuery(cmd) == 1;
        } 
        #endregion
    }
}
