using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Globalization;
using System.ComponentModel;
using WpfApplication1;
using System.IO;

namespace WpfApplication1
{
    public class AddCustomerViewModel: INotifyPropertyChanged
    {
        private RelayCommand SaveCommand;

        public AddCustomerViewModel()
        {
           SaveCommand = new RelayCommand(SaveFile);
        }
        private List<string> ItemList = new List<string>() { "Customer Working Directory"};
        private List<string> _MenuButtonItemList = null;
        public List<string> MenuButtonItemList
        {
            get
            {
                if (_MenuButtonItemList == null)
                    _MenuButtonItemList = new List<string>(ItemList);
                return _MenuButtonItemList;
            }
        }

        private bool _isAddCustomerPageOpen = false;
        public bool IsAddCustomerPageOpen
        {
            get
            {
                return _isAddCustomerPageOpen;
            }
            set
            {
                _isAddCustomerPageOpen = value;
                RaisePropertyChanged("IsAddCustomerPageOpen");
            }
        }

        private bool _isChooseDirectoryOpen = false;
        public bool IsChooseDirectoryOpen
        {
            get
            {
                return _isChooseDirectoryOpen;
            }
            set
            {
                _isChooseDirectoryOpen = value;
                RaisePropertyChanged("IsChooseDirectoryOpen");
            }
        }

        private bool _isDeleteCustomerPageOpen = false;
        public bool IsDeleteCustomerPageOpen
        {
            get
            {
                return _isDeleteCustomerPageOpen;
            }
            set
            {
                _isDeleteCustomerPageOpen = value;
                RaisePropertyChanged("IsDeleteCustomerPageOpen");
            }
        }

        private string _fileToDelete;

        public string FileToDelete
        {
            get
            {
                return _fileToDelete;
            }
            set
            {
                _fileToDelete = value;
                RaisePropertyChanged(FileToDelete);
            }
        }

        private string _workingDirectory = @"C:\";

        public string WorkingDirectory
        {
            get
            {
                return _workingDirectory;
            }
            set
            {
                _workingDirectory = value;
                RaisePropertyChanged(WorkingDirectory);
            }
        }

        private string _customerFirstName;

        public string CustomerFirstName
        {
            get
            {
                return _customerFirstName;
            }
            set
            {
                //Set(ref _customerLastName, value);
                _customerFirstName = value;
                RaisePropertyChanged(CustomerFirstName);
            }
        }

        private string _customerLastName;

        public string CustomerLastName
        {
            get
            {
                return _customerLastName;
            }
            set
            {
                //Set(ref _customerLastName, value);
                _customerLastName = value;
                RaisePropertyChanged(CustomerLastName);
            }
        }

        private string _customerEmailAddress;

        public string CustomerEmailAddress
        {
            get
            {
                return _customerEmailAddress;
            }
            set
            {
                //Set(ref _customerLastName, value);
                _customerEmailAddress = value;
                RaisePropertyChanged(CustomerEmailAddress);
            }
        }

        private string _customerPhoneNumber;

        public string CustomerPhoneNumber
        {
            get
            {
                return _customerPhoneNumber;
            }
            set
            {
                //Set(ref _customerLastName, value);
                _customerPhoneNumber = value;
                RaisePropertyChanged(CustomerPhoneNumber);
            }
        }

        private string _customerStreet;

        public string CustomerStreet
        {
            get
            {
                return _customerStreet;
            }
            set
            {
                //Set(ref _customerLastName, value);
                _customerStreet = value;
                RaisePropertyChanged(CustomerStreet);
            }
        }

        private string _customerCity;

        public string CustomerCity
        {
            get
            {
                return _customerCity;
            }
            set
            {
                //Set(ref _customerLastName, value);
                _customerCity = value;
                RaisePropertyChanged(CustomerCity);
            }
        }

        private string _customerProvince;

        public string CustomerProvince
        {
            get
            {
                return _customerProvince;
            }
            set
            {
                //Set(ref _customerLastName, value);
                _customerProvince = value;
                RaisePropertyChanged(CustomerProvince);
            }
        }

        private string _customerCountry;

        public string CustomerCountry
        {
            get
            {
                return _customerCountry;
            }
            set
            {
                //Set(ref _customerLastName, value);
                _customerCountry = value;
                RaisePropertyChanged(CustomerCountry);
            }
        }

        private string _customerPostalCode;

        public string CustomerPostalCode
        {
            get
            {
                return _customerPostalCode;
            }
            set
            {
                //Set(ref _customerLastName, value);
                _customerPostalCode = value;
                RaisePropertyChanged(CustomerPostalCode);
            }
        }

        //private string _customerDateOfPurchase = DateTime.Today.ToLongDateString();

        //public string CustomerDateOfPurchase
        //{
        //    get
        //    {
        //        return _customerDateOfPurchase;
        //    }
        //    set
        //    {
        //        //Set(ref _customerLastName, value);
        //        _customerDateOfPurchase = value;
        //        RaisePropertyChanged(CustomerDateOfPurchase);
        //    }
        //}

        private string _customerPurchaseTotal;

        public string CustomerPurchaseTotal
        {
            get
            {
                return _customerPurchaseTotal;
            }
            set
            {
                //Set(ref _customerLastName, value);
                _customerPurchaseTotal = value;
                RaisePropertyChanged(CustomerPurchaseTotal);
            }
        }

        private bool _customerWarranty;

        public bool CustomerWarranty
        {
            get
            {
                return _customerWarranty;
            }
            set
            {
                //Set(ref _customerLastName, value);
                _customerWarranty = value;
                RaisePropertyChanged("CustomerWarranty");
            }
        }


        public void SaveFile()
        {
            string workingDirectory = @"M:\New Customers";
            string newFileName = Path.Combine(workingDirectory, "SavedFiled.txt");
            var newFile = File.Create(newFileName);
            StreamWriter temp = new StreamWriter(newFileName);
            temp.Write("hello");
            temp.Close();
        }

        public string[] CreateOutput()
        {
            return new string[] 
            { "First Name: " + CustomerFirstName,
              "Last Name: " + CustomerLastName,
              "Email: " + CustomerEmailAddress,
              "Phone: " + CustomerPhoneNumber,
              "Street: " + CustomerStreet,
              "City: " + CustomerCity,
              "Postal Code: " + CustomerPostalCode,
              "Province: " + CustomerProvince,
              "Country: " + CustomerCountry,
              "Date of Purchase: " + DateTime.Today.ToLongDateString(),
              "Purchase Total: " + CustomerPurchaseTotal,
              "Warranty: " + CustomerWarranty.ToString()
            };
        }

        public void ClearAllProperties()
        {
            CustomerFirstName = null;
            CustomerLastName = null;
            CustomerEmailAddress = null;
            CustomerPhoneNumber = null;
            CustomerStreet = null;
            CustomerCity = null;
            CustomerPostalCode = null;
            CustomerProvince = null;
            CustomerCountry = null;
            //CustomerDateOfPurchase = null;
            CustomerPurchaseTotal = null;
            CustomerWarranty = false;
        }       

        public event PropertyChangedEventHandler PropertyChanged;

        private void RaisePropertyChanged(string propertyName)
        {
            // take a copy to prevent thread issues
            PropertyChangedEventHandler handler = PropertyChanged;
            if (handler != null)
            {
                handler(this, new PropertyChangedEventArgs(propertyName));
            }
        }



    }
}
