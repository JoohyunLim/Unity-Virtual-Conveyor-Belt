using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

//쓰레기 자동 생성
public class InstantiateBottle : MonoBehaviour
{
    public GameObject Bottle;
    public GameObject Bottle_labeled;
    public GameObject GlassBottle;

    public GameObject Can_pepsi;
    public GameObject Can_beer;
    public GameObject Can_fanta;

    public GameObject Plate_glass;
    public GameObject Plate_plastic;
    public GameObject Plate_metal;
    public GameObject Plate_wood;
    public GameObject Plate_paper;

    public GameObject Spoon_metal;
    public GameObject Spoon_plastic;
    public GameObject Spoon_wood;

    public GameObject Mug;
    public GameObject Fork;
    public GameObject WineGlass;
    public GameObject Pen;
    public GameObject Scissors;
    public GameObject Bowl;
    public GameObject Knife;
    public GameObject Book;
    public GameObject Chopsticks;
    public GameObject Cream;
    public GameObject Straw;

    public GameObject etc;

    public float Timer = 5;
    public static bool inputNew = false;
    public static int classNumber;
    int inputNumber = 1;

    public static List<GameObject> Bottles = new List<GameObject>(); //Bottle prefab들을 담은 리스트
    public static List<GameObject> Cans = new List<GameObject>(); //Can prefab들을 담은 리스트
    public static List<GameObject> Plates = new List<GameObject>(); //Plate prefab들을 담은 리스트
    public static List<GameObject> Spoons = new List<GameObject>(); //Spoon prefab들을 담은 리스트

    public static List<GameObject> Trash = new List<GameObject>();  //모든 쓰레기 prefab을 담은 리스트


    void Start()
    {
        //앱 알림 #1: 컨베이어벨트 시작
        Data2.message = "컨베이어벨트 작동이 시작되었습니다.";
        Data2.occurationTime = System.DateTime.Now.ToString("h:mm:ss tt");
         
        //서버로 시작 메세지 전송
        Bottles.Add(Bottle);
        Bottles.Add(Bottle_labeled);

        Cans.Add(Can_pepsi);
        Cans.Add(Can_beer);
        Cans.Add(Can_fanta);

        Plates.Add(Plate_glass);
        Plates.Add(Plate_plastic);
        Plates.Add(Plate_paper);
        Plates.Add(Plate_metal);
        Plates.Add(Plate_wood);

        Spoons.Add(Spoon_metal);
        Spoons.Add(Spoon_plastic);
        Spoons.Add(Spoon_wood);

        Trash.Add(Bottle);
        Trash.Add(Bottle_labeled);
        Trash.Add(GlassBottle);
        Trash.Add(Can_pepsi);
        Trash.Add(Can_beer);
        Trash.Add(Can_fanta);
        Trash.Add(Fork);
        Trash.Add(WineGlass);
        Trash.Add(Pen);
        Trash.Add(Scissors);
        Trash.Add(Bowl);
        Trash.Add(Knife);
        Trash.Add(Mug);
        Trash.Add(Plate_glass);
        Trash.Add(Plate_plastic);
       // Trash.Add(Plate_metal);
       // Trash.Add(Plate_wood);
        //Trash.Add(Plate_paper);
        Trash.Add(Book);
        Trash.Add(Spoon_metal);
        Trash.Add(Spoon_plastic);
        Trash.Add(Spoon_wood);
        Trash.Add(Chopsticks);
        Trash.Add(Cream);
        Trash.Add(Straw);
        Trash.Add(etc);
        }

