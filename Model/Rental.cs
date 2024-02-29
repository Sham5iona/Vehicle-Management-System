namespace VMS_EntityFrameworkCore.Model
{
    internal class Rental
    {
        private int _RentalID;
        public int RentalID
        {
            get { return _RentalID;}
            set { _RentalID = value;}
        }
        private int _CustomerID;
        public int CustomerID
        {
            get { return _CustomerID;}
            set { _CustomerID = value;}
        }

        public Customer Customer { get; set; } //relation to the Customer table

        private DateTime _RentalStart;
        public DateTime RentalStart
        {
            get { return _RentalStart; }
            set { _RentalStart = value; }
        }
        private DateTime _RentalEnd;
        public DateTime RentalEnd
        {
            get { return _RentalEnd; }
            set { _RentalEnd = value; }
        }
        
        private int _CarID;
        public int CarID
        {
            get { return _CarID; }
            set { _CarID = value; }
        }

        public Car Car { get; set; } //relation to the Car table

        public Rental() { } // empty constructor for EFCore to be able to create an object

        public Rental(DateTime _RentalStart, DateTime _RentalEnd,
            int _CustomerID, int _CarID)
        {
            this._RentalStart = _RentalStart;
            this._RentalEnd = _RentalEnd;
            this._CustomerID = _CustomerID;
            this._CarID = _CarID;
        }
    }
}
