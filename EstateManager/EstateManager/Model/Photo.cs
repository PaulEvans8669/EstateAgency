using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EstateManager.Tools;

namespace EstateManager.Model
{
    public class Photo : BaseNotifyPropertyChanged
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
        public string Title
        {
            get { return GetProperty<string>(); }
            set { SetProperty(value); }
        }
        public string Content
        {
            get { return GetProperty<string>(); }
            set { SetProperty(value); }
        }
    }
}
