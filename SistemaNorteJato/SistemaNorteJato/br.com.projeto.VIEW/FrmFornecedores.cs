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
using Application = Microsoft.Office.Interop.Excel.Application;

namespace SistemaNorteJato.br.com.projeto.VIEW
{
    public partial class FrmFornecedores : Form
    {
        public FrmFornecedores()
        {
            InitializeComponent();
        }

        private void btnPesquisar_Click(object sender, EventArgs e)
        {
            string razao_social = txtPesquisa.Text;

            FornecedorDAO dao = new FornecedorDAO();
            tabelaFornecedores.DataSource = dao.ListarFornecedorPorNome(razao_social);

            if (tabelaFornecedores.Rows.Count == 0 || txtPesquisa.Text == string.Empty )
            {
                MessageBox.Show("Fornecedor não encontrado!");
                txtPesquisa.Text = string.Empty;

                //Recarregar lista de fornecedores//
                tabelaFornecedores.DataSource = dao.ListarFornecedor();
            }
        }

        private void btnConsultarCep_Click(object sender, EventArgs e)
        {
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

        private void btnSalvar_Click(object sender, EventArgs e)    
        {
            try
            {
                //1 passo - Instanciar o OBJ Fornecedor e informar campos que irá ser salvos//
                Fornecedor obj = new Fornecedor();
                obj.razao_social = txtRazaoSocial.Text;
                obj.cnpj = txtCnpj.Text;
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

                //2 passo - Instanciar o FornecedorDAO para executar o camando SQL//
                FornecedorDAO dao = new FornecedorDAO();
                dao.CadastrarFornecedor(obj);

                //3 passo - Recarregar a tabela de fornecedores//
                tabelaFornecedores.DataSource = dao.ListarFornecedor();

                //4 passo - Limpar os campos//
                new Helpers().LimparTela(this);

            }
            catch (Exception)
            {
                MessageBox.Show("ERRO! Preencha os campos para cadastrar o Fornecedor!");
            }
        }

        private void btnEditar_Click(object sender, EventArgs e)
        {
            try
            {
                //1 passo - Instanciar o OBJ Fornecedor e informar campos que irá ser salvos//
                Fornecedor obj = new Fornecedor();
                obj.codigo = int.Parse(txtCodigo.Text);
                obj.razao_social = txtRazaoSocial.Text;
                obj.cnpj = txtCnpj.Text;
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

                //2 passo - Instanciar o FornecedorDAO para executar o camando SQL//
                FornecedorDAO dao = new FornecedorDAO();
                dao.AlterarFornecedor(obj);

                MessageBox.Show("Fornecedor editado com sucesso!");

                //3 passo - Recarregar a tabela de fornecedores//
                tabelaFornecedores.DataSource = dao.ListarFornecedor();

                //4 passo - Limpar os campos//
                new Helpers().LimparTela(this);

                tabFornecedores.TabPages.Add(tabPage2);
                tabFornecedores.SelectedTab = tabPage2;

            }
            catch (Exception)
            {
                MessageBox.Show("ERRO! Fornecedor não cadastrado para realizar a edição");
            }
        }

        private void btnExcluir_Click(object sender, EventArgs e)
        {
            try
            {
                //1 passo - Instanciar o OBJ Fornecedor e o atributo que será alterado//
                Fornecedor obj = new Fornecedor();
                obj.codigo = int.Parse(txtCodigo.Text);

                //2 passo - Instanciar o OBJ FornecedorDAO e executar comando SQL//
                FornecedorDAO dao = new FornecedorDAO();
                dao.ExcluirFornecedor(obj);

                //3 passo - Recarregar a tabela de fornecedores//
                tabelaFornecedores.DataSource = dao.ListarFornecedor();

                //4 passo - Limpar campos//
                new Helpers().LimparTela(this);

                tabFornecedores.TabPages.Add(tabPage2);
                tabFornecedores.SelectedTab = tabPage2;

            }
            catch (Exception)
            {
                MessageBox.Show("ERRO! Fornecedor não cadastrado para realizar a exclusão!");
            }
        }

        private void FrmFornecedores_Load(object sender, EventArgs e)
        {
            this.KeyPreview = true;
            txtRazaoSocial.Focus();
            txtRazaoSocial.Select();
            FornecedorDAO dao = new FornecedorDAO();
            tabelaFornecedores.DataSource = dao.ListarFornecedor();          
        }

        private void txtPesquisa_KeyPress(object sender, KeyPressEventArgs e)
        {
            string razao_social = "%" + txtPesquisa.Text + "%";

            FornecedorDAO dao = new FornecedorDAO();
            tabelaFornecedores.DataSource = dao.ListarFornecedorPorNome(razao_social);
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

        private void tabelaFornecedores_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            //1 passo - Pegar os dados da linha selecionada//
            txtCodigo.Text = tabelaFornecedores.CurrentRow.Cells[0].Value.ToString();
            txtRazaoSocial.Text = tabelaFornecedores.CurrentRow.Cells[1].Value.ToString();
            txtCnpj.Text = tabelaFornecedores.CurrentRow.Cells[2].Value.ToString();
            txtEmail.Text = tabelaFornecedores.CurrentRow.Cells[3].Value.ToString();
            txtTelefone.Text = tabelaFornecedores.CurrentRow.Cells[4].Value.ToString();
            txtCelular.Text = tabelaFornecedores.CurrentRow.Cells[5].Value.ToString();
            txtCep.Text = tabelaFornecedores.CurrentRow.Cells[6].Value.ToString();
            txtEndereco.Text = tabelaFornecedores.CurrentRow.Cells[7].Value.ToString();
            txtNumero.Text = tabelaFornecedores.CurrentRow.Cells[8].Value.ToString();
            txtComplemento.Text = tabelaFornecedores.CurrentRow.Cells[9].Value.ToString();
            txtBairro.Text = tabelaFornecedores.CurrentRow.Cells[10].Value.ToString();
            txtCidade.Text = tabelaFornecedores.CurrentRow.Cells[11].Value.ToString();
            cbUf.Text = tabelaFornecedores.CurrentRow.Cells[12].Value.ToString();

            //2 passo - Retornar com os dados para a pagina de alteração//
            tabFornecedores.SelectedTab = tabPage1;

            if (tabFornecedores.SelectedTab == tabPage1)
            {
                tabFornecedores.TabPages.Remove(tabPage2);
                btnSalvar.Enabled = false;
            }
        }

        private void btnExportar_Click(object sender, EventArgs e)
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
                for (int i = 1; i <= tabelaFornecedores.Columns.Count; i++)
                {
                    worksheet.Cells[1, i] = tabelaFornecedores.Columns[i - 1].HeaderText;
                }

                for (int i = 0; i < tabelaFornecedores.Rows.Count; i++)
                {
                    for (int j = 0; j < tabelaFornecedores.Columns.Count; j++)
                    {
                        worksheet.Cells[i + 2, j + 1] = tabelaFornecedores.Rows[i].Cells[j].Value.ToString();
                    }
                }

                // Salva o arquivo Excel na pasta selecionada pelo usuário
                workbook.SaveAs(saveFileDialog.FileName);

                // Fecha o aplicativo Excel
                excelApp.Quit();
            }
        }

        private void FrmFornecedores_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                this.SelectNextControl(this.ActiveControl, !e.Shift, true, true, true);
            }
        }
    }
}
