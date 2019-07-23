using Common.Media.Core;
using Common.Media.FFmpeg;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MediaSample
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Button1_Click(object sender, EventArgs e)
        {
            FmPlayer fmPlayer = new FmPlayer();
            fmPlayer.ShowDialog();
        }

        private void Button2_Click(object sender, EventArgs e)
        {
            FmWritter fmWritter = new FmWritter();
            fmWritter.ShowDialog();
        }
    }
}
