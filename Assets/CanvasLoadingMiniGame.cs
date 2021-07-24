using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class CanvasLoadingMiniGame : MonoBehaviour
{
    bool textPlaying = false;
    string sentence;

    public TextMeshProUGUI txtLoading;
    public Animator loadingANim;
    public Transform posisiPlayerStartMiniGame;
    private void Start()
    {

    }

    private void OnEnable()
    {
        sentence = txtLoading.text;
        StartCoroutine(delay_startAnimText());
    }
    private void Update()
    {
        if (loadingANim.GetCurrentAnimatorStateInfo(0).normalizedTime > 1 && !loadingANim.IsInTransition(0))
        {
            gameObject.SetActive(false);
        }
        else
        {
            if (!textPlaying && txtLoading.gameObject.activeSelf)
            {
                textPlaying = true;
                StartCoroutine(ie_animateText());
            }
        }
    }

    IEnumerator delay_startAnimText()
    {
        yield return new WaitForSeconds(1.6f);
        GameObject.FindGameObjectWithTag("Player").transform.position = posisiPlayerStartMiniGame.position;
        txtLoading.gameObject.SetActive(true);
    }
    IEnumerator ie_animateText()
    {
        txtLoading.text = "";
        foreach (var a in sentence.ToCharArray())
        {
            txtLoading.text += a;
            yield return new WaitForSeconds(0.2f);
        }
        textPlaying = false;
    }
}
