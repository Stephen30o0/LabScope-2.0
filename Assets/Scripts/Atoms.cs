using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class Atoms : MonoBehaviour
{
    //creates array of all atoms 
    public GameObject[] atoms = new GameObject[4];

    void Awake()
    {
        //sets all atoms to false so they can not be seen
        for (int i = 0; i < atoms.Length; i++)
        {
            atoms[i].SetActive(false);
        }
        //However we do want the hydrogen atom showing as it is the first one pre-selected for the user
        //atoms[0].SetActive(true);
        
    }

    public void atomSelected(int elementNumber)
    {
        //sets all of atoms to false so you cant see them and the atom that was selected and is within the range of atoms that were created will be shown
        elementNumber = elementNumber - 1;
        for (int i = 0; i < atoms.Length; i++)
        {
            atoms[i].SetActive(false);
        }
        if (elementNumber < atoms.Length)
        {
            atoms[elementNumber].SetActive(true);
            //ensures that the atom will show at this position and not anywhere else
            atoms[elementNumber].transform.position = new Vector3(9,3,6);
        }
    }


}
