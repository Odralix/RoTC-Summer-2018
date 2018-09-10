using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayAnimC : MonoBehaviour {

    public Animator tehAnimator;
    public void open()
    {
        tehAnimator.SetBool("OpenBook", true);
    }
    public void close()
    {
        tehAnimator.SetBool("OpenBook", false);
    }
}
