using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Windows;
using System.Windows.Input;

namespace Sample.UI.Wpf
{
    public class MainViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        private readonly ImageLogic imageLogic;

        private string searchText = string.Empty;
        private Image selectedImage;

        public MainViewModel()
        {
            this.imageLogic = new ImageLogic(new FileSystemImageManager("Images"));
            this.Images= new ObservableCollection<Image>();

            this.SearchCommand = new DelegateCommand(this.SearchImages);
            this.DeleteCommand = new DelegateCommand(this.DeleteImage);
        }

        public ObservableCollection<Image> Images { get; private set; }
        public ICommand SearchCommand { get; private set; }
        public ICommand DeleteCommand { get; private set; }

        public string SearchText
        {
            get
            {
                return this.searchText;
            }

            set
            {
                this.searchText = value;
                this.PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(this.SearchText)));
            }
        }

        public Image SelectedImage
        {
            get
            {
                return this.selectedImage;
            }

            set
            {
                this.selectedImage = value;
                this.PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(this.SelectedImage)));
            }
        }


        public void SearchImages()
        {
            this.Images = new ObservableCollection<Image>(this.imageLogic.SearchImages(this.SearchText));
            this.PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(this.Images)));
        }

        private void DeleteImage()
        {
            if (MessageBox.Show($"Are you sure you want do delete {this.SelectedImage.Name}?", "Delete image", MessageBoxButton.YesNo, MessageBoxImage.Warning) == MessageBoxResult.Yes)
            {
                this.imageLogic.DeleteImage(this.SelectedImage);
                this.Images.Remove(this.SelectedImage);
            }
        }
    }
}
