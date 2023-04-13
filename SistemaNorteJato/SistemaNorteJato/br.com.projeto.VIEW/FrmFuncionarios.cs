using Microsoft.Office.Interop.Excel;
using SistemaNorteJato.br.com.projeto.DAO;
using SistemaNorteJato.br.com.projeto.MODEL;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Management;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Application = Microsoft.Office.Interop.Excel.Application;

namespace SistemaNorteJato.br.com.projeto.VIEW
{
    public partial class FrmFuncionarios : Form
    {
        public FrmFuncionarios()
        {
            InitializeComponent();
        }

        private void btnSalvar_Click(object sender, EventArgs e)
        {
            try
            {
                //1 passo - Instanciar um novo Funcionario e passar seus atributos//
                Funcionario obj = new Funcionario();
                obj.nome = txtNome.Text;
                obj.rg = txtRg.Text;
                obj.cpf = txtCpf.Text;
                obj.email = txtEmail.Text;
                obj.senha = txtSenha.Text;
                obj.cargo = cbCargo.Text;
                obj.acesso = cbAcesso.Text;
                obj.telefone = txtTelefone.Text;
                obj.celular = txtCelular.Text;
                obj.cep = txtCep.Text;
                obj.endereco = txtEndereco.Text;
                obj.numero = int.Parse(txtNumero.Text);
                obj.complemento = txtComplemento.Text;
                obj.bairro = txtBairro.Text;
                obj.cidade = txtCidade.Text;
                obj.estado = cbUf.Text;


                //2 passo - Instanciar a classe DAO e chamar o método CadastrarFuncionario//
                FuncionarioDAO dao = new FuncionarioDAO();
                dao.CadastrarFuncionario(obj);

                //3 passo - Recarregar tabela de funcionarios//
                tabelaFuncionarios.DataSource = dao.ListarFuncionarios();

                //4 passo - Limpar os campos//
                new Helpers().LimparTela(this);

            }
            catch (Exception)
            {
                MessageBox.Show("ERRO! Preencha os campos para cadastrar o Funcionário");
            }
            

        }

