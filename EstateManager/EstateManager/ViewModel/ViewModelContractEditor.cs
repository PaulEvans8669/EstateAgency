using EstateManager.DataAccess;
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
        private Contract con;


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

        public ViewModelContractEditor(Estate estate, ContractEditor editor, ViewModelEstates vmEstate ,Contract c)
        {
            this.estate = estate;
            this.editor = editor;
            this.vmEstate = vmEstate;
            this.con = c;
            if(con!= null)
            {
                CloseDate = con.CloseDate;
                Description = con.Description;
                estate = con.Estate;
                Price = con.Price;
                PubDate = con.PubDate;
                SignDate = con.SignDate;
                Title = con.Title;
                Type = con.Type; 
            }
        }

        public BaseCommand CloseWindowSuccess
        {
            get { return new BaseCommand(saveAndClose); }
        }
        public void saveAndClose()
        {
            if (con == null)
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
                EstateDbContext.Current.Add(c);
            }
            else
            {
                con.CloseDate = CloseDate;
                con.Description = Description;
                con.EstateId = estate.Id;
                con.Price = Price;
                con.PubDate = PubDate;
                con.SignDate = SignDate;
                con.Title = Title;
                con.Type = Type;
                EstateDbContext.Current.Update(con);
            }
            EstateDbContext.Current.SaveChanges();
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
