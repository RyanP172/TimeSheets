using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace TimeSheets.Command
{
    public class AppCommands : ICommand
    {
        private readonly Func<object?, bool>? _canExecute;
        private readonly Action<object?> _execute;


        public AppCommands(Action<object?> execute, Func<object?, bool>? canExecute = null)
        {
            ArgumentNullException.ThrowIfNull(execute);
            _execute = execute;
            _canExecute = canExecute;
        }

        public event EventHandler? CanExecuteChanged;
        /// <summary>
        /// When set the Command Property, it will call this method
        ///return _canExecute and let's check if that _canExecute field is null 
        /// </summary>
        /// <param name="parameter"></param>
        /// <returns>if that is the case, return true</returns>
        /// else, return the result of the CanExecute 
        /// Use the return value to set its own IsEnabled property
        public bool CanExecute(object? parameter) => _canExecute is null|| _canExecute(parameter);
        /// <summary>
        /// When command is called, it will call this method
        /// </summary>
        /// <param name="parameter"></param>
        public void Execute(object? parameter) => _execute(parameter);


    }
}
