using EstateManager.DataAccess;
using EstateManager.Model;
using EstateManager.View;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EstateManager.ViewModel
{
    class ViewModelPersonEditor
    {



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
            Person estate = new Person();

            //EstateDbContext.Current.Add(estate);

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
