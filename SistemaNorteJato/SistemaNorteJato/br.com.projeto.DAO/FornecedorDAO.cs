using Microsoft.Office.Interop.Excel;
using MySql.Data.MySqlClient;
using SistemaNorteJato.br.com.projeto.CONEXAO;
using SistemaNorteJato.br.com.projeto.MODEL;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DataTable = System.Data.DataTable;

namespace SistemaNorteJato.br.com.projeto.DAO
{
    public class FornecedorDAO
    {
        private MySqlConnection conexao;

        #region Construtor FornecedorDAO
        public FornecedorDAO()
        {
            this.conexao = new ConnectionFactory().getconnection();
        }
        #endregion

        #region Cadastrar Fornecedor
        public void CadastrarFornecedor(Fornecedor obj)
        {
            //Método de cadastrar fornecedor com comandos SQL//
            try
            {
                //1 passo - Definir comando SQL (insert into)
                string sql = @"insert into tb_fornecedores (razao_social,cnpj,email,telefone,celular,cep,endereco,numero,complemento,bairro,cidade,estado) 
                values (@razao_social,@cnpj,@email,@telefone,@celular,@cep,@endereco,@numero,@complemento,@bairro,@cidade,@estado)";

                //2 passo - Organizar o camando SQL//
                MySqlCommand executacmd = new MySqlCommand(sql, conexao);
                executacmd.Parameters.AddWithValue("@razao_social", obj.razao_social);
                executacmd.Parameters.AddWithValue("@cnpj", obj.cnpj);
                executacmd.Parameters.AddWithValue("@email", obj.email);
                executacmd.Parameters.AddWithValue("@telefone", obj.telefone);
                executacmd.Parameters.AddWithValue("@celular", obj.celular);
                executacmd.Parameters.AddWithValue("@cep", obj.cep);
                executacmd.Parameters.AddWithValue("@endereco", obj.endereco);
                executacmd.Parameters.AddWithValue("@numero", obj.numero);
                executacmd.Parameters.AddWithValue("@complemento", obj.complemento);
                executacmd.Parameters.AddWithValue("@bairro", obj.bairro);
                executacmd.Parameters.AddWithValue("@cidade", obj.cidade);
                executacmd.Parameters.AddWithValue("@estado", obj.estado);

                //3 passo - Abrir a conexão com o bd e executar o comando SQL on querry//
                conexao.Open();
                executacmd.ExecuteNonQuery();

                MessageBox.Show("Fornecedor cadastrado com sucesso!");

                //4 passo - Fechar conexão
                conexao.Close();

            }
            catch (Exception erro)
            {
                MessageBox.Show("Aconteceu o erro: " + erro);
            }

        }
        #endregion

        #region Alterar Fornecedor
        public void AlterarFornecedor(Fornecedor obj)
        {
            try
            {
                //1 passo - Definir o comando SQL (update set where)
                string sql = @"update tb_fornecedores set razao_social=@razao_social,cnpj=@cnpj,email=@email,telefone=@telefone,celular=@celular,cep=@cep,endereco=@endereco,
            numero=@numero,complemento=@complemento,bairro=@bairro,cidade=@cidade,estado=@estado where id=@id";

                //2 passo - Organizar o comando SQL//
                MySqlCommand executacmd = new MySqlCommand(sql, conexao);
                executacmd.Parameters.AddWithValue("@id", obj.codigo);
                executacmd.Parameters.AddWithValue("@razao_social", obj.razao_social);
                executacmd.Parameters.AddWithValue("@cnpj", obj.cnpj);
                executacmd.Parameters.AddWithValue("@email", obj.email);
                executacmd.Parameters.AddWithValue("@telefone", obj.telefone);
                executacmd.Parameters.AddWithValue("@celular", obj.celular);
                executacmd.Parameters.AddWithValue("@cep", obj.cep);
                executacmd.Parameters.AddWithValue("@endereco", obj.endereco);
                executacmd.Parameters.AddWithValue("@numero", obj.numero);
                executacmd.Parameters.AddWithValue("@complemento", obj.complemento);
                executacmd.Parameters.AddWithValue("@bairro", obj.bairro);
                executacmd.Parameters.AddWithValue("@cidade", obj.cidade);
                executacmd.Parameters.AddWithValue("@estado", obj.estado);

                //3 passo - Abrir a conexão com o BD e executar o comando SQL//
                conexao.Open();
                executacmd.ExecuteNonQuery();

                //4 passo - Fechar conexão com o BD//
                conexao.Close();

            }
            catch (Exception erro)
            {
                MessageBox.Show("Aconteceu o erro: " + erro);
            }
        }


