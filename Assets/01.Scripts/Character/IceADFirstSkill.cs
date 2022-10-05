using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IceADFirstSkill : MonoBehaviour
{
    CharacterModule character;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            character = GetComponent<CharacterModule>();
            collision.gameObject.GetComponent<CharacterModule>().Damage(10);
            collision.gameObject.GetComponent<CharacterModule>().Ice();
        }
    }
}
