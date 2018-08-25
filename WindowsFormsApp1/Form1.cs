using System;
using System.Drawing;
using System.Threading;
using System.Windows.Forms;

namespace WindowsFormsApp1
{
    public partial class Form1 : Form
    {
        static string path = "";
        private void Form1_Load(object sender, EventArgs e)
        {
            path = @"C:\Users\" + Environment.UserName.ToString() + @"\Downloads\printscreen.jpg";
            Bitmap printscreen = new Bitmap(Screen.PrimaryScreen.Bounds.Width, Screen.PrimaryScreen.Bounds.Height);

            Graphics graphics = Graphics.FromImage(printscreen as Image);

            graphics.CopyFromScreen(0, 0, 0, 0, printscreen.Size);

            printscreen.Save(path, System.Drawing.Imaging.ImageFormat.Jpeg);
            Close();

            this.BackgroundImage = Image.FromFile(path);

        }

        public Form1()
        {
            InitializeComponent();
            //this.FormBorderStyle = FormBorderStyle.FixedToolWindow;
            this.FormBorderStyle = FormBorderStyle.None;
            //this.FormBorderStyle = FormBorderStyle.Sizable;
            this.MaximumSize = this.MinimumSize = this.Size = SystemInformation.PrimaryMonitorSize;
            this.ShowInTaskbar = false;
            this.Name = "Microsoft Visual Studio 2017";
            this.StartPosition = FormStartPosition.CenterScreen;
            //this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            Thread.CurrentThread.Name = "Microsoft Visual Studio 2017";
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            e.Cancel = true;
            //File.Delete(path);
        }

        private void Form1_Paint(object sender, PaintEventArgs e)
        {
            Graphics gr = e.Graphics;
            int s = 0;
            for (; ; )
            {
                s++;
                if (s == 782)
                {
                    p(gr, new Random().Next(0, SystemInformation.PrimaryMonitorSize.Width));
                    s = 0;
                }
            }

        }

        private void p(Graphics gr, int start_fpos_x)
        {
            Pen p = new Pen(Color.Blue, 1);// цвет линии и ширина

            Point p1 = new Point(0, start_fpos_x);// первая точка
            Point p2 = new Point(SystemInformation.PrimaryMonitorSize.Width, start_fpos_x);// вторая точка
            gr.DrawLine(p, p1, p2);// рисуем линию
                                   //  gr.Dispose();// освобождаем все ресурсы, связанные с отрисовкой
        }

        private void Form1_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = true;
        }

        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyData == (Keys.Alt | Keys.Tab))
            {
                e.SuppressKeyPress = true;
                e.Handled = true;
            //    MessageBox.Show("Test");
            }
        }
    }



}
