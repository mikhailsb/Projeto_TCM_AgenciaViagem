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
    public class PacoteDAO
    {
        private Banco DB;

        public void Inserir(Pacote pacote)
        {
            // Query de cadastro do Pacotes
            string Inserir = string.Format
                ("INSERT INTO pacote (data_ida, data_volta, origem, destino, tipo_trasporte, valor_unitario, descricao_pacote, resumo_pacote, roteiro_viagem)" +
                " VALUES ('{0}', '{1}', '{2}', '{3}', '{4}', '{5}', '{6}', '{7}', '{8}');", pacote.DataCheckin, pacote.DataCheckout, pacote.Origem, pacote.Destino, pacote.TipoTransporte, pacote.ValorUnitario, pacote.DescricaoPacote, pacote.ResumoPacote, pacote.RoteiroViagem);

            // instacia a classe Banco de dados na DLL AppBanco 
            DB = new Banco();

            DB.ExecutaComando(Inserir);
        }

        public void Atualizar(Pacote pacote)
        {
            // Query para atualizar os dados do Funcionário
            // o campo de Login não está incluso para alteração. A alteração de login é uma falha de segurança.
            string Atualizar = string.Format("UPDATE pacote set data_ida = {0}, data_volta = {1}, origem = {2}, destino = {3}, tipo_trasporte = {4}, valor_unitario = {5}, descricao_pacote = {6}, resumo_pacote = {7}, roteiro_viage = {8}';", pacote.DataCheckin, pacote.DataCheckout, pacote.Origem, pacote.Destino, pacote.TipoTransporte, pacote.ValorUnitario, pacote.DescricaoPacote, pacote.ResumoPacote, pacote.RoteiroViagem);
            
            // chama a classe Banco de dados na DLL AppBanco 
            DB = new Banco();

            DB.ExecutaComando(Atualizar);
        }

        public void Remover(Pacote pacote)
        {
            // Query para Deletar funcionário
            string Remover = string.Format("DELETE FROM pacote WHERE id_pacote = '{0}';", pacote.IdPacote);

            DB = new Banco();

            DB.ExecutaComando(Remover);
        }
        public List<Pacote> Listar()
        {
            // Função Para listar os Funcionários na paginá index do funcionário.
            // esta função utilizará ListaDeFuncionario que recebe uma DataReader e retorna uma lista de funcionários.
            var db = new Banco();
            var sqlQuery = "SELECT * FROM pacote;";
            var retorno = db.RetornaComando(sqlQuery);

            return ListaDePacotes(retorno);
        }

        private List<Pacote> ListaDePacotes(MySqlDataReader retorno)
        {
            var pacotes = new List<Pacote>();

            while (retorno.Read())
            {
                var TempPacote = new Pacote()
                {
                    IdPacote = ushort.Parse(retorno["id_pacote"].ToString()),
                    DataCheckin = DateTime.Parse(retorno["data_ida"].ToString()),
                    DataCheckout = DateTime.Parse(retorno["data_volta"].ToString()),
                    Origem = retorno["origem"].ToString(),
                    Destino = retorno["destino"].ToString(),
                    TipoTransporte = retorno["tipo_trasporte"].ToString(),
                    ValorUnitario = decimal.Parse(retorno["valor_unitario"].ToString()),
                    DescricaoPacote = retorno["descricao_pacote"].ToString(),
                    ResumoPacote = retorno["resumo_pacote"].ToString(),
                    RoteiroViagem = retorno["roteiro_viagem"].ToString()
                };
                pacotes.Add(TempPacote);
            }
            return pacotes;
        }
    }
}
