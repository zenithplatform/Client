using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Shapes;
using Zenith.Client.Shared.Commands;
using Zenith.UI.Tests.Views;

namespace Zenith.UI.Tests.ViewModels
{
    public class WorkspaceViewModel
    {
        Ellipse ellipse = null;
        Canvas canvas = null;
        private RelayCommand<object> _insertCommand;

        public ICommand InsertCommand
        {
            get
            {
                if (_insertCommand == null)
                    _insertCommand = new RelayCommand<object>(OnInsertClick);

                return _insertCommand;
            }
        }

        public void OnInsertClick(object parameters)
        {
            FlowDocument workspace = (FlowDocument)parameters;
            Point mousePos = Mouse.GetPosition(workspace);
            canvas = new Canvas();
            //Remove the previous ellipse from the paint canvas.
            //PaintCanvas.Children.Remove(ellipse);

            //if (--loopCounter == 0)
            //    timer.Stop();

            //Add the ellipse to the canvas
            
            ellipse = CreateAnEllipse(20, 20);
            canvas.Children.Add(ellipse);

            Canvas.SetLeft(ellipse, mousePos.X);
            Canvas.SetTop(ellipse, mousePos.Y);

            workspace.Blocks.Add(new BlockUIContainer(canvas));
        }

        public Ellipse CreateAnEllipse(int height, int width)
        {
            SolidColorBrush fillBrush = new SolidColorBrush() { Color = Colors.Red };
            SolidColorBrush borderBrush = new SolidColorBrush() { Color = Colors.Black };

            return new Ellipse()
            {
                Height = height,
                Width = width,
                StrokeThickness = 1,
                Stroke = borderBrush,
                Fill = fillBrush
            };
        }
    }
}
