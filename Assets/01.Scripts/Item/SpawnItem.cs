using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnItem : MonoBehaviour
{
    public GameObject Item;
    public float currTime;

    void Update()
    {
        currTime += Time.deltaTime;

        if (currTime > 60)
        {
            float newX = Random.Range(-17.5f, 17.5f), newY = Random.Range(10.5f,9.5f);

            GameObject item = Instantiate(Item);

            Debug.Log(item.transform.position);
            item.transform.position = new Vector3(newX, newY);

            currTime = 0;
        }
    }
}
