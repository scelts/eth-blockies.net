using System;
using System.Drawing.Imaging;
using System.Windows.Input;
using System.Windows.Media;
using ETH_Identicons;
using ExampleApp.WPF.Infra;

namespace ExampleApp.WPF
{
    public class MainWindowViewModel : ObservableObject
    {
        private string _address;
        private int _iconSixePx;
        private ImageSource _identiconImage;

        //size 8x8 is the standard one, used in Mist etc...
        private const int DEFAULT_BLOCK_SIZE = 8;

        public string Address
        {
            get => _address;
            set
            {
                if(string.IsNullOrEmpty(value) || value.ToLowerInvariant().StartsWith("0x") == false)
                    throw new Exception("Provide an address starting with 0x");

                SetAndRaisePropertyChangedEvent(nameof(Address), () => _address = value?.Trim());

                GenerateBitmap();
            }
        }

        public int IconSixePx
        {
            get => _iconSixePx;
            set
            {
                if(value <= 0 || value % 8 != 0)
                    throw new Exception("Should be a number as a multiple of 8");

               SetAndRaisePropertyChangedEvent(nameof(IconSixePx), () => _iconSixePx = value);
            }
        }

        public ImageSource IdenticonImage
        {
            get => _identiconImage;
            set => SetAndRaisePropertyChangedEvent(nameof(IdenticonImage), () => _identiconImage = value);
        }
        public string SaveFileName { get; set; }
        

        public ICommand GenerateBitmapCommand => new DelegateCommand(GenerateBitmap);
        public ICommand GenerateIconCommand => new DelegateCommand(GenerateIcon);
        public ICommand SaveBitmapCommand => new DelegateCommand(() => Save(ImageFormat.Bmp));
        public ICommand SaveIconCommand => new DelegateCommand(() => Save(ImageFormat.Icon));
        public ICommand SavePngCommand => new DelegateCommand(() => Save(ImageFormat.Png));



        public MainWindowViewModel()
        {
            // Initial values
            IconSixePx = 64;
            Address = "0x942766be6F3171A4D5c0257a3869233b501175e1";
        }

        private void GenerateBitmap()
        {
            var identicon = new Identicon(Address, DEFAULT_BLOCK_SIZE);
            var identiconBitmap = identicon.GetBitmap(IconSixePx);
            IdenticonImage = ImageHelper.ToImageSource(identiconBitmap);
        }

        private void GenerateIcon()
        {
            var identicon = new Identicon(Address, DEFAULT_BLOCK_SIZE);
            var identiconIcon = identicon.GetIcon(IconSixePx);
            IdenticonImage = ImageHelper.ToImageSource(identiconIcon);
        }

        private void Save(ImageFormat imageFormat)
        {
            if(string.IsNullOrEmpty(SaveFileName))
                return;

            // bitmaps will save into different formats, so using GetBitmap() here for convenience
            var bmp = new Identicon(Address, DEFAULT_BLOCK_SIZE).GetBitmap(IconSixePx);
            bmp.Save(SaveFileName, imageFormat);
        }


    }

}

