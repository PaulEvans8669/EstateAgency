using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using EstateManager.DataAccess;
using EstateManager.Model;
using Microsoft.EntityFrameworkCore;

namespace EstateManager.ViewModel
{
    class ViewModelHomePage
    {
        private Estate selectedEstate;
        public Estate SelectedEstate {
            get
            {
                return selectedEstate;
            }
            set
            {
                loadEstateByIdAsync(value.Id);
            }
        }
        public string MapCenterPoint { get; set; }

        public ObservableCollection<Estate> EstateList { get; set; }

        private async Task loadEstateByIdAsync(int id)
        {
            selectedEstate = await EstateDbContext.Current.Estate
                   .Where(estate => estate.Id == id)
                   .FirstOrDefaultAsync();
            Console.WriteLine(selectedEstate.ToString());
            MapCenterPoint = selectedEstate.Latitude.ToString() + "," + selectedEstate.Longitude.ToString();
            System.Windows.MessageBox.Show(MapCenterPoint);
        }

        private async Task loadEstatesPreviewAsync()
        {
            EstateList = new ObservableCollection<Estate>( 
                await EstateDbContext.Current.Estate
                   .Select(estate => new Estate
                   {
                       Id = estate.Id,
                       Zip = estate.Zip,
                       City = estate.City,
                       Type = estate.Type,
                       Surface = estate.Surface
                   }
                   ).ToListAsync()
                   );
        }


        public ViewModelHomePage()
        {
            loadEstatesPreviewAsync();
            foreach (Estate e in EstateList)
            {
                Console.WriteLine(e.ToString());
            }
            MapCenterPoint = "46.2,5.2167";
        }


    }
}
