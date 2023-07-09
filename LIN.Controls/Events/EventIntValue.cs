
namespace LIN.Controls.Events
{
    public class EventIntValue : EventArgs
    {
        public int OldValue { get; set; }
        public int NewValue { get; set; }
        public EventIntValue(int OldValue, int NewValue)
        {
            this.OldValue = OldValue;
            this.NewValue = NewValue;
        }
    }
}
