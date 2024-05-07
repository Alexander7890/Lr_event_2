using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace Lr_event_4
{
    public partial class Form1 : Form
    {
        private bool isUpMode = true; // Флаг, указывающий текущий режим движения

        public Form1()
        {
            InitializeComponent();
            // Присваиваем обработчики событий кнопке и другим элементам управления
            button2.Click += Control_Click;
            textBox1.Click += Control_Click;
            label1.Click += Control_Click;
        }

        private void Control_Click(object sender, EventArgs e)
        {
            // Вызываем метод, который двигает элементы вверх или вниз в зависимости от текущего режима
            if (isUpMode)
            {
                MoveControlUp(sender as Control);
            }
            else
            {
                MoveControlDown(sender as Control);
            }
        }

        private void ModeButton_Click(object sender, EventArgs e)
        {
            // Переключаем режим движения при нажатии на кнопку режима
            isUpMode = !isUpMode;
        }

        private void MoveControlUp(Control control)
        {
            // Проверяем, что элемент не первый кнопка и еще не в самом верхнем положении формы
            if (control != button1 && control.Top > 0)
            {
                int newTop = Math.Max(0, control.Top - 10); // Уменьшаем значение Top на 10 пикселей, но не ниже 0
                control.Top = newTop;
            }
        }

        private void MoveControlDown(Control control)
        {
            // Проверяем, что элемент не первый кнопка и еще не в самом нижнем положении формы
            if (control != button1 && control.Top + control.Height < this.ClientSize.Height)
            {
                int newTop = Math.Min(this.ClientSize.Height - control.Height, control.Top + 10); // Увеличиваем значение Top на 10 пикселей, но не выше высоты формы
                control.Top = newTop;
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            // Toggle the movement mode when the first button is clicked
            ModeButton_Click(sender, e);
        }

    }
}
