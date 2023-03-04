using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using System.IO;
using System;
using System.Globalization;

public class StartSearch
{
    public void StartSearching()
    {
        SearchAlgorithm algorithm = new SearchAlgorithm();
        try
        {
            SearchData.Path = algorithm.DominoAlgorithm();
            SceneManager.LoadScene("Search");
        }
        catch (TargetNotFoundExceptionException)
        {
            MainMenuUI.CreateErrorMessage();
        }
    }
}
