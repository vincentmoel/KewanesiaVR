using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ChangeScene : MonoBehaviour
{
    // Untuk menganti scene
    public void SceneChange(string sceneName) {
        SceneManager.LoadScene(sceneName);
    }

    // Keluar dari game
    public void QuitApp() {
        Application.Quit();
    }
}
