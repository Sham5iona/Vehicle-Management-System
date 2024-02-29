namespace VMS_EntityFrameworkCore.Model
{
    internal class Customer
    {
        private int _CustomerID;
        public int CustomerID { 
            get { return _CustomerID; }
            set { _CustomerID = value; }
        }
        private string _CustomerName;
        public string CustomerName
        {
            get { return _CustomerName; }
            set { _CustomerName = value; }
        }
        private string _CustomerPhone;
        public string CustomerPhone
        {
            get { return _CustomerPhone; }
            set { _CustomerPhone = value; }
        }
        private bool _isAdmin;
        public bool isAdmin
        {
            get { return _isAdmin; }
            set { _isAdmin = value; }
        }
        public ICollection<Rental> Rentals { get; set; }
        public Customer() // empty constructor for EFCore to be able to create an object
        {
            
        }
        public Customer(string _CustomerName, string _CustomerPhone, bool _isAdmin)
        {
            this._CustomerName = _CustomerName;
            this._CustomerPhone = _CustomerPhone;
            this._isAdmin = _isAdmin;
            Rentals = new List<Rental>();
        }
    }
}
