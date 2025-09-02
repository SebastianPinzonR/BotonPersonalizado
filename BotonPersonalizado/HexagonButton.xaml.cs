using Microsoft.Maui.Controls;
using Microsoft.Maui.Graphics;
using System;

namespace BotonPersonalizado
{
    public partial class HexagonButton : ContentView
    {
        public event EventHandler? Clicked;

        public HexagonButton()
        {
            InitializeComponent();
            HexView.Drawable = new HexagonDrawable();
            var tapGesture = new TapGestureRecognizer();
            tapGesture.Tapped += (s, e) => Clicked?.Invoke(this, EventArgs.Empty);
            HexView.GestureRecognizers.Add(tapGesture);
        }
    }

    public class HexagonDrawable : IDrawable
    {
        public void Draw(ICanvas canvas, RectF dirtyRect)
        {
            float width = dirtyRect.Width;
            float height = dirtyRect.Height;
            float size = Math.Min(width, height);
            float centerX = width / 2;
            float centerY = height / 2;
            float radius = size / 2 - 4;

            var points = new PointF[6];
            for (int i = 0; i < 6; i++)
            {
                double angle = Math.PI / 3 * i - Math.PI / 6;
                points[i] = new PointF(
                    centerX + (float)(radius * Math.Cos(angle)),
                    centerY + (float)(radius * Math.Sin(angle))
                );
            }

            var path = new PathF();
            path.MoveTo(points[0].X, points[0].Y);
            for (int i = 1; i < 6; i++)
            {
                path.LineTo(points[i].X, points[i].Y);
            }
            path.Close();

            canvas.FillColor = Colors.Orange;
            canvas.FillPath(path);
            canvas.StrokeColor = Colors.Black;
            canvas.StrokeSize = 2;
            canvas.DrawPath(path);
        }
    }
}
