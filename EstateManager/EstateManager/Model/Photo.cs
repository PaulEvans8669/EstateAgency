using EstateManager.Tools;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EstateManager.Model
{
    public class Photo : BaseNotifyPropertyChanged
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

        #endregion

    }
}
