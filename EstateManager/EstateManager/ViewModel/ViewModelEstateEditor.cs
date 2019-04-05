using EstateManager.DataAccess;
using EstateManager.Model;
using EstateManager.Model.Enums;
using EstateManager.Tools;
using EstateManager.View;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EstateManager.ViewModel
{
    class ViewModelEstateEditor : BaseNotifyPropertyChanged
    {
        private EstateEditor editor;
        public EstateType Estate { get { return GetProperty<EstateType>(); } set { SetProperty(value); } }
        public string Address { get { return GetProperty<string>();} set { SetProperty(value); } }
        public string ZIP { get { return GetProperty<string>(); } set { SetProperty(value); } }
        public string City {get { return GetProperty<string>(); } set { SetProperty(value); }}
        public DateTime? BuildDate {get { return GetProperty<DateTime?>(); } set { SetProperty(value); }}
        public double? Latitude {get { return GetProperty<double>(); } set { SetProperty(value); }}
        public double? Longitude {get { return GetProperty<double>(); } set { SetProperty(value); }}
        public int NbOfRooms {get { return GetProperty<int>(); } set { SetProperty(value); }}
        public int FloorCount {get { return GetProperty<int>(); } set { SetProperty(value); }}
        public int FloorNumber {get { return GetProperty<int>(); } set { SetProperty(value); }}
        public int Surface {get { return GetProperty<int>(); } set { SetProperty(value); }}
        public int EnergyEfficiency {get { return GetProperty<int>(); } set { SetProperty(value); }}
        public Person Owner {get { return GetProperty<Person>(); } set { SetProperty(value); }}

        public BaseCommand CloseWindowSuccess
        {
            get { return new BaseCommand(saveAndClose); }
        }
        public void saveAndClose()
        {
            Estate estate = new Estate();
            estate.Address = Address;
            estate.BuildDate = BuildDate;
            estate.City = City;
            estate.EnergyEfficiency = EnergyEfficiency;
            estate.FloorCount = FloorCount;
            estate.FloorNumber = FloorNumber;
            estate.Latitude = Latitude;
            estate.Longitude = Longitude;
            estate.Owner = Owner;
            estate.RoomsCount = NbOfRooms;
            estate.Surface = Surface;
            estate.Type = Estate;
            estate.Zip = ZIP;

            EstateDbContext.Current.Add(estate);

            editor.Close();

        }

        public ViewModelEstateEditor(EstateEditor editor)
        {
            this.editor = editor;
        }

        public BaseCommand CloseWindowFailure
        {
            get { return new BaseCommand(closeWindow); }
        }
        public void closeWindow()
        {
            editor.Close();
        }

    }
}