    void Update()
    {
        Timer -= Time.deltaTime;
        int trashIndex = Random.Range(0, 23); // Random.Range(0,19gamobject 종류의 수)**
        float xpos = Random.Range(-0.2f, 0.2f);
        float angle = Random.Range(-50f, 50f);
        int canIndex = Random.Range(0, 3);
        int plateIndex = Random.Range(0, 5);
        int spoonIndex = Random.Range(0, 3);

        Quaternion qRotation = Quaternion.Euler(angle, angle, angle);
        
        //error alarm test : 스페이스키 누르면 에러메세지 전송
        if (Input.GetKeyDown(KeyCode.Space))
        {
            Data2.message = "컨베이어벨트에 오류가 발생했습니다.";
            Data2.occurationTime = System.DateTime.Now.ToString("h:mm:ss tt");
        }

        //숫자 누르면 씬 전환
        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            if (SceneManager.GetActiveScene().name != "glassPlateConveyor")
            {
                print("GLASSPLATE CONVEYOR로 전환합니다.");
                SceneManager.LoadScene("glassPlateConveyor");
              
            }

        }
        else if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            if (SceneManager.GetActiveScene().name != "petConveyor")
            {
                print("PET CONVEYOR로 전환합니다.");
                SceneManager.LoadScene("PetConveyor");
                
            }

        }
        else if (Input.GetKeyDown(KeyCode.Alpha3))
        {
            if (SceneManager.GetActiveScene().name != "metalSpoonConveyor")
            {
                print("METALSPOON CONVEYOR로 전환합니다.");
                SceneManager.LoadScene("metalSpoonConveyor");
            }

        }


        if (Timer <= 0f)
        {

            if (inputNew == true)
            {

                switch (classNumber)
                {
                                       
                    case 0:
                        print("INPUT #" +inputNumber+" NEW BOOK!");
                        Instantiate(Book, new Vector3(xpos, 1.3f, -7.0f), qRotation);
                        break;

                    case 20:
                        print("INPUT #" + inputNumber + " NEW PLASTIC BOTTLE!");
                        Instantiate(Bottles[1], new Vector3(xpos, 1.3f, -7.0f), qRotation);
                        break;

                    case 21:
                        print("INPUT #" + inputNumber + " NEW GLASS BOTTLE!");
                        Instantiate(GlassBottle, new Vector3(xpos, 1.3f, -7.0f), qRotation);
                        break;

                    case 2:
                        print("INPUT #" + inputNumber + " NEW BOWL!");
                        Instantiate(Bowl, new Vector3(xpos, 1.3f, -7.0f), qRotation);
                        break;

                    case 3:
                        print("INPUT #" + inputNumber + " CHOPSTICKS!");
                        Instantiate(Chopsticks, new Vector3(xpos, 1.3f, -7.0f), qRotation);
                        break;

                    case 4:
                        print("INPUT #" + inputNumber + " NEW CREAM!");
                        Instantiate(Cream, new Vector3(xpos, 1.3f, -7.0f), qRotation);
                        break;

                    case 5:
                        print("INPUT #" + inputNumber + " NEW STRAW!");
                        Instantiate(Straw, new Vector3(xpos, 1.3f, -7.0f), qRotation);
                        break;

                    case 6:
                        print("INPUT #" + inputNumber + " NEW FORK!");
                        Instantiate(Fork, new Vector3(xpos, 1.3f, -7.0f), qRotation);
                        break;

                    case 7:
                        print("INPUT #" + inputNumber + " NEW KNIFE!");
                        Instantiate(Knife, new Vector3(xpos, 1.3f, -7.0f), qRotation);
                        break;

                     case 8:
                        print("INPUT #" + inputNumber + " MUG!");
                        Instantiate(Mug, new Vector3(xpos, 1.3f, -7.0f), qRotation);
                        break;

                    case 9:
                        print("INPUT #" + inputNumber + " NEW PEN!");
                        Instantiate(Pen, new Vector3(xpos, 1.3f, -7.0f), qRotation);
                        break;

                    case 10:
                        print("INPUT #" + inputNumber + " NEW RANDOM PLATE!");
                        Instantiate(Plates[plateIndex], new Vector3(xpos, 1.3f, -7.0f), qRotation);
                        break;

                    case 11:
                        print("INPUT #" + inputNumber + " NEW SCISSORS!");
                        Instantiate(Scissors, new Vector3(xpos, 1.3f, -7.0f), qRotation);
                        break;

                    case 13:
                        print("INPUT #" + inputNumber + " NEW CAN!");
                        Instantiate(Cans[canIndex], new Vector3(xpos, 1.3f, -7.0f), qRotation);
                        break;

                    case 14:
                        print("INPUT #" + inputNumber + " NEW WINE GLASS!");
                        Instantiate(WineGlass, new Vector3(xpos, 1.3f, -7.0f), qRotation);
                        break;
                    case 18:
                        print("INPUT #" + inputNumber + " NEW GLASS PLATE!");
                        Instantiate(Plates[0], new Vector3(xpos, 1.3f, -7.0f), qRotation);
                        break;
                    case 19:
                        print("INPUT #" + inputNumber + " NEW PLASTIC PLATE!");
                        Instantiate(Plates[1], new Vector3(xpos, 1.3f, -7.0f), qRotation);
                        break;
                    case 30:
                        print("INPUT #" + inputNumber + " NEW METAL SPOON!");
                        Instantiate(Spoons[0], new Vector3(xpos, 1.3f, -7.0f), qRotation);
                        break;
                    case 31:
                        print("INPUT #" + inputNumber + " NEW PLASTIC SPOON!");
                        Instantiate(Spoons[1], new Vector3(xpos, 1.3f, -7.0f), qRotation);
                        break;
                    case 32:
                        print("INPUT #" + inputNumber + " NEW WOOD SPOON!");
                        Instantiate(Spoons[2], new Vector3(xpos, 1.3f, -7.0f), qRotation);
                        break;

                    default:
                        print("INPUT #" + inputNumber + " NEW ETC!");
                        Instantiate(etc, new Vector3(xpos, 1.3f, -7.0f), qRotation);
                        break;
                    

                }
                inputNew = false;
                inputNumber += 1;
               
            }
            else
            {
                if(SceneManager.GetActiveScene().name == "glassPlateConveyor")
                {
                    Instantiate(Plates[0], new Vector3(xpos, 1.3f, -7.0f), qRotation);  
                }
                else if(SceneManager.GetActiveScene().name == "petConveyor")
                {
                    Instantiate(Bottles[1], new Vector3(xpos, 1.3f, -7.0f), qRotation);
                }
                else if(SceneManager.GetActiveScene().name == "metalSpoonConveyor")
                {
                    Instantiate(Spoons[0], new Vector3(xpos, 1.3f, -7.0f), qRotation);
                }
                else
                {
                    Instantiate(Trash[trashIndex], new Vector3(xpos, 1.3f, -7.0f), qRotation);
                }
            }
            Timer = 5f;
        }
    }
    
    public static void getClass(string classNum)
    {
        classNumber = int.Parse(classNum);
        inputNew = true;
    }
}
