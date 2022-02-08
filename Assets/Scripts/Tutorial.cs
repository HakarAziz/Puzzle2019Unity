using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;
using System.Timers;


public class Tutorial : MonoBehaviour
{

    public Text UpdateText;


    // Start is called before the first frame update
    void Start()
    {
        UpdateText.text = "Welcome to this tutorial!";
        Invoke("UpdateText1", 5f);       
    }

    // Update is called once per frame
    void Update()
    {
    }

    public void GrabCube()
    { 
        UpdateText.text = "You managed to grab the cube!";
        Invoke("UpdateText2", 2f);
    }

    public void Colliding() 
    {
        UpdateText.text = "You managed to drop the cube on the plate";
        Invoke("UpdateText3", 2f);
    }

    void UpdateText1()
    {
        UpdateText.text = "Try to grab the cube by squeezeing the cube with your thumb and index finger";
    }

    void UpdateText2()
    {
        UpdateText.text = "Now try to place the cube on the plate";
    }

    void UpdateText3()
    {
        UpdateText.text = "You passed the tutorial!";
    }

}
