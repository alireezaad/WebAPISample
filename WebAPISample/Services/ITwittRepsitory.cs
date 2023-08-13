using WebAPISample.Model;
using WebAPISample.Model.ViewModel;

namespace WebAPISample.Services
{
    public interface ITwittRepsitory
    {
        IEnumerable<Twitt> GetAll();
        Twitt Get(int id);
        void Add(TwittViewModel twitt);
        void Update(TwittViewModel twitt);
        void Delete(TwittViewModel twitt);
        void Delete(int id);
        void SaveChanges();

    }
}
