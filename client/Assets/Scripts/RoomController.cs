using System;
using System.Collections.Generic;
using UnityEngine;

using Colyseus;

[Serializable]
class Message
{
    public string Data { get; set; }
    
    public Message() {}

    public Message(string msg)
    {
        Data = msg;
    }
}

[Serializable]
public class RoomController
{
    private static ColyseusClient client = new ColyseusClient("ws://localhost:2567");
    private static ColyseusRoom<RoomState> room;

    private static IDisposable disposeCallback1;
    private static IDisposable disposeCallback2;
    
    public static async void JoinOrCreateRoom()
    {
        Dictionary<string, object> roomOptionsDictionary = new Dictionary<string, object>();
        // Populate an options dictionary with custom options provided elsewhere
        var options = new Dictionary<string, object>();
        foreach (var option in roomOptionsDictionary) options.Add(option.Key, option.Value);
        
        room = await client.JoinOrCreate<RoomState>("my_room", options);
        disposeCallback1 = room.OnMessage<Message>("up", obj =>
        {
            Debug.Log($"Msg Callback 1 {obj.Data}");
        });
        
        disposeCallback2 = room.OnMessage<Message>("up", obj =>
        {
            Debug.Log($"Msg Callback 2 {obj.Data}");
        });
        
        Debug.Log($"{room.Id} <- room");
    }

    public static async void SendMessage()
    {
        await room.Send("up", new Message($"{room.SessionId} has sent a message at {DateTime.Now.ToString()}!"));
    }

    public static void DisposeMsgCallback()
    {
        Debug.Log($"Disposing message callback 1...");
        disposeCallback1.Dispose();
    }
}
