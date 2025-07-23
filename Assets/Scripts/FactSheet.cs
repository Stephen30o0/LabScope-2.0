using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class FactSheet : MonoBehaviour
{
    public TextMeshProUGUI factText;
    int currentpage = 1;

    //When next page button is pressed this is called which changes the page number on the fact sheet 
    public void ButtonNextPage()
    {

        int totalpages = factText.textInfo.pageCount;

        if (currentpage < totalpages)
        {
            currentpage++;
            factText.pageToDisplay++;
        }
        else
        {
            currentpage--;
            factText.pageToDisplay--;
        }
    }
}
