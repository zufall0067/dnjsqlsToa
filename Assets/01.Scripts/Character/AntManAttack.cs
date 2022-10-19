using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AntManAttack : MonoBehaviour
{
    public GameObject myObject;


    Collider2D collision1;
    void Start()
    {
        StartCoroutine(EffectTime());
    }

    public void Update()
    {
        transform.Translate(Vector2.right / 6f);
    }

    public IEnumerator EffectTime()
    {
        yield return new WaitForSeconds(0.15f);
        Destroy(this.gameObject);
    }



    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player" && collision.gameObject != myObject)
        {
            collision1 = collision;
            collision.gameObject.GetComponent<CharacterModule>().Damage(15);
        }
    }
}
