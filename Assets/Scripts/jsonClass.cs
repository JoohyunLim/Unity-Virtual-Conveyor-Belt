[System.Serializable]
public class jsonClass
{
    public string item; //컨베이어벨트 종류
    public int inputTrash; //배출되는 모든 쓰레기의 수 
    public int recyclingTrash; //재활용되는 쓰레기의 수
    public float recyclingRate; //재활용률
    public int uptime; //컨베이어 가동 시간
    public string eventName;
}
