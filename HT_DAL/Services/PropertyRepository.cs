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
    public class PropertyRepository : BaseRepository<Property>, IPropertyRepository
    {
        #region Constructor
        public PropertyRepository(IConfiguration config) : base(config)
        {
        }
        #endregion

        #region Delete method
        public void Delete(int id)
        {
            string query = "UPDATE Property SET Status = 'i' WHERE Id_Property = @id";
            Command cmd = new Command(query);
            cmd.AddParameter(nameof(Property.Id_Property), id);

            Connect().ExecuteNonQuery(cmd);
        } 
        #endregion

        #region GetAll method
        public IEnumerable<Property> GetAll()
        {
            string query = "SELECT * FROM Property WHERE Status = 'a'";
            Command cmd = new Command(query);

            return Connect().ExecuteReader(cmd, Convert);
        } 
        #endregion

        #region GetById method
        public Property GetById(int id)
        {
            string query = "SELECT * FROM Property WHERE Id_Property = @id AND Status = 'a'";
            Command cmd = new Command(query);
            cmd.AddParameter(nameof(Property.Id_Property), id);

            Connection connection = new Connection(_connectionString);
            return connection.ExecuteReader(cmd, Convert).FirstOrDefault();
        } 
        #endregion

        #region Insert method
        public bool Insert(Property p)
        {
            string query = "INSERT INTO Property (" +
                            "CreationDate, " +
                            "Title," +
                            "ShortDescription," +
                            "LongDescription," +
                            "City," +
                            "ZipCode," +
                            "Street," +
                            "Number," +
                            "Image," +
                            "Person," +
                            "BathRoom," +
                            "WC," +
                            "Garden," +
                            "Pool," +
                            "Washing," +
                            "Internet," +
                            "Pets," +
                            "Status," +
                            "InactiveDate," +
                            "IsInsurance," +
                            "Id_Country," +
                            "Id_Customer) " +
                    "VALUES(" +
                            "@creadate, " +
                            "@title, " +
                            "@sdesc, " +
                            "@ldesc, " +
                            "@city, " +
                            "@zc, " +
                            "@street, " +
                            "@nber, " +
                            "@img, " +
                            "@person," +
                            "@broom," +
                            "@wc," +
                            "@garden," +
                            "@pool," +
                            "@washing," +
                            "@internet," +
                            "@pets," +
                            "@status," +
                            "@inacdate," +
                            "@isi," +
                            "@id_c," +
                            "@id_cust)";
            Command cmd = new Command(query);
            cmd.AddParameter("creadate", p.CreationDate);
            cmd.AddParameter("title", p.Title);
            cmd.AddParameter("sdesc", p.ShortDescription);
            cmd.AddParameter("ldesc", p.LongDescription);
            cmd.AddParameter("city", p.City);
            cmd.AddParameter("zc", p.ZipCode);
            cmd.AddParameter("street", p.Street);
            cmd.AddParameter("nber", p.Number);
            cmd.AddParameter("img", p.Image);
            cmd.AddParameter("person", p.Person);
            cmd.AddParameter("broom", p.BathRoom);
            cmd.AddParameter("wc", p.WC);
            cmd.AddParameter("garden", p.Garden);
            cmd.AddParameter("pool", p.Pool);
            cmd.AddParameter("washing", p.Washing);
            cmd.AddParameter("internet", p.Internet);
            cmd.AddParameter("pets", p.Pets);
            cmd.AddParameter("status", p.Status);
            cmd.AddParameter("inacdate", p.InactiveDate);
            cmd.AddParameter("isi", p.IsInsurance);
            cmd.AddParameter("id_c", p.Id_Country);
            cmd.AddParameter("id_cust", p.Id_Customer);

            Connection connection = new Connection(_connectionString);
            return connection.ExecuteNonQuery(cmd) == 1;
        } 
        #endregion

        #region Update method
        public bool Update(Property p)
        {
            string query = "UPDATE Property SET " +
                            "Title = @title," +
                            "ShortDescription = @sdesc," +
                            "LongDescription = @ldesc," +
                            "City = @city," +
                            "ZipCode = @zp," +
                            "Street = @street," +
                            "Number = @nber," +
                            "Image = @img," +
                            "Person = @person," +
                            "BathRoom = @broom," +
                            "WC = @wc," +
                            "Garden = @garden," +
                            "Pool = @pool," +
                            "Washing = @washing," +
                            "Internet = @internet," +
                            "Pets = @pets," +
                            "IsInsurance = @isi," +
                            "WHERE Id_Property = @id_p";

            Command cmd = new Command(query);
            cmd.AddParameter("title", p.Title);
            cmd.AddParameter("sdesc", p.ShortDescription);
            cmd.AddParameter("ldesc", p.LongDescription);
            cmd.AddParameter("city", p.City);
            cmd.AddParameter("zp", p.ZipCode);
            cmd.AddParameter("street", p.Street);
            cmd.AddParameter("nber", p.Number);
            cmd.AddParameter("img", p.Image);
            cmd.AddParameter("person", p.Person);
            cmd.AddParameter("broom", p.BathRoom);
            cmd.AddParameter("wc", p.WC);
            cmd.AddParameter("garden", p.Garden);
            cmd.AddParameter("pool", p.Pool);
            cmd.AddParameter("washing", p.Washing);
            cmd.AddParameter("internet", p.Internet);
            cmd.AddParameter("pets", p.Pets);
            cmd.AddParameter("isi", p.IsInsurance);
            cmd.AddParameter("id_p", p.Id_Property);

            Connection connection = new Connection(_connectionString);
            return connection.ExecuteNonQuery(cmd) == 1;
        } 
        #endregion
    }
}
