namespace cadeteria.Models;

public class PedidoModel
{
        private string numero ,obs;
        private string estado;
        int idCadete;
        
        //siguiendo la teoria de composicion si creo clientes desde la clase pedido este se eliminara cuando elimine el pedido
        ClienteModel cliente;

        public PedidoModel(string numero, string obs, string estado){
            this.Numero = numero;
            this.Obs = obs;
            this.Estado = estado;
        }

        public string Numero { get => numero; set => numero = value; }
        public string Obs { get => obs; set => obs = value; }
        public ClienteModel Cliente { get => cliente; set => cliente = value; }
        public string Estado { get => estado; set => estado = value; }
        public int IdCadete { get => idCadete; set => idCadete = value; }
    
}
