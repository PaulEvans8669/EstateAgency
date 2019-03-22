using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EstateManager.Model.Enums;
using EstateManager.View;
using EstateManager.Model;
using System.Reflection;
using EstateManager.Tools;
using System.Windows;
using System.ComponentModel;

namespace EstateManager.ModelView
{
    class ViewModelAdd : BaseNotifyPropertyChanged
    {

        int currentProp;

        PropertyInfo[] listProp;

        private string _propertyName;

        public string PropertyName
        {
            get { return (string)GetField(); }
            set { SetField(value); }
        }

        private string _textIn;

        public string TextIn
        {
            get { return (string)GetField(); }
            set { SetField(value); }
        }

        public Visibility CloseButtonVisibility
        {
            get { return (Visibility)GetField(); }
            set { SetField(value); }
        }

        public Visibility DatePickerVisibility
        {
            get { return (Visibility)GetField(); }
            set { SetField(value); }
        }

        public Visibility TextInVisibility
        {
            get { return (Visibility)GetField(); }
            set { SetField(value); }
        }

        public ViewModelAdd(Type t)
        {

            listProp = t.GetProperties();
            currentProp = 1;
            CloseButtonVisibility = Visibility.Hidden;
            TextInVisibility = Visibility.Visible;
            DatePickerVisibility = Visibility.Hidden;
            loadpropInfo(currentProp);

        }

        

        private void loadpropInfo(int currentProp)
        {
            var attr = listProp[currentProp].GetCustomAttribute<DescriptionAttribute>();
            if (attr == null || attr.Description == "")
            {
                next();
                return;
            }

            PropertyName = attr.Description;

            if (currentProp == listProp.Length-1)
            {
                CloseButtonVisibility = Visibility.Visible;
            }

            if (listProp[currentProp].Name == "BuildDate")
            {
                TextInVisibility = Visibility.Hidden;
                DatePickerVisibility = Visibility.Visible;
            }
            else if (listProp[currentProp].Name != "BuildDate" && TextInVisibility == Visibility.Hidden)
            {
                TextInVisibility = Visibility.Visible;
                DatePickerVisibility = Visibility.Hidden;
            }

        }

        public BaseCommand NextProperty
        {
            get
            {
                return new BaseCommand(next);
            }
        }

        public BaseCommand<AddEstateWindow> CloseWindow
        {
            get
            {
                return new BaseCommand<AddEstateWindow>(close);
            }
        }

        private void close(AddEstateWindow view)
        {
            view.DialogResult = true;
            view.Close();
        }

        public void next()
        {

            if ((currentProp+1)<listProp.Length)
            {
                currentProp++;
                loadpropInfo(currentProp);
            }

        }

    }
}
