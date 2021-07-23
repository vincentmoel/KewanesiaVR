using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MiniGame3Movement : MonoBehaviour
{
    public Transform vrCamera;
    public float speed = 10.0f;
    public Rigidbody rb;
    public Ikan ikan;
    public Animator sharkAnim;
    public AudioSource feedSource;
    public AudioClip feedSound;
    public AudioClip bombSound;
    private int score = 0;
    public GameObject pleyer;
    public GameObject minigeym;
    public TextMeshProUGUI textCounter;
    public TextMeshProUGUI textTimer;
    public GameObject tutor;
    public GameObject animal;
    public Transform startPoint;
    public int time;

    void Start()
    {
        sharkAnim.SetBool("isSwimming", true);
        feedSource.clip = feedSound;
    }

    // Update is called once per frame
    void Update()
    {
        if (!ikan.state)
        {
            return;
        } 
        
        Quaternion tes = transform.localRotation;
        
        transform.Translate(Vector3.forward * (speed * Time.deltaTime));
    }

    private void LateUpdate()
    {
        transform.localRotation = vrCamera.localRotation;
        vrCamera.localRotation = Quaternion.Euler(0, 0, 0);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Ikan"))
        {
            ikan.totIkan.Remove(other.gameObject);
            feedSource.clip = feedSound;
            feedSource.Play();
            Destroy(other.gameObject);
            score += 100;
            textCounter.text = "Score : " + score.ToString();
        }
        
        if (other.CompareTag("Bomb"))
        {
            ikan.totBomb.Remove(other.gameObject);
            GetComponent<Rigidbody>().AddExplosionForce(10,transform.position,10);
            feedSource.clip = bombSound;
            feedSource.Play();
            Destroy(other.gameObject);
            score -= 100;
            textCounter.text = "Score : " + score.ToString();
        }
    }

    public void StartGame()
    {
        ikan.state = true;
        animal.SetActive(false);
        textCounter.gameObject.SetActive(true);
        textTimer.gameObject.SetActive(true);
        tutor.SetActive(false);

        StartCoroutine(Timer());
    }

    public void EndGame()
    {
        ikan.state = false;
        animal.SetActive(true);
        textCounter.gameObject.SetActive(false);
        textTimer.gameObject.SetActive(false);
        foreach (var b in ikan.totBomb)
        {
            Destroy(b);
        }

        foreach (var i in ikan.totIkan)
        {
            Destroy(i);
        }
        
        ikan.totIkan.Clear();
        ikan.totBomb.Clear();
        
        minigeym.SetActive(false);
        pleyer.SetActive(true);

        SceneManager.LoadScene("Laut");
    }
    private IEnumerator Timer()
    {
        yield return new WaitForSeconds(1);
        time -= 1;

        textTimer.text = "Timer : " + time.ToString();

        if (time == 0)
        {
            EndGame();
        }
        else
        {
            StartCoroutine(Timer());
        }
    }

}
