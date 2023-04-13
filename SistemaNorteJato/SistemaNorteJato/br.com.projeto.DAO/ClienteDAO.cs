using MySql.Data.MySqlClient;
using Mysqlx.Cursor;
using SistemaNorteJato.br.com.projeto.CONEXAO;
using SistemaNorteJato.br.com.projeto.MODEL;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Management;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SistemaNorteJato.br.com.projeto.DAO
{
    public class ClienteDAO
    {

        private MySqlConnection conexao;

        #region ConstrutorClienteDAO
        //Construtor Cliente//
        public ClienteDAO()
        {
            this.conexao = new ConnectionFactory().getconnection();
        }
        #endregion

        #region CadastrarCliente
        //Método cadastrar cliente//
        public void CadastrarCliente(Cliente obj)
        {
            try
            {
                //1 passo - definir comando SQL (insert into)//
                string sql = @"insert into tb_clientes (nome,rg,cpf,email,telefone,celular,cep,endereco,numero,complemento,bairro,cidade,estado)
                values (@nome,@rg,@cpf,@email,@telefone,@celular,@cep,@endereco,@numero,@complemento,@bairro,@cidade,@estado)";

                //2 passo - organizar comando SQL//
                MySqlCommand executacmd = new MySqlCommand(sql,conexao);
                executacmd.Parameters.AddWithValue("@nome",obj.nome);
                executacmd.Parameters.AddWithValue("@rg", obj.rg);
                executacmd.Parameters.AddWithValue("@cpf", obj.cpf);
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

                //3 passo - abrir a conexao e executar o comando SQL//
                conexao.Open();
                executacmd.ExecuteNonQuery();

                MessageBox.Show("Cliente cadastrado com sucesso!");

                //Fechando a conexão
                conexao.Close();

            }
            catch (Exception erro)
            {
                MessageBox.Show("Aconteceu o erro" + erro);
                
            }


        }
        #endregion

        #region AlterarCliente
        //Método alterar cliente//
        public void AlterarCliente(Cliente obj)
        {
            try
            {
                //1 passo - definir comando SQL (update (tabela) set ())//
                string sql = @"update tb_clientes set nome=@nome,rg=@rg,cpf=@cpf,email=@email,telefone=@telefone,celular=@celular,cep=@cep,endereco=@endereco,numero=@numero,complemento=@complemento,
                bairro=@bairro,cidade=@cidade,estado=@estado where id=@id";

                //2 passo - organizar comando SQL//
                MySqlCommand executacmd = new MySqlCommand(sql, conexao);
                executacmd.Parameters.AddWithValue("@nome", obj.nome);
                executacmd.Parameters.AddWithValue("@rg", obj.rg);
                executacmd.Parameters.AddWithValue("@cpf", obj.cpf);
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
                executacmd.Parameters.AddWithValue("@id", obj.codigo);

                //3 passo - abrir a conexao e executar o comando SQL//
                conexao.Open();
                executacmd.ExecuteNonQuery();

                MessageBox.Show("Cliente atualizado com sucesso!");

                //Fechando a conexão
                conexao.Close();

            }
            catch (Exception erro)
            {
                MessageBox.Show("Aconteceu o erro: " + erro);

            }


        }



        #endregion

        #region ExcluirCliente
        //Método excluir cliente//
        public void ExcluirCliente(Cliente obj)
        {
            try
            {
                //1 passo - definir comando SQL (Delete)//
                string sql = @"delete from tb_clientes where id=@id";

                //2 passo - organizar comando SQL//
                MySqlCommand executacmd = new MySqlCommand(sql, conexao);
                executacmd.Parameters.AddWithValue("@id", obj.codigo);

                //3 passo - abrir a conexao e executar o comando SQL//
                conexao.Open();
                executacmd.ExecuteNonQuery();

                MessageBox.Show("Cliente excluido com sucesso!");

                //Fechando a conexão
                conexao.Close();
            }
            catch (Exception erro)
            {
                MessageBox.Show("Aconteceu o erro: " + erro);

            }
            


        }


        #endregion

        #region ListarClientes
        //Método listar clientes//
        public DataTable ListarClientes()
        {
            try
            {
                //1 passo - Criar o DataTable e o comando SQL//
                DataTable tabelacliente = new DataTable();
                string sql = "select * from tb_clientes";

                //2 passo - Organizar o camando SQL e executar//
                MySqlCommand executacmd = new MySqlCommand(sql, conexao);
                conexao.Open();
                executacmd.ExecuteNonQuery();

                //3 passo - Criar o MySqlDataAdapter para preencher os dados no DataTable
                MySqlDataAdapter da = new MySqlDataAdapter(executacmd);
                da.Fill(tabelacliente);

                //Fechando a conexão
                conexao.Close();

                return tabelacliente;

            }
            catch (Exception erro)
            {
                MessageBox.Show("Erro ao executar comando SQL: "+erro);
                return null;
            }


        }

        #endregion

        #region BuscarClientePorNome
        //Método buscar cliente por Nome//
        public DataTable BuscarClientePorNome(string nome)
        {
            try
            {
                //1 passo - Criar o DataTable e o comando SQL//
                DataTable tabelacliente = new DataTable();
                string sql = "select * from tb_clientes where nome=@nome";

                //2 passo - Organizar o camando SQL e executar//
                MySqlCommand executacmd = new MySqlCommand(sql, conexao);
                executacmd.Parameters.AddWithValue("@nome", nome);
                conexao.Open();
                executacmd.ExecuteNonQuery();

                //3 passo - Criar o MySqlDataAdapter para preencher os dados no DataTable
                MySqlDataAdapter da = new MySqlDataAdapter(executacmd);
                da.Fill(tabelacliente);

                //Fechando a conexão
                conexao.Close();

                return tabelacliente;

            }
            catch (Exception erro)
            {
                MessageBox.Show("Erro ao executar comando SQL: " + erro);
                return null;
            }
        }


        #endregion

        #region ListarClientePorNome
        //Método listar cliente por Nome//
        public DataTable ListarClientePorNome(string nome)
        {
            try
            {
                //1 passo - Criar o DataTable e o comando SQL//
                DataTable tabelacliente = new DataTable();
                string sql = "select * from tb_clientes where nome like @nome";

                //2 passo - Organizar o camando SQL e executar//
                MySqlCommand executacmd = new MySqlCommand(sql, conexao);
                executacmd.Parameters.AddWithValue("@nome", nome);
                conexao.Open();
                executacmd.ExecuteNonQuery();

                //3 passo - Criar o MySqlDataAdapter para preencher os dados no DataTable
                MySqlDataAdapter da = new MySqlDataAdapter(executacmd);
                da.Fill(tabelacliente);

                //Fechando a conexão
                conexao.Close();

                return tabelacliente;

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
