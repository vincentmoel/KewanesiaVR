using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ChangeScene : MonoBehaviour
{
    public Animator animPintu, animPlayer;
    public Transform playerTargetToLook;

    public bool startAnim = false;

    private IEnumerator IeAnimasi(string scene)
    {
        animPintu.Play("Anim Pintu Buka");
        animPlayer.Play("Anim Masuk Player In");
        GetComponent<Animator>().Play("RMapAnim");
        startAnim = true;
        yield return new WaitForSeconds(3.5f);

        LoadScene();
    }

    // Untuk menganti scene
    public void SceneChange(string sceneName)
    {
        StartCoroutine(IeAnimasi(sceneName));
        GameManager.NamaScene = sceneName;
    }

    // Keluar dari game
    public void QuitApp()
    {
        Application.Quit();
    }

    public void LoadScene()
    {

        //masuk loading screen dulu
        SceneManager.LoadScene("LoadingScene");
    }
}
