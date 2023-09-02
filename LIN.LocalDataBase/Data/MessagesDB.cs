using LIN.LocalDataBase.Models;
using LIN.Types.Communication.Models;
using SQLite;

namespace LIN.LocalDataBase.Data;

public class MessagesDB
{

    /// <summary>
    /// Base de datos
    /// </summary>
    SQLiteAsyncConnection? Database;








    /// <summary>
    /// Inicia la base de datos
    /// </summary>
    private async Task Init()
    {
        try
        {
            if (Database is not null)
                return;

            Database = new SQLiteAsyncConnection(Constants.DatabasePath, Constants.Flags);

            var result = await Database.CreateTableAsync<Message>();
        }
        catch (Exception ex)
        {
            System.Diagnostics.Debug.WriteLine("Exception en UserLocalDB: " + ex);
        }

    }




    /// <summary>
    /// Guarda un usuario
    /// </summary>
    public async Task Save(LIN.Types.Communication.Models.MessageModel modelo)
    {
        await Init();

        var message = new Message
        {
            Content = modelo.Contenido,
            Date = modelo.Time,
            ID = modelo.ID,
            Remitente = modelo.Remitente.Alias,
            Conversation = modelo.Conversacion.ID,
            RemitenteID = modelo.Remitente.ID
        };

        await Database!.InsertAsync(message);
    }



    /// <summary>
    /// Obtiene todos los usuarios
    /// </summary>
    public async Task<List<LIN.Types.Communication.Models.MessageModel>> Get(int conversacion)
    {
        await Init();

        var messages = await Database!.Table<Message>().Where(M => M.Conversation == conversacion).ToListAsync();


        List<MessageModel> Mensajes = new();
        foreach(var mess in messages)
        {
            Mensajes.Add(new()
            {
                Contenido = mess.Content,
                Conversacion = new()
                {
                    ID = mess.Conversation
                },
                ID = mess.ID,
                Remitente = new()
                {
                    Alias = mess.Remitente,
                    ID = mess.RemitenteID
                },
                Time = mess.Date,
               
            });
        }
        return Mensajes;

}



    public async Task Delete()
    {
        await Init();

        await Database!.Table<Message>().DeleteAsync(T => 1 == 1);

    }



}
