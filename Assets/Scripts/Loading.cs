using System.Collections;
using TMPro;
using UnityEngine;
using UnityEngine.SocialPlatforms;
using Random = UnityEngine.Random;

public class Loading : MonoBehaviour
{
    private int loading;
    public TextMeshProUGUI textCounter;
    void Start()
    {
        StartCoroutine(RandomLoading());
    }

    private IEnumerator RandomLoading()
    {
        yield return new WaitForSeconds(Random.Range(0, 3));
        
        loading += Random.Range(10, 20);
        
        textCounter.text = loading + "%";
        
        if (loading >= 100)
        {
            textCounter.text = "100 %";
            StopCoroutine(RandomLoading());
        }
        else
        {
            StartCoroutine(RandomLoading());
        }
        
        
    }
}
