namespace cadeteria.Models;

public class CadeteModel : PersonaModel
{
    //clase hija que hereda de persona sus atributos que comparten
        //relacion de agregacion con los pedidos;
        private List<PedidoModel> listpedido = new List<PedidoModel>();


        internal List<PedidoModel> Listpedido { get => listpedido; set => listpedido = value; }

        public CadeteModel(int id, string name, string adress, string phone):base(id,name,adress,phone){
            this.Id = id;
            this.Nombre = name;
            this.Direccion = adress;
            this.Telefono = phone;
        }

        /*public  CadeteModel(){

        }*/


        public string jornalACobrar(List<PedidoModel> pedidos){
            //sacar el calculo de cada PedidoModel realizado por 300 pesos

            return "la jornada laboral es de ";
        }

        public void get(List<PedidoModel> pedidos){
            //sacar el calculo de cada PedidoModel realizado por 300 pesos
            foreach (var item in pedidos)
            {
                Console.WriteLine("estado del PedidoModel {0} es {1}",item.Numero,item.Estado);
            }
            
        }



    public List<CadeteModel> get()
    {
            List<CadeteModel> lista = new List<CadeteModel>();
            string path = @"registros\Cadete.csv";
            CadeteModel aux = new CadeteModel(0,"","","");

            try
            {
                if(File.Exists(path)){
                    string[] lines = File.ReadAllLines(path);
                    foreach (string line in lines)
                    {
                        string[] array = line.Split(",");
                        aux.Id = Convert.ToInt32(array[0]);
                        aux.Nombre = array[1];
                        aux.Direccion = array[2];
                        aux.Telefono = array[3];
                        lista.Add(aux);                       
                    }
                return lista;
                }
                return lista;
            }
            catch (System.Exception ex)
            {
                //Logger.Error(ex.Message);
                return lista;
            }

            return lista;
        }
}
