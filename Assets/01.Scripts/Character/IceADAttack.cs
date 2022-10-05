using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IceADAttack : MonoBehaviour
{
    Collider2D collision1;
    void Start()
    {
        StartCoroutine(EffectTime());
    }

    public void Update()
    {
        
        transform.Translate(Vector2.right / 5f);
    }

    public IEnumerator EffectTime()
    {
        yield return new WaitForSeconds(5f);
        Destroy(this.gameObject);
    }



    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            collision1 = collision;
            collision.gameObject.GetComponent<CharacterModule>().Damage(10);
            collision.gameObject.GetComponent<CharacterModule>().defaultSpeed = 750;
            collision.gameObject.GetComponent<CharacterModule>().currentSpeed = 750;
            StartCoroutine(Slow());
        }

    }

    public IEnumerator Slow()
    {
        yield return new WaitForSeconds(0.25f);
        collision1.gameObject.GetComponent<CharacterModule>().defaultSpeed = 1500;
        collision1.gameObject.GetComponent<CharacterModule>().currentSpeed = 1500;
    }



}
