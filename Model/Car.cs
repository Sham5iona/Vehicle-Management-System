
namespace VMS_EntityFrameworkCore.Model
{
    internal class Car
    {
        private int _CarID;
        public int CarID
        {
            get { return _CarID; }
            set { _CarID = value; }
        }
        private string _brand;
        public string Brand
        {
            get { return _brand; }
            set { _brand = value; }
        }
        private bool _isActive;
        public bool isActive
        {
            get { return _isActive; }
            set { _isActive = value; }
        }
        private string _model;
        public string Model
        {
            get { return _model; }
            set { _model = value; }
        }
        private string _manufacture_year;
        public string ManufactureYear
        {
            get { return _manufacture_year; }
            set { _manufacture_year = value; }
        }
        public ICollection<Rental> Rentals { get; set; }
        public Car() // empty constructor for EFCore to be able to create an object
        {

        }
        public Car(string _brand, string _model, string _manufacture_year, bool _isActive)
        {
            this._brand = _brand;
            this._model = _model;
            this._manufacture_year = _manufacture_year;
            this._isActive = _isActive;
            Rentals = new List<Rental>();
        }
        
            
        }

    }
