using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EstateManager.View;
using EstateManager.Model;

namespace EstateManager.ModelView
{
    class ViewModelHomePage
    {

        public BaseCommand addEstateCommand
        {
            get
            {
                return new BaseCommand(form);
            }
        }

        private void form()
        {

            AddEstateWindow win = new AddEstateWindow();
            ViewModelAdd vm = new ViewModelAdd(typeof(Estate));
            win.DataContext = vm;
            win.ShowDialog();

        }

    }
}
