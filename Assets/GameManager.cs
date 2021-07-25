using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class GameManager : MonoBehaviour
{
    public static string NamaScene;

    AsyncOperation scenesLoading = new AsyncOperation();

    public Image imgLoading;

    public Image backgroundImg;
    public Sprite[] bg_sprites;

    private void Awake()
    {

        switch (NamaScene)
        {
            case "Hutan":
                backgroundImg.sprite = bg_sprites[0];
                break;
            case "Laut":
                backgroundImg.sprite = bg_sprites[1];
                break;
            case "Mountain":
                backgroundImg.sprite = bg_sprites[2];
                break;
        }

        LoadGame();
    }

    private void Update()
    {

    }

    /// <summary>
    /// fungsi untuk load ke game nya
    /// </summary>
    public void LoadGame()
    {

        StartCoroutine(GetSceneLoadProgress());
    }

    float totalProgress = 0f;
    public IEnumerator GetSceneLoadProgress()
    {
        yield return new WaitForSeconds(0.4f);
        scenesLoading = SceneManager.LoadSceneAsync(NamaScene);
        while (!scenesLoading.isDone)
        {
            imgLoading.fillAmount = Mathf.Clamp01(scenesLoading.progress / 0.9f);
            Debug.Log(scenesLoading.progress / 0.9f);
            yield return 0;
        }

        SceneManager.UnloadScene("LoadingScene");
    }

}
