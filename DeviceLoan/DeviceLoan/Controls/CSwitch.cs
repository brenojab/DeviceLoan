﻿using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;

namespace DeviceLoan.Controls
{
    public class CSwitch : ContentView
    {

        public static readonly BindableProperty CommandProperty =
            BindableProperty.Create("Command", typeof(ICommand), typeof(CSwitch), null);

        public static readonly BindableProperty CommandParameterProperty =
            BindableProperty.Create("CommandParameter", typeof(object), typeof(CSwitch), null);

        public static readonly BindableProperty CheckedProperty =
            BindableProperty.Create("Checked", typeof(bool), typeof(CSwitch), false, BindingMode.TwoWay);

        public static readonly BindableProperty AnimateProperty =
            BindableProperty.Create("Animate", typeof(bool), typeof(CSwitch), false);

        public static readonly BindableProperty EnabledProperty =
            BindableProperty.Create("Enabled", typeof(bool), typeof(CSwitch), false);

        public static readonly BindableProperty CheckedImageProperty =
            BindableProperty.Create("CheckedImage", typeof(ImageSource), typeof(CSwitch), null);

        public static readonly BindableProperty UnCheckedImageProperty =
            BindableProperty.Create("UnCheckedImage", typeof(ImageSource), typeof(CSwitch), null);

        private ICommand _toggleCommand;
        private Image _toggleImage;

        public CSwitch()
        {
            Initialize();
        }

        public ICommand Command
        {
            get { return (ICommand)GetValue(CommandProperty); }
            set { SetValue(CommandProperty, value); }
        }

        public object CommandParameter
        {
            get { return GetValue(CommandParameterProperty); }
            set { SetValue(CommandParameterProperty, value); }
        }

        public bool Checked
        {
            get { return (bool)GetValue(CheckedProperty); }
            set { SetValue(CheckedProperty, value); }
        }

        public bool Enabled
        {
            get { return (bool)GetValue(EnabledProperty); }
            set { SetValue(EnabledProperty, value); }
        }

        public bool Animate
        {
            get { return (bool)GetValue(AnimateProperty); }
            set { SetValue(AnimateProperty, value); }
        }

        public ImageSource CheckedImage
        {
            get { return (ImageSource)GetValue(CheckedImageProperty); }
            set { SetValue(CheckedImageProperty, value); }
        }

        public ImageSource UnCheckedImage
        {
            get { return (ImageSource)GetValue(UnCheckedImageProperty); }
            set { SetValue(UnCheckedImageProperty, value); }
        }

        public ICommand ToogleCommand
        {
            get
            {
                return _toggleCommand ??
                    (_toggleCommand = new Command(() =>
                    
                    {
                        if (!Enabled)
                        {
                            return;
                        }

                        Checked = _toggleImage.Source == UnCheckedImage;

                        if (Animate)
                        {
                            Device.BeginInvokeOnMainThread(() =>
                            {
                                this.ScaleTo(0.8, 50, Easing.Linear);
                                Task.Delay(100);
                                this.ScaleTo(1, 50, Easing.Linear);
                            });
                        }
                        if (Command != null)
                        {
                            Command.Execute(CommandParameter);
                        }
                    }
                    ));
            }
        }

        private void Initialize()
        {
            _toggleImage = new Image();

            Animate = true;
            GestureRecognizers.Add(new TapGestureRecognizer
            {
                Command = ToogleCommand
            });

            _toggleImage.Source = UnCheckedImage;

            var stk = new StackLayout
            {
                HorizontalOptions = LayoutOptions.FillAndExpand,
                VerticalOptions = LayoutOptions.FillAndExpand
            };
            _toggleImage.Aspect = Aspect.Fill;
            _toggleImage.VerticalOptions = LayoutOptions.CenterAndExpand;
            _toggleImage.HorizontalOptions = LayoutOptions.CenterAndExpand;
            stk.Children.Add(_toggleImage);

            Content = stk;
        }

        protected override void OnParentSet()
        {
            base.OnParentSet();
            _toggleImage.Source = UnCheckedImage;
            Content = _toggleImage;
        }

        protected override void OnPropertyChanged(string propertyName = null)
        {
            base.OnPropertyChanged();
            if (propertyName == null) return;
            if (Equals(propertyName, "Checked"))
            {
                _toggleImage.Source = Equals(Checked, true) ? CheckedImage : UnCheckedImage;
            }
        }
    }
}
