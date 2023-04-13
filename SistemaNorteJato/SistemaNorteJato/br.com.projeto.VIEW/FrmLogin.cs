using MySql.Data.MySqlClient;
using Org.BouncyCastle.Asn1.Esf;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SistemaNorteJato.br.com.projeto.VIEW
{
    public partial class FrmLogin : Form
    {
        //Criação de uma Thread//
        Thread nt;

        public FrmLogin()
        {
            InitializeComponent();
        }


        private void button1_Click(object sender, EventArgs e)
        {
     
            if (txtLogin.Text == "admin" && txtSenha.Text == "admin")
            {
                this.Close();
                nt = new Thread(FrmClientes);
                nt.SetApartmentState(ApartmentState.STA);
                nt.Start();
            }
            else
            {
                MessageBox.Show("Usuário ou senha incorretos!");
            }
     
        }

        //Instanciando o FormClientes para ser inicializada//
        private void FrmClientes()
        {
            Application.Run(new FrmClientes());
        }

    }
}
