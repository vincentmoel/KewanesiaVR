using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class MinigameMonyet : MonoBehaviour
{
    private int count;
    public GameObject cat;
    public GameObject animalCounter;

    public AudioClip finishSound;
    public AudioClip bgmSound;
    public AudioClip gameSound;
    public AudioClip animalSound;
    public AudioSource bgmSource;

    public AudioSource animalSource;

    public List<GameObject> listcats;

    public TextMeshProUGUI textCounter;

    public GameObject ObjPlaceAnimal; //parent dari list list animal

    public GameObject Animal;


    // Start is called before the first frame update
    void Start()
    {
        
    }
    
    private void OnTriggerEnter(Collider other)
    {

        if (other.gameObject.CompareTag("Cat"))
        {
            animalSource.clip = animalSound;
            animalSource.Play();
            
            other.gameObject.SetActive(false);
            
            count++;
            textCounter.text = "Cat : " + count.ToString() + "/5";

            if (count == 5)
            {
                textCounter.text = "Misi selesai !";
                textCounter.fontSize = 100;
                textCounter.alignment = TextAlignmentOptions.Center;
                
                bgmSource.Stop();
                bgmSource.clip = finishSound;
                bgmSource.Play();
                
                StartCoroutine(CounterTimer());
            }
        }
    }

    private IEnumerator CounterTimer()
    {
        yield return new WaitForSeconds(5);
        UnityEngine.SceneManagement.SceneManager.LoadScene("LoadingScene");
        cat.SetActive(false);
        animalCounter.SetActive(false);
        
        bgmSource.Stop();
        bgmSource.clip = bgmSound;
        bgmSource.Play();
        
        ObjPlaceAnimal.SetActive(transform);
        Animal.SetActive(true);
    }

    public void ResetMiniGame()
    {

        //reset the text canvas
        count = 0;
        textCounter.text = "Cat : " + count.ToString() + "/5";
        textCounter.alignment = TextAlignmentOptions.TopLeft;
        textCounter.fontSize = 32;

        GetComponent<Movement>().enabled = true;

        bgmSource.Stop();
        bgmSource.clip = gameSound;
        bgmSource.Play();
        
        ResetCatPosition();

    }

    public void ResetCatPosition()
    {
        List<int> catRandom = new List<int>();
        while (catRandom.Count != 5)
        {
            int random = Random.Range(0, 9);
            if (!catRandom.Contains(random))
            {
                catRandom.Add(random);
            }
        }

        foreach (var index in catRandom)
        {
            listcats[index].SetActive(true);
        }

        //play the audio game
        bgmSource.Stop();
        bgmSource.clip = gameSound;
        bgmSource.Play();
    }

    
}
