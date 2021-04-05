using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;

namespace NetSampleArch.Adapters.SQLServer.Models
{
    public abstract class BaseModel
        : INotifyPropertyChanged
    {
        private readonly List<string> _propertyChangedList;

        public Guid Id { get; set; }
        public DateTime CreatedAt { get; set; }
        public string CreatedBy { get; set; }
        public DateTime? UpdatedAt { get; set; }
        public string UpdatedBy { get; set; }
        public TimeSpan RowVersion { get; set; }

        public event PropertyChangedEventHandler PropertyChanged;

        protected BaseModel()
        {
            _propertyChangedList = new List<string>();

            PropertyChanged += (s, e) =>
            {
                AddPropertyChanged(e.PropertyName);
            };
        }

        protected void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        private void AddPropertyChanged(string propertyName)
        {
            if (_propertyChangedList.Contains(propertyName))
                return;

            _propertyChangedList.Add(propertyName);
        }

        public IEnumerable<string> GetPropertyChangedCollection()
        {
            return _propertyChangedList.Where(q =>
                !q.Equals(nameof(Id))
            ).AsEnumerable();
        }
    }
}