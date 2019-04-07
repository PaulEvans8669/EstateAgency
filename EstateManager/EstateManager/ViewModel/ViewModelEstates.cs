using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media.Imaging;
using EstateManager.DataAccess;
using EstateManager.Model;
using EstateManager.Tools;
using EstateManager.View;
using Microsoft.EntityFrameworkCore;
using Microsoft.Maps.MapControl.WPF;

namespace EstateManager.ViewModel
{
    public class ViewModelEstates: BaseNotifyPropertyChanged
    {
        private Map map;
        private Pushpin pin;

        
        public Visibility isEstateSelected{
            get
            {
                return GetProperty<Visibility>();
            }
            set
            {
                SetProperty(value);
            }
        }
        
        public Estate SelectedEstate {
            get
            {
                return GetProperty<Estate>();
            }
            set
            {
                if (value != null)
                {
                    if (value.Latitude != null && value.Longitude != null)
                    {
                        Location loc = new Location((double)value.Latitude, (double)value.Longitude);
                        map.Center = loc;
                        pin.Location = loc;
                    }
                    SetProperty(value);
                    isEstateSelected = Visibility.Hidden;
                    loadContractsAsync();
                    loadPhotosAsync();
                    loadImage(0);
                }
                else
                {
                    isEstateSelected = Visibility.Visible;
                }
            }
        }

        public Contract SelectedContract
        {
            get
            {
                return GetProperty<Contract>();
            }
            set
            {
                SetProperty(value);
                if(value != null)
                {
                    ContractEditor editor = new ContractEditor();
                    ViewModelContractEditor vmContractEditor = new ViewModelContractEditor(SelectedEstate, editor, this, SelectedContract);
                    editor.DataContext = vmContractEditor;
                    editor.ShowDialog();
                }
            }
        }

        public ObservableCollection<Estate> EstateList {
            get
            {
                return GetProperty<ObservableCollection<Estate>>();
            }
            set
            {
                SetProperty(value);
            }
        }

        public ObservableCollection<Contract> ContractList
        {
            get
            {
                return GetProperty<ObservableCollection<Contract>>();
            }
            set
            {
                SetProperty(value);
            }
        }

        public ObservableCollection<Photo> listImage
        {
            get
            {
                return GetProperty<ObservableCollection<Photo>>();
            }
            set
            {
                SetProperty(value);
            }
        }

        private int currentImage;

        public BitmapImage Image
        {
            get
            {
                return GetProperty<BitmapImage>();
            }
            set
            {
                SetProperty(value);
            }
        }

        private async Task loadEstatesAsync()
        {
            EstateList = new ObservableCollection<Estate>( 
                await EstateDbContext.Current.Estate.Include(e => e.MainPhoto).ToListAsync()
                   );
        }

        private async Task loadContractsAsync()
        {
            ContractList = new ObservableCollection<Contract>(
                await EstateDbContext.Current.Contract.Where(c => c.EstateId == SelectedEstate.Id).ToListAsync()
                   );
        }

        public ViewModelEstates(Map m)
        {
            this.isEstateSelected = Visibility.Visible;
            this.map = m;
            this.pin = new Pushpin();

            listImage = new ObservableCollection<Photo>();

            loadEstatesAsync();

            currentImage = listImage.Count;

            map.Center = new Location(46.2, 5.2167);
            map.Children.Add(pin);

        }

        public BaseCommand DeleteEstate
        {
            get { return new BaseCommand(deleteEstate); }
        }

        public void deleteEstate()
        {
            var toDelete = EstateDbContext.Current.Estate.SingleOrDefault(x => x.Id == SelectedEstate.Id);
            if(toDelete != null)
            {
                EstateDbContext.Current.Remove(toDelete);
                EstateList.Remove(SelectedEstate);
            }
        }

        public BaseCommand AddEstate
        {
            get { return new BaseCommand(addEstate); }
        }

        public void addEstate()
        {
            EstateEditor editor = new EstateEditor();
            ViewModelEstateEditor vmEstateEditor = new ViewModelEstateEditor(editor);
            editor.DataContext = vmEstateEditor;
            editor.ShowDialog();

            loadEstatesAsync();

        }

        public BaseCommand AddContract
        {
            get { return new BaseCommand(addContract); }
        }

        public void addContract()
        {
            ContractEditor editor = new ContractEditor();
            ViewModelContractEditor vmEstateEditor = new ViewModelContractEditor(SelectedEstate, editor, this);
            editor.DataContext = vmEstateEditor;
            editor.ShowDialog();
        }

        public BaseCommand DelContract
        {
            get { return new BaseCommand(delContract); }
        }

        public void delContract()
        {
            var toDelete = EstateDbContext.Current.Contract.SingleOrDefault(x => x.Id == SelectedContract.Id);
            if (toDelete != null)
            {
                EstateDbContext.Current.Remove(toDelete);
                ContractList.Remove(SelectedContract);
            }
        }

        public BaseCommand ModifyEstate
        {
            get { return new BaseCommand(modifyEstate); }
        }

        public void modifyEstate()
        {
            EstateEditor editor = new EstateEditor();
            ViewModelEstateEditor vmEstateEditor = new ViewModelEstateEditor(editor, SelectedEstate);
            editor.DataContext = vmEstateEditor;
            editor.ShowDialog();
            loadEstatesAsync();
        }
        public BaseCommand LeftImage
        {
            get { return new BaseCommand(leftImage); }
        }

        public void leftImage()
        {
            currentImage--;
            if (currentImage < 0)
            {
                currentImage = listImage.Count - 1;
            }
            loadImage(currentImage);
        }

        private void loadImage(int currentImage)
        {
            Image = Base64StringToBitmapImage(listImage[currentImage].Content);
        }

        public BaseCommand RightImage
        {
            get { return new BaseCommand(rightImage); }
        }
        public void rightImage()
        {
            currentImage++;
            if (currentImage >= listImage.Count)
            {
                currentImage = 0;
            }
            loadImage(currentImage);
        }

        public static BitmapImage Base64StringToBitmapImage(string base64String)
        {
            byte[] byteArray = System.Convert.FromBase64String(base64String);

            using (MemoryStream stream = new MemoryStream(byteArray))
            {
                BitmapImage image = new BitmapImage();
                image.BeginInit();
                image.CacheOption = BitmapCacheOption.OnLoad;
                image.StreamSource = stream;
                image.EndInit();
                image.Freeze();
                return image;
            }
        }

        private async Task loadPhotosAsync()
        {
            listImage = new ObservableCollection<Photo>(
                await EstateDbContext.Current.Photo.Where(c => c.EstateId == SelectedEstate.Id).ToListAsync()
                   );
        }
    }
}
