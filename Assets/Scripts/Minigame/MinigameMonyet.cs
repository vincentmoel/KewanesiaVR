using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class MinigameMonyet : MonoBehaviour
{
    private int count;
    public GameObject monyet;
    public GameObject animalCounter;

    public AudioClip finishSound;
    public AudioClip bgmSound;
    public AudioClip gameSound;
    public AudioSource bgmSource;
    private AudioSource finishSoundSource;

    public List<GameObject> listMonyet;

    public TextMeshProUGUI textCounter;

    public GameObject ObjPlaceAnimal; //parent dari list list animal

    public DataHewanScript dataHewanMonyet;

    // Start is called before the first frame update
    void Start()
    {
        finishSoundSource = GetComponent<AudioSource>();
        finishSoundSource.clip = finishSound;
    }


    private void OnTriggerEnter(Collider other)
    {

        if (other.gameObject.CompareTag("Monyet"))
        {
            other.gameObject.SetActive(false);
            count++;
            textCounter.text = "Monyet : " + count.ToString() + "/5";

            if (count == 5)
            {
                textCounter.text = "Misi selesai !";
                textCounter.fontSize = 100;
                textCounter.alignment = TextAlignmentOptions.Center;

                finishSoundSource.Play();
                StartCoroutine(CounterTimer());
            }
        }
    }

    private IEnumerator CounterTimer()
    {
        yield return new WaitForSeconds(5);
        monyet.SetActive(false);
        animalCounter.SetActive(false);
        dataHewanMonyet.OpenAnimal();
        finishSoundSource.Stop();
        bgmSource.clip = bgmSound;
        bgmSource.Play();
        ObjPlaceAnimal.SetActive(transform);
        ResetMiniGame();
    }

    public void ResetMiniGame()
    {

        //reset the text canvas
        count = 0;
        textCounter.text = "Monyet : " + count.ToString() + "/5";
        textCounter.alignment = TextAlignmentOptions.TopLeft;
        textCounter.fontSize = 32;
    }

    public void ResetMonkeysPosition()
    {
        List<int> monyetRandom = new List<int>();
        while (monyetRandom.Count != 5)
        {
            int random = Random.Range(0, 10);
            if (!monyetRandom.Contains(random))
            {
                monyetRandom.Add(random);
            }
        }

        foreach (var index in monyetRandom)
        {
            listMonyet[index].SetActive(true);
        }

        //play the audio game
        bgmSource.clip = gameSound;
        bgmSource.Play();
    }
}
