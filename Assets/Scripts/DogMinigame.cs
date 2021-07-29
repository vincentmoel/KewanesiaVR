using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DogMinigame : MonoBehaviour
{
    public TextMeshProUGUI timer;
    public TextMeshProUGUI highScore;
    public AudioSource speaker;
    public AudioClip finishSound;
    public AudioClip ingameSound;
    public AudioClip bgmSound;
    private float totalTime;
    private TimeSpan ts;
    
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Dog"))
        {
            other.gameObject.SetActive(false);
            StopAllCoroutines();
            timer.gameObject.SetActive(false);
            
            HighScore();
            StartCoroutine(loadScene());
            
            speaker.Stop();
            speaker.clip = finishSound;
            speaker.Play();
            speaker.loop = false;
        }
    }

    public void StartGame()
    {
        timer.gameObject.SetActive(true);
        
        speaker.Stop();
        speaker.clip = ingameSound;
        speaker.Play();

        StartCoroutine(StartTime());
    }

    private IEnumerator StartTime()
    {
        yield return new WaitForSeconds(1);

        totalTime += 1;

        ts = TimeSpan.FromSeconds(totalTime);
        timer.text = string.Format("{0:00}:{1:00}", ts.TotalMinutes, ts.Seconds);


        StartCoroutine(StartTime());
    }
    
    public void HighScore()
    {
        highScore.gameObject.SetActive(true);

        if (totalTime <= GlobalVar.GetTimeDog())
        {
            //simpan highscore
            GlobalVar.SetTimeDog(totalTime);
            
        }
        var ts2 = TimeSpan.FromSeconds(GlobalVar.GetTimeDog());
        highScore.text = "TIME : " + string.Format("{0:00}:{1:00}", ts.TotalMinutes, ts.Seconds) + "\nHIGHSCORE : " + string.Format("{0:00}:{1:00}", ts2.TotalMinutes, ts2.Seconds);
    }
    
    IEnumerator loadScene()
    {
        yield return new WaitForSeconds(4f);
        
        speaker.Stop();
        speaker.clip = bgmSound;
        speaker.Play();
        speaker.loop = true;
        
        SceneManager.LoadSceneAsync("LoadingScene");
    }
}
