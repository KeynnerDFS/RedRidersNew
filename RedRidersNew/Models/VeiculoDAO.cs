using RedRidersNew.Configs;

namespace RedRidersNew.Models
{
    public class VeiculoDAO
    {
        private readonly Conexao _conexao;

        public VeiculoDAO(Conexao conexao)
        {
            _conexao = conexao;
        }

        public void Inserir(Veiculo veiculo)
        {
            try
            {
                var comando = _conexao.CreateCommand("INSERT INTO Veiculo VALUES (null,@_nome, @_modelo,@_marca,@_placa,@_cor,@_rotaimg,)");

                comando.Parameters.AddWithValue("@_nome", veiculo.nome);
                comando.Parameters.AddWithValue("@_modelo", veiculo.modelo);
                comando.Parameters.AddWithValue("@_marca", veiculo.marca);
                comando.Parameters.AddWithValue("@_placa", veiculo.placa);
                comando.Parameters.AddWithValue("@_cor", veiculo.cor);
                comando.Parameters.AddWithValue("@_rotaimg", veiculo.rotaimg);
               

                comando.ExecuteNonQuery();

            }
            catch (Exception)
            {
                throw;
            }
        }
        public List<Veiculo> ListarTodos()
        {
            var lista = new List<Veiculo>();

            var comando = _conexao.CreateCommand("SELECT * FROM Veiculo");
            var leitor = comando.ExecuteReader();

            while (leitor.Read())
            {
                var veiculo = new Veiculo
                {
                    Id = leitor.GetInt32("id_vei"),
                    nome = leitor.GetString("nome_dono_vei"),
                    modelo = leitor.GetString("modelo_vei"),
                    marca = leitor.GetString("marca_vei"),
                    placa = leitor.GetString("placa_vei"),
                    cor = leitor.GetString("cor_vei"),
                    rotaimg = leitor.GetString("rotaimg_vei")
                    //  descricao = leitor.IsDBNull(leitor.GetOrdinal("descricao_cpra")) ? "" : leitor.GetString("descricao_cpra"),

                };

                lista.Add(veiculo);
            }

            return lista;
        }

        public Veiculo? BuscarPorId(int id)
        {
            var comando = _conexao.CreateCommand(
                "SELECT * FROM Veiculo WHERE id_vei = @id;");
            comando.Parameters.AddWithValue("@id", id);

            var leitor = comando.ExecuteReader();

            if (leitor.Read())
            {
                var p = new Veiculo();
                p.Id = leitor.GetInt32("id_vei");
                p.nome = leitor.GetString("nome_dono_vei");
                p.modelo = leitor.GetString("modelo_vei");
                p.marca = leitor.GetString("marca_vei");
                p.placa = leitor.GetString("placa_vei");
                p.cor = leitor.GetString("cor_vei");
                p.rotaimg = leitor.GetString("rotaimg_vei");


                return p;
            }
            else
            {
                return null;
            }
        }

        public void Atualizar(Veiculo p)
        {
            try
            {
                var comando = _conexao.CreateCommand(
                "UPDATE Veiculo SET nome_dono_vei = @_nome, modelo_vei = @_modelo, marca_vei = @_marca, placa_vei = @_placa, cor_vei = @_cor, " +
                "rotaimg_vei = @_rotaimg WHERE id_vei = @_id;");


                comando.Parameters.AddWithValue("@_nome", p.nome);
                comando.Parameters.AddWithValue("@_modelo", p.modelo);
                comando.Parameters.AddWithValue("@_marca", p.marca);
                comando.Parameters.AddWithValue("@_placa", p.placa);
                comando.Parameters.AddWithValue("@_cor", p.cor);
                comando.Parameters.AddWithValue("@_rotaimg", p.rotaimg);

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
                "DELETE FROM Veiculo WHERE id_vei = @id;");

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
