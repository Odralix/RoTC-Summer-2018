﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadSelect : MonoBehaviour
{

    public void loadSelect()
    {
        SceneManager.LoadScene("NewSelectionScene");
    }

}
