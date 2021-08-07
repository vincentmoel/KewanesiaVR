using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class TutorialScript : MonoBehaviour
{
    public Movement playerScript;
    int indx_teks = 0;
    public AudioSource audioSource;

    [Header("SETTING 1")]
    public string[] str_awal = new string[3];
    public TextMeshProUGUI txtAwal;
    public GameObject obj_teks_awal;

    [Header("SETTING 2")]
    public string[] str_kedua;
    public TextMeshProUGUI txtKedua;
    public GameObject obj_teks_kedua;
    public GameObject obj_panah;

    public Button btn_ya_mau;

    public int jumTekan = 0;
    public bool[] list_btnPapan = new bool[4];

    private void Start()
    {
        btn_ya_mau.GetComponent<BoxCollider>().enabled = false;

        playerScript.speed = 0;
        STATE_1();
    }


    void STATE_1()
    {
        StartCoroutine(ie_teks_awal());
    }

    // ReSharper disable Unity.PerformanceAnalysis
    /// <summary>
    /// fungsi animasi teks berjalan pada teks awal
    /// </summary>
    /// <returns></returns>
    IEnumerator ie_teks_awal()
    {
        txtAwal.text = "";
        foreach (char c in str_awal[indx_teks])
        {
            txtAwal.text += c;
            if (!audioSource.isPlaying)
                audioSource.Play();
            yield return new WaitForSeconds(0.05f);
        }
        audioSource.Stop();
        indx_teks++;
        if (indx_teks < str_awal.Length)
        {
            yield return new WaitForSeconds(4f);
            StartCoroutine(ie_teks_awal());
        }
        else
        {
            yield return new WaitForSeconds(4f);
            obj_teks_awal.GetComponent<FadeOutTutor>().isDone = true;
            indx_teks = 0;
            playerScript.speed = 5;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Tutorial"))
        {
            playerScript.speed = 0;
            obj_panah.SetActive(false);
            STATE_2_1();
        }
    }

    /// <summary>
    /// 
    /// </summary>
    void STATE_2_1()
    {
        StartCoroutine(ie_teks_dua_state1());
    }

    /// <summary>
    /// fungsi animasi teks berjalan pada teks ke dua
    /// </summary>
    /// <returns></returns>
    IEnumerator ie_teks_dua_state1()
    {
        txtKedua.text = "";
        foreach (char c in str_kedua[indx_teks])
        {
            txtKedua.text += c;
            if (!audioSource.isPlaying)
                audioSource.Play();
            yield return new WaitForSeconds(0.05f);
        }
        audioSource.Stop();
        indx_teks++;
        if (indx_teks < 2)
        {
            yield return new WaitForSeconds(4f);
            StartCoroutine(ie_teks_dua_state1());
            yield break;
        }
        else if (indx_teks == 2)
        {
            yield return new WaitForSeconds(4f);
            StartCoroutine(ie_teks_dua_state1());
            yield break;
        }

        btn_ya_mau.GetComponent<BoxCollider>().enabled = true;
        
        // btn_ya_mau.interactable = false;
    }

    public void STATE_2_2()
    {

        StartCoroutine(ie_teks_dua_state2());
    }
    IEnumerator ie_teks_dua_state2()
    {
        txtKedua.text = "";
        foreach (char c in str_kedua[indx_teks])
        {
            txtKedua.text += c;
            if (!audioSource.isPlaying)
                audioSource.Play();
            yield return new WaitForSeconds(0.05f);
        }
        audioSource.Stop();
        indx_teks++;
    }

    public void ButtonPapanClick(int indx)
    {
        if (list_btnPapan[indx])
            return;

        list_btnPapan[indx] = true;

        jumTekan++;
        if (jumTekan == 1)
        {
            STATE_2_2();
        }
        else if (jumTekan == 4)
        {
            // UnityEngine.SceneManagement.SceneManager.LoadScene("MainMenu");
            StartCoroutine(ie_teks_dua_state3());
        }
    }

    IEnumerator ie_teks_dua_state3()
    {
        txtKedua.text = "";
        txtKedua.color = Color.green;
        foreach (char c in str_kedua[indx_teks])
        {
            txtKedua.text += c;
            if (!audioSource.isPlaying)
                audioSource.Play();
            yield return new WaitForSeconds(0.05f);
        }
        audioSource.Stop();

        yield return new WaitForSeconds(3f);
        GameManager.NamaScene = "MainMenu";
        UnityEngine.SceneManagement.SceneManager.LoadScene("LoadingScene");
    }
}
