using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IceADAttack : MonoBehaviour
{
    public GameObject myObject;

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
        if (collision.gameObject.tag == "Player" && collision.gameObject != myObject)
        {
            collision1 = collision;
            collision.gameObject.GetComponent<CharacterModule>().Damage(10);
            collision.gameObject.GetComponent<CharacterModule>().slow();
        }
    }
}
