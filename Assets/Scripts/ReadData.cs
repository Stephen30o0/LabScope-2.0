using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class ReadData : MonoBehaviour
{
    //Gets csv file and creates array to hold text data
    public TextAsset PeriodicTableData;
    string[] lines = new string[118];

    //Game objects to be used 
    public GameObject elements;
    public GameObject PeriodicElement;


    void Awake()
    {
        //checks to make sure that this section of code is only run on the game object Controller
        if (this.transform.gameObject.name == "Controller")
        {
            //Gets csv file Peridoic table data and stores it in string arrays
            lines = PeriodicTableData.text.Split('\n');
            string[] elementNames = new string[lines.Length];
            string[] elementSymbols = new string[lines.Length];
            string[] atomicWeight = new string[lines.Length];

            int i = 0;
            foreach (string line in lines)
            {
                string[] lineData = line.Split(',');
                elementNames[i] = lineData[0];
                elementSymbols[i] = lineData[1];
                atomicWeight[i] = lineData[2];
                i++;
            }

            //writes the periodic element data onto each periodic element 
            for (int j = 1; j < elements.transform.childCount - 1; j++)
            {
                string temp = j.ToString();
                PeriodicElement = elements.transform.Find(temp).gameObject;
                int periodNumber = System.Convert.ToInt32(PeriodicElement.name);
                PeriodicElement.transform.GetChild(0).gameObject.GetComponent<TextMesh>().text = periodNumber.ToString();
                PeriodicElement.transform.GetChild(1).gameObject.GetComponent<TextMesh>().text = elementSymbols[periodNumber - 1].ToString();
                PeriodicElement.transform.GetChild(2).gameObject.GetComponent<TextMesh>().text = elementNames[periodNumber - 1].ToString();
                PeriodicElement.transform.GetChild(3).gameObject.GetComponent<TextMesh>().text = atomicWeight[periodNumber - 1].ToString();
            } 
        }
        
    }

}
