using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gear : MonoBehaviour
{
    public float force;
    public GameObject deadEffect;


    private void OnCollisionStay2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            CharacterModule character = collision.gameObject.GetComponent<CharacterModule>();
            character.currentHP -= 1;
            character.rigidbody.AddForce(new Vector2(-4f,1f) * force,ForceMode2D.Impulse);

            if (character.currentHP < 0)
            {
                character.currentHP = 0;
                character.CharacterDead();
            }
        }
    }   
}
