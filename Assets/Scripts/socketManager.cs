using UnityEngine;
using WebSocketSharp;
using System.Collections;
using System;


public class socketManager : MonoBehaviour
{
    WebSocket ws;

    private void Start()
    {
        Debug.Log("start");
        ws = new WebSocket("ws://3.37.86.169:8080");

        try
        {
            ws.Connect();
            ws.OnMessage += (sender, e) =>
            { 
                Debug.Log("서버와 연결되었습니다.");
            };
            StartCoroutine("SockettoServer");
        }
        catch (Exception err)
        {
            print(err.ToString());
            print("FAILED TO CONNECT TO SERVER");
            //+서버에게 오류메세지 전송
        }
 

        /*
        ws.Connect();
        ws.OnMessage += (sender, e) =>
        {
            //  Debug.Log("Message Received from " + ((WebSocket)sender).Url + ", Data : " + e.Data);
            Debug.Log("서버와 연결되었습니다.");
        };
        StartCoroutine("SockettoServer");
        */
    }
    private void Update()
    {
        if (ws == null)
        {
            return;
        }


    }
    private IEnumerator SockettoServer()
    {
        yield return new WaitForSeconds(1f);
        ws.Send(Data.status);
        StartCoroutine("SockettoServer");
    }
}