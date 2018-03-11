using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;

public class ChatView : MonoBehaviour
{
    [SerializeField]
    private InputField IPInputField;

    [SerializeField]
    private InputField PortInputField;

    [SerializeField]
    private InputField NickNameInputField;

    [SerializeField]
    private Button ConnectButton;

    public event Action<string, int, string> OnConnectIP;

    void Awake()
    {
        ConnectButton.onClick.AddListener(OnClickConnect);
    }

    private void OnClickConnect()
    {
        OnConnect(IPInputField.text, Convert.ToInt32(PortInputField.text), NickNameInputField.text);
    }

    private void OnConnect(string ip, int port, string nickName)
    {
        if (OnConnectIP != null)
        {
            OnConnectIP(ip, port, nickName);
        }
    }

    public void SetDefaultIPAndPort(string ip, int port)
    {
        IPInputField.text = ip;
        PortInputField.text = port.ToString();
    }
}