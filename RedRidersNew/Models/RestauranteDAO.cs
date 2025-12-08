using Microsoft.AspNetCore.Razor.TagHelpers;
using RedRidersNew.Configs;

namespace RedRidersNew.Models
{
    public class RestauranteDAO
    {
        private readonly Conexao _conexao;

        public RestauranteDAO(Conexao conexao)
        {
            _conexao = conexao;
        }

        public void Inserir(Restaurante restaurante)
        {
            try
            {
                var comando = _conexao.CreateCommand("INSERT INTO cadastrar_restaurante VALUES (null,@_nome, @_telefone,@_endereco,@_cnpj,@_imagem)");

                comando.Parameters.AddWithValue("@_nome", restaurante.nome);
                comando.Parameters.AddWithValue("@_telefone", restaurante.Telefone);
                comando.Parameters.AddWithValue("@_endereco", restaurante.endereco);
                comando.Parameters.AddWithValue("@_cnpj", restaurante.CNPJ);
                comando.Parameters.AddWithValue("@_imagem", restaurante.imagem);


                comando.ExecuteNonQuery();

            }
            catch (Exception)
            {
                throw;
            }
        }
        public List<Restaurante> ListarTodos()
        {
            var lista = new List<Restaurante>();

            var comando = _conexao.CreateCommand("SELECT * FROM cadastrar_restaurante");
            var leitor = comando.ExecuteReader();

            while (leitor.Read())
            {
                var restaurante = new Restaurante
                {
                    Id = leitor.GetInt32("id_cres"),
                    nome = leitor.GetString("nome_cres"),
                    Telefone = leitor.GetString("telefone_cres"),
                    endereco = leitor.GetString("endereco_cres"),
                    CNPJ = leitor.GetString("cnpj_cres"),
                    imagem = leitor.GetString("imagem_cres"),
                    //  descricao = leitor.IsDBNull(leitor.GetOrdinal("descricao_cpra")) ? "" : leitor.GetString("descricao_cpra"),

                };

                lista.Add(restaurante);
            }

            return lista;
        }

        public Restaurante? BuscarPorId(int id)
        {
            var comando = _conexao.CreateCommand(
                "SELECT * FROM cadastrar_restaurante WHERE id_cres = @id;");
            comando.Parameters.AddWithValue("@id", id);

            var leitor = comando.ExecuteReader();

            if (leitor.Read())
            {
                var restaurante = new Restaurante();
                restaurante.Id = leitor.GetInt32("id_cres");
                restaurante.nome = leitor.GetString("nome_cres");
                restaurante.Telefone = leitor.GetString("telefone_cres");
                restaurante.endereco = leitor.GetString("endereco_cres");
                restaurante.CNPJ = leitor.GetString("cnpj_cres");
                restaurante.imagem = leitor.GetString("imagem_cres");

                return restaurante;
            }
            else
            {
                return null;
            }
        }

        public void Atualizar(Restaurante restaurante)
        {
            try
            {
                var comando = _conexao.CreateCommand(
                "UPDATE cadastrar_restaurante SET nome_cres = @_nome, telefone_cres = @_telefone, endereco_cres = @_endereco, cnpj_cres = @_cnpj, imagem_cres = @_imagem" +
                " WHERE id_cres = @_id;");

                
                comando.Parameters.AddWithValue("@_nome", restaurante.nome);
                comando.Parameters.AddWithValue("@_telefone", restaurante.Telefone);
                comando.Parameters.AddWithValue("@_endereco", restaurante.endereco);
                comando.Parameters.AddWithValue("@_cnpj", restaurante.CNPJ);
                comando.Parameters.AddWithValue("@_imagem", restaurante.imagem);

                comando.Parameters.AddWithValue("@_id", restaurante.Id);

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
                "DELETE FROM cadastrar_restaurante WHERE id_cres = @id;");

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
