using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class ElementSelected : MonoBehaviour
{
    public TextAsset factData;
    string[] lines = new string[3];
    public void selected(GameObject buttonSelected)
    {
        //stores csv data in the lines array
        if (factData != null)
        {
            lines = factData.text.Split('\n');
        }
        
        //Gets the button that was selected to get the name of it. Which is a number representing the elements number 
        int elementNumber = System.Convert.ToInt32(buttonSelected.name);
        
        Debug.Log("Element selected: " + elementNumber + " (" + buttonSelected.name + ")");
        
        // Get the element data from the selected button's children
        Transform atomicNumberChild = buttonSelected.transform.Find("AtomicNumber");
        Transform symbolChild = buttonSelected.transform.Find("ElementSymbol");
        Transform nameChild = buttonSelected.transform.Find("ElementName");
        Transform weightChild = buttonSelected.transform.Find("AtomicWeight");
        
        //When this public void is called it gets the data from the element selected and rewrites it onto the big element above the periodic table 
        GameObject bigElement = GameObject.Find("GameObject 1 Variant/BigElement");
        if (bigElement != null)
        {
            if (atomicNumberChild != null && bigElement.transform.childCount > 0)
            {
                TextMesh atomicNumberText = bigElement.transform.GetChild(0).GetComponent<TextMesh>();
                if (atomicNumberText != null)
                    atomicNumberText.text = atomicNumberChild.GetComponent<TextMesh>().text;
            }
            
            if (symbolChild != null && bigElement.transform.childCount > 1)
            {
                TextMesh symbolText = bigElement.transform.GetChild(1).GetComponent<TextMesh>();
                if (symbolText != null)
                    symbolText.text = symbolChild.GetComponent<TextMesh>().text;
            }
            
            if (nameChild != null && bigElement.transform.childCount > 2)
            {
                TextMesh nameText = bigElement.transform.GetChild(2).GetComponent<TextMesh>();
                if (nameText != null)
                    nameText.text = nameChild.GetComponent<TextMesh>().text;
            }
            
            if (weightChild != null && bigElement.transform.childCount > 3)
            {
                TextMesh weightText = bigElement.transform.GetChild(3).GetComponent<TextMesh>();
                if (weightText != null)
                    weightText.text = weightChild.GetComponent<TextMesh>().text;
            }
        }
        
        //Writes the name of the element onto the fact sheet and if it has any data associated with it in the csv file it will also display that
        GameObject dataPanel = GameObject.Find("GameObject 1 Variant/dataPanel");
        if (dataPanel != null && nameChild != null)
        {
            var nameComponent = dataPanel.transform.GetChild(1).GetChild(0).GetComponent<TMPro.TextMeshProUGUI>();
            if (nameComponent != null)
                nameComponent.text = nameChild.GetComponent<TextMesh>().text;
                
            if (elementNumber <= lines.Length && lines.Length > 0)
            {
                var factComponent = dataPanel.transform.GetChild(1).GetChild(1).GetComponent<TMPro.TextMeshProUGUI>();
                if (factComponent != null)
                    factComponent.text = lines[elementNumber - 1];
            }
            else 
            {
                var factComponent = dataPanel.transform.GetChild(1).GetChild(1).GetComponent<TMPro.TextMeshProUGUI>();
                if (factComponent != null)
                    factComponent.text = "";
            }
        }
        
        //calls the Atoms script and atom selected function. This displays the atom to the user if it has a corrisponding atom.
        GameObject controller = GameObject.Find("Controller");
        if (controller != null)
        {
            Atoms atomsComponent = controller.GetComponent<Atoms>();
            if (atomsComponent != null)
            {
                //Give the script elementNumber so it knows which element was selected 
                atomsComponent.atomSelected(elementNumber);
            }
        }
    }
}
