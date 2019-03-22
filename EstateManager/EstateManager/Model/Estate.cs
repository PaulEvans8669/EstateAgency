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
        public int? MainPhotoId
        {
            get { return GetProperty<int>(); }
            set { SetProperty(value); }
        }
        [ForeignKey(nameof(MainPhotoId))]
        public Photo MainPhoto
        {
            get { return GetProperty<Photo>(); }
            set { SetProperty(value); }
        }
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
        public float Surface
        {
            get { return GetProperty<float>(); }
            set { SetProperty(value); }
        }
        public EstateType Type
        {
            get { return GetProperty<EstateType>(); }
            set { SetProperty(value); }
        }
        public int RoomsCount
        {
            get { return GetProperty<int>(); }
            set { SetProperty(value); }
        }
        public DateTime ? BuildDate
        {
            get { return GetProperty<DateTime>(); }
            set { SetProperty(value); }
        }
        public int FloorCount
        {
            get { return GetProperty<int>(); }
            set { SetProperty(value); }
        }
        public int FloorNumber
        {
            get { return GetProperty<int>(); }
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
        public double ? Latitude
        {
            get { return GetProperty<double?>(); }
            set { SetProperty(value); }
        }
        public double ? Longitude
        {
            get { return GetProperty<double?>(); }
            set { SetProperty(value); }
        }
        public int EnergyEfficiency
        {
            get { return GetProperty<int>(); }
            set { SetProperty(value); }
        }
        [InverseProperty(nameof(Photo.Estate))]
        public ObservableCollection<Photo> Photos
        {
            get { return GetProperty<ObservableCollection<Photo>>(); }
            set { SetProperty(value); }
        }
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
