using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InOrder : MonoBehaviour
{


    public List<GameObject> Zones = new List<GameObject>();

    // Start is called before the first frame update
    void Start()
    {


        ZoneList();
        InactivateZones();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void ZoneList()
    {
        Transform[] Children = GetComponentsInChildren<Transform>();
        foreach (Transform child in Children)
        {
            Zones.Add(child.gameObject);

        }
        print(Zones.Count);
    }


    public void InactivateZones()
    {

        for (int i = 2; i <= 9; i++)
        {
            Zones[i].SetActive(false);
        }

    }


    public void ActivateZones(int i)
    {

        Zones[i].SetActive(true);
        //Zones[i-1].SetActive(false);

        //i++;
        //print(i);
    }
}
