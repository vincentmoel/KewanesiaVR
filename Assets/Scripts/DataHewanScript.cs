using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class DataHewanScript : MonoBehaviour
{
    [Header("SO hewan")]
    public HewanScriptable so_hewan;
    [Header("Tampilan text dan gambar")]
    [SerializeField] private TextMeshProUGUI txtNamaHewan;
    [SerializeField] private TextMeshProUGUI txtDeskripsi;
    [SerializeField] private TextMeshProUGUI txtCiri;
    [SerializeField] private TextMeshProUGUI txtMakanan;
    [SerializeField] private Image imgHewan;
    [Header("Page bacaan")]
    [SerializeField] private GameObject obj_deskripsi;
    [SerializeField] private GameObject obj_ciri;
    [SerializeField] private GameObject obj_gambar;
    [SerializeField] private GameObject obj_makanan;


    private void Awake()
    {
        SetObjTampilan();
        SetTampilan();
    }

    /// <summary>
    /// Set tampilan data hewan dari scriptable object
    /// </summary>
    private void SetTampilan()
    {
        txtNamaHewan.text = so_hewan.namaHewan;
        txtDeskripsi.text = so_hewan.deskripsiHewan;
        txtCiri.text = so_hewan.ciriHewan;
        txtMakanan.text = so_hewan.makananHewan;
        imgHewan.sprite = so_hewan.gambarHewan;
    }

    /// <summary>
    /// Hide semua object yang ditampilkan (deskripsi,ciri,makanan,gambar)
    /// </summary>
    public void HideObjTampilan()
    {
        obj_deskripsi.SetActive(false);
        obj_ciri.SetActive(false);
        obj_gambar.SetActive(false);
        obj_makanan.SetActive(false);
    }

    private void SetObjTampilan()
    {
        obj_deskripsi = txtDeskripsi.gameObject;
        obj_ciri = txtCiri.gameObject;
        obj_gambar = imgHewan.gameObject;
        obj_makanan = txtMakanan.gameObject;
    }

}
