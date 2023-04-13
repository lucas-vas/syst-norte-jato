using Microsoft.Office.Interop.Excel;
using SistemaNorteJato.br.com.projeto.DAO;
using SistemaNorteJato.br.com.projeto.MODEL;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Net.WebRequestMethods;
using Application = Microsoft.Office.Interop.Excel.Application;

namespace SistemaNorteJato.br.com.projeto.VIEW
{
    public partial class FrmClientes : Form
    {
        public FrmClientes()
        {
            InitializeComponent();
        }

        private void btnSalvar_Click(object sender, EventArgs e)
        {
            try
            {
                //1º passo - Receber os dados de um objeto model//
                Cliente obj = new Cliente();
                obj.nome = txtNome.Text;
                obj.rg = txtRg.Text;
                obj.cpf = txtCpf.Text;
                obj.email = txtEmail.Text;
                obj.telefone = txtTelefone.Text;
                obj.celular = txtCelular.Text;
                obj.cep = txtCep.Text;
                obj.endereco = txtEndereco.Text;
                obj.numero = int.Parse(txtNumero.Text);
                obj.complemento = txtComplemento.Text;
                obj.bairro = txtBairro.Text;
                obj.cidade = txtCidade.Text;
                obj.estado = cbUf.Text;

                //2 passo - Criar um objeto da classe ClienteDAO e chamar o metodo CadastrarCliente//
                ClienteDAO dao = new ClienteDAO();
                dao.CadastrarCliente(obj);

                //3 passo - Recarregar a tabela de clientes//
                tabelaClientes.DataSource = dao.ListarClientes();

                //Limpar campos//
                new Helpers().LimparTela(this);

            }
            catch (Exception)
            {
                MessageBox.Show("ERRO! Preencha os campos para cadastrar o Cliente!");
            }
            

        }

        private void FrmClientes_Load(object sender, EventArgs e)
        {
            ClienteDAO dao = new ClienteDAO();
            tabelaClientes.DataSource = dao.ListarClientes();
        }

        private void tabelaClientes_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            //1 passo - Pegar os dados da linha selecionada//
            txtCodigo.Text = tabelaClientes.CurrentRow.Cells[0].Value.ToString();
            txtNome.Text = tabelaClientes.CurrentRow.Cells[1].Value.ToString();
            txtRg.Text = tabelaClientes.CurrentRow.Cells[2].Value.ToString();
            txtCpf.Text = tabelaClientes.CurrentRow.Cells[3].Value.ToString();
            txtEmail.Text = tabelaClientes.CurrentRow.Cells[4].Value.ToString();
            txtTelefone.Text = tabelaClientes.CurrentRow.Cells[5].Value.ToString();
            txtCelular.Text = tabelaClientes.CurrentRow.Cells[6].Value.ToString();
            txtCep.Text = tabelaClientes.CurrentRow.Cells[7].Value.ToString();
            txtEndereco.Text = tabelaClientes.CurrentRow.Cells[8].Value.ToString();
            txtNumero.Text = tabelaClientes.CurrentRow.Cells[9].Value.ToString();
            txtComplemento.Text = tabelaClientes.CurrentRow.Cells[10].Value.ToString();
            txtBairro.Text = tabelaClientes.CurrentRow.Cells[11].Value.ToString();
            txtCidade.Text = tabelaClientes.CurrentRow.Cells[12].Value.ToString();
            cbUf.Text = tabelaClientes.CurrentRow.Cells[13].Value.ToString();

            //2 passo - Retornar com os dados para a pagina de alteração//
            tabClientes.SelectedTab = tabPage1;

            if (tabClientes.SelectedTab == tabPage1)
            {
                tabClientes.TabPages.Remove(tabPage2);  
                btnSalvar.Enabled = false;
            }
            
            
        }

        private void btnExcluir_Click(object sender, EventArgs e)
        {

            try
            {
                //Botão excluir
                Cliente obj = new Cliente();
                obj.codigo = int.Parse(txtCodigo.Text);

                ClienteDAO dao = new ClienteDAO();
                dao.ExcluirCliente(obj);

                //Recarregar a tabela de clientes
                tabelaClientes.DataSource = dao.ListarClientes();

                //Limpar os campos//
                new Helpers().LimparTela(this);

                btnSalvar.Enabled = true;
                tabClientes.TabPages.Add(tabPage2);
                tabClientes.SelectedTab = tabPage2;

            }
            catch (Exception)
            {
                MessageBox.Show("ERRO! Cliente não cadastrado para ser realizado a exclusão");
            }
        

        }

