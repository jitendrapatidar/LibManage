using veripark.DataAccess.Models;
using veripark.ViewMode.Entities;

namespace veripark.Infrastructure
{
    public interface IBookService
    {
        IEnumerable<BooksEntity> GetAll();

        BooksEntity GetById(int id);

        Int32 Save(BooksEntity obj);

        Int32 Update(int id, BooksEntity obj);

        Int32 Delete(int id);
         
    }
}