using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;

namespace NetSampleArch.Adapters.SQLServer.Models
{
    public abstract class BaseModel
        : INotifyPropertyChanged
    {
         // Attributes
        private readonly List<string> _propertyChangedList;

        // Properties
        public Guid Id { get; set; }
        public DateTime CreatedAt { get; set; }
        public string CreatedBy { get; set; }
        public DateTime? UpdatedAt { get; set; }
        public string UpdatedBy { get; set; }
        public TimeSpan RowVersion { get; set; }

        // Events
        public event PropertyChangedEventHandler PropertyChanged;

        // Constructors
        protected BaseModel()
        {
            _propertyChangedList = new List<string>();

            PropertyChanged += (s, e) =>
            {
                AddPropertyChanged(e.PropertyName);
            };
        }

        // Protected Methods
        protected void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        // Private Methods
        private void AddPropertyChanged(string propertyName)
        {
            if (_propertyChangedList.Contains(propertyName))
                return;

            _propertyChangedList.Add(propertyName);
        }

        // Public Methods
        public IEnumerable<string> GetPropertyChangedCollection()
        {
            return _propertyChangedList.Where(q =>
                !q.Equals(nameof(Id))
            ).AsEnumerable();
        }
    }
}