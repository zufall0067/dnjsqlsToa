using System.Collections;
using System.Collections.Generic;
using WebSocketSharp;
using System;
using System.Threading;
using System.Text;
using UnityEngine;

public class Client : MonoBehaviour
{
    private string IP = "127.0.0.1";
    private string PORT = "9090";

    private string SERVICE_NAME = "/Server";

    public WebSocketSharp.WebSocket m_Socket = null;

    private void Start()
    {
        try
        {
            m_Socket = new WebSocketSharp.WebSocket("ws://" + IP + ":" + PORT + SERVICE_NAME);
            m_Socket.OnMessage += Recv;
            m_Socket.OnClose += CloseConnet;
        }
        catch
        {
            
        }
    }

    public void Connect()
    {
        try
        {
            if (m_Socket == null || !m_Socket.IsAlive)
                m_Socket.Connect();
        }
        catch (Exception e)
        {
            Debug.Log(e.ToString());
        }
    }

    private void CloseConnet(object sender, CloseEventArgs e)
    {
        DisconnectServer();
    }

    public void DisconnectServer()
    {
        try
        {
            if (m_Socket == null)
                return;

            if (m_Socket.IsAlive)
                m_Socket.Close();
        }
        catch (Exception e)
        {
            Debug.Log(e.ToString());
        }
    }

    public void SendMessage(string msg)
    {
        if (!m_Socket.IsAlive)
            return;

        try
        {
            m_Socket.Send(Encoding.UTF8.GetBytes(msg));
        }
        catch
        {
            throw;
        }
    }
    
    public void Recv(object sender, MessageEventArgs e)
    {
        
        switch (sender.ToString())
        {
            case "EnemyMove":
                break;

            case "EnemyAttack":
                break;

            case "EnemyFisrtSkill":
                break;

            case "EnemySecondSkill":
                break;

            case "EnemyDead":
                break;

            default:
                break;
        }
    }

    private void OnApplicationQuit()
    {
        DisconnectServer();
    }
}
