using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;


public class Zone_Trigger : MonoBehaviour
{
    public Renderer rend;
    public GameObject puzzle_piece;
    public GameObject pie;
    public GameObject zones;
    PuzzelScript puzzelScript;
    InOrder inorder;




    // Start is called before the first frame update
    void Start()
    {

        /*rend = GetComponent<Renderer>();
        rend.enabled = false;   //Turns the visibility of the object off
        */


     

        

    }

    // Update is called once per frame
    void Update()
    {
        puzzelScript = pie.GetComponent<PuzzelScript>();
        inorder = zones.GetComponent<InOrder>();



    }

    

    void OnTriggerEnter(Collider other)
    {

        

        if (other.tag == gameObject.tag)  //Checks if the correct piece is in the correct spot and deletes the zone
        {
            
            print(gameObject.tag + ", Right piece");
            //Destroy(gameObject);
            gameObject.SetActive(false);
            


            inorder.ActivateZones();

           

            puzzelScript.RightPiece(other.gameObject);

        }
        else
        {
            print("Wrong Piece");
            puzzelScript.ChangePos(other.gameObject);
        }
        
    }
}


