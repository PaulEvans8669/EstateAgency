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
        public string Title
        {
            get { return (string)GetField(); }
            set { SetField(value); }
        }
        public string Content
        {
            get { return (string)GetField(); }
            set { SetField(value); }
        }
    }
}