        private void btnEditar_Click(object sender, EventArgs e)
        {
            //1º passo - Receber os dados de um objeto model//
            try
            {
                Cliente obj = new Cliente();
                obj.codigo = int.Parse(txtCodigo.Text);
                obj.nome = txtNome.Text;
                obj.rg = txtRg.Text;
                obj.cpf = txtCpf.Text;
                obj.email = txtEmail.Text;
                obj.telefone = txtTelefone.Text;
                obj.celular = txtCelular.Text;
                obj.cep = txtCep.Text;
                obj.endereco = txtEndereco.Text;
                obj.numero = int.Parse(txtNumero.Text);
                obj.complemento = txtComplemento.Text;
                obj.bairro = txtBairro.Text;
                obj.cidade = txtCidade.Text;
                obj.estado = cbUf.Text;

                //2 passo - Criar um objeto da classe ClienteDAO e chamar o metodo AlterarCliente//
                ClienteDAO dao = new ClienteDAO();
                dao.AlterarCliente(obj);

                //3 passo - Recarregar a tabela de clientes//
                tabelaClientes.DataSource = dao.ListarClientes();

                //Limpar campos//
                new Helpers().LimparTela(this);

                btnSalvar.Enabled = true;
                tabClientes.TabPages.Add(tabPage2);
                tabClientes.SelectedTab = tabPage2;
            }
            catch (Exception)
            {
                MessageBox.Show("ERRO! Cliente não cadastrado para realizar a edição");
            }
            
        }

        private void btnPesquisar_Click(object sender, EventArgs e)
        {
            string nome = txtPesquisa.Text;
            ClienteDAO dao = new ClienteDAO();

            tabelaClientes.DataSource = dao.ListarClientePorNome(nome);

            if (tabelaClientes.Rows.Count == 0 || txtPesquisa.Text == string.Empty)
            {
                MessageBox.Show("Cliente não encontrado!");
                txtPesquisa.Text = string.Empty;

                //Recarregar a tabela de clientes//
                tabelaClientes.DataSource = dao.ListarClientes();
            }

        }


        private void txtPesquisa_KeyPress(object sender, KeyPressEventArgs e)
        {
            //Listando clientes por nome//
            string nome = "%" + txtPesquisa.Text + "%";

            ClienteDAO dao = new ClienteDAO();
            tabelaClientes.DataSource = dao.ListarClientePorNome(nome);

        }

        private void btnConsultarCep_Click(object sender, EventArgs e)
        {
            //Botão para consultar por CEP//
            try
            {
                string cep = txtCep.Text;
                string xml = "https://viacep.com.br/ws/" + cep + "/xml/";

                DataSet dados = new DataSet();
                dados.ReadXml(xml);

                txtEndereco.Text = dados.Tables[0].Rows[0]["logradouro"].ToString();
                txtBairro.Text = dados.Tables[0].Rows[0]["bairro"].ToString();
                txtCidade.Text = dados.Tables[0].Rows[0]["localidade"].ToString();
                txtComplemento.Text = dados.Tables[0].Rows[0]["complemento"].ToString();
                cbUf.Text = dados.Tables[0].Rows[0]["uf"].ToString();
            }
            catch (Exception)
            {
                MessageBox.Show("CEP não localizado!");
            }


        }

        private void tabPage2_Enter(object sender, EventArgs e)
        {
            btnSalvar.Enabled = false;
            btnExcluir.Enabled = false;
            btnEditar.Enabled = false;
        }

        private void tabPage1_Enter(object sender, EventArgs e)
        {
            btnSalvar.Enabled = true;
            btnExcluir.Enabled = true;
            btnEditar.Enabled = true;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            //Método para exportar os dados para o EXCEL//

            // Cria uma instância do SaveFileDialog
            SaveFileDialog saveFileDialog = new SaveFileDialog();
            saveFileDialog.Filter = "Arquivo Excel (*.xlsx)|*.xlsx";
            saveFileDialog.Title = "Salvar como...";

            // Abre o diálogo de salvar e verifica se o usuário selecionou um arquivo
            if (saveFileDialog.ShowDialog() == DialogResult.OK)
            {
                // Cria uma instância do aplicativo Excel
                var excelApp = new Application();
                excelApp.Visible = false;

                // Cria uma nova pasta de trabalho do Excel
                var workbook = excelApp.Workbooks.Add(XlWBATemplate.xlWBATWorksheet);

                // Cria uma nova planilha do Excel
                var worksheet = (Worksheet)workbook.Worksheets[1];

                // Preenche a planilha com o conteúdo do DataGridView
                for (int i = 1; i <= tabelaClientes.Columns.Count; i++)
                {
                    worksheet.Cells[1, i] = tabelaClientes.Columns[i - 1].HeaderText;
                }

                for (int i = 0; i < tabelaClientes.Rows.Count; i++)
                {
                    for (int j = 0; j < tabelaClientes.Columns.Count; j++)
                    {
                        worksheet.Cells[i + 2, j + 1] = tabelaClientes.Rows[i].Cells[j].Value.ToString();
                    }
                }

                // Salva o arquivo Excel na pasta selecionada pelo usuário
                workbook.SaveAs(saveFileDialog.FileName);

                // Fecha o aplicativo Excel
                excelApp.Quit();
            }
        }
    }
}
