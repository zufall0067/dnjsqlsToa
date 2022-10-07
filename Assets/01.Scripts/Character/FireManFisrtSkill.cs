using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireManFisrtSkill : MonoBehaviour
{
    public GameObject myObject;
    private float delayTime;
    private float startTime;

    private void Start()
    {
        //startTime = 0f;
        //delayTime = 1.3f;
        //gameObject.transform.localScale = new Vector3(0f,0f,0f);
        //StartCoroutine(Destroy());
    }

    /*public IEnumerator Destroy()
    {
        //while(true)
        //{
        //    if(startTime > delayTime)
        //    {
        //        break;
        //    }

        //    startTime += Time.deltaTime;
            
        //    gameObject.transform.localScale += new Vector3(1f,1f,1f) * Time.deltaTime;

        //    yield return new WaitForSeconds(Time.deltaTime);
        //}
        //yield return null;
        //Destroy(gameObject);
    }*/

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player") && collision.gameObject != myObject)
        {
            collision.gameObject.GetComponent<CharacterModule>().Damage(20);
        }
    }
}
