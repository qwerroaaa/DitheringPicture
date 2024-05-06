using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DitheringPicture
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            label4.Text = "Сила дизеринга: 1";
            LevelDitheringBar.Scroll += LevelDitheringBar_Scroll;
        }

        private void LevelDitheringBar_Scroll(object sender, EventArgs e)
        {
            label4.Text = String.Format("Сила дизеринга: {0}", LevelDitheringBar.Value);
        }

        private void LoadPictureBut_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "Изображения (*.jpg;*.jpeg;*.png;*.bmp)|*.jpg;*.jpeg;*.png;*.bmp|Все файлы (*.*)|*.*";
            openFileDialog.Title = "Выберите изображение";

            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                //Путь
                string imagePath = openFileDialog.FileName;
                Image img = Image.FromFile(imagePath);

                if (img.Width <= 256 && img.Height <= 256)
                {
                    InputPictureBox.Image = img;
                } else
                {
                    MessageBox.Show("Выбранное изображение должно быть не больше 256x256 пикселей.", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    img.Dispose(); // Освобождаем ресурсы изображения
                }
            }
        }
    }
}
