using System.Collections.Generic;
using UnityEngine;

using System;
using Colyseus;

public class ButtonHandler : MonoBehaviour
{
    public async void JoinOrCreateRoom()
    {
        Debug.Log("clicked");
        RoomController.JoinOrCreateRoom();
    }

    public async void SendAcknowledgment()
    {
        RoomController.SendMessage();
    }
    
    public async void DisposeMessageCallback()
    {
        RoomController.DisposeMsgCallback();
    }
}
