using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MapMove : MonoBehaviour
{
    Vector3 pos; //현재위치


    public float delta = 2.0f; // 좌(우)로 이동가능한 (x)최대값

    public float speed = 3.0f; // 이동속도


    GameObject Object;
    Image image;


    void Start()
    {
        image = GameObject.Find("Canvas/MapMove").GetComponent<Image>();
        //Object = GameObject.Find("Canvas/MapMove");
        pos = transform.position;
        //image = Object.GetComponent<Image>();
        StartCoroutine(ChangeColor());
    }


    void Update()
    {
        Vector3 v = pos;
        v.y += delta * Mathf.Sin(Time.time * speed);
        v.x += delta * Mathf.Sin(Time.time * speed);
        transform.position = v;
    }


    IEnumerator ChangeColor()
    {
        WaitForSeconds waitForSeconds = new WaitForSeconds(2f);
        while (true)
        {
            image.color = new Color(Random.value, Random.value, Random.value, Random.Range(0.1f, 0.5f));
            yield return waitForSeconds;
        }
    }
}
