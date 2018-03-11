using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Network;

public class ChatController : MonoBehaviour {

    public string ip = "127.0.0.1";
    public int port = 8888;

    [SerializeField]
    private ChatView ChatView;

    private Client Client;

    void Start()
    {
        ChatView.SetDefaultIPAndPort(ip, port);
        ChatView.OnConnectIP += OnConnect;
    }
    int i = 0;
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            Client.SendMessageToServer((i++).ToString());
        }
    }

    public void OnConnect(string ip, int port, string nickName)
    {
        Debug.Log(ip);
        Debug.Log(port);

        if (string.IsNullOrEmpty(nickName))
        {
            return;
        }

        Client = new Client();
        Client.ConnectToServer(ip, port);
    }
}
