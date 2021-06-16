using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//쓰레기 자동 생성
public class InstantiateBottle : MonoBehaviour
{
    public GameObject Bottle;
    public GameObject Bottle_labeled;

    public GameObject Can_pepsi;
    public GameObject Can_beer;
    public GameObject Can_fanta;

    public GameObject Plate_glass;
    public GameObject Plate_plastic;
    public GameObject Plate_metal;
    public GameObject Plate_wood;
    public GameObject Plate_paper;

    public GameObject Mug;
    public GameObject Fork;
    public GameObject WineGlass;
    public GameObject Pen;
    public GameObject Scissors;
    public GameObject Bowl;
    public GameObject Knife;
    public GameObject Book;
    public GameObject Spoon;
    public GameObject Chopsticks;
    public GameObject Cream;
    public GameObject Straw;

    public GameObject etc;

    public float Timer = 5;
    public static bool inputNew = false;
    public static int classNumber;

    public static List<GameObject> Bottles = new List<GameObject>(); //Bottle prefab들을 담은 리스트
    public static List<GameObject> Cans = new List<GameObject>(); //Can prefab들을 담은 리스트
    public static List<GameObject> Plates = new List<GameObject>(); //Plate prefab들을 담은 리스트

    public static List<GameObject> Trash = new List<GameObject>();  //모든 쓰레기 prefab을 담은 리스트
   


    void Start()
    {
        Bottles.Add(Bottle);
        Bottles.Add(Bottle_labeled);

        Cans.Add(Can_pepsi);
        Cans.Add(Can_beer);
        Cans.Add(Can_fanta);

        Plates.Add(Plate_glass);
        Plates.Add(Plate_plastic);
        Plates.Add(Plate_metal);
        Plates.Add(Plate_wood);
        Plates.Add(Plate_paper);

        Trash.Add(Bottle);
        Trash.Add(Bottle_labeled);
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
        Trash.Add(Plate_metal);
        Trash.Add(Plate_wood);
        Trash.Add(Plate_paper);
        Trash.Add(Book);
        Trash.Add(Spoon);
        Trash.Add(Chopsticks);
        Trash.Add(Cream);
        Trash.Add(Straw);
        Trash.Add(etc);

    }

    void Update()
    {
        Timer -= Time.deltaTime;
        int trashIndex = Random.Range(0, 22); // Random.Range(0,gamobject 종류의 수)**
        float xpos = Random.Range(-0.2f, 0.2f);
        float angle = Random.Range(-50f, 50f);
        int canIndex = Random.Range(0, 3);
        int plateIndex = Random.Range(0, 5);
        Quaternion qRotation = Quaternion.Euler(angle, angle, angle);


        if (Timer <= 0f)
        {

            if (inputNew == true)
            {

                switch (classNumber)
                {
                                       
                    case 0:
                        print("INPUT NEW BOOK!");
                        Instantiate(Book, new Vector3(xpos, 1.3f, -7.0f), qRotation);
                        break;

                    case 1:
                        print("INPUT NEW BOTTLE!");
                        Instantiate(Bottles[1], new Vector3(xpos, 1.3f, -7.0f), qRotation);
                        break;

                    case 2:
                        print("INPUT NEW BOWL!");
                        Instantiate(Bowl, new Vector3(xpos, 1.3f, -7.0f), qRotation);
                        break;

                    case 3:
                        print("INPUT NEW CHOPSTICKS!");
                        Instantiate(Chopsticks, new Vector3(xpos, 1.3f, -7.0f), qRotation);
                        break;

                    case 4:
                        print("INPUT NEW CREAM!");
                        Instantiate(Cream, new Vector3(xpos, 1.3f, -7.0f), qRotation);
                        break;

                    case 5:
                        print("INPUT NEW STRAW!");
                        Instantiate(Straw, new Vector3(xpos, 1.3f, -7.0f), qRotation);
                        break;

                    case 6:
                        print("INPUT NEW FORK!");
                        Instantiate(Fork, new Vector3(xpos, 1.3f, -7.0f), qRotation);
                        break;

                    case 7:
                        print("INPUT NEW KNIFE!");
                        Instantiate(Knife, new Vector3(xpos, 1.3f, -7.0f), qRotation);
                        break;

                     case 8:
                        print("INPUT NEW MUG!");
                        Instantiate(Mug, new Vector3(xpos, 1.3f, -7.0f), qRotation);
                        break;

                    case 9:
                        print("INPUT NEW PEN!");
                        Instantiate(Pen, new Vector3(xpos, 1.3f, -7.0f), qRotation);
                        break;

                    case 10:
                        print("INPUT NEW PLATE!");
                        Instantiate(Plates[plateIndex], new Vector3(xpos, 1.3f, -7.0f), qRotation);
                        break;

                    case 11:
                        print("INPUT NEW SCISSORS!");
                        Instantiate(Scissors, new Vector3(xpos, 1.3f, -7.0f), qRotation);
                        break;

                    case 12:
                        print("INPUT NEW SPOON!");
                        Instantiate(Spoon, new Vector3(xpos, 1.3f, -7.0f), qRotation);
                        break;

                    case 13:
                        print("INPUT NEW CAN!");
                        Instantiate(Cans[canIndex], new Vector3(xpos, 1.3f, -7.0f), qRotation);
                        break;

                    case 14:
                        print("INPUT NEW WINE GLASS!");
                        Instantiate(WineGlass, new Vector3(xpos, 1.3f, -7.0f), qRotation);
                        break;

                    default:
                        print("INPUT NEW ETC!");
                        Instantiate(Trash[20], new Vector3(xpos, 1.3f, -7.0f), qRotation);
                        break;
                    

                }
                inputNew = false;
               
            }
            else
            {
                Instantiate(Plates[0], new Vector3(xpos, 1.3f, -7.0f), qRotation);

               // Instantiate(Trash[trashIndex], new Vector3(xpos, 1.3f, -7.0f), qRotation);
                 

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
