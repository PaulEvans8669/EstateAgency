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
            get { return (int)GetField(); }
            set { SetField(value); }
        }
        public int? MainPhotoId
        {
            get { return (int)GetField(); }
            set { SetField(value); }
        }
        [ForeignKey(nameof(MainPhotoId))]
        public Photo MainPhoto
        {
            get { return (Photo)GetField(); }
            set { SetField(value); }
        }
        public int OwnerId
        {
            get { return (int)GetField(); }
            set { SetField(value); }
        }
        [ForeignKey(nameof(OwnerId))]
        public Person Owner
        {
            get { return (Person)GetField(); }
            set { SetField(value); }
        }
        public float Surface
        {
            get { return (float)GetField(); }
            set { SetField(value); }
        }
        public EstateType Type
        {
            get { return (EstateType)GetField(); }
            set { SetField(value); }
        }
        public int RoomsCount
        {
            get { return (int)GetField(); }
            set { SetField(value); }
        }
        public DateTime ? BuildDate
        {
            get { return (DateTime)GetField(); }
            set { SetField(value); }
        }
        public int FloorCount
        {
            get { return (int)GetField(); }
            set { SetField(value); }
        }
        public int FloorNumber
        {
            get { return (int)GetField(); }
            set { SetField(value); }
        }
        public string Address
        {
            get { return (string)GetField(); }
            set { SetField(value); }
        }
        public string Zip
        {
            get { return (string)GetField(); }
            set { SetField(value); }
        }
        public string City
        {
            get { return (string)GetField(); }
            set { SetField(value); }
        }
        public double ? Latitude
        {
            get { return (double)GetField(); }
            set { SetField(value); }
        }
        public double ? Longitude
        {
            get { return (double)GetField(); }
            set { SetField(value); }
        }
        public int EnergyEfficiency
        {
            get { return (int)GetField(); }
            set { SetField(value); }
        }
        [InverseProperty(nameof(Photo.Estate))]
        public ObservableCollection<Photo> Photos
        {
            get { return (ObservableCollection<Photo>)GetField(); }
            set { SetField(value); }
        }
        [InverseProperty(nameof(Contract.Estate))]
        public ObservableCollection<Contract> Contracts
        {
            get { return (ObservableCollection<Contract>)GetField(); }
            set { SetField(value); }
        }

    }
}
