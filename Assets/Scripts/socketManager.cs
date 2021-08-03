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
            //print("FAILED TO CONNECT TO SERVER");
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
        //ws.Send(Data.status);
        // StartCoroutine("SockettoServer");

        try
        {
            ws.Send(Data.status);

            if(Data2.message != "")
            {
                ws.Send(Data2.status);
            }
            Data2.message = "";
            Data2.occurationTime = "";


            StartCoroutine("SockettoServer");
        }
        catch (Exception err)
        {
            print("FAILED TO CONNECT TO SERVER");
            //앱 알림 #3: 데이터 전송 실패
            Data2.message = "컨베이어벨트 데이터 전송에 실패하였습니다.";
            Data2.occurationTime = System.DateTime.Now.ToString("h:mm:ss tt");
        }
    }
}