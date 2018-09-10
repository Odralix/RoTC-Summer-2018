using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class setNamePlayer : MonoBehaviour
{
    public Text pName;
    public void inputName()
    {
        PlayerPrefs.SetString("PlayerName", pName.text);
    }
	
}
