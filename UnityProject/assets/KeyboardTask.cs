using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using UnityEngine;

public class KeyboardTask : MonoBehaviour
{   public GameObject GuidingCanvasText;
    public GameObject Keyboard;
    
    public GameObject C4;
    public GameObject D4;
    public GameObject E4;
    public GameObject F4;
    public GameObject G4;
    public GameObject A4;
    public GameObject B4;
    public GameObject C5;
    public GameObject D5;
    public GameObject E5;
    public GameObject F5;
    public GameObject G5;
    public GameObject A5;
    public GameObject B5;
    public GameObject C6;
    public GameObject D6;
    public GameObject E6;
    public GameObject F6;
    public GameObject G6;
    public GameObject A6;
    public GameObject B6;
    public GameObject C7;

    public GameObject DbC1;
    public GameObject EbD1;
    public GameObject GbF1;
    public GameObject AbG1;
    public GameObject BbA1;
    public GameObject DbC2;
    public GameObject EbD2;
    public GameObject GbF2;
    public GameObject AbG2;
    public GameObject BbA2;
    public GameObject DbC3;
    public GameObject EbD3;
    public GameObject GbF3;
    public GameObject AbG3;
    public GameObject BbA3;


    FingerCollision fingerCollisionC4;
    FingerCollision fingerCollisionD4;
    FingerCollision fingerCollisionE4;
    FingerCollision fingerCollisionF4;
    FingerCollision fingerCollisionG4;
    FingerCollision fingerCollisionA4;
    FingerCollision fingerCollisionB4;
    FingerCollision fingerCollisionC5;
    FingerCollision fingerCollisionD5;
    FingerCollision fingerCollisionE5;
    FingerCollision fingerCollisionF5;
    FingerCollision fingerCollisionG5;
    FingerCollision fingerCollisionA5;
    FingerCollision fingerCollisionB5;
    FingerCollision fingerCollisionC6;
    FingerCollision fingerCollisionD6;
    FingerCollision fingerCollisionE6;
    FingerCollision fingerCollisionF6;
    FingerCollision fingerCollisionG6;
    FingerCollision fingerCollisionA6;
    FingerCollision fingerCollisionB6;
    FingerCollision fingerCollisionC7;
    
    FingerCollision fingerCollisionDbC1;
    FingerCollision fingerCollisionEbD1;
    FingerCollision fingerCollisionGbF1;
    FingerCollision fingerCollisionAbG1;
    FingerCollision fingerCollisionBbA1;
    FingerCollision fingerCollisionDbC2;
    FingerCollision fingerCollisionEbD2;
    FingerCollision fingerCollisionGbF2;
    FingerCollision fingerCollisionAbG2;
    FingerCollision fingerCollisionBbA2;
    FingerCollision fingerCollisionDbC3;
    FingerCollision fingerCollisionEbD3;
    FingerCollision fingerCollisionGbF3;
    FingerCollision fingerCollisionAbG3;
    FingerCollision fingerCollisionBbA3;

    private GameObject[] keys = new GameObject[37];
    private FingerCollision[] fingercollisions = new FingerCollision[37];
    GameObject activeKey;
    FingerCollision activeCollision;
    int random;
    private LatinHand latinHand;
    private string KeyboardInstruction = "Please play on the Keyboard by pressing the glowing keys!";
    private StreamWriter swkeyboard;
    public Stopwatch tasktime = new Stopwatch();
    public bool keyboardDisabled = true;
    private String path;

    public void EnableTask()
    {
        FingerCollision.collisionEventPassed += this.onTriggerExit;
        Keyboard.SetActive(true);
        keyboardDisabled = false;
        GuidingCanvasText.GetComponent<TextMesh>().text = KeyboardInstruction;

        for (int y = 0; y <= 21; y++)
        {
            keys[y].GetComponent<MeshRenderer>().material.color = Color.white;
        }
        for (int z = 22; z < 37; z++)
        {
            keys[z].GetComponent<MeshRenderer>().material.color = Color.black;
        }
        random = UnityEngine.Random.Range(0, keys.Length);
        activeKey = keys[random];
        activeCollision = fingercollisions[random];
        activeKey.GetComponent<MeshRenderer>().material.color = Color.blue;

        tasktime.Reset();
    }

    public void Update()
    {
        //second tasktime component out of four
        tasktime.Start();
    }

    public void Awake()
    {
        latinHand = GameObject.FindObjectOfType(typeof(LatinHand)) as LatinHand;
        path = "C:\\Users\\GEVAKUB\\Documents\\KTask\\" + latinHand.Participant + "_" + DateTime.Now.Ticks + "_" + "KeyboardTask.txt";
        swkeyboard = new StreamWriter(path);
        swkeyboard.WriteLine("subjectid;hands;handname;timestamp;finger;object;task");
    }

