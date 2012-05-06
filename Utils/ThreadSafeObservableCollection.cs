using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Threading;
using System.Windows.Threading;

namespace Utils
{
    public class ThreadSafeObservableCollection<T> : ObservableCollection<T>
    {
        #region Fields

        private readonly Dispatcher dispatcher;
        private readonly ReaderWriterLock readerWriterLock;

        #endregion

        #region Constructors and Destructor

        public ThreadSafeObservableCollection() {
            dispatcher = Dispatcher.CurrentDispatcher;
            readerWriterLock = new ReaderWriterLock();
        }

        #endregion

        #region Protected And Private Methods

        protected override void ClearItems() {
            if (dispatcher.CheckAccess()) {
                var c = readerWriterLock.UpgradeToWriterLock(-1);
                base.ClearItems();
                readerWriterLock.DowngradeFromWriterLock(ref c);
            }
            else {
                dispatcher.Invoke(DispatcherPriority.DataBind, (SendOrPostCallback) delegate { Clear(); });
            }
        }

        protected override void InsertItem(int index, T item) {
            if (dispatcher.CheckAccess()) {
                if (index > Count)
                    return;
                var c = readerWriterLock.UpgradeToWriterLock(-1);
                base.InsertItem(index, item);
                readerWriterLock.DowngradeFromWriterLock(ref c);
            }
            else {
                var e = new object[] {index, item};
                dispatcher.Invoke(DispatcherPriority.DataBind, (SendOrPostCallback) delegate { InsertItemImpl(e); }, e);
            }
        }

        private void InsertItemImpl(IList<object> e) {
            if (dispatcher.CheckAccess()) {
                InsertItem((int) e[0], (T) e[1]);
            }
            else {
                dispatcher.Invoke(DispatcherPriority.DataBind, (SendOrPostCallback) delegate { InsertItemImpl(e); });
            }
        }

        protected override void MoveItem(int oldIndex, int newIndex) {
            if (dispatcher.CheckAccess()) {
                if (oldIndex >= Count | newIndex >= Count | oldIndex == newIndex)
                    return;
                var c = readerWriterLock.UpgradeToWriterLock(-1);
                base.MoveItem(oldIndex, newIndex);
                readerWriterLock.DowngradeFromWriterLock(ref c);
            }
            else {
                var e = new object[] {oldIndex, newIndex};
                dispatcher.Invoke(DispatcherPriority.DataBind, (SendOrPostCallback) delegate { MoveItemImpl(e); }, e);
            }
        }

        private void MoveItemImpl(object[] e) {
            if (dispatcher.CheckAccess()) {
                MoveItem((int) e[0], (int) e[1]);
            }
            else {
                dispatcher.Invoke(DispatcherPriority.DataBind, (SendOrPostCallback) delegate { MoveItemImpl(e); });
            }
        }

        protected override void RemoveItem(int index) {
            if (dispatcher.CheckAccess()) {
                if (index >= Count)
                    return;
                var c = readerWriterLock.UpgradeToWriterLock(-1);
                base.RemoveItem(index);
                readerWriterLock.DowngradeFromWriterLock(ref c);
            }
            else {
                dispatcher.Invoke(DispatcherPriority.DataBind, (SendOrPostCallback) delegate { RemoveItem(index); }, index);
            }
        }

        protected override void SetItem(int index, T item) {
            if (dispatcher.CheckAccess()) {
                var c = readerWriterLock.UpgradeToWriterLock(-1);
                base.SetItem(index, item);
                readerWriterLock.DowngradeFromWriterLock(ref c);
            }
            else {
                var e = new object[] {index, item};
                dispatcher.Invoke(DispatcherPriority.DataBind, (SendOrPostCallback) delegate { SetItemImpl(e); }, e);
            }
        }

        private void SetItemImpl(IList<object> e) {
            if (dispatcher.CheckAccess()) {
                SetItem((int) e[0], (T) e[1]);
            }
            else {
                dispatcher.Invoke(DispatcherPriority.DataBind, (SendOrPostCallback) delegate { SetItemImpl(e); });
            }
        }

        #endregion
    }
}