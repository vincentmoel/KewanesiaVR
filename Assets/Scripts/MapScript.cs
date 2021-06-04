using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapScript : MonoBehaviour
{
    [SerializeField] private List<MapScriptableObject> listMap;
    [SerializeField] private List<GameObject> objMap;
    [SerializeField] private List<GameObject> objProgressTemplate;
    [SerializeField] private List<Transform> contentParentProgress;

    private void Start()
    {
        BuatProgress();
    }

    public void CheckStatusProgress()
    {

    }

    private void BuatProgress()
    {
        int indxParent = 0;
        List<GameObject> listProgress = new List<GameObject>();
        foreach (var a in listMap)
        {
            int indxHewan = 0;
            int jumActive = 0;
            foreach (var b in a.listHewan)
            {
                //bikin tampilan progress
                GameObject progress = Instantiate(objProgressTemplate[indxParent], contentParentProgress[indxParent]);
                progress.SetActive(true);
                listProgress.Add(progress);
              

                b.Awake();
                if (b.getStatusHewan())
                    jumActive++;
            }
            indxParent++;
            //cek status hewan yang active
            if (jumActive == a.listHewan.Count && indxParent < listMap.Count)//jika jumlah yang active sama dengan jumlah hewan, berarti selesai
            {
                //activekan map selanjutnya
                CheckStatusHewan(jumActive, listProgress);
                objMap[indxParent].GetComponent<SphereCollider>().enabled = true;
            }
            else if(indxParent < listMap.Count)
            {
                CheckStatusHewan(jumActive, listProgress);
                objMap[indxParent].GetComponent<SphereCollider>().enabled = false;
            }
            listProgress.Clear();
        }
    }

    private void CheckStatusHewan(int jumlahActive, List<GameObject> _progress)
    {
        for (int i = 0; i < jumlahActive; i++)
        {
            _progress[i].transform.Find("active").gameObject.SetActive(true);
        }
    }
}
