namespace DealershipSoftware
{
    public class Vehicle
    {
        private int mID;
        private int mMakeYear;
        private Manufacturer mManufacturer;
        private string mModel;
        private decimal mPrice;
        private VehicleType mVehicleType;
        private byte[] mImage = new byte[0];
        private bool mIsSold;

        public int ID
        {
            get { return mID; }
            set { mID = value; }
        }
        public int MakeYear
        {
            get { return mMakeYear; }
            set { mMakeYear = value; }
        }
        public Manufacturer Manufacturer
        {
            get { return mManufacturer; }
            set { mManufacturer = value; }
        }
        public string Model
        {
            get { return mModel; }
            set { mModel = value; }
        }
        public decimal Price
        {
            get { return mPrice; }
            set { mPrice = value; }
        }
        public VehicleType VehicleType
        {
            get { return mVehicleType; }
            set { mVehicleType = value; }
        }
        public byte[] Image
        {
            get { return mImage; }
            set { mImage = value; }
        }
        public bool IsSold
        {
            get { return mIsSold; }
            set { mIsSold = value; }
        }
    }
}
