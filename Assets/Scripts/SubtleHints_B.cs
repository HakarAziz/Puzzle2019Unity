using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class SubtleHints_B : MonoBehaviour
{
    public bool Seeing;
    public bool test;
    public float ChangePosVariable;
    public float ColorIntensity;
    public int counter;
    public Material hej;
    public Color color;
    public int counter2;

    public List<GameObject> Pieces2 = new List<GameObject>();

    PuzzelScript_B puzzelScript; //imports the puzzelScript
    CheckPieceScript checkscript;



    // Start is called before the first frame update
    IEnumerator Start()
    {
        counter2 = 3;
        counter = 2;
        Seeing = true;
        test = false;
        ChangePosVariable = 1.0F;
        puzzelScript = GetComponent<PuzzelScript_B>(); //Gets component from the PuzzelScript
        yield return new WaitForEndOfFrame();
        foreach (GameObject s in puzzelScript.Pieces) //Gets the list with puzzel pieces from puzzel Script and adds them to a new list 
        {
            Pieces2.Add(s);

        }
        
        StartCoroutine(SubtleCube()); //Start SubtleCube and executes it under several frames.
    }
    void Update()
    {
        //checkscript = GetComponent<CheckPieceScript>();
    }
    public void CounterIncrease()
    {
        StopAllCoroutines(); //Stops all Coroutines before starting a new one
        hej = Pieces2[counter2].GetComponent<Renderer>().material;
        ColorIntensity = 0F;
        color = hej.color;
        color.a = ColorIntensity;
        hej.color = color;
        counter2 = counter2 + 2;
        counter = counter + 2;
        
        
        StartCoroutine(SubtleCube());
    }

    public void NotOnPiece() //Checks when the hand is not on the puzzle piece (may be swapped to eyetracking)
    {
        if (CheckPieceScript.ThisPiece == Pieces2[counter])
        {
            StopAllCoroutines(); //Stops all Coroutines before starting a new one
            StartCoroutine(SubtleCube());
            test = false;
            Seeing = true;

        }
        else
        {
            print("fin print sats");
        }
    }

    public void OnPiece() //Checks when the hand is on the Piece
    {

        if (CheckPieceScript.ThisPiece == Pieces2[counter])
        {
            Seeing = false;

        }
        else
        {
            Seeing = true;

        }


    }

    IEnumerator SubtleCube() //The SubtleCube method, moves the piece a little bit after some seconds
    {
        hej = Pieces2[counter2].GetComponent<Renderer>().material;
        print("aaaaaaaaaaaaaaaaaaa");
        yield return new WaitForSeconds(5);
        while (Seeing == true)
        {
            print("bbbbbbbbbbbbbbbbbb");
            if (ChangePosVariable == 1.0F) //starts the subtlehint after 3 seconds
            {
                print("cccccccccccccccccccccccc");
                ChangePosVariable = ChangePosVariable + 0.001F; //increases the ChangePosVariable for the movement
                yield return new WaitForSeconds(3); //after 3 seconds and then returns every element only once
            }
            else
            {
                if (Seeing == false)
                {
                    break;
                }
                else
                {
                    print("dddddddddddddddddddddddd");
                    color = hej.color;
                    color.a = ColorIntensity;
                    hej.color = color;

                    yield return new WaitForSeconds(1);
                    if (Seeing == false)
                    {
                        break;
                    }
                    else
                    {
                        ColorIntensity = ColorIntensity + 0.1F;
                        yield return new WaitForSeconds(4);
                    }
                }
            }

        }
    }
}

