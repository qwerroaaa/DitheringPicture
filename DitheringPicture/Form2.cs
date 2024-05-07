using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DitheringPicture
{
    public partial class Form2 : Form
    {
        public string SelectedPackage {  get; private set; }
        public Form2()
        {
            InitializeComponent();
        }

        private void btnAnime_Click(object sender, EventArgs e)
        {
            SelectedPackage = "Аниме";
            this.Close();
        }

        private void btnGames_Click(object sender, EventArgs e)
        {
            SelectedPackage = "Игры";
            this.Close();
        }

        private void btnHistory_Click(object sender, EventArgs e)
        {
            SelectedPackage = "Исторические личности";
            this.Close();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            SelectedPackage = "Не выбрано";
            this.Close();
        }
    }
}
