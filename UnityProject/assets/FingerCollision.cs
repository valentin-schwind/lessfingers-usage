using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FingerCollision : MonoBehaviour
{
    public bool L_index = false;
    public bool L_middle = false;
    public bool L_pinky = false;
    public bool L_ring = false;
    public bool L_thumb = false;

    public bool R_index = false;
    public bool R_middle = false;
    public bool R_pinky = false;
    public bool R_ring = false;
    public bool R_thumb = false;

    public delegate void onTriggerExit(Collider other, FingerCollision blubb);
    public static event onTriggerExit collisionEventPassed;

    private void OnTriggerExit(Collider other)
    {
        collisionEventPassed?.Invoke(other, this);
    }
}
