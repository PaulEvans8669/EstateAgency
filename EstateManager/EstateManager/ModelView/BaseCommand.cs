using System;
using System.Windows;
using System.Windows.Input;


public class BaseCommand : ICommand
{
    private readonly Action _execute;
    private readonly Func<bool> _canExecute;
    public event EventHandler CanExecuteChanged;

    public BaseCommand(Action execute)
    {
        if (execute == null) { throw new ArgumentNullException("execute"); }
        _execute = execute;
    }

    public bool CanExecute(object parameter)
    {
        return _canExecute == null || _canExecute();
    }

    public virtual void Execute(object parameter)
    {
        if (CanExecute(parameter) && _execute != null)
        {
            _execute();
        }
    }

    public void ajouterBienImmobilier(string saisie)
    {

        

    }


}

public class BaseCommand<T> : ICommand
{
    private readonly Action<T> _execute;
    private readonly Func<T, bool> _canExecute;
    public event EventHandler CanExecuteChanged;

    public BaseCommand(Action<T> execute)
    {
        if (execute == null) { throw new ArgumentNullException("execute"); }
        _execute = execute;
    }

    public bool CanExecute(object parameter)
    {
        return _canExecute == null || _canExecute((T)parameter);
    }

    public virtual void Execute(object parameter)
    {
        if (CanExecute(parameter) && _execute != null)
        {
            _execute((T)parameter);
        }
    }

}
