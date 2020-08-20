using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CubeReset : MonoBehaviour
{
    Vector3 defaultPos;
    public GameObject cube;
   

    // Start is called before the first frame update
    void Start()
    {
        defaultPos = gameObject.transform.position;
    }

    // HotKey falls manuelles Zurücksetzen erwünscht
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Keypad1))
        {
            transform.position = defaultPos;
        }
    }

    //Boden als Trigger damit automatisch Zurückgesetzt wird
     void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.name == "Floor")
        {
            gameObject.transform.position = defaultPos;
        }
    }
}
