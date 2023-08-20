using LIN.Access.Inventory.Controllers;


namespace LIN.UI.Views.Inventorys;

public partial class Index : ContentPage
{

    /// <summary>
    /// Lista de modelos
    /// </summary>
    private List<InventoryDataModel> Modelos { get; set; } = new();



    /// <summary>
    /// Lista de los controles
    /// </summary>
    private List<Controls.Inventory> Controles { get; set; } = new();



    private InventoryAccessHub? ActualHub { get; set; }


    /// <summary>
    /// Constructor
    /// </summary>
    public Index()
    {
        InitializeComponent();
        Reload();
        Appearing += AppearingEvent;
    }



    private void AppearingEvent(object? sender, EventArgs e)
    {
        AppShell.ActualPage = this;
    }








    /// <summary>
    /// Operacion de cargar
    /// </summary>
    public async void Reload()
    {
        // Prepara la vista de carga
        PrepareChargeView();
        content.Clear();
        await Task.Delay(100);



        // Rellena los datos
        var dataRes = await RetrieveData();

        // Comprueba si se rellenaron los datos
        if (!dataRes)
        {
            ShowInfo("Hubo un error");
            return;
        }

        // Carga los controles
        BuildControls(Modelos);

        // Carga los controles a la vista
        RenderControls(Controles);

        // Muestra el mensaje
        indicador.Hide();
        lbInfo.Show();

        Calculate();
    }



    /// <summary>
    /// Obtiene informacion desde el servidor
    /// </summary>
    private async Task<bool> RetrieveData()
    {
        // Items
        var response = await Inventories.ReadAll(Session.Instance.Token);

        // Analisis de respuesta
        if (response.Response != Responses.Success)
            return false;

        // Rellena los items
        Modelos = response.Models.OrderBy(model => model.Nombre).ToList();
        return true;

    }



    /// <summary>
    /// Renderiza los controles a la vista
    /// </summary>
    private async void RenderControls(List<Controls.Inventory> lista)
    {

        // Vacia los elementos
        content.Clear();

        // Mensaje
        ShowQuantityInfo(lista.Count);

        // Agrega los controles
        int counter = 0;
        foreach (var control in lista)
        {
            RenderOneControl(control);
            counter++;
            if (counter == 50)
            {
                await Task.Delay(100);
                counter = 0;
            }
        }

    }



    /// <summary>
    /// Renderiza los controles a la vista
    /// </summary>
    private void RenderOneControl(Controls.Inventory control)
    {
        control.Show();
        content.Add(control);
    }



    /// <summary>
    /// Construlle los controles apartir de una lista de modelos
    /// </summary>
    private void BuildControls(List<InventoryDataModel> lista)
    {

        // Limpia los controles
        Controles.Clear();

        // Agrega los controles
        foreach (var model in lista)
        {
            var control = BuildOneControl(model);
            Controles.Add(control);
        }

    }



    /// <summary>
    /// Renderiza un control
    /// </summary>
    private Controls.Inventory BuildOneControl(InventoryDataModel modelo)
    {
        var control = new Controls.Inventory(modelo ?? new());
        control.Clicked += (sender, e) =>
        {
            ActualHub?.Dispose();
            var page = new Products.Index(control.Modelo, control.Modelo.Nombre);
            ActualHub = page.HubConnection;
            page.Show();
        };
        return control;
    }



    /// <summary>
    /// Agrega un nuevo modelo (Cache y vista)
    /// </summary>
    public void AppendModel(InventoryDataModel modelo)
    {
        // Modelo nulo
        if (modelo == null)
            return;

        // Cuenta si existen elementos
        var count = Modelos.Where(element => element.ID == modelo.ID).Count();

        if (count > 0)
            return;

        // Agrega el nuevo modelo
        Modelos.Add(modelo);

        // Nuevo control
        var control = BuildOneControl(modelo);
        Controles.Add(control);
        RenderOneControl(control);

        // Nuevo mensaje
        ShowInfo($"Se agrego a '{modelo.Nombre}' a la lista.");

    }



    /// <summary>
    /// Prepara la vista de carga
    /// </summary>
    private void PrepareChargeView()
    {
        indicador.Show();
        lbInfo.Hide();
        content.Clear();
        cardInventarios.Contenido = $"0";
        cardInventarios.ChartText = "Cargando...";
    }



    /// <summary>
    /// Muestra un mensaje de informacion
    /// </summary>
    private void ShowInfo(string message)
    {
        indicador.Hide();
        lbInfo.Show();
        lbInfo.Text = message ?? "";
    }



    /// <summary>
    /// Muestra un mensaje de informacion de cantidad
    /// </summary>
    private void ShowQuantityInfo(int cantidad)
    {
        // No hay elementos
        if (cantidad <= 0)
        {
            ShowInfo("No hay ningun inventario asociado");
            return;
        }

        // Solo uno
        else if (cantidad == 1)
        {
            ShowInfo("Hay 1 inventario asociado");
            return;
        }

        // Mas de uno
        ShowInfo($"Hay {cantidad} inventarios asociados");

    }







    //******** Eventos ********//



    /// <summary>
    /// Boton de agregar
    /// </summary>
    private void btnAdd_Clicked(object sender, EventArgs e)
    {
        new AddInventory().Show();
    }



    private void Calculate()
    {
        cardInventarios.Contenido = $"{Modelos.Count}";
        cardInventarios.ChartText = $"{Modelos.Where(T => T.Creador == Session.Instance.Informacion.ID).Count()} eres fundador";
    }



    /// <summary>
    /// Boton de actualizar
    /// </summary>
    private void btnUpdate_Clicked(object sender, EventArgs e)
    {
        Reload();
    }


}