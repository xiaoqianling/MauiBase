using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Globalization;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace MauiBase.ViewModels
{
    partial class ColorSelectViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
        private float _hue, _saturation, _luminosity;
        private Color _HSLColor;
        public string HSLColorHex { set; get; }
        public float Hue
        {
            get => _hue;
            set
            {
                if(_hue != value)
                {
                    HSLColor = Color.FromHsla(value, _saturation, _luminosity);
                }
            }
        }
        public float Saturation
        {
            get => _saturation; 
            set
            {
                if (_saturation != value)
                {
                    HSLColor = Color.FromHsla(_hue, value, _luminosity);
                }
            }
        }
        public float Luminosity
        {
            get => _luminosity;
            set
            {
                if (_luminosity != value)
                {
                    //_luminosity = value;
                    HSLColor = Color.FromHsla(_hue, _saturation, value);
                }
            }
        }
        public Color HSLColor
        {
            get => _HSLColor;
            set
            {
                if(_HSLColor != value)
                {
                    _HSLColor = value;
                    _hue = _HSLColor.GetHue();
                    _saturation = _HSLColor.GetSaturation();
                    _luminosity = _HSLColor.GetLuminosity();

                    HSLColorHex = _HSLColor.ToHex();

                    OnPropertyChanged("Hue");
                    OnPropertyChanged("Saturation");
                    OnPropertyChanged("Luminosity");
                    OnPropertyChanged("HSLColorHex");
                    OnPropertyChanged();

                }
            }
        }

        private float _red, _green, _blue;
        private Color _RGBColor;
        public string _RGBColorHex;
        public string RGBColorHex
        {
            get => _RGBColorHex;
            set
            {
                _RGBColorHex = value;
            }
        }
        public float Red
        {
            get => _red;
            set
            {
                if (_red != value)
                {
                    RGBColor = Color.FromRgb(value, _green, _blue);
                }
            }
        }
        public float Green
        {
            get => _green;
            set
            {
                if (_green != value)
                {
                    RGBColor = Color.FromRgb(_red, value, _blue);
                }
            }
        }
        public float Blue
        {
            get => _blue;
            set
            {
                if (_blue != value)
                {
                    RGBColor = Color.FromRgb(_red, _green, value);
                }
            }
        }
        public Color RGBColor
        {
            get => _RGBColor;
            set
            {
                _RGBColor = value;
                _red = _RGBColor.Red;
                _green = _RGBColor.Green;
                _blue = _RGBColor.Blue;

                RGBColorHex = _RGBColor.ToHex();

                OnPropertyChanged("Red");
                OnPropertyChanged("Green");
                OnPropertyChanged("Blue");
                OnPropertyChanged("RGBColorHex");
                OnPropertyChanged();
            }
        }


        private void OnPropertyChanged([CallerMemberName] string name="")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
        }
    }

   
}
