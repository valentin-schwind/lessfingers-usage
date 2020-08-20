using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using UnityEngine;

public class CubesTask : MonoBehaviour
{
    public GameObject GuidingCanvasText;
    public GameObject Cube1;
    public GameObject Cube2;
    public GameObject Cube3;

    FingerCollision fingerCollision1;
    FingerCollision fingerCollision2;
    FingerCollision fingerCollision3;

    Die_d6 value1;
    Die_d6 value2;
    Die_d6 value3;

    private int number1;
    private int number2;
    private int number3;

    private LatinHand latinHand;

    private string CubeInstruction = "Please position the Cubes in front of you \nso that the following numbers are on top: ";
    private string CubeSecondInstr = "Here are your next numbers. \n Please position them as well: ";

    private StreamWriter swcubes;

    //first tasktime component out of four
    public Stopwatch tasktime = new Stopwatch();
    //TimeSpan maybe

    public bool cubesDisabled = true;

    private String path;

    public void EnableTask()
    {
        cubesDisabled = false;

        //SystemDiagnostic enables Random!!!
        FingerCollision.collisionEventPassed += this.onTriggerExit;

        Cube1.SetActive(true);
        Cube2.SetActive(true);
        Cube3.SetActive(true);

        //number1 = UnityEngine.Random.Range(1, 6);
        //number2 = UnityEngine.Random.Range(1, 6);
        //number3 = UnityEngine.Random.Range(1, 6);

        GuidingCanvasText.GetComponent<TextMesh>().text = CubeInstruction+ "\n" + number1 +"    "+ number2 + "    " + number3;

        //fingerCollision1 = Cube1.GetComponent<FingerCollision>();
        //fingerCollision2 = Cube2.GetComponent<FingerCollision>();
        //fingerCollision3 = Cube3.GetComponent<FingerCollision>();

        //value1 = Cube1.GetComponent<Die_d6>();
        //value2 = Cube2.GetComponent<Die_d6>();
        //value3 = Cube3.GetComponent<Die_d6>();

        tasktime.Reset();

    }

    private void Awake()
    {
        latinHand = GameObject.FindObjectOfType(typeof(LatinHand)) as LatinHand;
        path = "C:\\Users\\GEVAKUB\\Documents\\CTask\\" + latinHand.Participant + "_" + DateTime.Now.Ticks + "_" + "CubeTask.txt";
        swcubes = new StreamWriter(path);
        swcubes.WriteLine("subjectid;hands;handname;timestamp;finger;object;digits;task");
    }

    public void onTriggerExit(Collider fingerCollider, FingerCollision objectCollider)
    {
        if (objectCollider.name.Contains("ICube"))
        {
            swcubes.WriteLine(latinHand.Participant + ";" + latinHand.CurrentGroup + ";" + latinHand.GroupNames[latinHand.CurrentGroup].ToString() + ";" + tasktime.ElapsedMilliseconds + ";" + fingerCollider.ToString() + ";" + objectCollider.ToString() + ";" + value1.value + value2.value + value3.value + ";" + number1 + number2 + number3);
        }

        /*if (value1.value == number1 && value2.value == number2 && value3.value == number3
            || value1.value == number1 && value2.value == number3 && value3.value == number2
            || value1.value == number2 && value2.value == number1 && value3.value == number3
            || value1.value == number2 && value2.value == number3 && value3.value == number1
            || value1.value == number3 && value2.value == number1 && value3.value == number2
            || value1.value == number3 && value2.value == number2 && value3.value == number1)
        {
            number1 = UnityEngine.Random.Range(1, 6);
            number2 = UnityEngine.Random.Range(1, 6);
            number3 = UnityEngine.Random.Range(1, 6);

            GuidingCanvasText.GetComponent<TextMesh>().text = CubeInstruction + "\n" + number1 + "    " + number2 + "    " + number3;
        }*/
    }

    public void Update()
    {
        //second tasktime component out of four
        tasktime.Start();

        if (value1.value == number1 && value2.value == number2 && value3.value == number3
            || value1.value == number1 && value2.value == number3 && value3.value == number2
            || value1.value == number2 && value2.value == number1 && value3.value == number3
            || value1.value == number2 && value2.value == number3 && value3.value == number1
            || value1.value == number3 && value2.value == number1 && value3.value == number2
            || value1.value == number3 && value2.value == number2 && value3.value == number1)
        {
            number1 = UnityEngine.Random.Range(1, 6);
            number2 = UnityEngine.Random.Range(1, 6);
            number3 = UnityEngine.Random.Range(1, 6);

            GuidingCanvasText.GetComponent<TextMesh>().text = CubeSecondInstr + "\n" + number1 + "    " + number2 + "    " + number3;
        }
    }

    public bool DisableTask()
    {


        number1 = UnityEngine.Random.Range(1, 6);
        number2 = UnityEngine.Random.Range(1, 6);
        number3 = UnityEngine.Random.Range(1, 6);

        fingerCollision1 = Cube1.GetComponent<FingerCollision>();
        fingerCollision2 = Cube2.GetComponent<FingerCollision>();
        fingerCollision3 = Cube3.GetComponent<FingerCollision>();

        value1 = Cube1.GetComponent<Die_d6>();
        value2 = Cube2.GetComponent<Die_d6>();
        value3 = Cube3.GetComponent<Die_d6>();

        cubesDisabled = true;
        Cube1.SetActive(false);
        Cube2.SetActive(false);
        Cube3.SetActive(false);
        return cubesDisabled;
    }

    public void CloseCubes()
    {
        swcubes.Close();
        swcubes.Dispose();
    }
}
