using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Server.IIS.Core;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Diagnostics;
using WebAPISample.Model.DBContext;
using WebAPISample.Model.ViewModel;

namespace WebAPISample.Model
{
    public class TwittRepository : IDisposable
    {
        private readonly MyDBContext db;

        public TwittRepository(MyDBContext db)
        {
            this.db = db;
        }

        public IEnumerable<Twitt> GetAll()
        {
            try
            {
                return db.twitts.ToList();
            }
            catch (Exception) { throw; }
        }
        public Twitt Get(int id)
        {
            try
            {
                return db.twitts.FirstOrDefault(t => t.Id == id);
            }
            catch (Exception)
            {

                throw;
            }
        }
        public bool Add(TwittViewModel twittModel)
        {
            try
            {
                var twitt = new Twitt() { Body = twittModel.Body };
                db.twitts.Add(twitt);
                return true;
            }
            catch (Exception)
            {
                return false;
                throw;
            }
        }

        public Twitt Update(TwittViewModel twittModel)
        {
            try
            {
                var twitt = new Twitt() { Id = twittModel.Id, Body = twittModel.Body };
                db.twitts.Update(twitt);
                return twitt;
                
            }
            catch (Exception)
            {
                throw;
            }

        }
        public bool Delete(int id)
        {
            try
            {
                var twitt = Get(id);
                db.twitts.Remove(twitt);
                return true;
            }
            catch (Exception)
            {

                return false;
                throw;

            }
        }

        public bool Delete(TwittViewModel twittModel)
        {
            try
            {
                var twitt = new Twitt() { Id = twittModel.Id, Body = twittModel.Body };
                db.twitts.Remove(twitt);
                return true;
            }
            catch (Exception)
            {
                return false;
                throw;
            }
        }
        public void SaveChanges()
        {
            db.SaveChanges();
        }

        public void Dispose()
        {
            if (db != null) 
            { 
                db.Dispose();
            }
        }
    }
}
