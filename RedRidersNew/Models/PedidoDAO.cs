using RedRidersNew.Configs;

namespace AppRedRidersBlazor.Models
{
    public class PedidoDAO
    {
        private readonly Conexao _conexao;

        public PedidoDAO(Conexao conexao)
        {
            _conexao = conexao;
        }

        public void Inserir(Pedido pedido)
        {
            try
            {
                var comando = _conexao.CreateCommand("INSERT INTO novo_pedido VALUES (null,@_nomeRestaurante,@_precoPelaEntrega, @_ondeEntregar, " +
                    "@_ondeBuscar, @_distancia,@_quantidade, @_descricao, @_cliente, @_Status, @_idCresFk,@_idCentFk,@_idCaloFk)");

                comando.Parameters.AddWithValue("@_precoPelaEntrega", pedido.PrecoPelaEntrega);
                comando.Parameters.AddWithValue("@_nomeRestaurante", pedido.nomeRestaurante);
                comando.Parameters.AddWithValue("@_ondeEntregar", pedido.OndeEntregar);
                comando.Parameters.AddWithValue("@_ondeBuscar", pedido.OndeBuscar);
                comando.Parameters.AddWithValue("@_distancia", pedido.distancia);
                comando.Parameters.AddWithValue("@_quantidade", pedido.Quantidade);
                comando.Parameters.AddWithValue("@_descricao", pedido.Descricao);
                comando.Parameters.AddWithValue("@_cliente", pedido.Cliente);
                comando.Parameters.AddWithValue("@_Status", pedido.Status);
                comando.Parameters.AddWithValue("@_idCresFk", pedido.idCresFk);
                comando.Parameters.AddWithValue("@_idCentFk", pedido.idCentFk);
                comando.Parameters.AddWithValue("@_idCaloFk", pedido.idCaloFk);


                comando.ExecuteNonQuery();

            }
            catch (Exception)
            {
                throw;
            }
        }

        public List<Pedido> ListarTodos()
        {
            var lista = new List<Pedido>();

            var comando = _conexao.CreateCommand("SELECT * FROM novo_pedido");
            var leitor = comando.ExecuteReader();

            while (leitor.Read())
            {
                var pedido = new Pedido
                {
                    id = leitor.GetInt32("id_nope"),
                    nomeRestaurante = leitor.GetString("nome_restaurante_nope"),
                    PrecoPelaEntrega = leitor.GetFloat("preco_nope"),
                    OndeEntregar = leitor.GetString("endereco_entrega_nope"),
                    OndeBuscar = leitor.GetString("endereco_buscar_nope"),
                    distancia = leitor.GetString("distancia_nope"),
                    Quantidade = leitor.GetInt32("quantidade_nope"),
                    Descricao = leitor.IsDBNull(leitor.GetOrdinal("descricao_nope")) ? "" : leitor.GetString("descricao_nope"),
                    Cliente = leitor.GetString("cliente_nope"),
                    Status = leitor.GetString("status_nope")

                };

                lista.Add(pedido);
            }

            return lista;
        }
    }
}
