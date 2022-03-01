using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;


public class Zone_Trigger_B : MonoBehaviour
{
    public Renderer rend;
    public GameObject puzzle_piece;
    public GameObject pie;
    public GameObject zones;
    PuzzelScript_B puzzelScript;
    CheckPieceScript checkPieceScript;
    InOrder inorder;


    [Header("Disable Piece")]
    public UnityEvent pcs;


    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        puzzelScript = pie.GetComponent<PuzzelScript_B>();
        inorder = zones.GetComponent<InOrder>();
    }

    void OnTriggerEnter(Collider other)
    {
        print("före");
        if (CheckPieceScript.grab_object == false)
        {
            print("efter");
            if (other.tag == gameObject.tag)  //Checks if the correct piece is in the correct spot and deletes the zone
            {
                print("hej igen");
                puzzelScript.RightPiece(other.gameObject);
                gameObject.SetActive(false);
                inorder.ActivateZones();
                pcs.Invoke();

            }
            else
            {
                puzzelScript.ChangePos(other.gameObject);
            }
        }
        else
        {
            print("Hoppas att det funkar");
        }

    }
}


