using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EstateManager.Tools;
using EstateManager.Model.Enums;
using System.Collections.ObjectModel;
using System.ComponentModel;

namespace EstateManager.Model
{
    public class Estate : BaseNotifyPropertyChanged
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id
        {
            get { return GetProperty<int>(); }
            set { SetProperty(value); }
        }

        [Description("Choose the main Photo (number) :")]
        public int? MainPhotoId
        {
            get { return GetProperty<int>(); }
            set { SetProperty(value); }
        }

        [Description("")]
        [ForeignKey(nameof(MainPhotoId))]
        public Photo MainPhoto
        {
            get { return GetProperty<Photo>(); }
            set { SetProperty(value); }
        }

        [Description("Owner :")]
        public int OwnerId
        {
            get { return GetProperty<int>(); }
            set { SetProperty(value); }
        }
        
        [ForeignKey(nameof(OwnerId))]
        public Person Owner
        {
            get { return GetProperty<Person>(); }
            set { SetProperty(value); }
        }

        [Description("Surface :")]
        public float Surface
        {
            get { return GetProperty<float>(); }
            set { SetProperty(value); }
        }

        [Description("type of Estate :")]
        public EstateType Type
        {
            get { return GetProperty<EstateType>(); }
            set { SetProperty(value); }
        }

        [Description("Number of rooms :")]
        public int RoomsCount
        {
            get { return GetProperty<int>(); }
            set { SetProperty(value); }
        }

        [Description("Build date :")]
        public DateTime ? BuildDate
        {
            get { return GetProperty<DateTime>(); }
            set { SetProperty(value); }
        }

        [Description("number of floors")]
        public int FloorCount
        {
            get { return GetProperty<int>(); }
            set { SetProperty(value); }
        }

        [Description("floor number of your flat")]
        public int FloorNumber
        {
            get { return GetProperty<int>(); }
            set { SetProperty(value); }
        }

        [Description("Address")]
        public string Address
        {
            get { return GetProperty<string>(); }
            set { SetProperty(value); }
        }

        [Description("Zip code")]
        public string Zip
        {
            get { return GetProperty<string>(); }
            set { SetProperty(value); }
        }

        [Description("City")]
        public string City
        {
            get { return GetProperty<string>(); }
            set { SetProperty(value); }
        }

        [Description("Latitude")]
        public double ? Latitude
        {
            get { return GetProperty<double?>(); }
            set { SetProperty(value); }
        }

        [Description("Longitude")]
        public double ? Longitude
        {
            get { return GetProperty<double?>(); }
            set { SetProperty(value); }
        }

        [Description("Energy efficiency")]
        public int EnergyEfficiency
        {
            get { return GetProperty<int>(); }
            set { SetProperty(value); }
        }

        [Description("Add pictures")]
        [InverseProperty(nameof(Photo.Estate))]
        public ObservableCollection<Photo> Photos
        {
            get { return GetProperty<ObservableCollection<Photo>>(); }
            set { SetProperty(value); }
        }

        [Description("type of Contract")]
        [InverseProperty(nameof(Contract.Estate))]
        public ObservableCollection<Contract> Contracts
        {
            get { return GetProperty<ObservableCollection<Contract>>(); }
            set { SetProperty(value); }
        }

        public override string ToString()
        {
            return Id + " " + Surface + "m² " + City + " " + Latitude + "," + Longitude;
        }

    }
}
