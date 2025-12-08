using RedRidersNew.Configs;

namespace RedRidersNew.Models
{
    public class CardapioDAO
    {
        private readonly Conexao _conexao;

        public CardapioDAO(Conexao conexao)
        {
            _conexao = conexao;
        }

        public void Inserir(Cardapio cardapio)
        {
            try
            {
                var comando = _conexao.CreateCommand("INSERT INTO cadastrar_cardapio VALUES (null, @_nome, @_descricao,@_idCresFk)");

                comando.Parameters.AddWithValue("@_nome", cardapio.nome);
                comando.Parameters.AddWithValue("@_descricao", cardapio.descricao);
                comando.Parameters.AddWithValue("@_idCresFk", cardapio.idCresFk);
                


                comando.ExecuteNonQuery();

            }
            catch (Exception)
            {
                throw;
            }
        }
        public List<Cardapio> ListarTodos()
        {
            var lista = new List<Cardapio>();

            var comando = _conexao.CreateCommand("SELECT * FROM cadastrar_cardapio");
            var leitor = comando.ExecuteReader();

            while (leitor.Read())
            {
                var cardapio = new Cardapio
                {
                    Id = leitor.GetInt32("id_ccar"),
                    nome = leitor.GetString("nome_ccar"),
                    descricao = leitor.IsDBNull(leitor.GetOrdinal("descricao_ccar")) ? "" : leitor.GetString("descricao_ccar"),

                };

                lista.Add(cardapio);
            }

            return lista;
        }

        public Cardapio? BuscarPorId(int id)
        {
            var comando = _conexao.CreateCommand(
                "SELECT * FROM cadastrar_cardapio WHERE id_ccar = @id;");
            comando.Parameters.AddWithValue("@id", id);

            var leitor = comando.ExecuteReader();

            if (leitor.Read())
            {
                var c = new Cardapio();
                c.Id = leitor.GetInt32("id_ccar");
                c.nome = leitor.GetString("nome_ccar");
                c.descricao = leitor.GetString("descricao_ccar");
              

                return c;
            }
            else
            {
                return null;
            }
        }

        public void Atualizar(Cardapio c)
        {
            try
            {
                var comando = _conexao.CreateCommand(
                "UPDATE cadastrar_cardapio SET nome_ccar = @_nome, descricao_ccar = @_descricao" +
                " WHERE id_ccar = @_id;");


                comando.Parameters.AddWithValue("@_nome", c.nome);
                
                comando.Parameters.AddWithValue("@_descricao", c.descricao);
               

                comando.Parameters.AddWithValue("@_id", c.Id);

                comando.ExecuteNonQuery();
            }
            catch
            {
                throw;
            }
        }

        public void Excluir(int id)
        {
            try
            {
                var comando = _conexao.CreateCommand(
                "DELETE FROM cadastrar_cardapio WHERE id_ccar = @id;");

                comando.Parameters.AddWithValue("@id", id);

                comando.ExecuteNonQuery();
            }
            catch
            {
                throw;
            }
        }
    }
}
