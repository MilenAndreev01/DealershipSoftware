namespace DealershipSoftware
{
    public class VehicleType
    {
        private int mID;
        private string mTypeEN;
        private string mTypeBG;
        public int ID
        {
            get { return mID; }
            set { mID = value; }
        }
        public string TypeEN
        {
            get { return mTypeEN; }
            set { mTypeEN = value; }
        }
        public string TypeBG
        {
            get { return mTypeBG; }
            set { mTypeBG = value; }
        }
    }
}
