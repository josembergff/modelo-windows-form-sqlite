using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Printing;
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

            try
            {
                PrintDocument printDoc = new PrintDocument();
                printDoc.PrinterSettings.PrinterName = "Bematech 4200";
                printDoc.DocumentName = "Cupom";

                if (!printDoc.PrinterSettings.IsValid)
                {
                    string message = $"Não foi possível localizar a impressora!";
                    string caption = "Falha na impressão!";
                    MessageBoxButtons buttons = MessageBoxButtons.OK;
                    DialogResult result = MessageBox.Show(message, caption, buttons);
                    if (result == DialogResult.OK)
                    {
                        Hide();
                        abrirForm1();
                    }
                }
                else
                {
                    printDoc.PrintPage += new PrintPageEventHandler(PrintPageFicha);
                    printDoc.Print();
                }

                Console.WriteLine("Hello World!");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Erro: {ex.Message}");
            }
        }

        private void Form2_FormClosed(object sender, FormClosedEventArgs e)
        {
            abrirForm1();
        }

        private void abrirForm1()
        {
            var formulario = new Form1(sqLiteContexto);
            formulario.Show();
        }

        private static void PrintPageFicha(object sender, PrintPageEventArgs ev)
        {
            Font titleFont = new System.Drawing.Font("Segoe UI", 17f, FontStyle.Bold);
            Font pdvFont = new System.Drawing.Font("Segoe UI", 7f, FontStyle.Regular);
            Font obsFont = new System.Drawing.Font("Segoe UI", 7f, FontStyle.Regular);

            SizeF size = new SizeF();
            float currentUsedHeight = 0f;

            ev.Graphics.DrawString("PDV : " + "Constante Usuário Berg", pdvFont, Brushes.Black, 15, currentUsedHeight, new StringFormat());
            size = ev.Graphics.MeasureString("PDV : " + "Constante Usuário Berg", pdvFont);
            currentUsedHeight += size.Height;

            ev.Graphics.DrawString("VENDA : Cartão", pdvFont, Brushes.Black, 15, currentUsedHeight, new StringFormat());
            size = ev.Graphics.MeasureString("VENDA", pdvFont);
            currentUsedHeight += size.Height;
        }
    }
}
