using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireWarSecondSkill : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag.Equals("Player"))
        {
            collision.gameObject.GetComponent<CharacterModule>().Damage(10);
            Debug.Log("플레이어 충돌");
        }
    }
}
