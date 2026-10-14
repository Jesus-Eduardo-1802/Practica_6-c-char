using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO.Ports;//libreria para comunicacion cerial

namespace Practica_6_c_char
{
    public partial class Form1 : Form
    {
        public SerialPort ArduinoProt { get; }
        public Form1()
        {
            InitializeComponent();
            //configuracion de comunicacion serial
            ArduinoProt = new System.IO.Ports.SerialPort();
            ArduinoProt.PortName = "COM9";
            ArduinoProt.BaudRate = 9600;
            sArduinoProt.Open();

            //Manejador de eventos 
            this.FormClosing += CerrandoForm1;
            this.btnEncender.Click += btnEncender_Click;
            this.btnApagar.Click += BtnApagar_Click;
        }

        private void CerrandoForm1 (object sender, EventArgs e)
        {
            if (ArduinoProt.IsOpen)
            {
                ArduinoProt.Close();
            }
        }
        private void BtnApagar_Click(object sender, EventArgs e)
        {
            ArduinoProt.Write("a");
        }

        private void btnEncender_Click(object sender, EventArgs e)
        {
            ArduinoProt.Write("b");
        }
    }
}
