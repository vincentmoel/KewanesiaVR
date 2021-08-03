using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class FadeOutTutor : MonoBehaviour
{
    /// <summary>
    /// kalau teks ini udah selesai
    /// </summary>
    public bool isDone;
    public Image img_bg;
    public TextMeshProUGUI text;

    [SerializeField] float nilaiAwal = 1;
    public float speed = 10f;
    private void Update()
    {
        if (isDone)
        {
            nilaiAwal -= (speed * Time.deltaTime);
            text.color = new Color(1, 1, 1, nilaiAwal);
            img_bg.color = new Color(1, 1, 1, nilaiAwal);
        }
        if (nilaiAwal < 0)
            gameObject.SetActive(false);
    }
}
