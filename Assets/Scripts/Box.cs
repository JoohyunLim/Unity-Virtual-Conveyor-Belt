using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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
        if(col.gameObject.tag == "paperplate")
        {
            col.gameObject.transform.position = new Vector3(Random.Range(0.2f, 0.25f), transform.position.y, -1.68f);
        } else
        {
            col.gameObject.transform.position = new Vector3(Random.Range(-0.25f, -0.2f), transform.position.y, -1.68f);
        }
    }
}
