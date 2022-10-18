using System;
using System.Windows.Input;

namespace SW.Framework.WPF {
    public class RelayCommand : ICommand {
        private readonly Predicate<object?>? _CanExecute;
        private readonly Action<object?> _Execute;

        /// <summary>
        /// Occures when state changed.
        /// </summary>
        public event EventHandler? CanExecuteChanged {
            add => CommandManager.RequerySuggested += value;
            remove => CommandManager.RequerySuggested -= value;
        }

        #region CONSTRUCTORS
        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="execute"></param>
        public RelayCommand(Action<object?> execute) : this(execute, null) {
            _Execute = execute;
        }

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="execute">Function to execute.</param>
        /// <param name="canExecute">Predicate to check if function can be executed.</param>
        public RelayCommand(Action<object?> execute, Predicate<object?>? canExecute) {
            _Execute = execute ?? throw new ArgumentNullException(nameof(execute));
            _CanExecute = canExecute;
        }
        #endregion CONSTRUCTORS

        /// <summary>
        /// Check if command can be executed.
        /// </summary>
        /// <param name="parameter">Parameter for function.</param>
        /// <returns><c>TRUE</c> if function can be executed.</returns>
        public bool CanExecute(object? parameter) {
            return _CanExecute == null || _CanExecute(parameter);
        }

        /// <summary>
        /// Executes function.
        /// </summary>
        public void Execute(object? parameter) {
            _Execute(parameter);
        }
    }
}
