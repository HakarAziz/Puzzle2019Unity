﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SubtleHints : MonoBehaviour
{
    public bool Seeing;
    public float ChangePosVariable;
    public int counter;

    public List<GameObject> Pieces2 = new List<GameObject>();
    public List<Vector3> StartPos2 = new List<Vector3>();
    public List<Quaternion> Rot2 = new List<Quaternion>();

    PuzzelScript puzzelScript; //imports the puzzelScript


    // Start is called before the first frame update
    IEnumerator Start()
    {
        counter = 2;
        Seeing = true;
        ChangePosVariable = 1.0F;
        puzzelScript = GetComponent<PuzzelScript>(); //Gets component from the PuzzelScript
        yield return new WaitForEndOfFrame();
        foreach (GameObject s in puzzelScript.Pieces) //Gets the list with puzzel pieces from puzzel Script and adds them to a new list 
        {
            Rot2.Add(s.transform.rotation);
            StartPos2.Add(s.transform.position);
            Pieces2.Add(s);
           
        }
        StartCoroutine(SubtleMove());//Start SubtleMove and executes it under several frames.
    }
    void Update()
    {
    }
    public void CounterIncrease()
    {
        counter++;
        ChangePosVariable = 1.0F;
    }

    public void NotOnPiece() //Checks when the hand is not on the puzzle piece (may be swapped to eyetracking)
    {
        Seeing = true;
        StartCoroutine(SubtleMove());
    }

    public void OnPiece() //Checks when the hand is on the Piece
    {
        Seeing = false;
    }

    IEnumerator SubtleMove() //The SubtleMove method, moves the piece a little bit after some seconds
    {
        while (Seeing == true)
        {
            if (ChangePosVariable == 1.0F) //starts the subtlehint after 3 seconds
            {
                ChangePosVariable = ChangePosVariable + 0.001F; //increases the ChangePosVariable for the movement
                yield return new WaitForSeconds(3); //after 3 seconds and then returns every element only once
            }
            else
            {
                if (Seeing == false) 
                {
                    break;
                }
                else {
                    Pieces2[counter].transform.position = ChangePosVariable * StartPos2[counter]; //Moves the piece 
                    Pieces2[counter].transform.rotation = Rot2[counter];

                    yield return new WaitForSeconds(1);
                    if (Seeing == false)
                    {
                        break;
                    }
                    else
                    {
                        Pieces2[counter].transform.position = StartPos2[counter]; //Moves the piece to the start position
                        Pieces2[counter].transform.rotation = Rot2[counter];
                        ChangePosVariable = ChangePosVariable + 0.001F;
                        yield return new WaitForSeconds(4);
                    }
                }
            }
            
        }
        
    }
}
