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
        private List<Estate> estateList;
        private List<Person> personList;
        private List<Pushpin> pinList;
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
                        if(ea.LeftButton == System.Windows.Input.MouseButtonState.Pressed)
                        {
                            
                        }
                    };
                    globalMap.Children.Add(p);
                }
            }
        }
    }
}
