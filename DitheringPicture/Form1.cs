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

        public class FloydSteinbergDithering
        {
            public static Bitmap ApplyDithering(Bitmap originalImage, int strength, Color[] palette)
            {
                Bitmap ditheredImage = new Bitmap(originalImage.Width, originalImage.Height);
                for (int y =  0; y < originalImage.Height; y++)
                {
                    for (int x = 0; x < originalImage.Width; x++)
                    {
                        Color oldColor = originalImage.GetPixel(x, y);
                        Color newColor = CalculateClosestColor(oldColor, palette);

                        ditheredImage.SetPixel(x, y, newColor);

                        //Вычисление ошибок дизеринга
                        int errorR = oldColor.R - newColor.R;
                        int errorG = oldColor.G - newColor.G;
                        int errorB = oldColor.B - newColor.B;

                        SpreadError(originalImage, x, y, errorR, errorG, errorB, strength);   
                    }
                }

                return ditheredImage;
            }

            private static double ColorDistance(Color color1, Color color2)
            {
                double rDiff = color1.R - color2.R;
                double gDiff = color1.G - color2.G;
                double bDiff = color1.B - color2.B;

                return Math.Sqrt(rDiff * rDiff + gDiff * gDiff + bDiff * bDiff);
            }

            private static Color CalculateClosestColor(Color color, Color[] palette)
            {
                double minDistance = double.MaxValue;
                Color closestColor = palette[0];

                foreach (Color paletteColor in palette)
                {
                    double distance = ColorDistance(color, paletteColor);
                    if (distance < minDistance)
                    {
                        minDistance = distance;
                        closestColor = paletteColor;
                    }
                }

                return closestColor;
            }

            private static void SpreadError(Bitmap image, int x, int y, int errorR, int errorG, int errorB, int strength)
            {
                double[] coefficients = {7.0 / 16.0, 3.0 / 16.0, 5.0 / 16.0, 1.0 / 16.0 };

                for (int i = 0; i < 4; i++)
                {
                    int nx = x + (i % 2 == 0 ? 1 : -1);
                    int ny = y + (i < 2 ? 1 : -1);

                    // Проверяем, находимся ли мы в пределах изображения
                    if (nx >= 0 && nx < image.Width && ny >= 0 && ny < image.Height)
                    {
                        Color oldColor = image.GetPixel(nx, ny);
                        int newR = (int)(oldColor.R + errorR * coefficients[i] * strength);
                        int newG = (int)(oldColor.G + errorG * coefficients[i] * strength);
                        int newB = (int)(oldColor.B + errorB * coefficients[i] * strength);

                        // Ограничиваем значения в диапазоне 0-255
                        newR = Math.Max(0, Math.Min(255, newR));
                        newG = Math.Max(0, Math.Min(255, newG));
                        newB = Math.Max(0, Math.Min(255, newB));

                        Color newColor = Color.FromArgb(newR, newG, newB);
                        image.SetPixel(nx, ny, newColor);
                    }
                }
            }
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
            ExportPictureBox.Image = null;
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

        private void ExportPictureBut_Click(object sender, EventArgs e)
        {
            // Проверяем, загружено ли изображение в PictureBox
            if (ExportPictureBox.Image == null)
            {
                MessageBox.Show("Изображение не загружено. Невозможно сохранить.", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            SaveFileDialog saveFileDialog = new SaveFileDialog();
            saveFileDialog.Filter = "JPEG (*.jpg)|*.jpg|PNG (*.png)|*.png|Все файлы (*.*)|*.*";
            saveFileDialog.Title = "Выберите место сохранения изображения";
            if (saveFileDialog.ShowDialog() == DialogResult.OK)
            {
                string filePath = saveFileDialog.FileName;

                Image image = ExportPictureBox.Image;
                
                image.Save(filePath);
                
                image.Dispose();
            }
        }

        private Color[] palette = new Color[]
        {
            Color.FromArgb(255, 252, 254),
            Color.FromArgb(255, 194, 0),
            Color.FromArgb(255, 42, 0),
            Color.FromArgb(255, 17, 7, 10)
        };

        private void DitheringBut_Click(object sender, EventArgs e)
        {
            if (InputPictureBox.Image == null)
            {
                MessageBox.Show("Изображение не загружено. Нажмите 'Загрузить'. ", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            ExportPictureBox.Image = null; //чистим картинку
            Image inputImage = new Bitmap(InputPictureBox.Image);

            // Применяем дизеринг к изображению
            int strength = LevelDitheringBar.Value; // Сила дизеринга
            Bitmap ditheredImage = FloydSteinbergDithering.ApplyDithering((Bitmap)inputImage, strength, palette);

            // Отображаем обработанное изображение 
            ExportPictureBox.Image = ditheredImage;
        }

        private void deleteBut_Click(object sender, EventArgs e)
        {
            ExportPictureBox.Image = null;
        }
    }
}
