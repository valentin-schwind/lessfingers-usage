using Leap.Unity;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LatinHand : MonoBehaviour
{
    public int Participant;

    public HandModelManager HandPool;
    public string[] GroupNames;
    private int currentGroup;


    public int CurrentGroup
    {
        get { return currentGroup; }
        set
        {
            disableAllGroups();
            if (value >= GroupNames.Length)
                value = 0;
            if (value < 0)
                value = GroupNames.Length - 1;
            currentGroup = value;
            HandPool.EnableGroup(GroupNames[value]);
            
        }
    }

    private void disableAllGroups()
    {
        for (int i = 0; i < GroupNames.Length; i++)
        {
            HandPool.DisableGroup(GroupNames[i]);
        }
    }

    void Start()
    {
        HandPool = GetComponent<HandModelManager>();
        disableAllGroups();

        GroupNames = GetLatinSquare(GroupNames, Participant);

        CurrentGroup = 0;
    }

    void Update()
    {
        if (Input.GetKeyUp(KeyCode.D))
        {
            nextHandModel();
        }
        if (Input.GetKeyUp(KeyCode.A))
        {
            previousHandModel();
        }
    }

    public void nextHandModel()
    {
        CurrentGroup++;
        
    }

    public void previousHandModel()
    {
        CurrentGroup--;
    }

    public static T[] GetLatinSquare<T>(T[] array, int participant)
    {
        if (array.Length <= 1) return array;
        // Init Square
        int[,] latinSquare = new int[array.Length, array.Length];

        latinSquare[0, 0] = 1;
        latinSquare[0, 1] = 2;

        // Fill 1st row
        for (int i = 2, j = 3, k = 0; i < array.Length; i++)
        {
            if (i % 2 == 1)
                latinSquare[0, i] = j++;
            else
                latinSquare[0, i] = array.Length - (k++);
        }

        // Fill first column
        for (int i = 1; i <= array.Length; i++)
        {
            latinSquare[i - 1, 0] = i;
        }

        // The rest of the square
        for (int row = 1; row < array.Length; row++)
        {
            for (int col = 1; col < array.Length; col++)
            {
                latinSquare[row, col] = (latinSquare[row - 1, col] + 1) % array.Length;

                if (latinSquare[row, col] == 0)
                    latinSquare[row, col] = array.Length;
            }
        }

        int squareItem = (((participant - 1) % array.Length));
        // Debug.Log("participant no. " + (squareItem + 1));

        // Return only the Participants' Latin Square Item 
        T[] newArray = new T[array.Length];

        for (int col = 0; col < array.Length; col++)
        {
            newArray[col] = array[latinSquare[squareItem, col] - 1];
        }
        return newArray;
    }
}
