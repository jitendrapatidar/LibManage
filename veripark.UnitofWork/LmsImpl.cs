using veripark.Core.Repository.Impl;
using veripark.Core.Repository.Interface;

namespace veripark.UnitofWork
{
    public class LmsImpl
      : UnitofWork, ILmsImpl
    {

        public ICustomerRepository customerRepository { get; private set; }
        public IBookRepository booksRepository { get; private set; }
        public IBorrowerRepository borrowerRepository { get; private set; }
        public IHolidayMasterRepository holidayMasterRepository { get; private set; }
        public IRoleRepository roleRepository { get; private set; }
        public IRoleInUserRepository roleInUserRepository { get; private set; }
        public ITransactionsDetailRepository transactionsDetailRepository { get; private set; }
        public IUserRepository userRepository { get; private set; }


        public LmsImpl()
        {
            customerRepository = new CustomerRepository(libraryManagementContext);
            booksRepository = new BookRepository(libraryManagementContext);
            borrowerRepository = new BorrowerRepository(libraryManagementContext);
            holidayMasterRepository = new HolidayMasterRepository(libraryManagementContext);
            roleRepository = new RoleRepository(libraryManagementContext);
            roleInUserRepository = new RoleInUserRepository(libraryManagementContext);
            transactionsDetailRepository = new TransactionsDetailRepository(libraryManagementContext);
            userRepository = new UserRepository(libraryManagementContext);

        }
    }

    public interface ILmsImpl
        : IUnitofWork
    {
        public ICustomerRepository customerRepository { get; }
        public IBookRepository booksRepository { get; }
        public IBorrowerRepository borrowerRepository { get; }
        public IHolidayMasterRepository holidayMasterRepository { get; }
        public IRoleRepository roleRepository { get; }
        public IRoleInUserRepository roleInUserRepository { get; }
        public ITransactionsDetailRepository transactionsDetailRepository { get; }
        public IUserRepository userRepository { get; }
    }
}