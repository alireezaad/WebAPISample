using Microsoft.AspNetCore.Server.IIS.Core;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Diagnostics;
using WebAPISample.Model.DBContext;

namespace WebAPISample.Model
{
    public class TwittRepository : IDisposable
    {
        private readonly MyDBContext db;

        public TwittRepository(MyDBContext db)
        {
            this.db = db;
        }

        public async Task<IEnumerable<Twitt>> GetAll()
        {
            return await db.twitts.ToListAsync();
        }
        public async Task<Twitt> Get(int id)
        {
            return await db.twitts.FirstOrDefaultAsync(t => t.Id == id);
        }
        public async Task<bool> Add(Twitt twitt)
        {
            try
            {
                db.twitts.AddAsync(twitt);
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public bool Update(Twitt twitt)
        {
            try
            {
                db.twitts.Update(twitt);
                return true;
            }
            catch (Exception)
            {

                return false;
            }

        }
        public async Task<bool> Delete(int id)
        {
            try
            {
                var twitt =await Get(id);
                db.twitts.Remove(twitt);
                return true;
            }
            catch (Exception)
            {

                return false;
            }
        }

        public bool Delete(Twitt twitt)
        {
            try
            {
                db.twitts.Remove(twitt);
                return true;
            }
            catch (Exception)
            {

                return false;
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
