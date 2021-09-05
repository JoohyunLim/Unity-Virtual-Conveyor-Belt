using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Box : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnTriggerEnter(Collider col)
    {

        if (SceneManager.GetActiveScene().name == "glassPlateConveyor")
        {
            if (col.gameObject.tag == "Glassplate") //GlassPlate만 재활용
            {
                col.gameObject.transform.position = new Vector3(Random.Range(0.2f, 0.25f), transform.position.y, -1.68f);
            }
            else
            {
                col.gameObject.transform.position = new Vector3(Random.Range(-0.25f, -0.2f), transform.position.y, -1.68f);
            }
        }
        else if (SceneManager.GetActiveScene().name == "petConveyor") //Pet만 재활용
        {
            if (col.gameObject.tag == "Bottle")
            {
                col.gameObject.transform.position = new Vector3(Random.Range(0.2f, 0.25f), transform.position.y, -1.68f);
            }
            else
            {
                col.gameObject.transform.position = new Vector3(Random.Range(-0.25f, -0.2f), transform.position.y, -1.68f);
            }
        }
        else //재활용X, 모두 이물질로 분류
        {    
                col.gameObject.transform.position = new Vector3(Random.Range(-0.25f, -0.2f), transform.position.y, -1.68f);
        }

         
    }
}
