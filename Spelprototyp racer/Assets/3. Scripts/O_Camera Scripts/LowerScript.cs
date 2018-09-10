using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LowerScript : MonoBehaviour
{

    public float howLow;
    public Animator theAnimator;
    private float howHigh;
    // Use this for initialization
    void Start()
    {
        howHigh = transform.position.y;
    }

    public void Lower()
    {
        theAnimator.SetBool("SignDown", true);
        //Vector3 tmp = transform.position;
        //tmp.y = howLow;
        //transform.position = tmp;
        //transform.position.Set(transform.position.x, howLow, transform.position.z);
    }
    public void Raise()
    {
        theAnimator.SetBool("SignDown", false);
        //Vector3 tmp = transform.position;
        //tmp.y = howHigh;
        //transform.position = tmp;
        //transform.position.Set(transform.position.x, howHigh, transform.position.z);
    }
}
