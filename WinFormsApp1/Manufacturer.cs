using System.Security.Cryptography;
using System.Xml.Linq;

namespace DealershipSoftware
{
    public class Manufacturer
    {
        private int mID;
        private string mName;
        private List<VehicleType> mVehicleTypes;
        public int ID
        {
            get { return mID; }
            set { mID = value; }
        }
        public string Name
        {
            get { return mName; }
            set { mName = value; }
        }
        public List<VehicleType> VehicleTypes
        {
            get { return mVehicleTypes; }
            set { mVehicleTypes = value; }
        }
    }
    
}
