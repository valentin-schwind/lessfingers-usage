using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Leap.Unity;

//NO LONGER IN USE

public class FingerUsed : MonoBehaviour
{
    public Transform form;

    HandModel hand_model;
    Leap.Hand leap_hand;

    private void Start()
    {
     //   hand_model = GetComponent<HandModel>;
     //   leap_hand = hand_model.GetLeapHand();
    }

    private void OnTriggerExit(Collider other)
    {
        Debug.Log("Collision with Index "+other);
       // FingerModel finger = other.GetComponentInParent<FingerModel>;
       // if (finger)
       // {
       //     Debug.Log("Finger " + finger.fingerType);
       //s }
    }

    //keine Collision sondern Trigger
    //das Script auf einen Teil der Hand legen

    void OnCollisionEnter(Collision collision)
    {
        /*    FingerModel finger = collision.gameObject.GetComponentInParent<FingerModel>();
              if (finger)
              {
                  Debug.Log("Finger " + finger.fingerType);
              }
        */
        /*if (collision.gameObject.name == "R_index_02")
        {
            Debug.Log("It worked");
        }*/
    }
}
