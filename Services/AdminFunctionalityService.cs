using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using VMS_EntityFrameworkCore.Data;
using VMS_EntityFrameworkCore.Model;

namespace VMS_EntityFrameworkCore.Services
{
    internal class AdminFunctionalityService
    {

        private VMSDBContext db;
        public AdminFunctionalityService()
        {
            db = new VMSDBContext();
        }
        public bool isAdmin()
        {
            Console.WriteLine("Are you an Admin ??");
            Console.WriteLine("Enter your credentials:");
            Console.WriteLine("Fullname: ");
            string fullname = Console.ReadLine();
            Console.WriteLine("Phone number: ");
            string phone = Console.ReadLine();
            Customer? Customers = db.Customers.FirstOrDefault<Customer>(c => c.CustomerName == fullname &&
                                                                        c.CustomerPhone == phone);
            if (Customers == null)
            {

                Console.WriteLine("Sorry, there is no admin with this credentials !");

                return false;
            }

            return true;
        }
        public void AddCar(string brand, string model, string manufacture_year, bool isActive)
        {


            try
            {
                Car car = new Car(brand, model, manufacture_year, isActive);
                db.Cars.Add(car);
                db.SaveChanges();
                Console.WriteLine("Successfully added a car !");
            }
            catch (Exception ex)
            {
                Console.WriteLine("An error occured in the operation!");
                Console.WriteLine(ex.Message);
            }


        }
        public void AddRental(DateTime rentalStart, DateTime rentalEnd,
                              int _CustomerID, int _CarID)
        {
           
              if (_CustomerID != 0)
              {
                  if (_CarID != 0)
                  {

                      if (isCarAvailable(_CarID))
                      {

                          Rental rental = new Rental(rentalStart, rentalEnd, _CustomerID, _CarID);
                          db.Rentals.Add(rental);
                          db.SaveChanges();
                          Console.WriteLine("Successfully added a rent !");
                          return;


                      }
                  }
              }

        }
        public void UpdateCar(string current_brand, string current_model, string current_year,
                         bool current_isActive,
                         string updated_brand, string updated_model, string updated_year,
                         bool updated_isActive)
        {

            try
            {

                var current_row = db.Cars.FirstOrDefault(c => c.Brand == current_brand &&
                c.Model == current_model && c.ManufactureYear == current_year &&
                c.isActive == current_isActive); // connection to Cars

                var current_row_in_Rentals = db.Rentals.FirstOrDefault(r =>
                        r.Car.Brand == current_brand &&
                        r.Car.Model == current_model && r.Car.ManufactureYear == current_year &&
                        r.Car.isActive == current_isActive);
                //make a connectio to Rentals to check if the
                // current car is already used in any rental

                if (current_row != null)
                {
                    if(current_row_in_Rentals != null)
                    {
                        throw new Exception("Can't update the car because its already in a rental !");
                        // it will jump to the catch block
                    }
                        current_row.Brand = updated_brand;
                        current_row.Model = updated_model;
                        current_row.ManufactureYear = updated_year;
                        current_row.isActive = updated_isActive;
                        db.SaveChanges();
                        Console.WriteLine("Successfully updated the car !");
                }
                else
                {
                    throw new Exception("Error: no suitable row!");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("An error occured in the operation!");
                Console.WriteLine(ex.Message);
            }

        }
        public void UpdateRental(DateTime current_started_at, DateTime current_finish_at,
                         string current_customerName,
                        string current_customerPhone, string current_brand, string current_model,
                         string current_year,
                         DateTime updated_started_at, DateTime updated_finish_at,
                         string updated_customerName,
                        string updated_customerPhone, string updated_brand, string updated_model,
                           string updated_year)
        {
            if (isCarAvailable(getIdOfCar(current_brand, current_model, current_year)))
            {
                if (isCarAvailable(getIdOfCar(updated_brand, updated_model, updated_year)))
                {

                    try
                    {
                        var current_row = db.Rentals.
                            Include(r => r.Customer).
                            Include(r => r.Car).
                            FirstOrDefault(r => r.RentalStart == current_started_at
                        && r.RentalEnd == current_finish_at && r.Customer.CustomerName == current_customerName
                        && r.Customer.CustomerPhone == current_customerPhone && r.Car.Brand == current_brand &&
                        r.Car.Model == current_model && r.Car.ManufactureYear == current_year);

                        if (current_row != null)
                        {
                            current_row.RentalStart = updated_started_at;
                            current_row.RentalEnd = updated_finish_at;

                            current_row.CustomerID = getIdOfCustomer(updated_customerName,
                                updated_customerPhone);
                            current_row.CarID = getIdOfCar(updated_brand, updated_model, updated_year);
                            db.SaveChanges();
                            Console.WriteLine("Successfully updated the rent !");

                        }
                        else
                        {
                            throw new Exception("Error: no suitable row!");
                        }
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine("An error occured in the operation!");
                        Console.WriteLine(ex.Message);
                    }

                }

            }
        }
        public void DeleteCar(string brand, string model, string manufacture_year, bool isActive)
        {

            try
            {
                var current_row = db.Cars.FirstOrDefault(c => c.Brand == brand &&
                c.Model == model && c.ManufactureYear == manufacture_year && c.isActive == isActive); ;
                if (current_row != null)
                {


                    if (!isCarAvailable(current_row.CarID))
                    {
                        Console.WriteLine("Therefore it can be deleted!");
                        db.Cars.Remove(current_row);
                        db.SaveChanges();
                        Console.WriteLine("Successfully deleted the car !");
                    }
                    else
                    {
                        throw new Exception("The selected car is active yet and can't be deleted!\n" +
                            "Try changing it's state!");
                    }
                }
                else
                {
                    throw new Exception("Error: no suitable row!");
                }
                
            }
            catch (Exception ex)
            {
                Console.WriteLine("An error occured in the operation!");
                Console.WriteLine(ex.Message);
            }

        }
        public void DeleteRental(DateTime _started_at, DateTime _finish_at,
                       string _customerName,
                       string _customerPhone, string _brand, string _model,
                       string _year)
        {
            //no need of isCarAvailable()
            try
            {
                var current_row = db.Rentals.
                        Include(r => r.Customer).
                        Include(r => r.Car).
                        FirstOrDefault(r => r.RentalStart == _started_at
                    && r.RentalEnd == _finish_at && r.Customer.CustomerName == _customerName
                    && r.Customer.CustomerPhone == _customerPhone && r.Car.Brand == _brand &&
                    r.Car.Model == _model && r.Car.ManufactureYear == _year);

                if (current_row != null)
                {


                    db.Rentals.Remove(current_row);
                    db.SaveChanges();
                    Console.WriteLine("Successfully deleted the rent !");
                }
                else
                {
                    throw new Exception("Error: no suitable row!");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("An error occured in the operation!");
                Console.WriteLine(ex.Message);
            }

        }
        public void DeleteCustomer(string _customerName, string _customerPhone, bool isAdmin)
        {

            try
            {
                var current_row = db.Customers.FirstOrDefault(c => c.CustomerName == _customerName
                && c.CustomerPhone == _customerPhone && c.isAdmin == isAdmin);

                if (current_row != null)
                {
                    var current_row_in_Rentals = db.Rentals.FirstOrDefault(r =>
                        r.Customer.CustomerName == _customerName &&
                        r.Customer.CustomerPhone == _customerPhone &&
                        r.Customer.isAdmin == isAdmin);

                    if (current_row_in_Rentals == null)
                    {
                        db.Customers.Remove(current_row);
                        db.SaveChanges();
                        Console.WriteLine("Successfully deleted the customer !");
                    }
                    else
                    {
                        throw new Exception("The customer is in a rental so can't be deleted!");
                    }
                }
                else
                {
                    throw new Exception("Error: no suitable row!");
                }
                
            }
            catch (Exception ex)
            {
                Console.WriteLine("An error occured in the operation!");
                Console.WriteLine(ex.Message);
            }


        }

        public void UpdateCustomer(string current_fullname, string current_phone,
            bool current_status, string updated_fullname, string updated_phone,
            bool updated_status)
        {
            try
            {
                var current_row = db.Customers.FirstOrDefault(c => c.CustomerName == current_fullname
                && c.CustomerPhone == current_phone && c.isAdmin == current_status);

                if(current_row != null )
                {
                    var current_row_in_Rentals = db.Rentals.FirstOrDefault(r =>
                        current_row.CustomerName == current_fullname &&
                        current_row.CustomerPhone == current_phone &&
                        current_row.isAdmin == current_status);

                    if (current_row_in_Rentals == null)
                    {

                        current_row.CustomerName = updated_fullname;
                        current_row.CustomerPhone = updated_phone;
                        current_row.isAdmin = updated_status;
                        db.SaveChanges();
                        Console.WriteLine("Successfully updated the customer!");
                    }
                    else
                    {
                        throw new Exception("The customer is in a rental so can't be updated!");
                    }
                }
                else
                {
                    throw new Exception("Error: no suitable row!");
                }
                
            }
            catch (Exception ex)
            {
                Console.WriteLine("An error occured in the operation!");
                Console.WriteLine(ex.Message);
            }

        }

        public int getIdOfCustomer(string customerName, string phoneNumber)
        {

            try
            {
                var data = db.Customers.Where(c => c.CustomerName == customerName &&
                                c.CustomerPhone == phoneNumber).ToList();
                return data.First().CustomerID;
            }
            catch (Exception ex)
            {
                Console.WriteLine("There is no current user with this credentials !");
                
                return 0;
            }


        }

        public int getIdOfCar(string brand, string model, string year)
        {

            try
            {
                var data = db.Cars.Where(c => c.Brand == brand && c.Model == model &&
                                         c.ManufactureYear == year);
                return data.First().CarID;
            }
            catch (Exception ex)
            {
                Console.WriteLine("There is no car with this credentials!");
                
                return 0;
            }


        }
        public bool isCarAvailable(int CarID)
        {

            try
            {
                if (CarID != 0)
                {
                    var item = db.Cars.FirstOrDefault(c => c.CarID == CarID);
                    if(item.isActive ? true : false)
                    {
                        return true; //Here item.isActive is true
                    }
                    throw new Exception(); //Here item.isActive is false
                }

                throw new Exception();
                
            }
            catch (Exception ex)
            {
                Console.WriteLine("The car isn't available!");
                
                return false;
            }

        }


    }
}

