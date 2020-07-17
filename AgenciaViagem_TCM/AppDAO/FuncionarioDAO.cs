using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;
using AppClasses;
using AppBanco;

namespace AppDAO
{
    public class FuncionarioDAO
    {
        private Banco DB;

        public void Inserir(Funcionario Func)
        {
            // Query de cadastro do Funcionário
            string Inserir = string.Format("CALL p_ins_funcionario('{0}', '{1}', '{2}', '{3}');", Func.NomeFuncioario, Func.Login, Func.SenhaFuncionario, Func.Cargo);
            //INSERT INTO funcionario (nome_func, login, senha_func, cargo_func) VALUES (null,'Samuel Felix', 'func69', 'senhanadasujestiva', 'Auxiliar');

            // chama a classe Banco de dados na DLL AppBanco 
            DB = new Banco();

            DB.ExecutaComando(Inserir);
        }

        public void Atualizar(Funcionario Func)
        {
            // Query para atualizar os dados do Funcionário
            // o campo de Login não está incluso para alteração. A alteração de login é uma falha de segurança.
            string Atualizar = string.Format("UPDATE funcionario set nome_func = '{0}', cargo_func = '{1}' Where id_func = '{2}';", Func.NomeFuncioario, Func.Cargo, Func.IdFuncionario);

            // chama a classe Banco de dados na DLL AppBanco 
            DB = new Banco();

            DB.ExecutaComando(Atualizar);
        }
        public Funcionario BuscaID(ushort ID)
        {
            string busca = string.Format("SELECT * FROM funcionario WHERE id_func = '{0}';", ID);
            DB = new Banco();

            var x= ListaDeFuncionario(DB.RetornaComando(busca));

            return x[0];
        }

        public void Remover(Funcionario Func)
        {
            // Query para Deletar funcionário
            string Remover = string.Format("DELETE FROM funcionario WHERE id_func = '{0}';", Func.IdFuncionario);

            DB = new Banco();

            DB.ExecutaComando(Remover);
        }
        public List<Funcionario> Listar()
        {
            // Função Para listar os Funcionários na paginá index do funcionário.
            // esta função utilizará ListaDeFuncionario que recebe uma DataReader e retorna uma lista de funcionários.
            var db = new Banco();
            var sqlQuery = "SELECT id_func, nome_func, login, cargo_func FROM funcionario";
            var retorno = db.RetornaComando(sqlQuery);

            return ListaDeFuncionario(retorno);
        }

        private List<Funcionario> ListaDeFuncionario(MySqlDataReader retorno)
        {
            var funcionarios = new List<Funcionario>();

            while (retorno.Read())
            {
                var TempFuncionarios = new Funcionario()
                {
                    IdFuncionario = ushort.Parse(retorno["id_func"].ToString()),
                    NomeFuncioario = retorno["nome_func"].ToString(),
                    Login = retorno["login"].ToString(),
                    Cargo = retorno["cargo_func"].ToString()
                };

                funcionarios.Add(TempFuncionarios);
            }
            return funcionarios;
        }

        public Boolean ValidaLogin(string login)
        {
            bool vlLogin = false;

            var db = new Banco();
            var sqlQuery = string.Format("SELECT login FROM funcionario WHERE login = '{0}'", login);
            var retorno = db.RetornaComando(sqlQuery);

            if(retorno.Read() == true)
            {
                return vlLogin = true;
            }
            return vlLogin;
        }
    }
}
