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
using Microsoft.Maps.MapControl.WPF;

namespace EstateManager.ViewModel
{
    class ViewModelHomePage
    {
        private Map map;
        private Pushpin pin;

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

        public ObservableCollection<Estate> EstateList { get; set; }

        private async Task loadEstateByIdAsync(int id)
        {
            selectedEstate = await EstateDbContext.Current.Estate
                   .Where(estate => estate.Id == id)
                   .FirstOrDefaultAsync();
            Console.WriteLine(selectedEstate.ToString());
            if (selectedEstate.Latitude != null && selectedEstate.Longitude != null)
            {
                Location loc = new Location((double)selectedEstate.Latitude, (double)selectedEstate.Longitude);
                map.Center = loc;
                pin.Location = loc;
            }
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


        public ViewModelHomePage(Map m)
        {
            this.map = m;
            this.pin = new Pushpin();

            loadEstatesPreviewAsync();

            map.Center = new Location(46.2,5.2167);
            map.Children.Add(pin);
        }


    }
}
