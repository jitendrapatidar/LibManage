using AutoMapper;
using System.Security.Policy;
using veripark.ConfigurationSettings;
using veripark.DataAccess.Models;
using veripark.UnitofWork;
using veripark.ViewMode.Entities;

namespace veripark.Infrastructure.Impl
{
    public class BookService
        : IBookService
    {
        private readonly ILmsImpl _lmsImpl;
        private readonly IMapper _mapper;
        public BookService(ILmsImpl lmsImpl, IMapper mapper)
        {
            _lmsImpl = lmsImpl;
            _mapper = mapper;

        }

        public IEnumerable<BooksEntity> GetAll()
        {
            var obj = _lmsImpl.booksRepository.GetAll();
            if (obj == null) return new List<BooksEntity>();
            var result = _mapper.Map<IEnumerable<Books>, IEnumerable<BooksEntity>>(obj);
            return result;

        }
        public BooksEntity GetById(int id)
        {
            var obj = _lmsImpl.booksRepository.Find(e => e.Id == id).FirstOrDefault();
            var result = _mapper.Map<Books, BooksEntity>(obj);
            return result;
        }
        public Int32 Save(BooksEntity source)
        {
            var obj = _mapper.Map<BooksEntity, Books>(source);
            obj.MaxIssueDays = LmsUnit.MaxIssueDays;
            _lmsImpl.booksRepository.Add(obj);
            int result = _lmsImpl.Save();
            return result;

        }
        public Int32 Update(int id, BooksEntity source)
        {

            var book = _lmsImpl.booksRepository.FirstOrDefault(e => e.Id == id);
            if (book != null)
            {
                book.Title = source.Title;
                book.Isbn = source.Isbn;
                book.Author = source.Author;
                book.Publisher = source.Publisher;
                book.MaxIssueDays = LmsUnit.MaxIssueDays;
                book.Available = source.Available;
                book.OnDate = DateTime.Now;
                _lmsImpl.booksRepository.Update(book);
                _lmsImpl.Dispose();
                return 1;

            }
            return 0;

        }
        public Int32 Delete(int id)
        {

            var book = _lmsImpl.booksRepository.FirstOrDefault(e => e.Id == id);
            if (book != null)
            {
                _lmsImpl.booksRepository.Remove(book);
                _lmsImpl.Save();
                return 1;
            }
            return 0;



        }
    }
}
