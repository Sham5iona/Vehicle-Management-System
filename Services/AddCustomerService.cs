using VMS_EntityFrameworkCore.Data;
using VMS_EntityFrameworkCore.Model;

namespace VMS_EntityFrameworkCore.Services
{
    internal class AddCustomerService
    {
        private VMSDBContext db;
        
        public AddCustomerService()
        {
            db = new VMSDBContext();
        }
        public void Add(string fullName, string phoneNumber, bool isAdmin)
        {
            
            Customer customer = new Customer();
            customer.CustomerName = fullName;
            customer.CustomerPhone = phoneNumber;
            customer.isAdmin = isAdmin;
            db.Customers.Add(customer);
            db.SaveChanges();
            Console.WriteLine("Successfully added a new customer !");
        }
    }
}
