using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Compiladores20201ProjetoCSharp
{
    public partial class mainLayout : Form
    {
        private const int MIN_HEIGHT = 639;
        private const int MIN_WIDTH = 917;

        public mainLayout()
        {
            InitializeComponent();

            Resize += HandleResize;
        }

        private void HandleResize(object sender, EventArgs e)
        {
            Control control = (Control)sender;

            var size = new Size(control.Size.Width, control.Size.Height);

            if (size.Height < MIN_HEIGHT)
            {
                size.Height = MIN_HEIGHT;
            }
            if (size.Width < MIN_WIDTH)
            {
                size.Width = MIN_WIDTH;
            }

            control.Size = size;
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