    public void onTriggerExit(Collider fingerCollider, FingerCollision objectCollider)
    {
        if (!objectCollider.name.Contains("Cube"))
        {
            swkeyboard.WriteLine(latinHand.Participant + ";" + latinHand.CurrentGroup +";" + latinHand.GroupNames[latinHand.CurrentGroup].ToString() + ";" + tasktime.ElapsedMilliseconds + ";" + fingerCollider.ToString() + ";" + objectCollider.ToString() + ";" + activeCollision);
        }
        if (activeCollision != null)
        {
            if (objectCollider.Equals(activeCollision)) {
                for (int i = 0; i < fingercollisions.Length; i++)
                {
                    if (random < 22)
                    {
                        activeKey.GetComponent<MeshRenderer>().material.color = Color.white;
                    }
                    else
                    {
                        activeKey.GetComponent<MeshRenderer>().material.color = Color.black;
                    }
                }
                random = UnityEngine.Random.Range(0, keys.Length);
                activeKey = keys[random];
                activeCollision = fingercollisions[random];
                activeKey.GetComponent<MeshRenderer>().material.color = Color.blue;
            }
        }
    }

    public void DisableTask()
    {
        keys[0] = C4;
        keys[1] = D4;
        keys[2] = E4;
        keys[3] = F4;
        keys[4] = G4;
        keys[5] = A4;
        keys[6] = B4;
        keys[7] = C5;
        keys[8] = D5;
        keys[9] = E5;
        keys[10] = F5;
        keys[11] = G5;
        keys[12] = A5;
        keys[13] = B5;
        keys[14] = C6;
        keys[15] = D6;
        keys[16] = E6;
        keys[17] = F6;
        keys[18] = G6;
        keys[19] = A6;
        keys[20] = B6;
        keys[21] = C7;

        keys[22] = DbC1;
        keys[23] = EbD1;
        keys[24] = GbF1;
        keys[25] = AbG1;
        keys[26] = BbA1;
        keys[27] = DbC2;
        keys[28] = EbD2;
        keys[29] = GbF2;
        keys[30] = AbG2;
        keys[31] = BbA2;
        keys[32] = DbC3;
        keys[33] = EbD3;
        keys[34] = GbF3;
        keys[35] = AbG3;
        keys[36] = BbA3;


        fingercollisions[0] = fingerCollisionC4;
        fingercollisions[1] = fingerCollisionD4;
        fingercollisions[2] = fingerCollisionE4;
        fingercollisions[3] = fingerCollisionF4;
        fingercollisions[4] = fingerCollisionG4;
        fingercollisions[5] = fingerCollisionA4;
        fingercollisions[6] = fingerCollisionB4;
        fingercollisions[7] = fingerCollisionC5;
        fingercollisions[8] = fingerCollisionD5;
        fingercollisions[9] = fingerCollisionE5;
        fingercollisions[10] = fingerCollisionF5;
        fingercollisions[11] = fingerCollisionG5;
        fingercollisions[12] = fingerCollisionA5;
        fingercollisions[13] = fingerCollisionB5;
        fingercollisions[14] = fingerCollisionC6;
        fingercollisions[15] = fingerCollisionD6;
        fingercollisions[16] = fingerCollisionE6;
        fingercollisions[17] = fingerCollisionF6;
        fingercollisions[18] = fingerCollisionG6;
        fingercollisions[19] = fingerCollisionA6;
        fingercollisions[20] = fingerCollisionB6;
        fingercollisions[21] = fingerCollisionC7;

        fingercollisions[22] = fingerCollisionDbC1;
        fingercollisions[23] = fingerCollisionEbD1;
        fingercollisions[24] = fingerCollisionGbF1;
        fingercollisions[25] = fingerCollisionAbG1;
        fingercollisions[26] = fingerCollisionBbA1;
        fingercollisions[27] = fingerCollisionDbC2;
        fingercollisions[28] = fingerCollisionEbD2;
        fingercollisions[29] = fingerCollisionGbF2;
        fingercollisions[30] = fingerCollisionAbG2;
        fingercollisions[31] = fingerCollisionBbA2;
        fingercollisions[32] = fingerCollisionDbC3;
        fingercollisions[33] = fingerCollisionEbD3;
        fingercollisions[34] = fingerCollisionGbF3;
        fingercollisions[35] = fingerCollisionAbG3;
        fingercollisions[36] = fingerCollisionBbA3;

        for (int x = 0; x < keys.Length; x++)
        {
            fingercollisions[x] = keys[x].GetComponent<FingerCollision>();
        }
        keyboardDisabled = true;
        Keyboard.SetActive(false);
    }

    public void CloseKeyboard()
    {
        swkeyboard.Close();
        swkeyboard.Dispose();
    }
}
