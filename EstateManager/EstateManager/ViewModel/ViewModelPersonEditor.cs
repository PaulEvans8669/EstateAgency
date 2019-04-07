using EstateManager.DataAccess;
using EstateManager.Model;
using EstateManager.Tools;
using EstateManager.View;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EstateManager.ViewModel
{
    class ViewModelPersonEditor : BaseNotifyPropertyChanged 
    {

        public Model.Enums.Quality Genre { get { return GetProperty<Model.Enums.Quality>(); } set { SetProperty(value); } }
        public string Name { get { return GetProperty<string>(); } set { SetProperty(value); } }
        public string FirstName { get { return GetProperty<string>(); } set { SetProperty(value); } }
        public string Address { get { return GetProperty<string>(); } set { SetProperty(value); } }
        public string City { get { return GetProperty<string>(); } set { SetProperty(value); } }
        public string ZIP { get { return GetProperty<string>(); } set { SetProperty(value); } }
        public double? Latitude { get { return GetProperty<double?>(); } set { SetProperty(value); } }
        public double? Longitude { get { return GetProperty<double?>(); } set { SetProperty(value); } }
        public string Phone { get { return GetProperty<string>(); } set { SetProperty(value); } }
        public string CellPhone { get { return GetProperty<string>(); } set { SetProperty(value); } }
        public string Mail { get { return GetProperty<string>(); } set { SetProperty(value); } }
        private PersonEditor editor { get; set; }
        private ViewModelEstateEditor estateEditor { get; set; }

        public ViewModelPersonEditor(ViewModelEstateEditor estateEditor, PersonEditor editor)
        {
            this.estateEditor = estateEditor;
            this.editor = editor;
        }

        public BaseCommand CloseWindowSuccess
        {
            get { return new BaseCommand(saveAndClose); }
        }
        public void saveAndClose()
        {
            Person person = new Person();

            person.Address = Address;
            person.CellPhone = CellPhone;
            person.City = City;
            person.FirstName = FirstName;
            person.Latitude = Latitude;
            person.Longitude = Longitude;
            person.Mail = Mail;
            person.Name = Name;
            person.Phone = Phone;
            person.Quality = Genre;
            person.Zip = ZIP;


            EstateDbContext.Current.Add(person);

            estateEditor.loadPersonAsync();
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
    }
}
