namespace DealershipSoftware
{
    public class Purchase
    {        
        private int mID;
        private Client mClient;
        private Vehicle mVehicle;
        private Employee mEmployee;
        private DateTime mDateOfPurchase;        
        private decimal mFinalPrice;
        private PaymentType mPaymentType;
        private bool mIsValid;

        public int ID
        { get { return mID; } set { mID = value; } }
        public Client Client
        { get { return mClient; } set { mClient = value; } }
        public Vehicle Vehicle
        { get { return mVehicle; } set { mVehicle = value; } }
        public Employee Employee
        { get { return mEmployee; } set { mEmployee = value; } }
        public DateTime DateOfPurchase
        { get { return mDateOfPurchase; } set { mDateOfPurchase = value; } }        
        public decimal FinalPrice
        { get { return mFinalPrice; } set { mFinalPrice = value; } }
        public PaymentType PaymentType
        { get { return mPaymentType; } set { mPaymentType = value; } }
        public bool IsValid
        { get { return mIsValid; } set { mIsValid = value; } }
    }
}