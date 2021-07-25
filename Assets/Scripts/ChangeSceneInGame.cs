using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ChangeSceneInGame : MonoBehaviour
{
    public void ChangeScene(string sceneName)
    {
        GameManager.NamaScene = sceneName;
        SceneManager.LoadScene("MainMenu");
    }
}
