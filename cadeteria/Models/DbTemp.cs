
namespace cadeteria.Models;

public class DbModel
    {
            private List<PedidoModel> ListaPedido;
            private CadeteriaModel Cadeteria;

            public List<PedidoModel> ListaPedido1 { get => ListaPedido; set => ListaPedido = value; }
            public CadeteriaModel Cadeteria1 { get => Cadeteria; set => Cadeteria = value; }

         public DbModel(){
                ListaPedido = new List<PedidoModel>();
                Cadeteria = new CadeteriaModel("Eternos","6542112");
        }



        public void savePedido(PedidoModel obj,int id){

            string path = @"csv\pedido.csv";
                            
            try
            {
                if(!File.Exists(path)){

                    FileStream Archivo = new FileStream(path, FileMode.OpenOrCreate);
                        using (StreamWriter strWrite = new StreamWriter(Archivo))
                        {
                            strWrite.WriteLine("{0},{1},{2},{3}",obj.Numero, obj.Obs, obj.Estado, id);
                            strWrite.Close();
                        }              
                }
                else
                {
                    FileStream Archivo = new FileStream(path, FileMode.Append);
                        using (StreamWriter strWrite = new StreamWriter(Archivo))
                        {
                            strWrite.WriteLine("{0},{1},{2},{3}",obj.Numero, obj.Obs, obj.Estado, id);
                            strWrite.Close();
                        }
                }
                        
            }
            catch (System.Exception ex)
            {
                //Logger.Error(ex.Message);            
            }
        }

        public void saveCliente(ClienteModel obj){

            string path = @"csv\cliente.csv";
                            
            try
            {
                if(!File.Exists(path)){

                    FileStream Archivo = new FileStream(path, FileMode.OpenOrCreate);
                        using (StreamWriter strWrite = new StreamWriter(Archivo))
                        {
                            strWrite.WriteLine("{0},{1},{2},{3},{4}",obj.Id, obj.Nombre, obj.Direccion, obj.Telefono, obj.DatosReferencia);
                            strWrite.Close();
                        }              
                }
                else
                {
                    FileStream Archivo = new FileStream(path, FileMode.Append);
                        using (StreamWriter strWrite = new StreamWriter(Archivo))
                        {
                            strWrite.WriteLine("{0},{1},{2},{3},{4}",obj.Id, obj.Nombre, obj.Direccion, obj.Telefono, obj.DatosReferencia);
                            strWrite.Close();
                        }
                }
                        
            }
            catch (System.Exception ex)
            {
                //Logger.Error(ex.Message);            
            }
        }

        public void deleteCliente(List<ClienteModel> clientes){

            string path = @"csv\cliente.csv";
                            
            try
            {
                if(File.Exists(path)){

                    FileStream Archivo = new FileStream(path, FileMode.Truncate);
                        using (StreamWriter strWrite = new StreamWriter(Archivo))
                        {
                            foreach (var item in clientes)
                            {
                                strWrite.WriteLine("{0},{1},{2},{3},{4}",item.Id, item.Nombre, item.Direccion, item.Telefono, item.DatosReferencia);  
                            }
                                strWrite.Close();
                        }              
                }
                        
            }
            catch (System.Exception ex)
            {
                //Logger.Error(ex.Message);            
            }
        }

        public void deletePedido(List<PedidoModel> lista){

            string path = @"csv\pedido.csv";
                            
            try
            {
                if(File.Exists(path)){

                    FileStream Archivo = new FileStream(path, FileMode.Truncate);
                        using (StreamWriter strWrite = new StreamWriter(Archivo))
                        {
                            foreach (var item in lista)
                            {
                                strWrite.WriteLine("{0},{1},{2},{3}",item.Numero, item.Obs, item.Estado, item.Cliente.Id);
                            }
                                strWrite.Close();  
                        }              
                }
                        
            }
            catch (System.Exception ex)
            {
                //Logger.Error(ex.Message);            
            }
        }


        public List<CadeteModel> getCadete(){  

            string path = @"csv\cadete.csv";
            List<CadeteModel> lista = new List<CadeteModel>();
            try
            {
                if(File.Exists(path)){
                    string[] lines = File.ReadAllLines(path);
                    foreach (string line in lines)
                    {
                        CadeteModel aux = new CadeteModel(0,"","","");
                        string [] array = line.Split(',');
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
        }

        public List<PedidoModel> getDatepedidos(List<ClienteModel>clientes){
            
            string path = @"csv\pedido.csv";
            List<PedidoModel> lista = new List<PedidoModel>();
            try
            {
                if(File.Exists(path)){
                    string[] lines = File.ReadAllLines(path);
                    foreach (string line in lines)
                    {
                        PedidoModel aux = new PedidoModel("0","","");
                        string [] array = line.Split(',');
                        aux.Numero = array[0];
                        aux.Obs = array[1];
                        aux.Estado = array[2];
                        aux.Cliente = clientes.Find(x => (x.Id).ToString() == array[3]);
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
        }

        public List<ClienteModel> getDateCliente(){
            
            string path = @"csv\cliente.csv";
            List<ClienteModel> lista = new List<ClienteModel>();
            try
            {
                if(File.Exists(path)){
                    string[] lines = File.ReadAllLines(path);
                    foreach (string line in lines)
                    {
                        ClienteModel aux = new ClienteModel(0,"","","","");
                        string [] array = line.Split(',');
                        aux.Id = Convert.ToInt32(array[0]);
                        aux.Nombre = array[1];
                        aux.Direccion = array[2];
                        aux.Telefono = array[3];
                        aux.DatosReferencia = array[4];
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
        }

    }
