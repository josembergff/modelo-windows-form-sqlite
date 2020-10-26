using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using WindowsFormsApp1.Models;

namespace WindowsFormsApp1
{
    public partial class Form1 : Form
    {
        private readonly SqLiteContexto sqLiteContexto;

        public Form1(SqLiteContexto sqLiteContexto)
        {
            InitializeComponent();
            this.sqLiteContexto = sqLiteContexto;
            if (sqLiteContexto.Usuarios.Count() == 0)
            {
                sqLiteContexto.Usuarios.Add(new Usuario() { Id = 1, Email = "josembergff@gmail.com", Senha = "123456", Nome = "Josemberg Ferreira" });
                sqLiteContexto.SaveChanges();
            }
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                var usuario = sqLiteContexto.Usuarios.FirstOrDefault(f => f.Email == textBox1.Text && f.Senha == textBox2.Text);
                if(usuario != null)
                {
                    string message = $"Bem vindo {usuario.Nome} ao sistema!";
                    string caption = "Bem vindo!";
                    MessageBoxButtons buttons = MessageBoxButtons.OK;
                    DialogResult result = MessageBox.Show(message, caption, buttons);
                    if (result == DialogResult.OK)
                    {
                        var formulario = new Form2(sqLiteContexto);
                        formulario.Show();
                        Hide();
                    }
                }
                else
                {
                    string message = "Não foi encontrado o usuario e senha informado!";
                    string caption = "Login inválido";
                    MessageBoxButtons buttons = MessageBoxButtons.OK;
                    DialogResult result = MessageBox.Show(message, caption, buttons);
                    if (result == DialogResult.OK)
                    {
                        textBox1.Text = string.Empty;
                        textBox2.Text = string.Empty;
                        textBox1.Focus();
                    }
                }
            }
            catch (Exception ex)
            {
                Close();
            }
        }

        private void Form1_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }
    }
}
