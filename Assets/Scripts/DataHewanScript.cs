using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class DataHewanScript : MonoBehaviour
{
    public Color colorDisable;

    [Header("SO hewan")]
    public HewanScriptable so_hewan;

    [Header("Tampilan text dan gambar")]
    [SerializeField] private TextMeshProUGUI txtNamaHewan;

    [Header("Page Isi")]
    [SerializeField] private TextMeshProUGUI txtIsiData;
    [SerializeField] private Image imgHewan;

    [Header("Status progress hewan")]
    [SerializeField] private List<Button> listButton;
    [SerializeField] private List<bool> listStatusActive;

    [Tooltip("Mengecek apakah player berada pada jangkauan hewan atau tidak")]
    [SerializeField] private bool isPlayerThere = false;

    private void Awake()
    {
        so_hewan.Awake();
        SetData();

        if (so_hewan.statusHewan)
            TampilanHewanSelesai();
        else
        {
            CheckStatusButton();
        }
    }

    #region Progress Hewan

    private void TampilanHewanSelesai()
    {
        txtNamaHewan.text = so_hewan.namaHewan;
        txtIsiData.text = so_hewan.deskripsiHewan;

        //buat status button menjadi true semua
        for (int i = 0; i < listStatusActive.Count; i++)
        {
            listStatusActive[i] = true;
        }
    }

    /// <summary>
    /// Set status button menjadi false semua dari awal
    /// Button deskripsi true, yang lain false
    /// </summary>
    private void CheckStatusButton()
    {
        for (int i = 0; i < listStatusActive.Count; i++)
        {
            //set color button
            if (listStatusActive[i])
                listButton[i].image.color = Color.white;
            else
                listButton[i].image.color = colorDisable;
        }
    }

    private IEnumerator ie_TimerBacaan(int indx)
    {
        yield return new WaitForSeconds(5f);
        //nyalakan button selanjutnya
        if (indx < 3)
        {
            listStatusActive[indx + 1] = true;
            listButton[indx + 1].interactable = true;
            CheckStatusButton();
        }
        else if (indx == 3)
        {
            txtNamaHewan.text = so_hewan.namaHewan;
            // status hewan terbuka
            so_hewan.statusHewan = true;
            so_hewan.ActivedHewan(1);
        }
    }
    #endregion

    /// <summary>
    /// Set tampilan data hewan dari scriptable object
    /// </summary>
    private void SetData()
    {
        txtNamaHewan.text = "Hewan apa hayoooo";
        imgHewan.sprite = so_hewan.gambarHewan;
    }

    /// <summary>
    /// Fungsi Click dari button untuk menampilkan data
    /// 0 = Deskripsi,
    /// 1 = Ciri,
    /// 2 = Gambar,
    /// 3 = Makanan
    /// </summary>
    /// <param name="indx"></param>
    public void TampilData(int indx)
    {
        switch (indx)
        {
            case 0:
                TampilText(so_hewan.deskripsiHewan);
                if (!listStatusActive[indx + 1] && !so_hewan.statusHewan)
                    StartCoroutine(ie_TimerBacaan(indx));
                break;
            case 1:
                TampilText(so_hewan.ciriHewan);
                if (!listStatusActive[indx + 1] && !so_hewan.statusHewan)
                    StartCoroutine(ie_TimerBacaan(indx));
                break;
            case 2:
                TampilGambar();
                if (!listStatusActive[indx + 1] && !so_hewan.statusHewan)
                    StartCoroutine(ie_TimerBacaan(indx));
                break;
            case 3:
                TampilText(so_hewan.makananHewan);
                if (!so_hewan.statusHewan)
                    StartCoroutine(ie_TimerBacaan(indx));
                break;
        }

    }

    /// <summary>
    /// Fungsi Untuk menampilkan Text isi
    /// </summary>
    /// <param name="txt"></param>
    private void TampilText(string txt)
    {
        imgHewan.gameObject.SetActive(false);
        txtIsiData.gameObject.SetActive(true);
        txtIsiData.text = txt;
    }

    /// <summary>
    /// Fungsi untuk menampilkan Gambar
    /// </summary>
    private void TampilGambar()
    {
        imgHewan.gameObject.SetActive(true);
        txtIsiData.gameObject.SetActive(false);
    }


    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            isPlayerThere = true;

            //bikin button interactable
            int i = 0;
            foreach(var a in listStatusActive)
            {
                if (a)
                    listButton[i].interactable = true;
                else
                    listButton[i].interactable = false;
                i++;
            }
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            StopAllCoroutines();
            isPlayerThere = false;

            //bikin button disable
            foreach (var a in listButton)
            {
                a.interactable = false;
            }
        }
    }
}
