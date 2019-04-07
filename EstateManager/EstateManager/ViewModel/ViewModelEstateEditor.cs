using EstateManager.DataAccess;
using EstateManager.Model;
using EstateManager.Model.Enums;
using EstateManager.Tools;
using EstateManager.View;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EstateManager.ViewModel
{
    class ViewModelEstateEditor : BaseNotifyPropertyChanged
    {
        public ObservableCollection<Person> PersonList;
        private EstateEditor editor;
        public EstateType Estate { get { return GetProperty<EstateType>(); } set { SetProperty(value); } }
        public string Address { get { return GetProperty<string>(); } set { SetProperty(value); } }
        public string ZIP { get { return GetProperty<string>(); } set { SetProperty(value); } }
        public string City { get { return GetProperty<string>(); } set { SetProperty(value); } }
        public DateTime? BuildDate { get { return GetProperty<DateTime?>(); } set { SetProperty(value); } }
        public double? Latitude { get { return GetProperty<double>(); } set { SetProperty(value); } }
        public double? Longitude { get { return GetProperty<double>(); } set { SetProperty(value); } }
        public int NbOfRooms { get { return GetProperty<int>(); } set { SetProperty(value); } }
        public int FloorCount { get { return GetProperty<int>(); } set { SetProperty(value); } }
        public int FloorNumber { get { return GetProperty<int>(); } set { SetProperty(value); } }
        public int Surface { get { return GetProperty<int>(); } set { SetProperty(value); } }
        public int EnergyEfficiency { get { return GetProperty<int>(); } set { SetProperty(value); } }
        public Person Owner { get { return GetProperty<Person>(); } set { SetProperty(value); } }

        public Photo SelectedPhoto
        {
            get { return GetProperty<Photo>(); }
            set { SetProperty(value); }
        }
        public ObservableCollection<Photo> PhotoList
        {
            get { return GetProperty<ObservableCollection<Photo>>(); }
            set { SetProperty(value); }
        }

        public ViewModelEstateEditor(EstateEditor editor)
        {
            loadPersonAsync();
            PhotoList = new ObservableCollection<Photo>();
            this.editor = editor;
        }

        public async Task loadPersonAsync()
        {
            PersonList = new ObservableCollection<Person>(
                await EstateDbContext.Current.Person.ToListAsync()
                   );
        }

        public BaseCommand AddPicture
        {
            get { return new BaseCommand(addPicture); }
        }
        public void addPicture()
        {
            PictureEditor editor = new PictureEditor();
            ViewModelPictureEditor vmPictureEditor = new ViewModelPictureEditor(this, editor);
            editor.DataContext = vmPictureEditor;
            editor.Show();
        }
        public BaseCommand DelPicture
        {
            get { return new BaseCommand(delPicture); }
        }
        public void delPicture()
        {
            PhotoList.Remove(SelectedPhoto);
        }

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
        public BaseCommand CloseWindowFailure
        {
            get { return new BaseCommand(closeWindow); }
        }
        public void closeWindow()
        {
            editor.Close();
        }
        public BaseCommand AddPerson
        {
            get { return new BaseCommand(addPerson); }
        }
        public void addPerson()
        {
            PersonEditor editor = new PersonEditor();
            ViewModelPersonEditor vmPictureEditor = new ViewModelPersonEditor(this, editor);
            editor.DataContext = vmPictureEditor;
            editor.Show();
        }
    }
}
