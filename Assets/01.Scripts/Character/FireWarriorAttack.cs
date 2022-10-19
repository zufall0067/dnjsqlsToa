using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireWarriorAttack : MonoBehaviour
{
    public GameObject myObject;

    void Start()
    {
        StartCoroutine(EffectTime());
    }

    void Update()
    {
        transform.Translate(Vector2.right / 4f);
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
            collision.gameObject.GetComponent<CharacterModule>().Damage(30);
        }
    }
}
