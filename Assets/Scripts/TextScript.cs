using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TextScript : MonoBehaviour
{
    public Text ConvText;
    //public Text ConvText2;

    // Start is called before the first frame update
    void Start()
    {
        ConvText.text = "Camera Controls: \n\nOrbit: Right Mouse Button \nZoom: Scroll Wheel \nPan: Middle Mouse Button";
      //  ConvText2.text = "Camera Controls: \n\nMove: WASD \nJump: Spacebar \nLook: Move Mouse";
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