        private void FrmFuncionarios_Load(object sender, EventArgs e)
        {
            FuncionarioDAO dao = new FuncionarioDAO();
            tabelaFuncionarios.DataSource = dao.ListarFuncionarios();
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

        private void txtPesquisa_KeyPress(object sender, KeyPressEventArgs e)
        {
            string nome = "%" + txtPesquisa.Text + "%";

            FuncionarioDAO dao = new FuncionarioDAO();
            tabelaFuncionarios.DataSource = dao.ListarFuncionarioPorNome(nome);
        }

        private void btnEditar_Click(object sender, EventArgs e)
        {
            try
            {
                //1 passo - Instanciar um novo Funcionario e passar seus atributos//
                Funcionario obj = new Funcionario();
                obj.codigo = int.Parse(txtCodigo.Text);
                obj.nome = txtNome.Text;
                obj.rg = txtRg.Text;
                obj.cpf = txtCpf.Text;
                obj.email = txtEmail.Text;
                obj.senha = txtSenha.Text;
                obj.cargo = cbCargo.Text;
                obj.acesso = cbAcesso.Text;
                obj.telefone = txtTelefone.Text;
                obj.celular = txtCelular.Text;
                obj.cep = txtCep.Text;
                obj.endereco = txtEndereco.Text;
                obj.numero = int.Parse(txtNumero.Text);
                obj.complemento = txtComplemento.Text;
                obj.bairro = txtBairro.Text;
                obj.cidade = txtCidade.Text;
                obj.estado = cbUf.Text;

                //2 passo - Instanciar a classe DAO e chamar o método AlterarFuncionario//
                FuncionarioDAO dao = new FuncionarioDAO();
                dao.AlterarFuncionario(obj);

                //3 passo - Recarregar tabela de funcionarios//
                tabelaFuncionarios.DataSource = dao.ListarFuncionarios();

                //4 passo - Limpar os campos//
                new Helpers().LimparTela(this);

                btnSalvar.Enabled = true;
                tabFuncionarios.TabPages.Add(tabPage2);
                tabFuncionarios.SelectedTab = tabPage2;

            }
            catch (Exception)
            {
                MessageBox.Show("ERRO! Funcionario não cadastrado para edição");
            }
            
        }

        private void btnExcluir_Click(object sender, EventArgs e)
        {
            try
            {
                //1 passo - Instanciar o OBJETO a ser excluido pelo ID//
                Funcionario obj = new Funcionario();
                obj.codigo = int.Parse(txtCodigo.Text);

                //2 passo - Instanciar o OBJETO DAO para realizar o comando de exclusão//
                FuncionarioDAO dao = new FuncionarioDAO();
                dao.ExcluirFuncionario(obj);

                //Recarregar a Lista de Funcionarios//
                tabelaFuncionarios.DataSource = dao.ListarFuncionarios();

                //Limpar campos da tela//
                new Helpers().LimparTela(this);

                btnSalvar.Enabled = true;
                tabFuncionarios.TabPages.Add(tabPage2);
                tabFuncionarios.SelectedTab = tabPage2;

            }
            catch (Exception)
            {
                MessageBox.Show("ERRO! Funcionário não cadastrado para realizar a exclusão");
            }


        }

        private void btnPesquisar_Click(object sender, EventArgs e)
        {
            string nome = txtPesquisa.Text;
            FuncionarioDAO dao = new FuncionarioDAO();

            tabelaFuncionarios.DataSource = dao.ListarFuncionarioPorNome(nome);

            if (tabelaFuncionarios.Rows.Count == 0 || txtPesquisa.Text == string.Empty)
            {
                MessageBox.Show("Funcionário não encontrado!");
                txtPesquisa.Text = string.Empty;

                //Recarregar a tabela de clientes//
                tabelaFuncionarios.DataSource = dao.ListarFuncionarios();
            }

        }

        private void tabPage2_Enter(object sender, EventArgs e)
        {
            btnSalvar.Enabled = false;
            btnEditar.Enabled = false;
            btnExcluir.Enabled = false;
        }

        private void tabPage1_Enter(object sender, EventArgs e)
        {
            btnSalvar.Enabled = true;
            btnEditar.Enabled = true;
            btnExcluir.Enabled = true;
        }

        private void tabelaFuncionarios_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            txtCodigo.Text = tabelaFuncionarios.CurrentRow.Cells[0].Value.ToString();
            txtNome.Text = tabelaFuncionarios.CurrentRow.Cells[1].Value.ToString();
            txtRg.Text = tabelaFuncionarios.CurrentRow.Cells[2].Value.ToString();
            txtCpf.Text = tabelaFuncionarios.CurrentRow.Cells[3].Value.ToString();
            txtEmail.Text = tabelaFuncionarios.CurrentRow.Cells[4].Value.ToString();
            txtSenha.Text = tabelaFuncionarios.CurrentRow.Cells[5].Value.ToString();
            cbCargo.Text = tabelaFuncionarios.CurrentRow.Cells[6].Value.ToString();
            cbAcesso.Text = tabelaFuncionarios.CurrentRow.Cells[7].Value.ToString();
            txtTelefone.Text = tabelaFuncionarios.CurrentRow.Cells[8].Value.ToString();
            txtCelular.Text = tabelaFuncionarios.CurrentRow.Cells[9].Value.ToString();
            txtCep.Text = tabelaFuncionarios.CurrentRow.Cells[10].Value.ToString();
            txtEndereco.Text = tabelaFuncionarios.CurrentRow.Cells[11].Value.ToString();
            txtNumero.Text = tabelaFuncionarios.CurrentRow.Cells[12].Value.ToString();
            txtComplemento.Text = tabelaFuncionarios.CurrentRow.Cells[13].Value.ToString();
            txtBairro.Text = tabelaFuncionarios.CurrentRow.Cells[14].Value.ToString();
            txtCidade.Text = tabelaFuncionarios.CurrentRow.Cells[15].Value.ToString();
            cbUf.Text = tabelaFuncionarios.CurrentRow.Cells[16].Value.ToString();

            //Retornar para a pagina onde estão os Dados
            tabFuncionarios.SelectedTab = tabPage1;

            if (tabFuncionarios.SelectedTab == tabPage1)
            {
                tabFuncionarios.TabPages.Remove(tabPage2);
                btnSalvar.Enabled = false;
            }

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
                for (int i = 1; i <= tabelaFuncionarios.Columns.Count; i++)
                {
                    worksheet.Cells[1, i] = tabelaFuncionarios.Columns[i - 1].HeaderText;
                }

                for (int i = 0; i < tabelaFuncionarios.Rows.Count; i++)
                {
                    for (int j = 0; j < tabelaFuncionarios.Columns.Count; j++)
                    {
                        worksheet.Cells[i + 2, j + 1] = tabelaFuncionarios.Rows[i].Cells[j].Value.ToString();
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
