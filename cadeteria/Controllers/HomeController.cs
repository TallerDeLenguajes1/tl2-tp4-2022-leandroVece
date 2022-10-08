using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using cadeteria.Models;


namespace cadeteria.Controllers;

public class HomeController : Controller
{
    private readonly ILogger<HomeController> _logger;
    DbModel db = new DbModel();

    public HomeController(ILogger<HomeController> logger)
    {
        _logger = logger;
    }

    
    public IActionResult Index()
    {

        db.Cadeteria1.ListaCadete = db.getCadete();
        db.ListaPedido1 = db.getDatepedidos(db.getDateCliente());
        return View(db);
    }

    public RedirectToActionResult delete(string Numero,int Id)
    {
        //con el valor que traigo de la vista separo de la lista el elemiento a eliminar y lo borro
        //el metodo de borrar es truncando el viejo archivo csv

        List<ClienteModel> clientes = db.getDateCliente().FindAll(x => x.Id != Id);
        List<PedidoModel> pedidos = db.getDatepedidos(clientes).FindAll(x=> x.Numero != Numero);

        db.deletePedido(pedidos);
        db.deleteCliente(clientes);

        Console.WriteLine(pedidos.Count);

        return RedirectToAction("Index");
    }

    [HttpPost]
    public IActionResult Index(string obj, string nombre,string direccion, string telefono,string referencia)
    {
        List<ClienteModel> listaC = db.getDateCliente();
        int idCliente = listaC[listaC.Count -1].Id +1;

        List<PedidoModel> listaP = db.getDatepedidos(db.getDateCliente());
        int idpedido = Convert.ToInt32(listaP[listaP.Count - 1].Numero) + 1;

        PedidoModel newPedido = new PedidoModel(idpedido.ToString(),obj,"pendiente");
        ClienteModel newCliente = new ClienteModel(idCliente,nombre,direccion,telefono,referencia);

        db.savePedido(newPedido,idCliente);
        db.saveCliente(newCliente);

        db.Cadeteria1.ListaCadete = db.getCadete();
        db.ListaPedido1 = db.getDatepedidos(db.getDateCliente());
        return View(db);
    }

    public IActionResult Privacy()
    {
        return View();
    }

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}
