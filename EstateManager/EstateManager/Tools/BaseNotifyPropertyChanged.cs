using System;
using System.Collections.Generic;
using System.Linq;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;

namespace EstateManager.Tools
{
    public abstract class BaseNotifyPropertyChanged : INotifyPropertyChanged
    {

        public event PropertyChangedEventHandler PropertyChanged;

        private Dictionary<string, object> _propertyValues;


        public BaseNotifyPropertyChanged()
        {
            _propertyValues = new Dictionary<string, object>();
        }

        protected Commands.Command GetCommand(Action execute,
                                              Func<bool> canExecute = null,
                                              [CallerMemberName] string propertyName = null)
        {
            if (!_propertyValues.ContainsKey(propertyName)) _propertyValues[propertyName] = new Commands.Command(execute, canExecute);
            return (Commands.Command)_propertyValues[propertyName];
        }
        protected Commands.Command<T> GetCommand<T>(Action<T> execute,
                                                    Func<T, bool> canExecute = null,
                                                    [CallerMemberName] string propertyName = null)
        {
            if (!_propertyValues.ContainsKey(propertyName)) _propertyValues[propertyName] = new Commands.Command<T>(execute, canExecute);
            return (Commands.Command<T>)_propertyValues[propertyName];
        }
        protected Commands.AsyncCommand GetCommand(Func<Task> execute,
                                                   Func<bool> canExecute = null,
                                                   [CallerMemberName] string propertyName = null)
        {
            if (!_propertyValues.ContainsKey(propertyName)) _propertyValues[propertyName] = new Commands.AsyncCommand(execute, canExecute);
            return (Commands.AsyncCommand)_propertyValues[propertyName];
        }
        protected Commands.AsyncCommand<T> GetCommand<T>(Func<T, Task> execute,
                                                         Func<T, bool> canExecute = null,
                                                         [CallerMemberName] string propertyName = null)
        {
            if (!_propertyValues.ContainsKey(propertyName)) _propertyValues[propertyName] = new Commands.AsyncCommand<T>(execute, canExecute);
            return (Commands.AsyncCommand<T>)_propertyValues[propertyName];
        }

        protected virtual T GetProperty<T>([CallerMemberName] string propertyName = null)
        {
            if (_propertyValues.ContainsKey(propertyName)) return (T)_propertyValues[propertyName];
            return default(T);
        }
        protected bool SetProperty<T>(T newValue, [CallerMemberName] string propertyName = null)
        {
            var current = GetProperty<T>(propertyName);

            if (EqualityComparer<T>.Default.Equals(current, newValue))
                return false;

            _propertyValues[propertyName] = newValue;
            OnPropertyChanged(propertyName);

            return true;
        }
        protected virtual bool SetProperty<T>(ref T field, T value, [CallerMemberName] string propertyName = null)
        {
            if (EqualityComparer<T>.Default.Equals(field, value)) return false;

            field = value;
            OnPropertyChanged(propertyName);

            return true;
        }


        public void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

    }
}
