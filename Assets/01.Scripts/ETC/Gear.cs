using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gear : MonoBehaviour
{
    public GameObject deadEffect;



    public void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.CompareTag("Player"))
        {
            CharacterModule character = collision.GetComponent<CharacterModule>();
            character.currentHP -= 10;
            if (character.currentHP < 0)
            {
                character.currentHP = 0;
                character.CharacterDead();
            }
        }
    }

}
