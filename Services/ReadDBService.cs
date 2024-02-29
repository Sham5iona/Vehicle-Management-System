using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using VMS_EntityFrameworkCore.Data;
using VMS_EntityFrameworkCore.Model;

namespace VMS_EntityFrameworkCore.Services
{
    internal class ReadDBService
    {
       private VMSDBContext db;
       
        public ReadDBService()
        {
            db = new VMSDBContext();
        }
        public void ReadDB(string username, string phone)
        {
            //filter the data and join the tables
            var data = db.Rentals.Include(r => r.Customer).Include(c => c.Car).
                       Where(c => c.Customer.CustomerName == username &&
                       c.Customer.CustomerPhone == phone);
            var customer = db.Customers.FirstOrDefault(c => c.CustomerName == username &&
                                                       c.CustomerPhone == phone);
            try
            {

                if (!data.IsNullOrEmpty())
                {
                    foreach (var item in data)
                    {
                        Console.WriteLine($"{item.Customer.CustomerName} has {item.Car.Brand} " +
                                          $"{item.Car.Model} with rental date {item.RentalStart} until " +
                                          $"{item.RentalEnd}.");
                    }
                }
                else if (customer == null)
                {
                    
                    throw new Exception("There is no user with this credentials");

                }
                else
                {
                    Console.WriteLine("The selected user hasn't got any rentals !");
                }

            }catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
    }
}
