using Models;

namespace DataAccesLayer.Repositories
{
    public interface IKategoriRepository<T> : IRepository<T> where T : Kategori
    {
        //T GetByNamn(string namn);
  


    }


    //public abstract class raknalista
    //{
    //    public virtual void Hamtaitemlista
    //    {
    //        int items = 0;
    //        Console.writeLine("You have this many items:"+ items);
    //    }
    //}

}


