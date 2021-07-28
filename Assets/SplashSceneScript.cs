using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class SplashSceneScript : MonoBehaviour
{

    private void Start()
    {
        StartCoroutine(loadSceneMenu());
        
    }

    IEnumerator loadSceneMenu()
    {
        yield return new WaitForSeconds(4.5f);
        SceneManager.LoadScene("MainMenu");
    }
}
