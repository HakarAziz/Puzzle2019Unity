using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.SceneManagement;

public class PuzzelScript_B : MonoBehaviour
{
    public List<GameObject> Pieces = new List<GameObject>();
    public List<Vector3> StartPos = new List<Vector3>();
    public List<Quaternion> Rot = new List<Quaternion>();


    public float intensity;
    public float ColorIntensity;
    public GameObject aukfwaduawhdhawidhiuwa;
    public Material hej;
    public Color color;

    SubtleHints_B subtlehint;
    GameObject Child;


    [Header("Disable handgrab")]
    public UnityEvent hand;



    void Start()
    {
        AddPieceInformation();
        //Child = Pieces[7].transform.GetChild(0).gameObject;
        //hej = Child.GetComponent<Renderer>().material;


        //StartCoroutine(SubtleColor());

    }

    void Update()
    {
        if (SceneManager.GetActiveScene() == SceneManager.GetSceneByName("Puzzel_B_sub"))
        {
            subtlehint = aukfwaduawhdhawidhiuwa.GetComponent<SubtleHints_B>();
        }
        //subtlehint = aukfwaduawhdhawidhiuwa.GetComponent<SubtleHints>();
    }


    public void AddPieceInformation()
    {
        Transform[] Children = GetComponentsInChildren<Transform>();
        foreach (Transform child in Children)
        {
            Pieces.Add(child.gameObject);
            print(child);
            StartPos.Add(child.transform.position);
            Rot.Add(child.transform.rotation);
        }
    }

    public void ChangePos(GameObject PieceName)
    {
        hand.Invoke();
        int Nr = Pieces.IndexOf(PieceName);
        if ((Nr % 2)==0)
        {
            Pieces[Nr].transform.position = StartPos[Nr];
            Pieces[Nr].transform.rotation = Rot[Nr];
        }
        else
        {
            print("hej");
        }
        
    }

    public void RightPiece(GameObject PieceName)
    {
        //hand.Invoke();
        print(PieceName);
        if(PieceName.name=="Piece 2")
        {
            int ConnectPiece = Pieces.IndexOf(PieceName) - 1; // Gets index from puzzle piece befor in list
        }
        else
        {
            int ConnectPiece = Pieces.IndexOf(PieceName) - 2; // Gets index from puzzle piece befor in list
            Vector3 temp = new Vector3(0.01f, 0, 0);           // Temporary vector that we will add to the new vector
            PieceName.transform.position = Pieces[ConnectPiece].transform.position;
            PieceName.transform.position += temp;             // Puzzle piece gets new position
            PieceName.transform.rotation = Rot[ConnectPiece];

            int CurrentPiece = Pieces.IndexOf(PieceName);
            Pieces[CurrentPiece].transform.position = PieceName.transform.position; // Updates the current position of the piece
        }
        

        if (SceneManager.GetActiveScene() == SceneManager.GetSceneByName("Puzzel_b_sub"))
        {
            subtlehint.CounterIncrease();
        }

    }


}