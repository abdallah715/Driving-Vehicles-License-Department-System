using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DVLD_DataAccessLayer;

namespace DVLD_BussinessLayer
{
    public class clsTestType
    {
        public enum enMode { AddNew = 0, Update = 1 };
        public enMode Mode = enMode.AddNew;
        public enum enTestType {VisionTest = 1 , WrittenTest = 2 , StreetTest = 3 };
        public clsTestType.enTestType ID {  get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public float Fees {  get; set; }


        public clsTestType()
        {
            this.ID = clsTestType.enTestType.VisionTest; 
            this.Title = "";
            this.Description = "";
            this.Fees = 0;
            Mode = enMode.AddNew;
        }
        private clsTestType( clsTestType.enTestType iD, string title, string description, float fees)
        {
            
            this.ID = iD;
            Title = title;
            Description = description;
            Fees = fees;
            Mode = enMode.Update;
        }

        public static clsTestType Find(clsTestType.enTestType TestTypeID)
        {
            string Title = "", Description = ""; float Fees = 0;

            if (clsTestTypesData.GetTestTypeInfoByID((int)TestTypeID, ref Title, ref Description, ref Fees))

                return new clsTestType(TestTypeID, Title, Description, Fees);
            else
                return null;

        }

        public static DataTable GetAllTestTypes()
        {
            return clsTestTypesData.GetAllTestTypes();
        }

        private bool _AddNewTestType()
        {
            //call DataAccess Layer 

            this.ID = (clsTestType.enTestType)clsTestTypesData.AddNewTestType(this.Title, this.Description, this.Fees);

            return (this.Title != "");
        }

        private bool _UpdateTestType()
        {
            //call DataAccess Layer 

            return clsTestTypesData.UpdateTestType((int)this.ID, this.Title, this.Description, this.Fees);
        }
        public bool Save()
        {
            switch (Mode)
            {
                case enMode.AddNew:
                    if (_AddNewTestType())
                    {

                        Mode = enMode.Update;
                        return true;
                    }
                    else
                    {
                        return false;
                    }

                case enMode.Update:

                    return _UpdateTestType();

            }

            return false;
        }
    }
}
