using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LastActiveButton : MonoBehaviour
{
    private LastActiveHandler script;
    
    void Start()
    {
        script = GameObject.FindObjectOfType(typeof(LastActiveHandler)) as LastActiveHandler;
    }

    public IEnumerator OnTriggerEnter(Collider other)
    {
        script.OnLastActiveButton(this.transform.GetSiblingIndex());
        yield return new WaitForSecondsRealtime(2f);
    }
}
