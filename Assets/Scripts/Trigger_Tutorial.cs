using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Trigger_Tutorial : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject pie;
    Tutorial tutorialScript;

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        tutorialScript = pie.GetComponent<Tutorial>();
    }

    void OnTriggerEnter(Collider Contact) 
    {
        if (Contact.tag == gameObject.tag) 
        {

            print("Dom krockade!!!!");
            tutorialScript.Collading();
        }
        else 
        { 
        
        }



    }
}
