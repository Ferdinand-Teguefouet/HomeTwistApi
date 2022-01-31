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
    public class OpinionRepository : BaseRepository<Opinion>, IOpinionRepository
    {
        #region Constructor
        public OpinionRepository(IConfiguration config) : base(config)
        {
        }
        #endregion

        #region Delete method
        public void Delete(int id)
        {
            string query = "UPDATE Opinion SET IsValidate = false WHERE Id_Opinion = @id";
            Command cmd = new Command(query);
            cmd.AddParameter(nameof(Opinion.Id_Opinion), id);

            Connect().ExecuteNonQuery(cmd);
        }
        #endregion

        #region GetAll method
        public IEnumerable<Opinion> GetAll()
        {
            string query = "SELECT * FROM Opinion WHERE IsValidate = true";
            Command cmd = new Command(query);

            return Connect().ExecuteReader(cmd, Convert);
        }
        #endregion

        #region GetById method
        public Opinion GetById(int id)
        {
            string query = "SELECT * FROM Opinion WHERE Id_Opinion = @id";
            Command cmd = new Command(query);
            cmd.AddParameter(nameof(Opinion.Id_Opinion), id);

            Connection connection = new Connection(_connectionString);
            return connection.ExecuteReader(cmd, Convert).FirstOrDefault();
        }
        #endregion

        #region Insert method
        public bool Insert(Opinion o)
        {
            string query = "INSERT INTO Opinion (" +
                            "Description, " +
                            "Note," +
                            "IsValidate," +
                            "Id_Property," +
                            "Id_Customer) " +
                    "VALUES(" +
                            "@desc, " +
                            "@note, " +
                            "@isv, " +
                            "@id_p, " +
                            "@id_c)";
            Command cmd = new Command(query);
            cmd.AddParameter("desc", o.Description);
            cmd.AddParameter("note", o.Note);
            cmd.AddParameter("isv", o.IsValidate);
            cmd.AddParameter("id_p", o.Id_Property);
            cmd.AddParameter("id_c", o.Id_Customer);

            Connection connection = new Connection(_connectionString);
            return connection.ExecuteNonQuery(cmd) == 1;
        }
        #endregion

        #region Update method
        public bool Update(Opinion o)
        {
            string query = "UPDATE Opinion SET " +
                            "Description = @desc," +
                            "Note = @note," +
                            "WHERE Id_Opinion = @id_o";

            Command cmd = new Command(query);
            cmd.AddParameter("desc", o.Description);
            cmd.AddParameter("note", o.Note);
            cmd.AddParameter("id_o", o.Id_Opinion);

            Connection connection = new Connection(_connectionString);
            return connection.ExecuteNonQuery(cmd) == 1;
        } 
        #endregion
    }
}
