using System.ComponentModel;
using System.Threading.Tasks;

namespace Adult.App.Models
{
    public class SwipeFeedModel : INotifyPropertyChanged
    {
        private string _photoUrl;
        private const string DefaultPhotoUrl = "https://loremflickr.com/500/800/woman,man/all";
        private const string AlternativePhotoUrl = "https://loremflickr.com/500/900/woman,man/all";
        public string PhotoUrl 
        { 
            get => _photoUrl;
            set
            {
                if (_photoUrl == value)
                {
                    return;
                }
                _photoUrl = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(PhotoUrl)));
            }
        }

        public SwipeFeedModel()
        {
            PhotoUrl = DefaultPhotoUrl;
        }

        public async Task PutMark(bool mark)
        {
            if (PhotoUrl == DefaultPhotoUrl)
            {
                PhotoUrl = AlternativePhotoUrl;
            }
            else
            {
                PhotoUrl = DefaultPhotoUrl;

            }
        }

        public event PropertyChangedEventHandler PropertyChanged;
    }
}
