using EstateManager.Model.Enums;
using EstateManager.Tools;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EstateManager.Model
{
    public class Contract : BaseNotifyPropertyChanged
    {

        #region Properties

        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id
        {
            get { return GetProperty<int>(); }
            private set { SetProperty(value); }
        }

        public int EstateId
        {
            get { return GetProperty<int>(); }
            set { SetProperty(value); }
        }
        [ForeignKey(nameof(EstateId))]
        public Estate Estate
        {
            get { return GetProperty<Estate>(); }
            protected set { SetProperty(value); }
        }

        public ContractType Type
        {
            get { return GetProperty<ContractType>(); }
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

        public decimal Price
        {
            get { return GetProperty<decimal>(); }
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

        #endregion

    }
}
