namespace cadeteria.Models;

public class CadeteriaModel
{
    //relacion de compossicion con la clase cadete
        private string nombre;
        private string telefono;

        public string Nombre { get => nombre; set => nombre = value; }

        public string Telefono { get => telefono; set => telefono = value; }
         public List<CadeteModel> ListaCadete { get => listaCadete; set => listaCadete = value; }

        List<CadeteModel> listaCadete = new List<CadeteModel>(); 

        public CadeteriaModel(string name, string phone){
            this.Nombre = name;
            this.Telefono = phone; 
        }
}
