using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StageManager : MonoBehaviour
{
    public GameObject[] prefabs;
    // Start is called before the first frame update
    void Start()
    {
        StageStart();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void StageStart()
    {
        int map = Random.Range(0, prefabs.Length);
        prefabs[map].SetActive(true);
    }
}
