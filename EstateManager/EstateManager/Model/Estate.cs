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
            get { return (int)GetField(); }
            set { SetField(value); }
        }

        [Description("Choose the main Photo (number) :")]
        public int? MainPhotoId
        {
            get { return (int)GetField(); }
            set { SetField(value); }
        }

        [Description("")]
        [ForeignKey(nameof(MainPhotoId))]
        public Photo MainPhoto
        {
            get { return (Photo)GetField(); }
            set { SetField(value); }
        }

        [Description("Owner :")]
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

        [Description("Surface :")]
        public float Surface
        {
            get { return (float)GetField(); }
            set { SetField(value); }
        }

        [Description("type of Estate :")]
        public EstateType Type
        {
            get { return (EstateType)GetField(); }
            set { SetField(value); }
        }

        [Description("Number of rooms :")]
        public int RoomsCount
        {
            get { return (int)GetField(); }
            set { SetField(value); }
        }

        [Description("Build date :")]
        public DateTime ? BuildDate
        {
            get { return (DateTime)GetField(); }
            set { SetField(value); }
        }

        [Description("number of floors")]
        public int FloorCount
        {
            get { return (int)GetField(); }
            set { SetField(value); }
        }

        [Description("floor number of your flat")]
        public int FloorNumber
        {
            get { return (int)GetField(); }
            set { SetField(value); }
        }

        [Description("Address")]
        public string Address
        {
            get { return (string)GetField(); }
            set { SetField(value); }
        }

        [Description("Zip code")]
        public string Zip
        {
            get { return (string)GetField(); }
            set { SetField(value); }
        }

        [Description("City")]
        public string City
        {
            get { return (string)GetField(); }
            set { SetField(value); }
        }

        [Description("Latitude")]
        public double ? Latitude
        {
            get { return (double)GetField(); }
            set { SetField(value); }
        }

        [Description("Longitude")]
        public double ? Longitude
        {
            get { return (double)GetField(); }
            set { SetField(value); }
        }

        [Description("Energy efficiency")]
        public int EnergyEfficiency
        {
            get { return (int)GetField(); }
            set { SetField(value); }
        }

        [Description("Add pictures")]
        [InverseProperty(nameof(Photo.Estate))]
        public ObservableCollection<Photo> Photos
        {
            get { return (ObservableCollection<Photo>)GetField(); }
            set { SetField(value); }
        }

        [Description("type of Contract")]
        [InverseProperty(nameof(Contract.Estate))]
        public ObservableCollection<Contract> Contracts
        {
            get { return (ObservableCollection<Contract>)GetField(); }
            set { SetField(value); }
        }

    }
}
