using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class O_HighScore : MonoBehaviour
{
    public Text tScore;
    public Text pName;
    public Text errText;
    //public string pName;
    //int pTime=0;
    Dictionary<float, string> dictNames = new Dictionary<float, string>();
    List<float> hLST = new List<float>();
    public List<Text> disNamesLst = new List<Text>();
    public List<Text> disHSLst = new List<Text>();

    void Start()
    {
        LoadScores();
    }

    public void RollDice()
    {
        int number = Random.Range(1, 11);
        tScore.text = number.ToString();

        addScore(number);
    }

    public void ResetScore()
    {
        //Clearing scores and names from memory
        for (int i = 0; i < PlayerPrefs.GetInt("nameCount"); i++)
        {
            PlayerPrefs.DeleteKey("pName" + i.ToString());
            PlayerPrefs.DeleteKey("HS" + i.ToString());
        }
        PlayerPrefs.DeleteKey("nameCount");
    }

    public void ClearScreen()
    {
        //Clearing the actual screen info
        for (int i = 0; i < disHSLst.Count; i++)
        {
            disHSLst[i].text = "0";
            disNamesLst[i].text = "_______";
        }

        //Clearing any current left over info
        dictNames.Clear();
        hLST.Clear();
    }

    public void addScore(float score)
    {
        pName.text = PlayerPrefs.GetString("PlayerName");
        Debug.Log(pName.text);
        //Debug.Log(pName.text);
        //Do Nothing if a name hasn't been put in
        if(pName.text == "")
        {
            errText.text = "You FooBar. Please input a name First!!";
        }
        else
        {
            errText.text = "";
            //This if is intended to add a "1" to the name if it is already in the list to avoid confusion
            if (dictNames.ContainsValue(pName.text) == true)
            {
                pName.text = (pName.text + "1");
            }
            //A dictonary cannot have two keys of the same number.
            //As a workaround we use floats and change it so little that we can round it to the same later
            while (dictNames.ContainsKey(score) == true)
            {
                score = (score - 0.00001f);
            }
            //The following three lines 1.adds the score to the list,2.Sorts it from lowest to highest, 3. Reverses order so it's highest to lowest
            hLST.Add(score);
            hLST.Sort();
            hLST.Reverse();

            dictNames.Add(score, pName.text);
            IntToText();


            if (hLST.Count > 10)
            {
                dictNames.Remove(hLST[10]);
                hLST.RemoveAt(10);
            }
        }
    }

    public void IntToText()
    {
        double rounded;
        //Note that we never need to empty disNamesLst nor disHSLst as they're bound by the length of hLST.
        for(int i=0;i<hLST.Count;i++)
        {
            disNamesLst[i].text = dictNames[(hLST[i])];
            rounded = System.Math.Round(hLST[i],2);//Rounds to two decimals.
            //Alternatively, Use the line below to round to whole numbers.
            //rounded = Mathf.Round(hLST[i]); 
            disHSLst[i].text = rounded.ToString();
        }

        //foreach (KeyValuePair<int, string> item in dictNames)
        //{
        //    Debug.Log("Key: " + item.Key + "Value: " + item.Value);
        //}
    }

    public void SaveScores()
    {
        //Delete old saved scores first just in case.
        ResetScore();
        for (int i = 0; i < hLST.Count; i++)
        {
            Debug.Log(hLST.Count);
            PlayerPrefs.SetString("pName" + i.ToString(), disNamesLst[i].text);
            PlayerPrefs.SetFloat("HS" + i.ToString(), hLST[i]); //Not using display list since we'll need the actual vaules to feed into the dictonary at start up
        }
        PlayerPrefs.SetInt("nameCount", hLST.Count);//We'll need how many were in the list too
    }

    public void LoadScores()
    {
        //Checking if we even have scores to be loaded in the first place
        if(PlayerPrefs.GetInt("nameCount",0) != 0)
        {
            //We only need to check through as many names as we want, they could be less than 10
            for(int i=0; i< PlayerPrefs.GetInt("nameCount");i++)
            {
                //Just to make it more overseeable. Here's the Keys for the saved data.
                string hSKey = "HS" + i.ToString();
                string pNameKey = "pName" + i.ToString();
                //Here we retrive the actual data. And to make it more overseeable put it into temporary variables
                string pNameTmp = PlayerPrefs.GetString(pNameKey);
                float hSNr = PlayerPrefs.GetFloat(hSKey);

                //The numbers have been rounded up for display and dictionaries still can't handle two variables with the same key.
                //Let's fix that
                int j = 0;
                while ((dictNames.ContainsKey( hSNr ) == true) && (j <100))
                {
                    hSNr = hSNr -0.00001f;
                    j++;
                }
                if(j >20)
                {
                    Debug.Log("INFINTE LOOP, ABORT;ABORT;ABORT");
                }
                else if (j>1)
                {
                    Debug.Log("Float was diminished to work in dict");
                }

                //Get the score and name for each spot on the list and put it into the dictionary
                dictNames.Add(hSNr, pNameTmp);
                //Also put it into the high list
                hLST.Add(hSNr);
            }
            //Call IntToText to actually display the information
            IntToText();
        }
        else
        {
            Debug.Log("NO SAVED SCORES!!");
        }
    }
}
//    //The following function creates a system of HighScore places in playerPrefs numbering from HS1 to HS10
//    //As well as a hirachy of playerNames numbering from pName1 to pName10
//    //Now as long as 
//    public int AddToPlayerPrefs (string pName, int pTime)
//    {
//        int currScoreIndex = -1;
//        //if the function has never been used before
//        //if(PlayerPrefs.GetInt("HS1",-1) == -1)
//        //{
//        //    PlayerPrefs.SetInt("HS1", pTime);
//        //    currScoreIndex = 1;
//        //}
//        //otherwise
//        //else
//        //{
//        for (int i = 1; i < 11; i++)
//            {
//            if (PlayerPrefs.GetInt(("HS" + i.ToString()), 0) < pTime)
//                {
//                    PlayerPrefs.SetInt(("HS" + i.ToString()), pTime);
//                    currScoreIndex = i;
//                    PlayerPrefs.SetString(("pName" + currScoreIndex.ToString()), pName.ToString());
//                    i = 11;
//                }
//            }
//        //}
//        return currScoreIndex;
//    }

//    public void printPlayerPrefs()
//    {
//        for (int i = 1; i < 11; i++)
//        {
//            Debug.Log("HighScore Number: " + PlayerPrefs.GetInt(("HS" + i.ToString())));
//            Debug.Log("Player Name: " + PlayerPrefs.GetString("pName" + i.ToString()));
//        }
//    }

//    public void tryFuncs()
//    {
//        int index = -2;
//        for(int i=1; i<11;i++)
//        {
//            index = AddToPlayerPrefs(("John" + i.ToString()), (i*10));
//            Debug.Log(index);
//        }
//        printPlayerPrefs();
//    }
//}
