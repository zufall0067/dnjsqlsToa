using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireWarriorAttack : MonoBehaviour
{
    void Start()
    {
        StartCoroutine(EffectTime());
    }

    void Update()
    {
        
    }

    public IEnumerator EffectTime()
    {
        yield return new WaitForSeconds(0.5f);
        Destroy(this.gameObject);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag == "Player")
        {
            collision.gameObject.GetComponent<CharacterModule>().Damage(30);
        }
    }
}
