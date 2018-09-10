using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playAnimS : MonoBehaviour {

    public Animator tehAnimator2;
    public void open()
    {
        tehAnimator2.SetBool("BookOpen", true);
    }
    public void close()
    {
        tehAnimator2.SetBool("BookOpen", false);
    }
}
