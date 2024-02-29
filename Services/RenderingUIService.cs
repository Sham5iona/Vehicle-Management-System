using VMS_EntityFrameworkCore.Model;
using VMS_EntityFrameworkCore.Data;

namespace VMS_EntityFrameworkCore.Services
{
    internal class RenderingUIService // Thats the User Interface
    {
        AddCustomerService AddCustomerService;
        AdminFunctionalityService Admin;
        ReadDBService ReadDBService;
        public RenderingUIService()
        {
            AddCustomerService = new AddCustomerService();
            Admin = new AdminFunctionalityService();
            ReadDBService = new ReadDBService();
        }
        public void UIAddCustomer()
        {
            Console.WriteLine("Create a user !");
            Console.Write("Fullname : ");
            string? fullname = Console.ReadLine();
            Console.WriteLine("Phone number : ");
            string? phone = Console.ReadLine();
            Console.WriteLine("Is Admin? (true or false)");
            bool isAdmin = bool.Parse(Console.ReadLine());
            AddCustomerService.Add(fullname, phone, isAdmin);
        }
        public void UIForAdmin()
        {

            int option = -1;

            while (option != 0)
            {
                Console.WriteLine("Welcome to Admin Panel !");
                Console.WriteLine("Choose an option :");
                Console.WriteLine("1 -> Add a car");
                Console.WriteLine("2 -> Add a rent");
                Console.WriteLine("3 -> Update a car");
                Console.WriteLine("4 -> Update a rent");
                Console.WriteLine("5 -> Delete a car");
                Console.WriteLine("6 -> Delete a rent");
                Console.WriteLine("7 -> Delete a customer");
                Console.WriteLine("8 -> Update a customer");
                Console.WriteLine("9 -> Add a customer");
                Console.WriteLine("0 -> Exit");
                option = int.Parse(Console.ReadLine());
                switch (option) // Options of Admin Panel
                {
                    case 0:
                        {
                            Console.WriteLine("Leaving the Admin Panel...");
                            return;
                            
                        }
                    case 1:
                        {

                            Console.Write("Brand name: ");
                            string brand = Console.ReadLine();
                            Console.WriteLine("Model name: ");
                            string model = Console.ReadLine();
                            Console.WriteLine("Manufacture year: ");
                            string year = Console.ReadLine();
                            Console.WriteLine("Is car active? (true or false)");
                            bool isActive = bool.Parse(Console.ReadLine());
                            Admin.AddCar(brand, model, year, isActive);
                            break;
                        }
                    case 2:
                        {
                            Console.Write("Rent started at: ");
                            DateTime started_at = DateTime.Parse(Console.ReadLine());
                            Console.WriteLine("Rent finish at: ");
                            DateTime finish_at = DateTime.Parse(Console.ReadLine());
                            Console.Write("Fullname : ");
                            string? fullname = Console.ReadLine();
                            Console.WriteLine("Phone number : ");
                            string? phone = Console.ReadLine();
                            Console.Write("Brand name: ");
                            string brand = Console.ReadLine();
                            Console.WriteLine("Model name: ");
                            string model = Console.ReadLine();
                            Console.WriteLine("Manufacture year: ");
                            string year = Console.ReadLine();
                            Admin.AddRental(started_at, finish_at,
                                            Admin.getIdOfCustomer(fullname, phone),
                                            Admin.getIdOfCar(brand, model, year));
                            break;
                        }
                    case 3:
                        {
                            Console.WriteLine("First give some data about the current car !");
                            Console.Write("Brand name: ");
                            string current_brand = Console.ReadLine();
                            Console.Write("Model name: ");
                            string current_model = Console.ReadLine();
                            Console.Write("Manufacture year: ");
                            string current_year = Console.ReadLine();
                            Console.WriteLine("Is car active? (true or false)");
                            bool current_isActive = bool.Parse(Console.ReadLine());
                            Console.Write("\nNice! Now give info about the new car!\n");

                            Console.Write("Brand name: ");
                            string updated_brand = Console.ReadLine();
                            Console.Write("Model name: ");
                            string updated_model = Console.ReadLine();
                            Console.Write("Manufacture year: ");
                            string updated_year = Console.ReadLine();
                            Console.WriteLine("Is car active? (true or false)");
                            bool updated_isActive = bool.Parse(Console.ReadLine());
                            Admin.UpdateCar(current_brand, current_model, current_year,
                                current_isActive, updated_brand, updated_model,
                                updated_year, updated_isActive);
                            break;
                        }
                    case 4:
                        {
                            Console.WriteLine("First give some data about the rent !");
                            Console.Write("Rent started at: ");
                            DateTime current_started_at = DateTime.Parse(Console.ReadLine());
                            Console.Write("Rent finish at: ");
                            DateTime current_finish_at = DateTime.Parse(Console.ReadLine());
                            Console.Write("Fullname : ");
                            string? current_fullname = Console.ReadLine();
                            Console.Write("Phone number : ");
                            string? current_phone = Console.ReadLine();
                            Console.Write("Brand name: ");
                            string current_brand = Console.ReadLine();
                            Console.Write("Model name: ");
                            string current_model = Console.ReadLine();
                            Console.Write("Manufacture year: ");
                            string current_year = Console.ReadLine();

                            Console.Write("\nNice! Now give info about the new rent!\n");

                            Console.Write("Rent started at: ");
                            DateTime updated_started_at = DateTime.Parse(Console.ReadLine());
                            Console.Write("Rent finish at: ");
                            DateTime updated_finish_at = DateTime.Parse(Console.ReadLine());
                            Console.Write("Fullname : ");
                            string? updated_fullname = Console.ReadLine();
                            Console.Write("Phone number : ");
                            string? updated_phone = Console.ReadLine();
                            Console.Write("Brand name: ");
                            string updated_brand = Console.ReadLine();
                            Console.Write("Model name: ");
                            string updated_model = Console.ReadLine();
                            Console.Write("Manufacture year: ");
                            string updated_year = Console.ReadLine();
                            Admin.UpdateRental(current_started_at, current_finish_at,
                                     current_fullname,
                                     current_phone, current_brand, current_model,
                                     current_year,
                                     updated_started_at, updated_finish_at,
                                     updated_fullname,
                                     updated_phone, updated_brand, updated_model,
                                     updated_year);
                            break;
                        }
                    case 5:
                        {
                            Console.WriteLine("Give some data about the car :");
                            Console.Write("Brand name: ");
                            string brand = Console.ReadLine();
                            Console.Write("Model name: ");
                            string model = Console.ReadLine();
                            Console.Write("Manufacture year: ");
                            string year = Console.ReadLine();
                            Console.WriteLine("Is car active? (true or false)");
                            bool isActive = bool.Parse(Console.ReadLine());

                            Admin.DeleteCar(brand, model, year, isActive);

                            break;
                        }
                    case 6:
                        {
                            Console.WriteLine("Give some data about the rent: ");

                            Console.Write("Rent started at: ");
                            DateTime _started_at = DateTime.Parse(Console.ReadLine());
                            Console.Write("Rent finish at: ");
                            DateTime _finish_at = DateTime.Parse(Console.ReadLine());
                            Console.Write("Fullname : ");
                            string? _fullname = Console.ReadLine();
                            Console.Write("Phone number : ");
                            string? _phone = Console.ReadLine();
                            Console.Write("Brand name: ");
                            string _brand = Console.ReadLine();
                            Console.WriteLine("Model name: ");
                            string _model = Console.ReadLine();
                            Console.WriteLine("Manufacture year: ");
                            string _year = Console.ReadLine();

                            Admin.DeleteRental(_started_at, _finish_at,
                            _fullname, _phone, _brand, _model, _year);

                            break;
                        }
                    case 7:
                        {
                            Console.WriteLine("Give some data about the customer");
                            Console.Write("Fullname : ");
                            string fullname = Console.ReadLine();
                            Console.Write("Phone number: ");
                            string phone = Console.ReadLine();
                            Console.WriteLine("Is admin? (true or false)");
                            bool isAdmin = bool.Parse(Console.ReadLine());
                            Admin.DeleteCustomer(fullname, phone, isAdmin);
                            break;
                        }
                    case 8:
                        {
                            Console.WriteLine("Give some data about the customer");
                            Console.Write("Fullname : ");
                            string current_fullname = Console.ReadLine();
                            Console.Write("Phone number: ");
                            string current_phone = Console.ReadLine();
                            Console.WriteLine("Is admin? (true or false)");
                            bool current_status = bool.Parse(Console.ReadLine());

                            Console.Write("\nNice! Now give info about the new customer!\n");
                            Console.Write("Fullname : ");
                            string updated_fullname = Console.ReadLine();
                            Console.Write("Phone number: ");
                            string updated_phone = Console.ReadLine();
                            Console.WriteLine("Is admin? (true or false)");
                            bool updated_status = bool.Parse(Console.ReadLine());
                            Admin.UpdateCustomer(current_fullname, current_phone, current_status,
                                updated_fullname, updated_phone, updated_status);
                            break;
                        }
                    case 9:
                        {
                            // To be more user-friendly the add customer functionality is added
                            // in Admin Panel as well
                            UIAddCustomer();
                            break;
                        }
                    default:
                        {
                            Console.WriteLine("Invalid option!");
                            break;
                        }
                } 
            }
            
        }

        public void CustomerReadDB()
        {
            Console.WriteLine("Give fullname and phone number of the customer !");
            Console.WriteLine("Fullname : ");
            string fullname = Console.ReadLine();
            Console.WriteLine("Phone number : ");
            string phone = Console.ReadLine();
            ReadDBService.ReadDB(fullname, phone);

        }
    }
}
