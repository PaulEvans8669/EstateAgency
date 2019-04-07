using EstateManager.Model;
using EstateManager.Model.Enums;
using EstateManager.Tools;
using EstateManager.View;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EstateManager.ViewModel
{
    class ViewModelContractEditor : BaseNotifyPropertyChanged
    {

        private Estate estate { get; set; }
        private ViewModelEstates vmEstate { get; set; }
        private ContractEditor editor { get; set; }


        public ContractType Type
        {
                get { return GetProperty<ContractType>(); }
                set { SetProperty(value); }
        }
        public DateTime PubDate
        {
            get { return GetProperty<DateTime>(); }
            set { SetProperty(value); }
        }
        public DateTime? SignDate
        {
            get { return GetProperty<DateTime?>(); }
            set { SetProperty(value); }
        }
        public DateTime? CloseDate
        {
            get { return GetProperty<DateTime?>(); }
            set { SetProperty(value); }
        }
        public string Title
        {
            get { return GetProperty<string>(); }
            set { SetProperty(value); }
        }
        public string Description
        {
            get { return GetProperty<string>(); }
            set { SetProperty(value); }
        }
        private decimal Price
        {
            get { return GetProperty<decimal>(); }
            set { SetProperty(value); }
        }

        public ViewModelContractEditor(Estate estate, ContractEditor editor, ViewModelEstates vmEstate)
        {
            this.estate = estate;
            this.editor = editor;
            this.vmEstate = vmEstate;
        }

        public BaseCommand CloseWindowSuccess
        {
            get { return new BaseCommand(saveAndClose); }
        }
        public void saveAndClose()
        {
            Contract c = new Contract();
            c.CloseDate = CloseDate;
            c.Description = Description;
            c.EstateId = estate.Id;
            c.Price = Price;
            c.PubDate = DateTime.Now;
            c.SignDate = SignDate;
            c.Title = Title;
            c.Type = Type;
            vmEstate.ContractList.Add(c);
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
