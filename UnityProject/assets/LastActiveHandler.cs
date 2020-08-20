using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LastActiveHandler : MonoBehaviour
{
    public GameObject slider;

    public int previousIndex = -1;
    private int interact = -1;

    public void OnLastActiveButton(int index)
    {
        if (slider.activeSelf)
        {
            interact = 7;
        } else
        {
            interact = 6;
        }
        if (previousIndex != -1)
        {
            this.transform.GetChild(interact).GetChild(previousIndex).GetChild(0).GetChild(0).GetComponent<MeshRenderer>().material.color = Color.Lerp(Color.black, Color.white, 0.8f);
        }
        this.transform.GetChild(interact).GetChild(index).GetChild(0).GetChild(0).GetComponent<MeshRenderer>().material.color = Color.blue;
        previousIndex = index;
    }

    public bool isSelected()
    {
        if(previousIndex != -1)
        {
            return true;
        } else
        {
            return false;
        }
    }

    public void resetSelect()
    {
        this.transform.GetChild(interact).GetChild(previousIndex).GetChild(0).GetChild(0).GetComponent<MeshRenderer>().material.color = Color.Lerp(Color.black, Color.white, 0.8f);
        previousIndex = -1;
    }
}
