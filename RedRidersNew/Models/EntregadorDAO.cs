using RedRidersNew.Configs;

namespace AppRedRidersBlazor.Models
{
    public class EntregadorDAO
    {
        private readonly Conexao _conexao;

        public EntregadorDAO(Conexao conexao)
        {
            _conexao = conexao;
        }

        public void Inserir(Entregador entregador)
        {
            try
            {
                var comando = _conexao.CreateCommand("INSERT INTO cadastrar_entregador VALUES (null, @_nome, @_cpf,@_rg,@_cnh,@_telefone," +
                    "@_idCaloFk )");

                comando.Parameters.AddWithValue("@_nome", entregador.Nome);
                comando.Parameters.AddWithValue("@_cpf", entregador.cpf);
                comando.Parameters.AddWithValue("@_rg", entregador.rg);
                comando.Parameters.AddWithValue("@_cnh", entregador.cnh);
                comando.Parameters.AddWithValue("@_telefone", entregador.telefone);
                comando.Parameters.AddWithValue("@_idCaloFk", entregador.idCaloFk);
            


                comando.ExecuteNonQuery();

            }
            catch (Exception)
            {
                throw;
            }
        }

        public List<Entregador> ListarTodos()
        {
            var lista = new List<Entregador>();

            var comando = _conexao.CreateCommand("SELECT * FROM cadastrar_entregador");
            var leitor = comando.ExecuteReader();

            while (leitor.Read())
            {
                var entregador = new Entregador
                {
                    Id = leitor.GetInt32("id_calo"),
                    Nome = leitor.GetString("nome_cent"),
                    cpf = leitor.GetString("cpf_cent"),
                    rg = leitor.GetString("rg_cent"),
                    cnh = leitor.GetString("cnh_cent"),
                    telefone = leitor.GetString("telefone_cent"),
                    // descricao = leitor.IsDBNull(leitor.GetOrdinal("descricao_ccar")) ? "" : leitor.GetString("descricao_ccar"),

                };

                lista.Add(entregador);
            }

            return lista;
        }
    }
}
