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
            get { return (int)GetField(); }
            set { SetField(value); }
        }
        public int EstateId
        {
            get { return (int)GetField(); }
            set { SetField(value); }
        }
        [ForeignKey(nameof(EstateId))]
        public Estate Estate
        {
            get { return (Estate)GetField(); }
            set { SetField(value); }
        }
        public ContractType Type
        {
            get { return (ContractType)GetField(); }
            set { SetField(value); }
        }
        public DateTime PubDate
        {
            get { return (DateTime)GetField(); }
            set { SetField(value); }
        }
        public DateTime ? SignDate
        {
            get { return (DateTime)GetField(); }
            set { SetField(value); }
        }
        public DateTime ? CloseDate
        {
            get { return (DateTime)GetField(); }
            set { SetField(value); }
        }
        public string Title
        {
            get { return (string)GetField(); }
            set { SetField(value); }
        }
        public string Description
        {
            get { return (string)GetField(); }
            set { SetField(value); }
        }
        public decimal Price
        {
            get { return (decimal)GetField(); }
            set { SetField(value); }
        }


    }
}
