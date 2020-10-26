using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using WindowsFormsApp1.Models;

namespace WindowsFormsApp1
{
    public partial class Form2 : Form
    {
        private readonly SqLiteContexto sqLiteContexto;

        public Form2(SqLiteContexto sqLiteContexto)
        {
            InitializeComponent();
            this.sqLiteContexto = sqLiteContexto;
        }

        private void Form2_FormClosed(object sender, FormClosedEventArgs e)
        {
            var formulario = new Form1(sqLiteContexto);
            formulario.Show();
        }
    }
}
