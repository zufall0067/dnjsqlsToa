using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireWarSecondSkillCollider : MonoBehaviour
{
    public GameObject myObject;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player") && collision.gameObject != myObject)
        {
            collision.gameObject.GetComponent<CharacterModule>().Damage(20);
        }
    }
}
