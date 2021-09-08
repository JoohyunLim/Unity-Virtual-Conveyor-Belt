using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//컨베이어벨트 오류알림
public class Data2 : MonoBehaviour
{
    public string eventName = "getError";
    public static string occurationTime = "";
    public static string message = "";
    public static string status;
    jsonClass2 errorData = new jsonClass2();

    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    { 
        errorData.eventName = eventName;
        errorData.occurationTime = occurationTime;
        errorData.message = message;
        status = JsonUtility.ToJson(errorData);
        print(status);
    }


}