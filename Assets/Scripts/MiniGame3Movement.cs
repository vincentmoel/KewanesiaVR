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
    private CharacterController cc;
    public Ikan ikan;
    public Animator sharkAnim;
    public AudioSource feedSource;
    public AudioSource bgmsource;
    public AudioClip bgmsound;
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

    public TextMeshProUGUI txtHighScore;

    public GameObject prefab_explosion;

    private float xRotation;
    private float yRotation;
    private float mouseSensitive = 100;

    public Rigidbody rb;
    void Start()
    {
        sharkAnim.SetBool("isSwimming", true);
        feedSource.clip = feedSound;
        cc = GetComponent<CharacterController>();
        speed *= GlobalVar.GetSpeedMovement();
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {


        float mouseX = Input.GetAxis("Mouse X") * Time.deltaTime * mouseSensitive;
        float mouseY = Input.GetAxis("Mouse Y") * Time.deltaTime * mouseSensitive;

        xRotation -= mouseY;
        yRotation += mouseX;
        xRotation = Mathf.Clamp(xRotation, -90f, 90f);

        Debug.Log(mouseX);
        vrCamera.localRotation = Quaternion.Euler(xRotation, yRotation, 0f);
        //transform.Rotate(Vector3.up * mouseX);

        if (!ikan.state)
        {
            return;
        }

        //Vector3 forward = vrCamera.TransformDirection(Vector3.forward);
        //cc.SimpleMove(forward * speed);

         transform.Translate(Vector3.forward * (speed * Time.deltaTime));

        //rb.velocity = (transform.forward * xRotation) * speed * Time.fixedDeltaTime;
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
            rb.AddExplosionForce(3000, other.transform.localPosition, 3000);
            ikan.totBomb.Remove(other.gameObject);
            GetComponent<Rigidbody>().AddExplosionForce(1000, transform.position, 1000);
            feedSource.clip = bombSound;
            feedSource.Play();
            GameObject particle = Instantiate(prefab_explosion, other.transform.position, Quaternion.identity);
            Destroy(other.gameObject);
            Destroy(particle, 5f);
            if(score > 0)
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

        bgmsource.clip = bgmsound;
        bgmsource.Play();

        StartCoroutine(Timer());
    }

    public void EndGame()
    {
        ikan.state = false;
        animal.SetActive(true);
        textCounter.gameObject.SetActive(false);
        textTimer.gameObject.SetActive(false);

        bgmsource.Stop();

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


        HighScore();
        StartCoroutine(loadScene());
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


    //tampil high score
    public void HighScore()
    {
        txtHighScore.gameObject.SetActive(true);

        if (score >= GlobalVar.GetHighScoreHiu())
        {
            //simpan highscore
            GlobalVar.SetHighScoreHiu(score);
        }
        txtHighScore.text = "SCORE : " + score.ToString() + "\nHIGHSCORE : " + GlobalVar.GetHighScoreHiu().ToString();

    }

    IEnumerator loadScene()
    {
        yield return new WaitForSeconds(4f);
        SceneManager.LoadSceneAsync("LoadingScene");
    }
}
