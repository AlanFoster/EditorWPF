using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using EditorWPF.Annotations;

namespace EditorWPF.Models
{
    /// <summary>
    /// Represents a container which has an object which can be mutated.
    /// When mutated the appropiate PropertyChanged events will fire as expected.
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public class ObservableWrapper<T> : INotifyPropertyChanged
    {
        private T _value;

        public T Value
        {
            get { return _value; }
            set
            {
                _value = value; 
                PropertyChanged(this, new PropertyChangedEventArgs("Value"));
            }
        }

        public ObservableWrapper(T value)
        {
            _value = value;
        }

        public event PropertyChangedEventHandler PropertyChanged = delegate { };

        [NotifyPropertyChangedInvocator]
        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChangedEventHandler handler = PropertyChanged;
            if (handler != null) handler(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
