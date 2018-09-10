using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class CharacterSelection : MonoBehaviour {

    private GameObject[] characterList;
    public int index;
    public Text crysName;
    public Text sphereName;
    private void Start()
    {
        //index = PlayerPrefs.GetInt("CharacterSelected");

        //characterList = new GameObject[transform.childCount];

        ////Fill the array with the models 
        //for (int i = 0; i < transform.childCount; i++ )
        //{
        //    characterList[i] = transform.GetChild(i).gameObject;
        //}
    }

    public void ToggleLeft()
    {
        //togge off the current model 
        characterList[index].SetActive(false);

        characterList[index].GetComponent<Floating>().amplitude = 0.1f;

        index--;

        if(index<0)
        {
            index = characterList.Length - 1;
        }

        //toggle on the next model 
        characterList[index].SetActive(true);

        characterList[index].GetComponent<Floating>().amplitude = 0.1f;
    }

    public void ToggleRight()
    {
        //togge off the current model 
        characterList[index].SetActive(false);

        characterList[index].GetComponent<Floating>().amplitude = 0.1f;

        index++;

        if (index == characterList.Length)
        {
            index = 0;
        }

        //toggle on the next model 
        characterList[index].SetActive(true);

        characterList[index].GetComponent<Floating>().amplitude = 0.1f;

    }

    public void SelectedBook()
    {
        // toggle off their renderer 
        foreach (GameObject go in characterList)
        {
            go.SetActive(false);
        }

        //Toggle in the first //selected character
        if (characterList[index])
        {
            characterList[index].SetActive(true);
        }
    }

    public void CrystalSelect()
    {
        PlayerPrefs.DeleteKey("PlayerName");
        Text pName = crysName;
        PlayerPrefs.SetString("PlayerName", pName.text);
        index = 0;
    }

    public void SphereSelect()
    {
        PlayerPrefs.DeleteKey("PlayerName");
        Text pName = sphereName;
        PlayerPrefs.SetString("PlayerName", pName.text);
        index = 1;
    }
    public void Confirmbutton()
    {
        PlayerPrefs.DeleteKey("CharacterSelected");
        PlayerPrefs.SetInt("CharacterSelected", index);

        SceneManager.LoadScene("LEVEL.1.5");
    }
  
}
