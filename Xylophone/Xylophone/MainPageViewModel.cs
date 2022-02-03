using Plugin.SimpleAudioPlayer;
using System;
using System.Collections.Generic;
using System.IO;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;

namespace Xylophone
{
    public class MainPageViewModel : BaseViewModel
    {
        private Random rnd = new Random();
        string _aColor, _bColor, _cColor, _dColor, _eColor, _fColor, _gColor;
        public string AColor { get => _aColor; set => SetProperty(ref _aColor, value); }
        public string BColor { get => _bColor; set => SetProperty(ref _bColor, value); }
        public string CColor { get => _cColor; set => SetProperty(ref _cColor, value); }
        public string DColor { get => _dColor; set => SetProperty(ref _dColor, value); }
        public string EColor { get => _eColor; set => SetProperty(ref _eColor, value); }
        public string FColor { get => _fColor; set => SetProperty(ref _fColor, value); }
        public string GColor { get => _gColor; set => SetProperty(ref _gColor, value); }
        public ICommand OnKeyPress
        {
            get => new Command<string>((keyName) => PlaySound(keyName));
        }
        public ICommand OnSwipe
        {
            get => new Command<string>((direction) => ChangeButtonColor());
        }
        private void ChangeButtonColor()
        {
            Color rCol = Color.FromRgb(rnd.Next(256), rnd.Next(256), rnd.Next(256));
            AColor = rCol.ToHex();

            rCol = Color.FromRgb(rnd.Next(256), rnd.Next(256), rnd.Next(256));
            BColor = rCol.ToHex();

            rCol = Color.FromRgb(rnd.Next(256), rnd.Next(256), rnd.Next(256));
            CColor = rCol.ToHex();

            rCol = Color.FromRgb(rnd.Next(256), rnd.Next(256), rnd.Next(256));
            DColor = rCol.ToHex();

            rCol = Color.FromRgb(rnd.Next(256), rnd.Next(256), rnd.Next(256));
            EColor = rCol.ToHex();

            rCol = Color.FromRgb(rnd.Next(256), rnd.Next(256), rnd.Next(256));
            FColor = rCol.ToHex();

            rCol = Color.FromRgb(rnd.Next(256), rnd.Next(256), rnd.Next(256));
            GColor = rCol.ToHex();

        }
        private void PlaySound(string keyName)
        {
            var assembly = typeof(App).GetTypeInfo().Assembly;
            string path = $"Xylophone.Resources.Audio.{keyName}.wav";
            Stream audioStream = assembly.GetManifestResourceStream(path);
            ISimpleAudioPlayer player = CrossSimpleAudioPlayer.Current;
            player.Load(audioStream);
            player.Play();
            ChangeButtonColor();
        }

        public MainPageViewModel()
        {
            AColor = "DarkSlateBlue";
            BColor = "Purple";
            CColor = "DarkRed";
            DColor = "DarkOrange";
            EColor = "Orange";
            FColor = "Green";
            GColor = "Blue";

        }
    }
}
