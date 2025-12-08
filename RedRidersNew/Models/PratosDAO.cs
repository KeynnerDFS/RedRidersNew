using RedRidersNew.Configs;

namespace RedRidersNew.Models
{
    public class PratosDAO
    {
        private readonly Conexao _conexao;

        public PratosDAO(Conexao conexao)
        {
            _conexao = conexao;
        }

        public void Inserir(Pratos pratos)
        {
            try
            {
                var comando = _conexao.CreateCommand("INSERT INTO cadastrar_pratos VALUES (null, @_nome, @_preco, @_descricao,@_idCcarFk)");

                comando.Parameters.AddWithValue("@_nome", pratos.nome);
                comando.Parameters.AddWithValue("@_preco", pratos.preco);
                comando.Parameters.AddWithValue("@_descricao", pratos.descricao);
                comando.Parameters.AddWithValue("@_idCcarFk", pratos.idCcarFk);
                


                comando.ExecuteNonQuery();

            }
            catch (Exception)
            {
                throw;
            }
        }
        public List<Pratos> ListarTodos()
        {
            var lista = new List<Pratos>();

            var comando = _conexao.CreateCommand("SELECT * FROM cadastrar_pratos");
            var leitor = comando.ExecuteReader();

            while (leitor.Read())
            {
                var pratos = new Pratos
                {
                    Id = leitor.GetInt32("id_cpra"),
                    nome = leitor.GetString("nome_cpra"),
                    preco = leitor.GetFloat("preco_cpra"),
                    descricao = leitor.IsDBNull(leitor.GetOrdinal("descricao_cpra")) ? "" : leitor.GetString("descricao_cpra"),

                };

                lista.Add(pratos);
            }

            return lista;
        }

        public Pratos? BuscarPorId(int id)
        {
            var comando = _conexao.CreateCommand(
                "SELECT * FROM cadastrar_pratos WHERE id_cpra = @id;");
            comando.Parameters.AddWithValue("@id", id);

            var leitor = comando.ExecuteReader();

            if (leitor.Read())
            {
                var p = new Pratos();
                p.Id = leitor.GetInt32("id_cpra");
                p.nome = leitor.GetString("nome_cpra");
                p.preco = leitor.GetFloat("preco_cpra");
                p.descricao = leitor.GetString("descricao_cpra");
                p.idCcarFk = leitor.GetInt32("id_ccar_fk");
                

                return p;
            }
            else
            {
                return null;
            }
        }

        public void Atualizar(Pratos p)
        {
            try
            {
                var comando = _conexao.CreateCommand(
                "UPDATE cadastrar_pratos SET nome_cpra = @_nome, preco_cpra = @_preco,descricao_cpra = @_descricao, idCcarFk = @_idCcarFk" +
                " WHERE id_cpra = @_id;");


                comando.Parameters.AddWithValue("@_nome", p.nome);
                comando.Parameters.AddWithValue("@_preco", p.preco);
                comando.Parameters.AddWithValue("@_descricao", p.descricao);
                comando.Parameters.AddWithValue("@_idCcarFk", p.idCcarFk);
                
                comando.Parameters.AddWithValue("@_id", p.Id);

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
                "DELETE FROM cadastrar_pratos WHERE id_cpra = @id;");

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
