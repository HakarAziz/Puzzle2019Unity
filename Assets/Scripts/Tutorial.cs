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
        
        UpdateText.text = "Welcome to this tutorial !!";

        //Timer som jag inte fattar hur man gör skall sitta på 2 eller 3 sek

        UpdateText.text = "Try to grab the cube by squeezeing the cube with your thumb and index finger";

    }

    // Update is called once per frame
    void Update()
    {
        
    }


    public void GrabCube()
    {
        
        UpdateText.text = "You managed to grab the cube !!";


        //Timer som jag inte fattar hur man gör skall sitta på 2 eller 3 sek

        UpdateText.text = "Now try to place the cube on the plate";


    }

    public void Collading() 
    {
        UpdateText.text = "You managed to drop the cube on the plate";

        //Timer som jag inte fattar hur man gör skall sitta på 2 eller 3 sek

        UpdateText.text = "You passed the tutorial !!";
    }





}
