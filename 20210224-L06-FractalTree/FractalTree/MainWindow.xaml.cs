using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace FractalTree
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private double CanvasWidth;
        private double CanvasHeight;

        public MainWindow()
        {
            InitializeComponent();
            CanvasWidth = cTree.Width;
            CanvasHeight = cTree.Height;

            DrawTree();
        }
        
        private void DrawLine(Point p1, Point p2)
        {
            Line line = new Line();
            line.X1 = p1.X;
            line.X2 = p2.X;
            line.Y1 = p1.Y;
            line.Y2 = p2.Y;
            line.Stroke = Brushes.HotPink;
            line.StrokeThickness = 1;
            cTree.Children.Add(line);
        }

        private void DrawTree() => DrawTree(new Point(800 / 2, 400-5), -90, 10);

        private void DrawTree(Point p, double angle, int depth)
        {
            if (depth == 0) return;

            Point pEnd = p.EndPoint(angle.ToRadian(), depth * 10.0);
            DrawLine(p, pEnd);

            DrawTree(pEnd, angle - 20, depth-1);
            DrawTree(pEnd, angle + 20, depth-1);
        }

    }

    public static class Extensions
    {
        public static Point EndPoint(this Point point, double radians, double distance) {
            return new Point(
                point.X + Math.Cos(radians) * distance,
                point.Y + Math.Sin(radians) * distance);
        }
        public static double ToRadian(this double angle) => (Math.PI / 180) * angle;
    }
}
