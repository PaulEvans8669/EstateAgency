﻿using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;
using EstateManager.DataAccess;
using EstateManager.Model;
using EstateManager.Tools;
using Microsoft.EntityFrameworkCore;
using Microsoft.Maps.MapControl.WPF;

namespace EstateManager.ViewModel
{
    class ViewModelEstates: BaseNotifyPropertyChanged
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

        private Estate selectedEstate;
        public Estate SelectedEstate {
            get
            {
                return GetProperty<Estate>();
            }
            set
            {
                if (value.Latitude != null && value.Longitude != null)
                {
                    Location loc = new Location((double)value.Latitude, (double)value.Longitude);
                    map.Center = loc;
                    pin.Location = loc;
                }
                SetProperty(value);
                isEstateSelected = Visibility.Hidden;
            }
        }

        public ObservableCollection<Estate> EstateList { get; set; }

        private async Task loadEstatesAsync()
        {
            EstateList = new ObservableCollection<Estate>( 
                await EstateDbContext.Current.Estate.ToListAsync()
                   );
        }


        public ViewModelEstates(Map m)
        {
            this.isEstateSelected = Visibility.Visible;
            this.map = m;
            this.pin = new Pushpin();

            loadEstatesAsync();

            map.Center = new Location(46.2,5.2167);
            map.Children.Add(pin);
        }


    }
}