using System.Linq.Expressions;
using VMS_EntityFrameworkCore.Data;
using VMS_EntityFrameworkCore.Model;
using VMS_EntityFrameworkCore.Services;

namespace VMS_EntityFrameworkCore
{
    internal class Program
    {
        public static void Main(string[] args)
        {
            RenderingUIService ui = new RenderingUIService();
            Console.WriteLine("Welcome to our VMS System !");
            int option = -1;
            
            
            RenderingUIService renderingUIService = new RenderingUIService();
            while (option != 0)
            {
                Console.WriteLine("Choose an option !");
                Console.WriteLine("1 -> Add a customer");
                Console.WriteLine("2 -> Admin Panel");
                Console.WriteLine("3 -> Customer's Data");
                Console.WriteLine("0 -> Exit");
                option = int.Parse(Console.ReadLine());
                switch (option)
                {
                    case 0:
                        {
                            Console.WriteLine("Terminating the program...");
                            return;
                        }
                    case 1:
                        {

                            renderingUIService.UIAddCustomer();
                            break;
                        }
                    case 2:
                        {
                            AdminFunctionalityService admin = new AdminFunctionalityService();

                            if (admin.isAdmin())
                            {
                                
                                renderingUIService.UIForAdmin();
                            }
                            break;
                        }
                    case 3:
                        {
                            renderingUIService.CustomerReadDB();
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
    }
}