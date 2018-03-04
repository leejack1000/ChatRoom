using UnityEngine;
using System.Collections;

public class Example_Socket : MonoBehaviour
{
    public string ip = "127.0.0.1";
    public int port = 8888;

    private SocketMgr mSocketMgr;

    void Start()
    {
        mSocketMgr = new SocketMgr();
    }

    public void OnClickConnect()
    {
        Debug.Log("OnClickConnect");
        mSocketMgr.Connect(ip, port);
    }

    public void OnClickClose()
    {
        mSocketMgr.Close();
    }

    public void OnClickSend()
    {
        Debug.Log("OnClickSend");
        mSocketMgr.SendServer("{Test:123456}");
    }
}