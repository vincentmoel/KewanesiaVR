using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ChangeScene : MonoBehaviour
{
    public Animator animPintu, animPlayer;
    public GvrEditorEmulator GvrEditorEmulator;
    public Transform playerTargetToLook;

    public bool startAnim = false;

    private IEnumerator IeAnimasi(string scene)
    {
        animPintu.Play("Anim Pintu Buka");
        animPlayer.Play("Anim Masuk Player In");
        GetComponent<Animator>().Play("RMapAnim");
        GvrEditorEmulator.enabled = false;
        startAnim = true;
        yield return new WaitForSeconds(3.5f);
        SceneManager.LoadScene(scene);

    }

    // Untuk menganti scene
    public void SceneChange(string sceneName)
    {
        StartCoroutine(IeAnimasi(sceneName));
    }

    // Keluar dari game
    public void QuitApp()
    {
        Application.Quit();
    }
}
