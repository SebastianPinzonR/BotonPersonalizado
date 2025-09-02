using Microsoft.Maui.Graphics;
using Microsoft.Maui.Controls;

namespace BotonPersonalizado
{
    public partial class MainPage : ContentPage
    {
        int count = 0;
        RectangularButton? rectangularBtn;
        Button? counterBtn;

        public MainPage()
        {
            InitializeComponent();
            rectangularBtn = this.FindByName<RectangularButton>("ReusableRectBtn");
            if (rectangularBtn != null)
                rectangularBtn.Clicked += OnRectangularClicked;
            counterBtn = this.FindByName<Button>("CounterBtn");
            ReusableHexagonBtn.Clicked += OnHexagonClicked;
            ReusableEllipBtn.Clicked += OnEllipseClicked;
        }

        private void OnRectangularClicked(object? sender, EventArgs e)
        {
            count++;
            if (rectangularBtn != null)
            {
                if (count == 1)
                    rectangularBtn.Text = $"Clicked {count} time";
                else
                    rectangularBtn.Text = $"Clicked {count} times";
            }
        }

        private void OnCounterClicked(object? sender, EventArgs e)
        {
            count++;
            if (counterBtn != null)
            {
                if (count == 1)
                    counterBtn.Text = $"Clicked {count} time";
                else
                    counterBtn.Text = $"Clicked {count} times";
                SemanticScreenReader.Announce(counterBtn.Text);
            }
        }

        private void OnHexagonClicked(object? sender, EventArgs e)
        {
            DisplayAlert("Hexágono", "¡Botón hexagonal presionado!", "OK");
        }

        private void OnEllipseClicked(object? sender, EventArgs e)
        {
            DisplayAlert("Ellipse", "¡Botón Ellipse presionado!", "OK");
        }
    }
}
