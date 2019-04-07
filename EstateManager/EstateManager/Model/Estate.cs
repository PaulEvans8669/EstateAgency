using EstateManager.Model.Enums;
using EstateManager.Tools;
using System;
using System.Collections.ObjectModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EstateManager.Model
{
    public class Estate : BaseNotifyPropertyChanged
    {

        #region Properties

        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id
        {
            get { return GetProperty<int>(); }
            private set { SetProperty(value); }
        }

        public int? MainPhotoId
        {
            get { return GetProperty<int?>(); }
            set { SetProperty(value); }
        }
        [ForeignKey(nameof(MainPhotoId))]
        public Photo MainPhoto
        {
            get { return GetProperty<Photo>(); }
            protected set { SetProperty(value); }
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
            protected set { SetProperty(value); }
        }

        public EstateType Type
        {
            get { return GetProperty<EstateType>(); }
            set { SetProperty(value); }
        }

        public float Surface
        {
            get { return GetProperty<float>(); }
            set { SetProperty(value); }
        }

        public int RoomsCount
        {
            get { return GetProperty<int>(); }
            set { SetProperty(value); }
        }

        public int FloorsCount
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

        public DateTime? BuildDate
        {
            get { return GetProperty<DateTime?>(); }
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
            get;
            private set;
        }

        [InverseProperty(nameof(Contract.Estate))]
        public ObservableCollection<Contract> Contracts
        {
            get;
            private set;
        }

        #endregion

    }
}
