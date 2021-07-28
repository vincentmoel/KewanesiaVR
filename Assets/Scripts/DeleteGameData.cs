using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeleteGameData : MonoBehaviour
{
    public void DeleteProgressData()
    {
        PlayerPrefs.DeleteAll();
    }


    public void RefreshMenu()
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene("MainMenu");
    }

}
