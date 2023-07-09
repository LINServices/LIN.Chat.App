
namespace LIN.Controls.UI
{

    public class Label : Microsoft.Maui.Controls.Label
    {

        //======= EVENTOS =======//


        /// <summary>
        /// Evento Click sobre el control
        /// </summary>
        public event EventHandler<EventArgs>? Clicked;


        /// <summary>
        /// Cuando el mause entra en el control
        /// </summary>
        public event EventHandler<PointerEventArgs>? MouseEnter;


        /// <summary>
        /// Cuando el mause sale de el control
        /// </summary>
        public event EventHandler<PointerEventArgs>? MouseLeave;


        /// <summary>
        /// Cuando el mause se mueve sobre el control
        /// </summary>
        public event EventHandler<PointerEventArgs>? MouseMove;




        /// <summary>
        /// Constructor
        /// </summary>
        public Label()
        {
            base.FontFamily = "OpenSansRegular";

            // Eventos
            SetClickGesture();
            SetMauseEnterGesture();
            SetMauseLeaveGesture();
            SetMauseMoveGesture();
        }



        //======= Pone los eventos =======//


        /// <summary>
        /// Pone el evento click
        /// </summary>
        private void SetClickGesture()
        {
            // Evento click
            var gesture = new TapGestureRecognizer() { NumberOfTapsRequired = 1 };
            gesture.Tapped += DispClick;
            base.GestureRecognizers.Add(gesture);
        }



        /// <summary>
        /// Permite cambiar el texto del label y lo hace visible
        /// </summary>
        /// <param name="text"></param>
        public void Show(string text, Color? color = null)
        {
            IsVisible = true;
            Text = text;
            if (color != null)
                TextColor = color;
        }


        /// <summary>
        /// Pone el evento de mause entrando al control
        /// </summary>
        private void SetMauseEnterGesture()
        {
            // Evento click
            var gesture = new PointerGestureRecognizer();
            gesture.PointerEntered += DispMouseEnter;
            GestureRecognizers.Add(gesture);
        }



        /// <summary>
        /// Pone el evento mause saliendo del control
        /// </summary>
        private void SetMauseLeaveGesture()
        {
            // Evento click
            var gesture = new PointerGestureRecognizer();
            gesture.PointerExited += DispMouseLeave;
            GestureRecognizers.Add(gesture);
        }



        /// <summary>
        /// Pone el evento mause moviendo dentro del control
        /// </summary>
        private void SetMauseMoveGesture()
        {
            // Evento click
            var gesture = new PointerGestureRecognizer();
            gesture.PointerMoved += DispMouseMove;
            GestureRecognizers.Add(gesture);
        }




        //======= Disparador de eventos =======//



        /// <summary>
        /// Gesture disparer: Mause Moviendose
        /// </summary>
        private void DispMouseMove(object? sender, PointerEventArgs e) => MouseMove?.Invoke(this, e);



        /// <summary>
        /// Gesture disparer: Mause saliendo
        /// </summary>
        private void DispMouseLeave(object? sender, PointerEventArgs e) => MouseLeave?.Invoke(this, e);



        /// <summary>
        /// Gesture disparer: Mause entrando
        /// </summary>
        private void DispMouseEnter(object? sender, PointerEventArgs e) => MouseEnter?.Invoke(this, e);



        /// <summary>
        /// Gesture disparer: Click
        /// </summary>
        private void DispClick(object? sender, EventArgs e) => Clicked?.Invoke(this, new());


    }

}
