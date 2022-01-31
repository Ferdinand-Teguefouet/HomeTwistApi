using HT_DAL.Entities;
using HT_DAL.Interfaces;
using Microsoft.Extensions.Configuration;
using MyADOLibrary;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HT_DAL.Services
{
    public class ExchangeRepository : BaseRepository<Exchange>, IExchangeRepository
    {
        #region Constructor
        public ExchangeRepository(IConfiguration config) : base(config)
        {
        }
        #endregion

        #region Delete method
        public void Delete(int id)
        {
            string query = "UPDATE Exchange SET Deleted = 'd' WHERE Id_Exchange = @id";
            Command cmd = new Command(query);
            cmd.AddParameter(nameof(Exchange.Id_Exchange), id);

            Connect().ExecuteNonQuery(cmd);
        }
        #endregion

        #region GetAll method
        public IEnumerable<Exchange> GetAll()
        {
            string query = "SELECT * FROM Exchange WHERE Deleted = null";
            Command cmd = new Command(query);

            return Connect().ExecuteReader(cmd, Convert);
        }
        #endregion

        #region GetById method
        public Exchange GetById(int id)
        {
            string query = "SELECT * FROM Exchange WHERE Id_Exchange = @id AND Deleted = null";
            Command cmd = new Command(query);
            cmd.AddParameter(nameof(Exchange.Id_Exchange), id);

            Connection connection = new Connection(_connectionString);
            return connection.ExecuteReader(cmd, Convert).FirstOrDefault();
        }
        #endregion

        #region Insert method
        public bool Insert(Exchange e)
        {
            string query = "INSERT INTO Exchange (" +
                            "CreationDate, " +
                            "StartDate," +
                            "EndDate," +
                            "IsAccepted," +
                            "PaymentDate," +
                            "PaidAmount," +
                            "Id_Cost," +
                            "Id_Insurance," +
                            "Id_Property," +
                            "Id_Customer, " +
                            "Deleted) " +
                    "VALUES(" +
                            "@creationdate, " +
                            "@startdate, " +
                            "@enddate, " +
                            "@isaccepted, " +
                            "@paymentdate, " +
                            "@paidamount, " +
                            "@idcost, " +
                            "@idinsurance, " +
                            "@idproperty, " +
                            "@idcustomer, " +
                            "@deleted)";
            Command cmd = new Command(query);
            cmd.AddParameter("creationdate", e.CreationDate);
            cmd.AddParameter("startdate", e.StartDate);
            cmd.AddParameter("enddate", e.EndDate);
            cmd.AddParameter("isaccepted", e.IsAccepted);
            cmd.AddParameter("paymentdate", e.PaymentDate);
            cmd.AddParameter("paidamount", e.PaidAmount);
            cmd.AddParameter("idcost", e.Id_Cost);
            cmd.AddParameter("idinsurance", e.Id_Insurance);
            cmd.AddParameter("idproperty", e.Id_Property);
            cmd.AddParameter("idcustomer", e.Id_Customer);
            cmd.AddParameter("idproperty", e.Id_Property);
            cmd.AddParameter("deleted", e.Deleted);

            Connection connection = new Connection(_connectionString);
            return connection.ExecuteNonQuery(cmd) == 1;
        }
        #endregion

        #region Update method
        public bool Update(Exchange e)
        {
            string query = "UPDATE Exchange SET " +
                            "CreationDate = @creationdate," +
                            "StartDate = @startdate," +
                            "EndDate = @enddate," +
                            "IsAccepted = @isaccepted," +
                            "PaymentDate = @paymentdate," +
                            "PaidAmount = @paidamount " +
                            "WHERE Id_Exchange = @idexc";

            Command cmd = new Command(query);
            cmd.AddParameter("creationdate", e.CreationDate);
            cmd.AddParameter("startdate", e.StartDate);
            cmd.AddParameter("enddate", e.EndDate);
            cmd.AddParameter("isaccepted", e.IsAccepted);
            cmd.AddParameter("paymentdate", e.PaymentDate);
            cmd.AddParameter("paidamount", e.PaidAmount);
            cmd.AddParameter("idexc", e.Id_Exchange);

            Connection connection = new Connection(_connectionString);
            return connection.ExecuteNonQuery(cmd) == 1;
        } 
        #endregion
    }
}
