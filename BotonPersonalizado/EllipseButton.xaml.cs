using Microsoft.Maui.Controls;
using Microsoft.Maui.Graphics;
using System;

namespace BotonPersonalizado
{
    public partial class EllipseButton : ContentView
    {
        public event EventHandler? Clicked;

        public EllipseButton()
        {
            InitializeComponent();
            EllipseView.Drawable = new EllipseDrawable();
            var tapGesture = new TapGestureRecognizer();
            tapGesture.Tapped += (s, e) => Clicked?.Invoke(this, EventArgs.Empty);
            EllipseView.GestureRecognizers.Add(tapGesture);
        }
    }

    public class EllipseDrawable : IDrawable
    {
        public void Draw(ICanvas canvas, RectF dirtyRect)
        {
            float width = dirtyRect.Width;
            float height = dirtyRect.Height;
            float stroke = 2;
            float margin = stroke + 2;

            var rect = new RectF(margin, margin, width - 2 * margin, height - 2 * margin);
            canvas.FillColor = Colors.MediumPurple;
            canvas.FillEllipse(rect);
            canvas.StrokeColor = Colors.Black;
            canvas.StrokeSize = stroke;
            canvas.DrawEllipse(rect);
        }
    }
}
