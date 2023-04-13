using MySql.Data.MySqlClient;
using Org.BouncyCastle.Crypto.Digests;
using SistemaNorteJato.br.com.projeto.CONEXAO;
using SistemaNorteJato.br.com.projeto.MODEL;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SistemaNorteJato.br.com.projeto.DAO
{
    public class FuncionarioDAO
    {
        private MySqlConnection conexao;

        #region ConstrutorFuncionario
        //Estabelecendo a conexão//
        public FuncionarioDAO()
        {
            this.conexao = new ConnectionFactory().getconnection();
        }
        #endregion

        #region CadastrarFuncionario
        public void CadastrarFuncionario(Funcionario obj)
        {

            try
            {
                //1 passo - Criar comando SQL (insert into)//
                string sql = @"insert into tb_funcionarios (nome,rg,cpf,email,senha,cargo,nivel_acesso,telefone,celular,cep,endereco,numero,complemento,bairro,estado) 
                values (@nome,@rg,@cpf,@email,@senha,@cargo,@nivel_acesso,@telefone,@celular,@cep,@endereco,@numero,@complemento,@bairro,@estado)";

                //2 passo - Organizar comando SQL//
                MySqlCommand executacmd = new MySqlCommand(sql, conexao);
                executacmd.Parameters.AddWithValue("@nome", obj.nome);
                executacmd.Parameters.AddWithValue("@rg", obj.rg);
                executacmd.Parameters.AddWithValue("@cpf", obj.cpf);
                executacmd.Parameters.AddWithValue("@email", obj.email);
                executacmd.Parameters.AddWithValue("@senha", obj.senha);
                executacmd.Parameters.AddWithValue("@cargo", obj.cargo);
                executacmd.Parameters.AddWithValue("@nivel_acesso", obj.acesso);
                executacmd.Parameters.AddWithValue("@telefone", obj.telefone);
                executacmd.Parameters.AddWithValue("@celular", obj.celular);
                executacmd.Parameters.AddWithValue("@cep", obj.cep);
                executacmd.Parameters.AddWithValue("@endereco", obj.endereco);
                executacmd.Parameters.AddWithValue("@numero", obj.numero);
                executacmd.Parameters.AddWithValue("@complemento", obj.complemento);
                executacmd.Parameters.AddWithValue("@bairro", obj.bairro);
                executacmd.Parameters.AddWithValue("@estado", obj.estado);

                //3 passo - Abrir conexao e executar comando SQL//
                conexao.Open();
                executacmd.ExecuteNonQuery();

                MessageBox.Show("Funcionário cadastrado com sucesso");

                conexao.Close();

            }
            catch (Exception erro)
            {
                MessageBox.Show("Aconteceu erro: " + erro);
            }
        }


        #endregion

        #region AlterarFuncionario

        public void AlterarFuncionario(Funcionario obj)
        {

            try
            {
                //1 passo - Definir comando SQL (update table set)//
                string sql = @"update tb_funcionarios set nome=@nome,rg=@rg,cpf=@cpf,email=@email,senha=@senha,cargo=@cargo,nivel_acesso=@nivel_acesso,telefone=@telefone,celular=@celular,cep=@cep,endereco=@endereco,numero=@numero,complemento=@complemento,
                bairro=@bairro,cidade=@cidade,estado=@estado where id=@id";

                //2 passo - Organizar comando SQL
                MySqlCommand executacmd = new MySqlCommand(sql, conexao);
                executacmd.Parameters.AddWithValue("@nome", obj.nome);
                executacmd.Parameters.AddWithValue("@rg", obj.rg);
                executacmd.Parameters.AddWithValue("@cpf", obj.cpf);
                executacmd.Parameters.AddWithValue("@email", obj.email);
                executacmd.Parameters.AddWithValue("@senha", obj.senha);
                executacmd.Parameters.AddWithValue("@cargo", obj.cargo);
                executacmd.Parameters.AddWithValue("@nivel_acesso", obj.acesso);
                executacmd.Parameters.AddWithValue("@telefone", obj.telefone);
                executacmd.Parameters.AddWithValue("@celular", obj.celular);
                executacmd.Parameters.AddWithValue("@cep", obj.cep);
                executacmd.Parameters.AddWithValue("@endereco", obj.endereco);
                executacmd.Parameters.AddWithValue("@numero", obj.numero);
                executacmd.Parameters.AddWithValue("@complemento", obj.complemento);
                executacmd.Parameters.AddWithValue("@bairro", obj.bairro);
                executacmd.Parameters.AddWithValue("@estado", obj.estado);
                executacmd.Parameters.AddWithValue("@cidade", obj.cidade);
                executacmd.Parameters.AddWithValue("@id", obj.codigo);

                //3 passo - Abrir conexão e Executar comando SQL//
                conexao.Open();
                executacmd.ExecuteNonQuery();

                MessageBox.Show("Funcionário atualizado com sucesso!");

                //Fechando a conexão//
                conexao.Close();


            }
            catch (Exception erro)
            {
                MessageBox.Show("Aconteceu o erro: " + erro);
            }


        }


        #endregion

        #region ExcluirFuncionario

        public void ExcluirFuncionario(Funcionario obj)
        {
            try
            {
                //1 passo - Definir comando SQL (delete from where)//
                string sql = "delete from tb_funcionarios where id=@id";

                //2 passo - Organizar comando SQL//
                MySqlCommand executacmd = new MySqlCommand(sql, conexao);
                executacmd.Parameters.AddWithValue("@id", obj.codigo);

                //3 passo - Abrir conexão e executar comando SQL//
                conexao.Open();
                executacmd.ExecuteNonQuery();

                MessageBox.Show("Funcionário excluido com sucesso!");

                //Fechando a conexão//
                conexao.Close();

            }
            catch (Exception erro)
            {
                MessageBox.Show("Aconteceu o erro: " + erro);
            }


        }


        #endregion

        #region ListarFuncionarios

        public DataTable ListarFuncionarios()
        {
            try
            {
                //1 passo - Instanciar o DataTable e definir comando SQL//
                DataTable tabelafuncionario = new DataTable();
                string sql = "select * from tb_funcionarios";

                //2 passo - Organizar comando SQL//
                MySqlCommand executacmd = new MySqlCommand(sql, conexao);

                //3 passo - Abrir conexão e executar comando SQL
                conexao.Open();
                executacmd.ExecuteNonQuery();

                //3 passo - Criar o MySqlDataAdapter para preencher os dados no DataTable
                MySqlDataAdapter da = new MySqlDataAdapter(executacmd);
                da.Fill(tabelafuncionario);

                //Fechando conexão
                conexao.Close();

                return tabelafuncionario;
            }
            catch (Exception erro)
            {
                MessageBox.Show("Erro ao executar comando SQL: " + erro);
                return null;
            }
        }

        #endregion

        #region BuscarFuncionarioPorNome
        public DataTable BuscarFuncionarioPorNome(string nome)
        {
            try
            {
                //1 passo - Criar o DataTable e o comando SQL//
                DataTable tabelafuncionario = new DataTable();
                string sql = "select * from tb_funcionarios where nome=@nome";

                //2 passo - Organizar o camando SQL e executar//
                MySqlCommand executacmd = new MySqlCommand(sql, conexao);
                executacmd.Parameters.AddWithValue("@nome", nome);
                conexao.Open();
                executacmd.ExecuteNonQuery();

                //3 passo - Criar o MySqlDataAdapter para preencher os dados no DataTable
                MySqlDataAdapter da = new MySqlDataAdapter(executacmd);
                da.Fill(tabelafuncionario);

                //Fechando a conexão
                conexao.Close();

                return tabelafuncionario;

            }
            catch (Exception erro)
            {
                MessageBox.Show("Erro ao executar comando SQL: " + erro);
                return null;
            }
        }



        #endregion

        #region ListarFuncionarioPorNome
        public DataTable ListarFuncionarioPorNome(string nome)
        {
            try
            {
                //1 passo - Criar o DataTable e o comando SQL//
                DataTable tabelafuncionario = new DataTable();
                string sql = "select * from tb_funcionarios where nome like @nome";

                //2 passo - Organizar o camando SQL e executar//
                MySqlCommand executacmd = new MySqlCommand(sql, conexao);
                executacmd.Parameters.AddWithValue("@nome", nome);
                conexao.Open();
                executacmd.ExecuteNonQuery();

                //3 passo - Criar o MySqlDataAdapter para preencher os dados no DataTable
                MySqlDataAdapter da = new MySqlDataAdapter(executacmd);
                da.Fill(tabelafuncionario);

                //Fechando a conexão
                conexao.Close();

                return tabelafuncionario;

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
