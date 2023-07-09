namespace LIN.Controls;


public static class ImageEncoder
{


    /// <summary>
    /// Retroa una imagen
    /// </summary>
    public static ImageSource Decode(byte[] bytes, string @default = "ask_red.png")
    {

        try
        {

            var base64 = Convert.ToBase64String(bytes);
            byte[] newBytes = Convert.FromBase64String(base64);

            MemoryStream ms1 = new(newBytes);
            ImageSource newImage = ImageSource.FromStream(() => ms1);
            return newImage;

        }
        catch
        {
            return ImageSource.FromFile(@default);
        }


    }



    /// <summary>
    /// Retroa una imagen
    /// </summary>
    public static ImageSource Decode(string inputString)
    {
        byte[] NewBytes = Convert.FromBase64String(inputString);

        MemoryStream ms1 = new(NewBytes);
        ImageSource NewImage = ImageSource.FromStream(() => ms1);

        return NewImage;
    }



    /// <summary>
    /// Convierte una imagen a Base64
    /// </summary>
    /// <param name="image">Imagen a convertir</param>
    public static async Task<byte[]> GetBytes(this Image image)
    {
#if ANDROID
        return await OnAndroid.ImageEncoder.GetBytes(image);
#elif WINDOWS
        return await OnWindows.ImageBytes.GetBytes(image);
#else
        return await Task.Run(Array.Empty<byte>);
#endif
    }


}
