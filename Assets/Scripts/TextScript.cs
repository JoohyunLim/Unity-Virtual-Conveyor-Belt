using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TextScript : MonoBehaviour
{
    public Text ConvText;

    // Start is called before the first frame update
    void Start()
    {
        ConvText.text = "Camera Controls: \n\nOrbit: Right Mouse Button \nZoom: Scroll Wheel \nPan: Middle Mouse Button";
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
