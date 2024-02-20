namespace LIN.Allo.App.Components;


public static class ConversationsObserver
{

  public  static Dictionary<int, ConversationLocal> Data = [];
  static  Dictionary<int, List<IMessageChanger>> Trackers = [];



    public static void Suscribe(int conversation, IMessageChanger messageChanger)
    {

        Trackers.TryGetValue(conversation, out var trackers);

        if (trackers == null)
        {
            Trackers.Add(conversation,
            [
                messageChanger
            ]);
            return;
        }

        trackers.Add(messageChanger);

    }


    public static void UnSuscribe(IMessageChanger messageChanger)
    {

        foreach(var e in Trackers.Values)
        {
            e.RemoveAll(t => t == messageChanger);
        }
    }



    public static void Notification(int conversation)
    {

        Trackers.TryGetValue(conversation, out var trackers);

        if (trackers == null)
            return;

        foreach (var item in trackers)
            item.Change();
        
    }



    public static void Create(ConversationModel conversation)
    {

        Data.TryGetValue(conversation.ID, out var local);

        if (local == null)
        {
            Data.Add(conversation.ID, new()
            {

                Conversation = conversation,
                Messages = conversation.Mensajes ?? []
            }); ;
            return;
        }


    }


    public static void PushMessage(int conversation, MessageModel message)
    {

        Data.TryGetValue(conversation, out var local);

        Trackers.TryGetValue(conversation, out var trackers);

        if (local == null || trackers == null)
            return;
        

        var exist = local.Messages.Where(t=>t.Guid ==  message.Guid);

        if (exist.Any())
        {
            foreach (var item in exist)
                item.IsLocal = false;

            foreach (var tracker in trackers)
                tracker.Change();

            return;
        }


        local.Messages.Add(message);

        foreach (var tracker in trackers)
            tracker.Change();

    }




    public static ConversationLocal Get(int id)
    {
        Data.TryGetValue(id, out var local);
        return local;
    }


}

public class ConversationLocal
{


    public ConversationModel Conversation { get; set; } = null!;

    public List<MessageModel> Messages { get; set; } = [];


}


public interface IMessageChanger
{



    void Change();



}