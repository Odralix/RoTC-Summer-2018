using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollowPoint : MonoBehaviour {

    private new Vector3 origPos;
    public new Vector3 newPos;
    public new Vector3 inBetweenPos1;
    public new Vector3 inBetweenPos2;
    public float waitTime= 0.1f;
    private bool hasSwitched = false;
	// Use this for initialization
	void Start ()
    {
		origPos = transform.position;
	}
	
    public void CameraSwitch()
    {
        if(hasSwitched == false)
        {
            transform.position = inBetweenPos1;
            StartCoroutine(Wait(waitTime));
            //transform.position = newPos;
            //hasSwitched = true;
        }
        else if(hasSwitched == true)
        {
            transform.position = inBetweenPos2;
            StartCoroutine(Wait(waitTime));
            //transform.position = origPos;
            //hasSwitched = false;
        }

        //DelayMenu(time2);

    }

    public void mapLook()
    {
        transform.position = new Vector3(52.98f, 4.924023f, -0.07f);
    }

    private IEnumerator Wait(float time)
    {
        yield return new WaitForSeconds(time);
        if (hasSwitched == false)
        {
            transform.position = newPos;
            hasSwitched = true;
        }
        else if(hasSwitched == true)
        {
            transform.position = origPos;
            hasSwitched = false;
        }
    }

    //private IEnumerator DelayMenu(float time)
    //{
    //    yield return new WaitForSeconds(time);
    //    int five = 5;
    //    five = 1 + 3;
    //}
}
