using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SubtleHints : MonoBehaviour
{
    public bool isSubtle = false;
    public float timeDelay;



    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (isSubtle == false)
        {
            StartCoroutine(FlickerLight()); //using coroutine to give unity back control over the frames, want to keep this animation over several frames and not only one
        }   
    }


    IEnumerator FlickerLight()
    {
        isSubtle = true;
        this.gameObject.GetComponent<Light>().enabled = false;  //Object is still active in the scene but turn the light off
        timeDelay = Random.Range(0.01f, 0.2f);       // will wait for 0.01 seconds right now
        yield return new WaitForSeconds(timeDelay); //Sets the amount of time we have to wait for the lights

        this.gameObject.GetComponent<Light>().enabled = true;
        timeDelay = Random.Range(0.01f, 0.2f);
        yield return new WaitForSeconds(timeDelay);
        isSubtle=false;

    }
}
