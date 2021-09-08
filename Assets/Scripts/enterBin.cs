using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enterBin : MonoBehaviour
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

        if (col.tag == "Bin1")
        {
            Data.recyclingTrash += 1;
            Data.inputTrash += 1;
            //Data.recyclingRate = ((float)Data.recyclingTrash / (float)Data.inputTrash);

        } else if (col.tag == "Bin2"){
            Data.inputTrash += 1;
        }

    }
}
