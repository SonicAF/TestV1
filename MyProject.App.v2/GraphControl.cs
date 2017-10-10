using System;
using System.Windows;
using System.Windows.Input;
using System.Windows.Media;

namespace MyProject.App.v2
{
    /// <summary>
    /// Каждый контрол в WPF знает как себя нарисовать. В данном случае, чтобы у нас была возможность это делать
    /// плюс у него были все стандартные обработчики мыши и клавиатуры, мы наследуем наш класс от FrameworkElement
    /// Дальше переопределяем метод OnRender и в нем рисуем
    /// </summary>
    class GraphControl : FrameworkElement
    {
        #region События мыши (просто для примера)

        protected override void OnMouseDown(MouseButtonEventArgs e) {
            var mousePos = e.GetPosition(this);
        }

        protected override void OnMouseUp(MouseButtonEventArgs e) {
            var mousePos = e.GetPosition(this);
        }

        protected override void OnMouseMove(MouseEventArgs e) {
            var mousePos = e.GetPosition(this);
        }

        protected override void OnMouseWheel(MouseWheelEventArgs e) {
            var delta = e.Delta;
        }

        #endregion

        protected override void OnRender(DrawingContext context) {
            context.DrawRectangle(Brushes.White, new Pen(Brushes.Black, 1) {DashStyle = DashStyles.Dash}, new Rect(new Size(ActualWidth, ActualHeight))); // рисуем фон

            //Рисовать нужно здесь, а пока тут просто случайным образом нарисуем различные фигуры для примера
            var random = new Random();

            var blackPen = new Pen(Brushes.Black, 1);

            for (var i = 0; i < 100; i++) {
                var figureIndex = random.Next(1, 4);

                switch (figureIndex) {
                    case 1:
                        context.DrawRectangle(Brushes.Green, blackPen, new Rect(random.Next(0, (int) ActualWidth), random.Next(0, (int) ActualHeight), random.Next(50, 150), random.Next(50, 150)));
                        break;
                    case 2: 
                        context.DrawEllipse(Brushes.Red, blackPen, new Point(random.Next(0, (int)ActualWidth), random.Next(0, (int)ActualHeight)), random.Next(5, 20), random.Next(5, 20));
                        break;
                    case 3:
                        context.DrawLine(blackPen, new Point(random.Next(0, (int)ActualWidth), random.Next(0, (int)ActualHeight)), new Point(random.Next(0, (int)ActualWidth), random.Next(0, (int)ActualHeight)));
                        break;

                }
            }
        }
    }
}
