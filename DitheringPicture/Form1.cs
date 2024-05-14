using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Reflection.Emit;
using System.Runtime.InteropServices;
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
            label4.Text = "Сила дизеринга: 200";
            LevelDitheringBar.Scroll += LevelDitheringBar_Scroll;
            exitBut.Click += exitBut_Click;
            ColorComboBox.Items.Add("Monochrome");
            ColorComboBox.Items.Add("Purple Energy");
            ColorComboBox.Items.Add("Neon roses");
            ColorComboBox.Items.Add("Emmanuel Lions");
            ColorComboBox.Items.Add("Light magic");
            ColorComboBox.Items.Add("Solar Eclipse");
            ColorComboBox.SelectedIndex = 5;
        }
        private string[] imageFiles;
        private int currectImageIndex = 0;
        private ImageReader imageReader;
        private Color[] palette;
        private Dictionary<string, ImageReader> imageReaders = new Dictionary<string, ImageReader>();
        private void DisplayCurrentImage()
        {
            if (currectImageIndex >= 0 && currectImageIndex < imageFiles.Length)
            {
                string imagePath = imageFiles[currectImageIndex];

                // Проверяем, есть ли объект ImageReader для данного пути
                if (!imageReaders.ContainsKey(imagePath))
                {
                    // Если нет, создаем новый объект ImageReader
                    ImageReader reader = new ImageReader(imagePath);
                    imageReaders.Add(imagePath, reader);
                }

                // Получаем изображение из объекта ImageReader
                InputPictureBox.Image = imageReaders[imagePath].GetImage();
            }
        }
        private void TakePicPackage(string selectedPackage)
        {
            ExportPictureBox.Image = null;
            string folderPath = "";

            switch (selectedPackage)
            {
                case "Аниме":
                    folderPath = @"D:\Projects\DitheringPicture\DitheringPicture\DitheringPicture\img\packs\anime\";
                    break;
                case "Игры":
                    folderPath = @"D:\Projects\DitheringPicture\DitheringPicture\DitheringPicture\img\packs\games\";
                    break;
                case "Исторические личности":
                    folderPath = @"D:\Projects\DitheringPicture\DitheringPicture\DitheringPicture\img\packs\history\";
                    break;
                case "Не выбрано":
                    InputPictureBox.Image = null;
                    return;
                default:
                    InputPictureBox.Image = null;
                    return;
            }
            NextBut.Enabled = true;
            PreviousBut.Enabled = true;
            imageFiles = Directory.GetFiles(folderPath);
            

            if(imageFiles.Length > 0 )
            {
                currectImageIndex = 0;
                DisplayCurrentImage();
            }
        }

        public class ImageReader
        {
            private string imagePath;
            private Image image;

            public ImageReader(string path)
            {
                imagePath = path;
            }

            public Image GetImage()
            {
                if (image == null)
                {
                    image = Image.FromFile(imagePath);
                }
                return image;
            }

            public void Dispose()
            {
                if (image != null)
                {
                    image.Dispose();
                    image = null;
                }
            }
        }

        public class DitherError
        {
            public int R { set; get; }
            public int G { set; get; }
            public int B { set; get; }
        }

        public class FloydSteinbergDithering
        {
            public static Bitmap ApplyDithering(Bitmap originalImage, int strength, Color[] palette)
            {
                Bitmap ditheredImage = new Bitmap(originalImage.Width, originalImage.Height);
                DitherError[,] errorMatrix = new DitherError[originalImage.Width + 2, originalImage.Height + 1];
                for (int y = 0; y < originalImage.Height + 1; y++)
                {
                    for (int x = 0; x < originalImage.Width + 2; x++)
                    {
                        errorMatrix[x, y] = new DitherError();
                    }
                }

                for (int y = 0; y < originalImage.Height; y++)
                {
                    for (int x = 0; x < originalImage.Width; x++)
                    {
                        Color oldColor = originalImage.GetPixel(x, y);

                        // Вычисление новых значений пикселя
                        int newR = ClipByte(oldColor.R + (errorMatrix[x + 1, y].R * strength / 16) / 255);
                        int newG = ClipByte(oldColor.G + (errorMatrix[x + 1, y].G * strength / 16) / 255);
                        int newB = ClipByte(oldColor.B + (errorMatrix[x + 1, y].B * strength / 16) / 255);

                        Color newColor = CalculateClosestColor(Color.FromArgb(newR, newG, newB), palette);
                        ditheredImage.SetPixel(x, y, newColor);
                        //Вычисление ошибок дизеринга
                        int errorR = oldColor.R - newColor.R;
                        int errorG = oldColor.G - newColor.G;
                        int errorB = oldColor.B - newColor.B;

                        //[                *    7/16    ...]    
                        //[ ... 3/16    5/16    1/16    ...]
                        errorMatrix[x + 2, y].R += errorR * 7;
                        errorMatrix[x + 2, y].G += errorG * 7;
                        errorMatrix[x + 2, y].B += errorB * 7;

                        errorMatrix[x, y + 1].R += errorR * 3;
                        errorMatrix[x, y + 1].G += errorG * 3;
                        errorMatrix[x, y + 1].B += errorB * 3;

                        errorMatrix[x + 1, y + 1].R += errorR * 5;
                        errorMatrix[x + 1, y + 1].G += errorG * 5;
                        errorMatrix[x + 1, y + 1].B += errorB * 5;

                        errorMatrix[x + 2, y + 1].R += errorR * 1;
                        errorMatrix[x + 2, y + 1].G += errorG * 1;
                        errorMatrix[x + 2, y + 1].B += errorB * 1;
                    }
                }
                return ditheredImage;
            }

            private static double ColorDistance(Color color1, Color color2)
            {
                double rDiff = color1.R - color2.R;
                double gDiff = color1.G - color2.G;
                double bDiff = color1.B - color2.B;

                return rDiff * rDiff + gDiff * gDiff + bDiff * bDiff;
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
        }

       private static int ClipByte(int Value)
       {
            if (Value > 255) return 255;
            else if (Value < 0) return 0;
            else return Value;
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

        private Color[] GetSelectedColorPalette(string selectedPalette)
        {
            switch (selectedPalette)
            {
                case "Monochrome":
                    return new Color[]
                    {
                Color.FromArgb(255, 255, 255),
                Color.FromArgb(192, 192, 192),
                Color.FromArgb(128, 128, 128),
                Color.FromArgb(64, 64, 64),
                Color.FromArgb(0, 0, 0)
                    };
                case "Purple Energy":
                    return new Color[]
                    {
                Color.FromArgb(218, 189, 238),
                Color.FromArgb(211, 168, 240),
                Color.FromArgb(198, 148, 232),
                Color.FromArgb(177, 150, 185),
                Color.FromArgb(208, 138, 231)
                    };

                case "Neon roses":
                    return new Color[]
                    {
                Color.FromArgb(154,253,255),
                Color.FromArgb(255,56,205),
                Color.FromArgb(255,124,213),
                Color.FromArgb(255,184,210),
                Color.FromArgb(255,219,223)
                    };
                case "Emmanuel Lions":
                    return new Color[]
                    {
                Color.FromArgb(19,46,82),
                Color.FromArgb(253,185,23),
                Color.FromArgb(152,0,46),
                Color.FromArgb(255,255,255),
                Color.FromArgb(0,0,0)
                    };
                case "Solar Eclipse":
                    return new Color[]
                    {
                Color.FromArgb(252, 254, 254),
                Color.FromArgb(194, 0, 0),
                Color.FromArgb(42, 0, 0),
                Color.FromArgb(17, 7, 10)
                    };
                case "Light magic":
                    return new Color[]
                    {
                Color.FromArgb(216,237,254),
                Color.FromArgb(172,189,203),
                Color.FromArgb(138,163,186),
                Color.FromArgb(249,213,103),
                Color.FromArgb(196,176,116)
                    };
                default:
                    return new Color[0];
            }
        }


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

        private void button1_Click(object sender, EventArgs e)
        {
            Form2 form2 = new Form2();
            form2.Show();
            form2.FormClosed += (s, args) =>
            {
                string selectedPackage = form2.SelectedPackage;
                packName.Text = selectedPackage;

                TakePicPackage(selectedPackage);
            };
        }

        private void PreviousBut_Click(object sender, EventArgs e)
        {
            if (InputPictureBox.Image == null)
            {
                MessageBox.Show("Изображение не загружено. Нажмите 'Загрузить'. ", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            else
            {
                if (packName.Text == "Не выбрано")
                {
                     PreviousBut.Enabled = false;
                } else
                {
                    currectImageIndex--;

                    if (currectImageIndex < 0)
                    {
                        currectImageIndex = imageFiles.Length - 1;
                    }

                    DisplayCurrentImage();
                }
            }
        }

        private void NextBut_Click(object sender, EventArgs e)
        {
            if (InputPictureBox.Image == null)
            {
                MessageBox.Show("Изображение не загружено. Нажмите 'Загрузить'. ", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            } 
            else
            {
                if (packName.Text == "Не выбрано")
                {
                    NextBut.Enabled = false;
                } 
                else
                {
                    NextBut.Enabled = true;
                    currectImageIndex++;

                    if (currectImageIndex >= imageFiles.Length)
                    {
                        currectImageIndex = 0;
                    }

                    DisplayCurrentImage();
                }
                
            }
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            foreach (var reader in imageReaders.Values)
            {
                reader.Dispose();
            }
            imageReaders.Clear();
        }

        private void exitBut_Click(object sender, EventArgs e)
        {
            foreach (var reader in imageReaders.Values)
            {
                reader.Dispose();
            }
            imageReaders.Clear();

            Application.Exit();
        }

        private void ColorComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            ExportPictureBox.Image = null;
            string selectedPalette = ColorComboBox.SelectedItem.ToString();
            palette = GetSelectedColorPalette(selectedPalette);
        }

        private void ColorComboBox_DrawItem(object sender, DrawItemEventArgs e)
        {
            
        } 
    }
}
