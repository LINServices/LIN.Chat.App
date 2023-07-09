using Android.Graphics;
using Android.Widget;

namespace LIN.Controls.OnAndroid
{

    /// <summary>
    /// Image Encoder
    /// </summary>
    internal class ImageEncoder
    {


        /// <summary>
        /// Convierte a base64
        /// </summary>
        public static async Task<byte[]> GetBytes(Microsoft.Maui.Controls.Image image)
        {

            // Control convertido en Android 
            ImageView control = (ImageView)(image?.Handler?.PlatformView ?? new());

            // Convierte la imagen
            Bitmap? bitmap = (control.Drawable as Android.Graphics.Drawables.BitmapDrawable)?.Bitmap;

            // Si es Null
            if (bitmap == null)
                return Array.Empty<byte>();


            // Compresion
            MemoryStream stream = new();
            await bitmap.CompressAsync(Bitmap.CompressFormat.Png, 70, stream);
            byte[] result = stream.ToArray();

            return result;
        }





        /// <summary>
        /// Convierte a base64
        /// </summary>
        public static async Task<string> ToBase64(Microsoft.Maui.Controls.Image image)
        {

            // Control convertido en Android 
            ImageView control = (ImageView)(image?.Handler?.PlatformView ?? new());

            // Convierte la imagen
            Bitmap? bitmap = (control.Drawable as Android.Graphics.Drawables.BitmapDrawable)?.Bitmap;

            // Si es Null
            if (bitmap == null)
                return "";


            // Compresion
            MemoryStream stream = new();
            await bitmap.CompressAsync(Bitmap.CompressFormat.Png, 30, stream);
            byte[] result = stream.ToArray();

            // Retorna
            return Convert.ToBase64String(result) ?? "";
        }


     

    }

}
