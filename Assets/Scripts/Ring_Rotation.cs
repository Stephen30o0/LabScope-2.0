using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ring_Rotation : MonoBehaviour
{
    //Gets atom for electrons to rotate
    public GameObject atom;

    // Update is called once per frame
    void Update()
    {
        //rotates electrons around atom
        transform.RotateAround(atom.transform.position, atom.transform.up, 100 * Time.deltaTime);

        //keeps atom at 14, 3, 6 constantly unless grabbed
    }
}
