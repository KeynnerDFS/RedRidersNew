using RedRidersNew.Configs;

namespace RedRidersNew.Models
{
    public class ClienteDAO
    {
        private readonly Conexao _conexao;

        public ClienteDAO(Conexao conexao)
        {
            _conexao = conexao;
        }

        public void Inserir(Cliente cliente)
        {
            try
            {
                var comando = _conexao.CreateCommand("INSERT INTO cadastrar_cliente VALUES (null, @_nome, @_endereco,  @_distanciaMoradia, " +
                    " @_FormaDePagamento, @_FormaDeContado  )");

                comando.Parameters.AddWithValue("@_nome", cliente.nome);
                comando.Parameters.AddWithValue("@_endereco", cliente.endereco);
                comando.Parameters.AddWithValue("@_distanciaMoradia", cliente.distanciaMoradia);
                comando.Parameters.AddWithValue("@_FormaDePagamento", cliente.FormaDePagamento);
                comando.Parameters.AddWithValue("@_FormaDeContado", cliente.FormaDeContato);
                comando.Parameters.AddWithValue("@_idCresFk", cliente.idCresFk);
                comando.Parameters.AddWithValue("@_idCaloFk", cliente.idCaloFk);


                comando.ExecuteNonQuery();

            }
            catch (Exception)
            {
                throw;
            }
        }

        public List<Cliente> ListarTodos()
        {
            var lista = new List<Cliente>();

            var comando = _conexao.CreateCommand("SELECT * FROM cadastrar_cliente");
            var leitor = comando.ExecuteReader();

            while (leitor.Read())
            {
                var cliente = new Cliente
                {
                    Id = leitor.GetInt32("id_ccli"),
                    nome = leitor.GetString("nome_ccli"),
                    endereco = leitor.GetString("endereco_ccli"),
                    distanciaMoradia = leitor.GetString("distancia_moradia_ccli "),
                    FormaDePagamento = leitor.GetString("forma_pagamento_ccli"),
                    FormaDeContato = leitor.GetString("forma_contato_ccli"),
                   // descricao = leitor.IsDBNull(leitor.GetOrdinal("descricao_ccar")) ? "" : leitor.GetString("descricao_ccar"),

                };

                lista.Add(cliente);
            }

            return lista;
        }
    }
}
