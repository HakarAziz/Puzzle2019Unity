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
        counter2 = 5;
        counter = 4;
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

    }

    public void StopIT()
    {
        StopAllCoroutines();
    }
    public void Stopguide()
    {
        /*if (CheckPieceScript.ThisPiece == Pieces2[counter])
        {
            StopAllCoroutines();
            color.a = ColorIntensity;
            StartCoroutine(SubtleCube());
        }*/

    }
    public void CounterIncrease()
    {
        StopAllCoroutines(); //Stops all Coroutines before starting a new one
        hej = Pieces2[counter2].GetComponent<Renderer>().material;
        ColorIntensity = 0F;
        color = hej.color;
        color.a = ColorIntensity;
        hej.color = color;
        counter2 = counter2 + 3;
        if (counter < 28)
        {
            counter = counter + 2;
        }
        
        StartCoroutine(SubtleCube());
    }

    public void NotOnPiece_B() //Checks when the hand is not on the puzzle piece (may be swapped to eyetracking)
    {
        if (CheckPieceScript.ThisPiece == Pieces2[counter])
        {
            
            StopAllCoroutines(); //Stops all Coroutines before starting a new one
            StartCoroutine(SubtleCube());
            test = false;
            Seeing = true;
        }
    }

    public void OnPiece_B() //Checks when the hand is on the Piece
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
        yield return new WaitForSeconds(0);
        while (Seeing == true)
        {
            if (Seeing == false)
            {

                break;
            }
            else
            {
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
                    yield return new WaitForSeconds(3);
                }
            }
            

        }
    }
}

