using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkeAssAttack : MonoBehaviour
{
    public GameObject myObject;

    Collider2D collision1;
    void Start()
    {
        StartCoroutine(EffectTime());
    }

    public void Update()
    {
        transform.Translate(Vector2.right / 8f);
    }

    public IEnumerator EffectTime()
    {
        yield return new WaitForSeconds(0.1f);
        Destroy(this.gameObject);
    }



    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player" && collision.gameObject != myObject)
        {
            collision1 = collision;
            collision.gameObject.GetComponent<CharacterModule>().Damage(10);
            if (collision.gameObject.GetComponent<CharacterModule>().currentSpeed == 0)
            {
                collision.gameObject.GetComponent<CharacterModule>().Damage(30);
            }
            else
            {
                collision.gameObject.GetComponent<CharacterModule>().Damage(10);
            }
        }

    }
}
