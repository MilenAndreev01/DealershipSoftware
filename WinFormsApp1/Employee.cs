namespace DealershipSoftware
{
    public class Employee
    {
        private int mID;
        private string mFirstName;
        private string mLastName;
        private string mTelephone;
        private string mEmail;
        private DateTime mDateOfBirth;
        private string mSalt;
        private byte[] mPassword;
        private int mEmployeeTypeID;
        public static readonly string Pepper = "Ak0_Diz310v_Avt()m0bil_Mn0g()_4@di,A_Ne_V1rvi=>S13d0vat31n()_3_Trakt0r!";

        
        public int ID
        {
            get { return mID; }
            set { mID = value; }
        }
        public string FirstName
        {
            get { return mFirstName; }
            set { mFirstName = value; }
        }
        public string LastName
        {
            get { return mLastName; }
            set { mLastName = value; }
        }
        public string Telephone
        {
            get { return mTelephone; }
            set { mTelephone = value; }
        }
        public string Email
        {
            get { return mEmail; }
            set { mEmail = value; }
        }
        public DateTime DateOfBirth
        {
            get { return mDateOfBirth; }
            set { mDateOfBirth = value; }
        }
        public byte[] Password
        {
            get { return mPassword; }
            set { mPassword = value; }
        }
        public string Salt
        {
            get { return mSalt; }
            set { mSalt = value; }
        }
        public int EmployeeTypeID
        {
            get { return mEmployeeTypeID; }
            set { mEmployeeTypeID = value; }
        }
        public static void GenerateSalt(ref string salt)
        {
            //salt = $2a$11$B26wlkmNTyDuTGKAeuY3Ie
            salt = BCrypt.Net.BCrypt.GenerateSalt(10);
        }
        
    }
}
