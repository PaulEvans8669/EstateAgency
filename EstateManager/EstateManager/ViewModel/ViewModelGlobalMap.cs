using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;
using EstateManager.DataAccess;
using EstateManager.Model;
using Microsoft.EntityFrameworkCore;
using Microsoft.Maps.MapControl.WPF;

namespace EstateManager.ViewModel
{
    class ViewModelGlobalMap
    {
        
        private Map globalMap;
        public ViewModelGlobalMap(Map map)
        {
            globalMap = map;
            initMap();
        }

        private void initMap()
        {
            globalMap.Center = new Location(46.2, 5.2167);
            loadEstatesAsync();
            loadPersonsAsync();
        }

        private async Task loadEstatesAsync()
        {
            List<Estate> estateList = new List<Estate>(
                await EstateDbContext.Current.Estate.ToListAsync()
                   );
            foreach(Estate e in estateList)
            {
                if (e.Latitude != null && e.Longitude != null) {
                    Pushpin p = new Pushpin();
                    p.Location = new Location(e.Latitude.Value, e.Longitude.Value);
                    ToolTipService.SetToolTip(p, e.Surface+"m² "+e.Type+"\nClick to go to details.");
                    p.Background = new SolidColorBrush(Colors.Blue);
                    p.MouseEnter += (sender, ea) =>
                    {
                        Mouse.OverrideCursor = Cursors.Hand;
                    };
                    p.MouseLeave += (sender, ea) =>
                    {
                        Mouse.OverrideCursor = null;
                    };
                    p.MouseDown += (sender, ea) => {
                        if(ea.LeftButton == MouseButtonState.Pressed)
                        {
                            Console.WriteLine(e.ToString());
                        }
                    };
                    globalMap.Children.Add(p);
                }
            }
        }
        private async Task loadPersonsAsync()
        {
            List<Person> personList = new List<Person>(
                await EstateDbContext.Current.Person.ToListAsync()
                   );
            foreach (Person pers in personList)
            {
                if (pers.Latitude != null && pers.Longitude != null)
                {
                    Pushpin p = new Pushpin();
                    p.Location = new Location(pers.Latitude.Value, pers.Longitude.Value);
                    ToolTipService.SetToolTip(p, pers.Name + " " + pers.FirstName + "\nClick to go to details.");
                    p.Background = new SolidColorBrush(Colors.Green);
                    p.MouseEnter += (sender, ea) =>
                    {
                        Mouse.OverrideCursor = Cursors.Hand;
                    };
                    p.MouseLeave += (sender, ea) =>
                    {
                        Mouse.OverrideCursor = null;
                    };
                    p.MouseDown += (sender, ea) => {
                        if (ea.LeftButton == MouseButtonState.Pressed)
                        {
                            Console.WriteLine(pers.ToString());
                        }
                    };
                    globalMap.Children.Add(p);
                }
            }
        }



    }
}
