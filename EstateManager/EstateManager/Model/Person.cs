using EstateManager.Model.Enums;
using EstateManager.Tools;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EstateManager.Model
{
    public class Person : BaseNotifyPropertyChanged
    {

        #region Properties

        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id
        {
            get { return GetProperty<int>(); }
            private set { SetProperty(value); }
        }

        public Quality Quality
        {
            get { return GetProperty<Quality>(); }
            set { SetProperty(value); }
        }

        public string Name
        {
            get { return GetProperty<string>(); }
            set { SetProperty(value); }
        }

        public string FirstName
        {
            get { return GetProperty<string>(); }
            set { SetProperty(value); }
        }

        public string Address
        {
            get { return GetProperty<string>(); }
            set { SetProperty(value); }
        }

        public string Zip
        {
            get { return GetProperty<string>(); }
            set { SetProperty(value); }
        }

        public string City
        {
            get { return GetProperty<string>(); }
            set { SetProperty(value); }
        }

        public double? Latitude
        {
            get { return GetProperty<double?>(); }
            set { SetProperty(value); }
        }

        public double? Longitude
        {
            get { return GetProperty<double?>(); }
            set { SetProperty(value); }
        }

        public string Phone
        {
            get { return GetProperty<string>(); }
            set { SetProperty(value); }
        }

        public string CellPhone
        {
            get { return GetProperty<string>(); }
            set { SetProperty(value); }
        }

        public string Mail
        {
            get { return GetProperty<string>(); }
            set { SetProperty(value); }
        }

        #endregion

    }
}
