namespace DealershipSoftware
{
    public class Client
    {
        private int mID;
        private string mFirstName;
        private string mLastName;
        private string mTelephone;

        public int ID
        { get { return mID; } set { mID = value; } }
        public string FirstName
        { get { return mFirstName; } set { mFirstName = value; } }
        public string LastName
        { get { return mLastName; } set { mLastName = value; } }
        public string Telephone
        { get { return mTelephone; } set { mTelephone = value; } }
    }
}
