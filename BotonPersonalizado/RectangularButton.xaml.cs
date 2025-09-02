using Microsoft.Maui.Controls;
using System;
using Microsoft.Maui.Graphics;

namespace BotonPersonalizado
{
    public partial class RectangularButton : ContentView
    {
        public event EventHandler? Clicked;

        public static readonly BindableProperty TextProperty =
            BindableProperty.Create(nameof(Text), typeof(string), typeof(RectangularButton), "Rectangular");
        public static readonly BindableProperty BackgroundColorProperty =
            BindableProperty.Create(nameof(BackgroundColor), typeof(Color), typeof(RectangularButton), Colors.Blue);
        public static readonly BindableProperty TextColorProperty =
            BindableProperty.Create(nameof(TextColor), typeof(Color), typeof(RectangularButton), Colors.White);

        public string Text
        {
            get => (string)GetValue(TextProperty);
            set => SetValue(TextProperty, value);
        }

        public new Color BackgroundColor
        {
            get => (Color)GetValue(BackgroundColorProperty);
            set => SetValue(BackgroundColorProperty, value);
        }

        public Color TextColor
        {
            get => (Color)GetValue(TextColorProperty);
            set => SetValue(TextColorProperty, value);
        }

        public RectangularButton()
        {
            InitializeComponent();
            BindingContext = this;
        }

        private void OnButtonClicked(object sender, EventArgs e)
        {
            Clicked?.Invoke(this, EventArgs.Empty);
        }
    }
}
