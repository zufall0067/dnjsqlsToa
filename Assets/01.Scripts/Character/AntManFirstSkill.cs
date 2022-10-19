using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AntManFirstSkill : MonoBehaviour
{
    public GameObject myObject;
    CharacterModule character;

    private void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player") && collision.gameObject != myObject)
        {
            character = GetComponent<CharacterModule>();

        }
    }
}
