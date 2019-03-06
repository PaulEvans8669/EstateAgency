using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EstateManager.Tools;
using EstateManager.Model.Enums;

namespace EstateManager.Model
{
    public class Person : BaseNotifyPropertyChanged
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id
        {
            get { return (int)GetField(); }
            set { SetField(value); }
        }
        public Quality Quality
        {
            get { return (Quality)GetField(); }
            set { SetField(value); }
        }
        public string Name
        {
            get { return (string)GetField(); }
            set { SetField(value); }
        }
        public string FirstName
        {
            get { return (string)GetField(); }
            set { SetField(value); }
        }
        public string Address
        {
            get { return (string)GetField(); }
            set { SetField(value); }
        }
        public string Zip
        {
            get { return (string)GetField(); }
            set { SetField(value); }
        }
        public string City
        {
            get { return (string)GetField(); }
            set { SetField(value); }
        }
        public double ? Latitude
        {
            get { return (double)GetField(); }
            set { SetField(value); }
        }
        public double ? Longitude
        {
            get { return (double)GetField(); }
            set { SetField(value); }
        }
        public string Phone
        {
            get { return (string)GetField(); }
            set { SetField(value); }
        }
        public string CellPhone
        {
            get { return (string)GetField(); }
            set { SetField(value); }
        }
        public string Mail
        {
            get { return (string)GetField(); }
            set { SetField(value); }
        }
    }
}