        #endregion

        #region Excluir Fornecedor
        public void ExcluirFornecedor(Fornecedor obj)
        {
            try
            {
                //1 passo - Definir comando SQL (delete from where)//
                string sql = "delete from tb_fornecedores where id=@id";

                //2 passo - Organizar o comando SQL//
                MySqlCommand executacmd = new MySqlCommand(sql, conexao);
                executacmd.Parameters.AddWithValue("@id", obj.codigo);

                //3 passo - Abrir conexão com o BD e executar o comando SQL//
                conexao.Open();
                executacmd.ExecuteNonQuery();

                MessageBox.Show("Fornecedor excluido com sucesso!");

                //4 passo - Fechar conexão com o BD//
                conexao.Close();
            }
            catch (Exception erro)
            {
                MessageBox.Show("Aconteceu o erro: " + erro);
            }

        }


        #endregion

        #region Listar Fornecedores
        public DataTable ListarFornecedor()
        {
            try
            {
                //1 passo - Criar o DataTable e o comando SQL//
                DataTable tabelafornecedor = new DataTable();
                string sql = @"select id as 'Código', razao_social as 'Razão Social', cnpj as 'CNPJ', email as 'E-mail', telefone as 'Telefone', celular as 'Celular', cep as 'CEP', endereco as 'Endereço',
                numero as 'Número', complemento as 'Complemento', bairro as 'Bairro', cidade as 'Cidade', estado as 'Estado' from tb_fornecedores";

                //2 passo - Organizar o camando SQL e executar//
                MySqlCommand executacmd = new MySqlCommand(sql, conexao);
                conexao.Open();
                executacmd.ExecuteNonQuery();

                //3 passo - Criar o MySqlDataAdapter para preencher os dados no DataTable
                MySqlDataAdapter da = new MySqlDataAdapter(executacmd);
                da.Fill(tabelafornecedor);

                //Fechando a conexão
                conexao.Close();

                return tabelafornecedor;

            }
            catch (Exception erro)
            {
                MessageBox.Show("Erro ao executar comando SQL: " + erro);
                return null;
            }


        }


        #endregion

        #region Buscar Fornecedor por Nome

        //Método buscar fornecedor por Nome//
        public DataTable BuscarFornecedorPorNome(string razao_social)
        {
            try
            {
                //1 passo - Criar o DataTable e o comando SQL//
                DataTable tabelafornecedor = new DataTable();
                string sql = "select * from tb_fornecedores where razao_social=@razao_social";

                //2 passo - Organizar o camando SQL e executar//
                MySqlCommand executacmd = new MySqlCommand(sql, conexao);
                executacmd.Parameters.AddWithValue("@razao_social", razao_social);
                conexao.Open();
                executacmd.ExecuteNonQuery();

                //3 passo - Criar o MySqlDataAdapter para preencher os dados no DataTable
                MySqlDataAdapter da = new MySqlDataAdapter(executacmd);
                da.Fill(tabelafornecedor);

                //Fechando a conexão
                conexao.Close();

                return tabelafornecedor;

            }
            catch (Exception erro)
            {
                MessageBox.Show("Erro ao executar comando SQL: " + erro);
                return null;
            }
        }
        #endregion

        #region Listar Fornecedor por Nome
        public DataTable ListarFornecedorPorNome(string razao_social)
        {
            try
            {
                //1 passo - Criar o DataTable e o comando SQL//
                DataTable tabelafornecedor = new DataTable();
                string sql = "select * from tb_fornecedores where razao_social like @razao_social";

                //2 passo - Organizar o camando SQL e executar//
                MySqlCommand executacmd = new MySqlCommand(sql, conexao);
                executacmd.Parameters.AddWithValue("@razao_social", razao_social);
                conexao.Open();
                executacmd.ExecuteNonQuery();

                //3 passo - Criar o MySqlDataAdapter para preencher os dados no DataTable
                MySqlDataAdapter da = new MySqlDataAdapter(executacmd);
                da.Fill(tabelafornecedor);

                //Fechando a conexão
                conexao.Close();

                return tabelafornecedor;

            }
            catch (Exception erro)
            {
                MessageBox.Show("Erro ao executar comando SQL: " + erro);
                return null;
            }
        }

        #endregion
    }
}
