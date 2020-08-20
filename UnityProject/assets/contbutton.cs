using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class contbutton : MonoBehaviour
{
    private IPQ script;
    private LastActiveHandler handler;
    private QuestionaireTask questTask;

    public static int selected;
    public static long timeStampQ;

    public delegate void onTriggerExit(Collider other, contbutton blubb);
    public static event onTriggerExit collisionEventPassed;
    
    void Start()
    {
        script = GameObject.FindObjectOfType(typeof(IPQ)) as IPQ;
        handler = GameObject.FindObjectOfType(typeof(LastActiveHandler)) as LastActiveHandler;
        questTask = GameObject.FindObjectOfType(typeof(QuestionaireTask)) as QuestionaireTask;
    }

    public void OnTriggerExit(Collider other)
    {
        if (handler.isSelected())
        {
            //collisionEventPassed?.Invoke(other, this);
            selected = handler.previousIndex;
            timeStampQ = questTask.qtime.ElapsedMilliseconds;

            Debug.Log("contbutton selected" + selected);
            Debug.Log("contbutton other" + other);
            Debug.Log("contbutton this" + this);

            collisionEventPassed?.Invoke(other, this);

            handler.resetSelect();
            script.OnContinueButtonPress();
        }
    }
}
