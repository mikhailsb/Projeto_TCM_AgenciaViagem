using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;
using AppBanco;
using AppClasses;

namespace AppDAO
{
    public class ClienteDAO
    {
        private Banco DB = new Banco();

        public void Insert(Cliente cliente)
        {
            string Inserir = string.Format("INSERT INTO cliente (nome_cliente, email, cpf, rg, telefone) Values('{0}', '{1}', '{2}', '{3}', '{4}');", cliente.NomeCliente, cliente.Email, cliente.CPF, cliente.RG, cliente.Telefone);

            DB.ExecutaComando(Inserir);
        }

        public void Atualizar(Cliente cliente)
        {
            string Atualizar = string.Format("UPDATE cliente set nome_cliente = '{0}', email = '{1}', cpf = '{2}', rg = '{3}', telefone = '{4}' Where id_cliente = '{5}';", cliente.NomeCliente, cliente.Email, cliente.CPF, cliente.RG, cliente.Telefone, cliente.IdCliente);

            DB = new Banco();

            DB.ExecutaComando(Atualizar);
        }

        public void Remover(Cliente cliente)
        {

            string remover = string.Format("DELETE FROM cliente WHERE id_cliente = '{0}';", cliente.IdCliente);
        }

        public List<Cliente> Listar()
        {
            var db = new Banco();
            var sqlQuery = "SELECT * FROM cliente";
            var retorno = db.RetornaComando(sqlQuery);

            return ListaDeCliente(retorno);
        }

        private List<Cliente> ListaDeCliente(MySqlDataReader retorno)
        {
            var usuarios = new List<Cliente>();

            while (retorno.Read())
            {
                var TempCliente = new Cliente()
                {
                    IdCliente = ushort.Parse(retorno["id_cliente"].ToString()),
                    NomeCliente = retorno["nome_cliente"].ToString(),
                    Email = retorno["email"].ToString(),
                    CPF = retorno["cpf"].ToString(),
                    RG = retorno["rg"].ToString(),
                    Telefone = retorno["telefone"].ToString()
                };

                usuarios.Add(TempCliente);
            }
            return usuarios;
        }

        public void CadastrarEndereco(Endereco endereco, Cliente cliente)
        {
            string Inserir = string.Format("INSERT INTO endereco (id_cliente, cep, rua, num, bairro, cidade, uf) VALUE ({0},'{1}','{2}','{3}','{4}','{5}','{6}');", cliente.IdCliente, endereco.CEP, endereco.Rua, endereco.NumeroEnd, endereco.Bairro, endereco.Cidade, endereco.UF);
            // INSERT INTO endereco (id_cliente, cep, rua, num, bairro, cidade, uf) VALUE ({0},'{1}','{2}','{3}','{4}','{5}','{6}');

            DB = new Banco();

            DB.ExecutaComando(Inserir);
        }
        public void AlterarEndereco(Endereco endereco, Cliente cliente)
        {
            string Alterar = string.Format("UPDATE endereco set cep = '{0}', rua = '{1}', num = '{2}', bairro = '{3}', cidade = '{4}', uf = '{5}' Where id_endereco = '{6}';", endereco.CEP, endereco.Rua, endereco.NumeroEnd, endereco.Bairro, endereco.Cidade, endereco.UF, endereco.IdEndereco);

            DB = new Banco();

            DB.ExecutaComando(Alterar);
        }

        public void RemoverEndereco(Endereco endereco, Cliente cliente)
        {
            string Remover = string.Format("DELETE FROM endereco WHERE id_endereco = '{0}' AND id_cliente = '{1}';", endereco.IdEndereco, cliente.IdCliente);

            DB = new Banco();

            DB.ExecutaComando(Remover);
        }

        public List<Endereco> ListarEndereco(Cliente cliente)
        {
            var db = new Banco();
            var sqlQuery = string.Format("SELECT * FROM endereco WHERE id_cliente = {0};", cliente.IdCliente );
            var retorno = db.RetornaComando(sqlQuery);

            return ListaDeEndececoDecluente(retorno);
        }

        private List<Endereco> ListaDeEndececoDecluente(MySqlDataReader retorno)
        {
            var enderecos = new List<Endereco>();

            while (retorno.Read())
            {
                var TempEnd = new Endereco()
                {
                    IdEndereco = ushort.Parse(retorno["id_endereco"].ToString()),
                    CEP = retorno["cep"].ToString(),
                    Rua = retorno["rua"].ToString(),
                    NumeroEnd = ushort.Parse(retorno["num"].ToString()),
                    Bairro = retorno["bairro"].ToString(),
                    Cidade = retorno["cidade"].ToString(),
                    UF = retorno["uf"].ToString()
                };

                enderecos.Add(TempEnd);
            }
            return enderecos;
        }

        public Boolean ValidaEmail(string email)
        {
            bool vlEmail = false;

            var db = new Banco();
            var sqlQuery = string.Format("SELECT email FROM cliente WHERE email = '{0}';", email);
            var retorno = db.RetornaComando(sqlQuery);

            if (retorno.Read() == true)
            {
                return vlEmail = true;
            }
            return vlEmail;
        }
    }
}

