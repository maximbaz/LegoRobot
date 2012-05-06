using System;
using System.Collections.Generic;
using System.Windows.Input;

namespace UI.Commands
{
    public class DelegateCommand : ICommand
    {
        #region Properties and Indexers

        /// <summary>
        ///   Property to enable or disable CommandManager's automatic requery on this command
        /// </summary>
        public bool IsAutomaticRequeryDisabled {
            get { return isAutomaticRequeryDisabled; }
            set {
                if (isAutomaticRequeryDisabled == value) 
                    return;

                if (value)
                    CommandManagerHelper.RemoveHandlersFromRequerySuggested(canExecuteChangedHandlers);
                else
                    CommandManagerHelper.AddHandlersToRequerySuggested(canExecuteChangedHandlers);

                isAutomaticRequeryDisabled = value;
            }
        }

        #endregion

        #region Fields

        private readonly Func<bool> canExecuteMethod;
        private readonly Action executeMethod;
        private List<WeakReference> canExecuteChangedHandlers;
        private bool isAutomaticRequeryDisabled;

        #endregion

        #region Constructors and Destructor

        public DelegateCommand(Action executeMethod) : this(executeMethod, null, false) {}
        
        public DelegateCommand(Action executeMethod, Func<bool> canExecuteMethod) : this(executeMethod, canExecuteMethod, false) {}

        public DelegateCommand(Action executeMethod, Func<bool> canExecuteMethod, bool isAutomaticRequeryDisabled) {
            if (executeMethod == null) {
                throw new ArgumentNullException("executeMethod");
            }

            this.executeMethod = executeMethod;
            this.canExecuteMethod = canExecuteMethod;
            this.isAutomaticRequeryDisabled = isAutomaticRequeryDisabled;
        }

        #endregion

        #region ICommand Members

        public event EventHandler CanExecuteChanged {
            add {
                if (!isAutomaticRequeryDisabled)
                    CommandManager.RequerySuggested += value;

                CommandManagerHelper.AddWeakReferenceHandler(ref canExecuteChangedHandlers, value, 2);
            }
            remove {
                if (!isAutomaticRequeryDisabled) 
                    CommandManager.RequerySuggested -= value;

                CommandManagerHelper.RemoveWeakReferenceHandler(canExecuteChangedHandlers, value);
            }
        }

        bool ICommand.CanExecute(object parameter) {
            return CanExecute();
        }

        void ICommand.Execute(object parameter) {
            Execute();
        }

        #endregion

        #region Public Methods

        public bool CanExecute() {
            return canExecuteMethod == null || canExecuteMethod();
        }

        public void Execute() {
            if (executeMethod != null)
                executeMethod();
        }

        public void RaiseCanExecuteChanged() {
            OnCanExecuteChanged();
        }

        #endregion

        #region Protected And Private Methods

        protected virtual void OnCanExecuteChanged() {
            CommandManagerHelper.CallWeakReferenceHandlers(canExecuteChangedHandlers);
        }

        #endregion
    }

    public class DelegateCommand<T> : ICommand
    {
        #region Properties and Indexers

        /// <summary>
        ///   Property to enable or disable CommandManager's automatic requery on this command
        /// </summary>
        public bool IsAutomaticRequeryDisabled {
            get { return isAutomaticRequeryDisabled; }
            set {
                if (isAutomaticRequeryDisabled == value) 
                    return;

                if (value)
                    CommandManagerHelper.RemoveHandlersFromRequerySuggested(canExecuteChangedHandlers);
                else
                    CommandManagerHelper.AddHandlersToRequerySuggested(canExecuteChangedHandlers);

                isAutomaticRequeryDisabled = value;
            }
        }

        #endregion

        #region Fields

        private readonly Func<T, bool> canExecuteMethod;
        private readonly Action<T> executeMethod;
        private List<WeakReference> canExecuteChangedHandlers;
        private bool isAutomaticRequeryDisabled;

        #endregion

        #region Constructors and Destructor

        public DelegateCommand(Action<T> executeMethod) : this(executeMethod, null, false) {}

        public DelegateCommand(Action<T> executeMethod, Func<T, bool> canExecuteMethod) : this(executeMethod, canExecuteMethod, false) {}

        public DelegateCommand(Action<T> executeMethod, Func<T, bool> canExecuteMethod, bool isAutomaticRequeryDisabled) {
            if (executeMethod == null)
                throw new ArgumentNullException("executeMethod");

            this.executeMethod = executeMethod;
            this.canExecuteMethod = canExecuteMethod;
            this.isAutomaticRequeryDisabled = isAutomaticRequeryDisabled;
        }

        #endregion

        #region ICommand Members

        public event EventHandler CanExecuteChanged {
            add {
                if (!isAutomaticRequeryDisabled)
                    CommandManager.RequerySuggested += value;

                CommandManagerHelper.AddWeakReferenceHandler(ref canExecuteChangedHandlers, value, 2);
            }
            remove {
                if (!isAutomaticRequeryDisabled)
                    CommandManager.RequerySuggested -= value;

                CommandManagerHelper.RemoveWeakReferenceHandler(canExecuteChangedHandlers, value);
            }
        }

        bool ICommand.CanExecute(object parameter) {
            return parameter == null && typeof (T).IsValueType 
                ? canExecuteMethod == null 
                : CanExecute((T) parameter);
        }

        void ICommand.Execute(object parameter) {
            Execute((T) parameter);
        }

        #endregion

        #region Public Methods

        public bool CanExecute(T parameter) {
            return canExecuteMethod == null || canExecuteMethod(parameter);
        }

        public void Execute(T parameter) {
            if (executeMethod != null)
                executeMethod(parameter);
        }

        public void RaiseCanExecuteChanged() {
            OnCanExecuteChanged();
        }

        #endregion

        #region Protected And Private Methods

        protected virtual void OnCanExecuteChanged() {
            CommandManagerHelper.CallWeakReferenceHandlers(canExecuteChangedHandlers);
        }

        #endregion
    }
}