namespace cadeteria.Models;

public class ClienteModel : PersonaModel
{

    //clase hija que hereda de persona sus atributos que comparten
        private string datosReferencia;
        public string DatosReferencia { get => datosReferencia; set => datosReferencia = value; }

        public ClienteModel(int id, string name, string adress, string phone, string datosReferencia):base(id, name,adress,phone){
            this.Id = id;
            this.Nombre = name;
            this.Direccion = adress;
            this.Telefono = phone;
            this.DatosReferencia = datosReferencia;
        }
    
}
