namespace LIN.Controls.UI;


public partial class InputImage : Grid
{


    //========== Eventos ==========//

    /// <summary>
    /// Evento cuando cambia la imagen seleccionada
    /// </summary>
    public event EventHandler<Events.ImageChanged>? ImageChanged;



    //========== Propiedades ==========//

    /// <summary>
    /// Obtiene la imagen actual
    /// </summary>
    public ImageSource Picture { get => picture.Source; }



    /// <summary>
    /// Obtiene si la imagen ya cambio
    /// </summary>
    public bool IsChanged { private set; get; } = false;



    /// <summary>
    /// Constructor
    /// </summary>
    public InputImage()
    {
        InitializeComponent();
    }




    /// <summary>
    /// Carga la imagen
    /// </summary>
    private async void LoadImageEvent(object sender, EventArgs e)
    {
        // Carga la imagen
        var loadImage = await OpenImage();
        if (loadImage == null)
            return;

        // Cambia las propiedades
        IsChanged = true;
        picture.Source = loadImage;

        // Envia el evento
        ImageChanged?.Invoke(this, new() { NewValue = picture?.Source });
    }


    /// <summary>
    /// Establece la imagen
    /// </summary>
    public void SetImage(byte[] source, string @default = "ask_red.png")
    {
        if (source.Length <= 0)
        {
            picture.Source = ImageSource.FromFile(@default);
            return;
        }


        picture.Source = LIN.Controls.ImageEncoder.Decode(source, @default);
    }



    /// <summary>
    /// Obtiene el array de bytes de la imagen
    /// </summary>
    /// <returns></returns>
    public async Task<byte[]> GetBytes()
    {

        try
        {

            var bites = await ImageEncoder.GetBytes(picture);
            return bites;
        }
        catch
        {

        }
        return Array.Empty<byte>();

    }


    /// <summary>
    /// Obtiene el array de bytes de la imagen
    /// </summary>
    /// <returns></returns>
    public async Task<byte[]> GetFileBytes()
    {

        try
        {

            var bites = await File.ReadAllBytesAsync(url);
            return bites;
        }
        catch
        {

        }
        return Array.Empty<byte>();

    }

    string url;


    /// <summary>
    /// Carga la imagen de perfil
    /// </summary>
    private async Task<ImageSource?> OpenImage()
    {

        // Carga el archivo
        var result = await FilePicker.Default.PickAsync();

        // analisa el resultado
        if (result == null)
            return null;


        // Extension del archivo
        if (result.FileName.EndsWith("jpg", StringComparison.OrdinalIgnoreCase) || result.FileName.EndsWith("png", StringComparison.OrdinalIgnoreCase))
        {

            url = result.FullPath;

            FileInfo dd = new(result.FullPath);
            var stream = dd.OpenRead();

            MemoryStream ms = new();
            stream.CopyTo(ms);
            var bytes = ms.ToArray();


            MemoryStream ms1 = new(bytes);
            ImageSource NewImage = ImageSource.FromStream(() => ms1);

            return NewImage;


        }


        return null;

    }


}