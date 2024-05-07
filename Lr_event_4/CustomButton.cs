using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Lr_event_4
{
    public class CustomButton : Button
    {
        // Переопределяем метод OnMouseClick
        protected override void OnMouseClick(MouseEventArgs e)
        {
            // Вызываем базовую реализацию метода
            base.OnMouseClick(e);

            // Получаем координаты клика мыши
            int clickX = e.X;
            int clickY = e.Y;

            // Вычисляем расстояние до места клика
            int dx = clickX - this.Left;
            int dy = clickY - this.Top;

            // Вычисляем шаг перемещения
            int step = 5;

            // Перемещаем кнопку к месту клика мыши с небольшими шагами
            while (this.Left != clickX || this.Top != clickY)
            {
                if (this.Left < clickX)
                    this.Left += Math.Min(step, clickX - this.Left);
                else if (this.Left > clickX)
                    this.Left -= Math.Min(step, this.Left - clickX);

                if (this.Top < clickY)
                    this.Top += Math.Min(step, clickY - this.Top);
                else if (this.Top > clickY)
                    this.Top -= Math.Min(step, this.Top - clickY);

                // Обновляем форму
                Application.DoEvents();
                System.Threading.Thread.Sleep(10); // Для плавности движения
            }
        }
    }
}
