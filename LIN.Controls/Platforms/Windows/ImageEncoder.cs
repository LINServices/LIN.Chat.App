using Microsoft.UI.Xaml.Media.Imaging;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Graphics.Imaging;
using Windows.Storage.Streams;

namespace LIN.Controls.OnWindows;


internal class ImageBytes
{


    /// <summary>
    /// Obtiene el array de bytes de una imagen
    /// </summary>
    /// <param name="image">Imagen</param>
    public static async Task<byte[]> GetBytes(Image image)
    {
        // Control convertido en WinUI
        Microsoft.UI.Xaml.Controls.Image control = (Microsoft.UI.Xaml.Controls.Image)(image?.Handler?.PlatformView ?? new());

        // Convierte a la base 64
        byte[] but = await GetBytes(control);
        return but ?? Array.Empty<byte>();

    }



    /// <summary>
    /// Renderiza el bitmap
    /// </summary>
    private static async Task<byte[]> GetBytes(Microsoft.UI.Xaml.Controls.Image control)
    {
        // X / Y
        int x = (int)control.RenderSize.Height;
        int y = (int)control.RenderSize.Width;
        control.UpdateLayout();

        // Renderiza
        var bitmap = new RenderTargetBitmap();
        await bitmap.RenderAsync(control, y * 3, x * 3);
        return await GetBytes(bitmap);
    }



    /// <summary>
    /// Obtiene los pixeles
    /// </summary>
    /// <param name="bitmap">Bitmap</param>
    private static async Task<byte[]> GetBytes(RenderTargetBitmap bitmap)
    {
        var bytes = (await bitmap.GetPixelsAsync()).ToArray();
        int h = bitmap.PixelHeight;
        int w = bitmap.PixelWidth;
        return await GetBytes(bytes, (uint)w, (uint)h);
    }



    /// <summary>
    /// Obtiene el array de bytes
    /// </summary>
    private static async Task<byte[]> GetBytes(byte[] image, uint height, uint width, double dpiX = 96, double dpiY = 96)
    {
        // encode image
        var encoded = new InMemoryRandomAccessStream();
        var encoder = await BitmapEncoder.CreateAsync(BitmapEncoder.PngEncoderId, encoded);
        encoder.SetPixelData(BitmapPixelFormat.Bgra8, BitmapAlphaMode.Straight, height, width, dpiX, dpiY, image);
        await encoder.FlushAsync();
        encoded.Seek(0);

        // read bytes
        var bytes = new byte[encoded.Size];
        await encoded.AsStream().ReadAsync(bytes, 0, bytes.Length);

        // create base64
        return bytes;
    }


}
