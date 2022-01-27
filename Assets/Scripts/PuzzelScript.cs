﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class PuzzelScript : MonoBehaviour
{
    public List<GameObject> Pieces = new List<GameObject>();
    public List<Vector3> StartPos = new List<Vector3>();
    public List<Quaternion> Rot = new List<Quaternion>();

    [Header("Disable handgrab")]
    public UnityEvent hand;

    void Start()
    {
        AddPieceInformation();
    }

    void Update()
    {
    }

    public void AddPieceInformation()
    {
        Transform[] Children = GetComponentsInChildren<Transform>();
        foreach (Transform child in Children)
        {
            Pieces.Add(child.gameObject);
            StartPos.Add(child.transform.position);
            Rot.Add(child.transform.rotation);
        }
    }

    public void ChangePos(GameObject PieceName)
    {
        hand.Invoke();
        int Nr = Pieces.IndexOf(PieceName);
        Pieces[Nr].transform.position = StartPos[Nr];
        Pieces[Nr].transform.rotation = Rot[Nr];
    }

    public void RightPiece(GameObject PieceName)
    {
        hand.Invoke();
        int ConnectPiece = Pieces.IndexOf(PieceName) - 1; // Gets index from puzzle piece befor in list
        Vector3 temp = new Vector3(0.01f, 0, 0);           // Temporary vector that we will add to the new vector
        PieceName.transform.position = Pieces[ConnectPiece].transform.position;
        PieceName.transform.position += temp;             // Puzzle piece gets new position
        PieceName.transform.rotation = Rot[ConnectPiece];

        int CurrentPiece = Pieces.IndexOf(PieceName);
        Pieces[CurrentPiece].transform.position = PieceName.transform.position; // Updates the current position of the piece
    }
}
