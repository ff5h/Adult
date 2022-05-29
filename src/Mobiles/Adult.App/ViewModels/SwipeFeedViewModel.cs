using Adult.App.Models;
using System;
using System.ComponentModel;
using System.Windows.Input;
using Xamarin.Essentials;
using Xamarin.Forms;

namespace Adult.App.ViewModels
{
    public class SwipeFeedViewModel : INotifyPropertyChanged
    {
        private SwipeFeedModel _model;
        public string PhotoUrl { get => _model.PhotoUrl; }
        public ICommand PutMark { get; }

        public SwipeFeedViewModel()
        {
            _model = new SwipeFeedModel();
            _model.PropertyChanged += _model_PropertyChanged;
            PutMark = new Command<bool>(async (bool mark) => await _model.PutMark(mark));
        }

        private void _model_PropertyChanged(object sender, PropertyChangedEventArgs e)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(e.PropertyName));
        }

        public event PropertyChangedEventHandler PropertyChanged;

    }
}