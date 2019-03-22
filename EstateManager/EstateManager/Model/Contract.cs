using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EstateManager.Tools;
using EstateManager.Model.Enums;
using Microsoft.EntityFrameworkCore;

namespace EstateManager.Model
{
    public class Contract : BaseNotifyPropertyChanged
    {

        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id
        {
            get { return GetProperty<int>(); }
            set { SetProperty(value); }
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
            set { SetProperty(value); }
        }
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
        public DateTime ? SignDate
        {
            get { return GetProperty<DateTime>(); }
            set { SetProperty(value); }
    }
        public DateTime ? CloseDate
        {
            get { return GetProperty<DateTime>(); }
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


    }
}
