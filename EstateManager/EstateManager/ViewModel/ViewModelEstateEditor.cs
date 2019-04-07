using EstateManager.DataAccess;
using EstateManager.Model;
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
        public ObservableCollection<Person> PersonList { get; set; }
        private EstateEditor editor;
        public Model.Enums.EstateType Estate { get { return GetProperty<Model.Enums.EstateType>(); } set { SetProperty(value); } }
        public string Address { get { return GetProperty<string>(); } set { SetProperty(value); } }
        public string ZIP { get { return GetProperty<string>(); } set { SetProperty(value); } }
        public string City { get { return GetProperty<string>(); } set { SetProperty(value); } }
        public DateTime? BuildDate { get { return GetProperty<DateTime?>(); } set { SetProperty(value); } }
        public double? Latitude { get { return GetProperty<double>(); } set { SetProperty(value); } }
        public double? Longitude { get { return GetProperty<double>(); } set { SetProperty(value); } }
        public int NbOfRooms { get { return GetProperty<int>(); } set { SetProperty(value); } }
        public int FloorCount { get { return GetProperty<int>(); } set { SetProperty(value); } }
        public int FloorNumber { get { return GetProperty<int>(); } set { SetProperty(value); } }
        public float Surface { get { return GetProperty<float>(); } set { SetProperty(value); } }
        public int EnergyEfficiency { get { return GetProperty<int>(); } set { SetProperty(value); } }
        public Person Owner { get { return GetProperty<Person>(); } set { SetProperty(value); } }
        private Estate es;

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

        public ViewModelEstateEditor(EstateEditor editor, Estate selectedEstate)
        {
            loadPersonAsync();
            PhotoList = new ObservableCollection<Photo>();
            this.editor = editor;
            es = selectedEstate;
            if (selectedEstate != null)
            {
                Estate = selectedEstate.Type;
                Address = selectedEstate.Address;
                ZIP = selectedEstate.Zip;
                City = selectedEstate.City;
                BuildDate = selectedEstate.BuildDate;
                Latitude = selectedEstate.Latitude;
                Longitude = selectedEstate.Longitude;
                NbOfRooms = selectedEstate.RoomsCount;
                FloorCount = selectedEstate.FloorsCount;
                FloorNumber = selectedEstate.FloorNumber;
                Surface = selectedEstate.Surface;
                EnergyEfficiency = selectedEstate.EnergyEfficiency;
                Owner = selectedEstate.Owner;

            }
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
            if (es == null)
            {
                Estate estate = new Estate();
                estate.Address = Address;
                estate.BuildDate = BuildDate;
                estate.City = City;
                estate.EnergyEfficiency = EnergyEfficiency;
                estate.FloorsCount = FloorCount;
                estate.FloorNumber = FloorNumber;
                estate.Latitude = Latitude;
                estate.Longitude = Longitude;
                estate.RoomsCount = NbOfRooms;
                estate.Surface = Surface;
                estate.OwnerId = Owner.Id;
                estate.Type = Estate;
                estate.Zip = ZIP;

                EstateDbContext.Current.Add(estate);
            }
            else
            {
                es.Address = Address;
                es.BuildDate = BuildDate;
                es.City = City;
                es.EnergyEfficiency = EnergyEfficiency;
                es.FloorsCount = FloorCount;
                es.FloorNumber = FloorNumber;
                es.Latitude = Latitude;
                es.Longitude = Longitude;
                es.RoomsCount = NbOfRooms;
                es.Surface = Surface;
                es.OwnerId = Owner.Id;
                es.Type = Estate;
                es.Zip = ZIP;

                EstateDbContext.Current.Update(es);
            }
            EstateDbContext.Current.SaveChanges();
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
