using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace _4_лаба
{
    public partial class Form1 : Form
    {
        List<gadget> gadgetlist = new List<gadget>();//список, который будет заполняться
        public Form1()
        {
            InitializeComponent();
            ShowInfo();
        }

        private void Button1_Click(object sender, EventArgs e)//кнопка "перезапонить"
        {
            this.gadgetlist.Clear();
            var rnd = new Random();
            for (var i = 0; i < 10; i++)
            {
                switch (rnd.Next() % 3)//заполнение автомата
                {
                    case 0:
                        this.gadgetlist.Add(laptop.Generate());
                        break;
                    case 1:
                        this.gadgetlist.Add(tablet.Generate());
                        break;
                    case 2:
                        this.gadgetlist.Add(smartphone.Generate()) ;
                        break;
                }
            }
            ShowInfo();
            Gadgetlist();
        }

        private void Gadgetlist()//выводится список всех гаджетов в отдельный ричтекстбокс
        {
            richTextBox3.Text = "";
            for (var i = 0; i < this.gadgetlist.Count; ++i)
            {
                var space = this.gadgetlist[i];
                if (space is laptop)
                {
                    richTextBox3.Text = richTextBox3.Text + ("\n Ноутбук");
                }
                if (space is tablet)
                {
                    richTextBox3.Text = richTextBox3.Text + ("\n Планшет");
                }
                if (space is smartphone)
                {
                    richTextBox3.Text = richTextBox3.Text + ("\n Смартфон"); ;
                }
            }
        }

        private void ShowInfo()//обновление информации о содержимом автомата
        {
            int laptopCount = 0;
            int tabletCount = 0;
            int smartphoneCount = 0;
            foreach (var gadget in this.gadgetlist)
            {
                if (gadget is laptop)//если гаджет это ноутбук, то +1
                {
                    laptopCount += 1;
                }
                else if (gadget is tablet)//если гаджет это планшет, то +1
                {
                    tabletCount += 1;
                }
                else if (gadget is smartphone)//если гаджет это сматрфон, то +1
                {
                    smartphoneCount += 1;
                }
            }
            richTextBox1.Text = "Ноутбук\tПланшет\tСмартфон";
            richTextBox1.Text += "\n";
            richTextBox1.Text += String.Format("{0}\t{1}\t{2}", laptopCount, tabletCount, smartphoneCount);
        }

        private void Button2_Click(object sender, EventArgs e)//кнопка "взять"
        {
            if (this.gadgetlist.Count == 0)
            {
                pictureBox1.Visible = false;
                pictureBox2.Visible = false;
                pictureBox3.Visible = false;
                richTextBox2.Text = "Я опустел... (ಥ﹏ಥ)";
                return;
            }
            var gadget = this.gadgetlist[0];//выводит первый элемент из списка
            this.gadgetlist.RemoveAt(0);//удаляет первый элемент из списка
            if (gadget is laptop)//вывод нужной картинки
            {
                pictureBox1.Visible = true;
                pictureBox2.Visible = false;
                pictureBox3.Visible = false;
            }
            else if (gadget is tablet)
            {
                pictureBox1.Visible = false;
                pictureBox2.Visible = true;
                pictureBox3.Visible = false;
            }
            else if (gadget is smartphone)
            {
                pictureBox1.Visible = false;
                pictureBox2.Visible = false;
                pictureBox3.Visible = true;
            }

            richTextBox2.Text = gadget.GetInfo();
            ShowInfo();
            Gadgetlist();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            pictureBox1.Visible = false;
            pictureBox2.Visible = false;
            pictureBox3.Visible = false;
        }
    }
}
