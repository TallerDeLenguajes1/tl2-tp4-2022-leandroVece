namespace cadeteria.Models;

public class PersonaModel
{
    private int id;
        private string nombre,direccion,telefono;
    private string name;
    private string adress;
    private string phone;

    public PersonaModel(int id, string name, string adress, string phone)
    {
        this.id = id;
        this.name = name;
        this.adress = adress;
        this.phone = phone;
    }

    public int Id { get => id; set => id = value; }
        public string Nombre { get => nombre; set => nombre = value; }
        public string Direccion { get => direccion; set => direccion = value; }
        public string Telefono { get => telefono; set => telefono = value; }

    
}
