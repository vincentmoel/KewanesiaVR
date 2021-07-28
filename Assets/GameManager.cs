using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;
using System.Collections;

public class GameManager : MonoBehaviour
{
    public static string NamaScene;

    public static Sprite bgSebelumnya;

    public Image imgLoading;

    public Image backgroundImg;
    public Image fillImage;
    public Sprite[] bg_sprites;
    public Sprite[] fill_sprites;

    public GameObject[] bg_obj;

    private int loading;
    public TextMeshProUGUI textCounter;

    public Color color1;
    public Color color2;


    public void HideAllBg()
    {
        foreach (var a in bg_obj)
        {
            a.SetActive(false);
        }
    }
    private void Awake()
    {
        switch (NamaScene)
        {
            case "Hutan":
                backgroundImg.sprite = bg_sprites[0];
                fillImage.sprite = fill_sprites[0];
                textCounter.color = color1;
                HideAllBg();
                bgSebelumnya = bg_sprites[0];
                //bg_obj[0].SetActive(true);
                break;
            case "Laut":
                backgroundImg.sprite = bg_sprites[1];
                fillImage.sprite = fill_sprites[1];
                textCounter.color = color1;
                bgSebelumnya = bg_sprites[1];
                HideAllBg();
                //bg_obj[1].SetActive(true);
                break;
            case "Mountain":
                backgroundImg.sprite = bg_sprites[2];
                fillImage.sprite = fill_sprites[2];
                textCounter.color = color2;
                bgSebelumnya = bg_sprites[2];
                HideAllBg();
                //bg_obj[2].SetActive(true);
                break;
            case "MainMenu":
                backgroundImg.sprite = bgSebelumnya;

                if (bgSebelumnya == bg_sprites[2])
                {
                    textCounter.color = color2;
                }
                else
                    textCounter.color = color1;

                break;

        }

        LoadGame();
    }



    /// <summary>
    /// fungsi untuk load ke game nya
    /// </summary>
    public void LoadGame()
    {

        StartCoroutine(RandomLoading());
    }

    float totalProgress = 0f;
    //public IEnumerator GetSceneLoadProgress()
    //{
    //    yield return new WaitForSeconds(0.4f);
    //    scenesLoading = SceneManager.LoadSceneAsync(NamaScene);
    //    while (!scenesLoading.isDone)
    //    {
    //        imgLoading.fillAmount = Mathf.Clamp01(scenesLoading.progress / 0.9f);
    //        Debug.Log(scenesLoading.progress / 0.9f);
    //        yield return 0;
    //    }


    //}




    //void Start()
    //{
    //    StartCoroutine(RandomLoading());
    //}

    private IEnumerator RandomLoading()
    {
        yield return new WaitForSeconds(Random.Range(0, 3));

        loading += Random.Range(10, 20);

        textCounter.text = "Loading " + loading + "%";

        if (loading >= 100)
        {
            textCounter.text = "Loading 100 %";
            SceneManager.LoadScene(NamaScene);
        }
        else
        {
            StartCoroutine(RandomLoading());
        }


    }

}
