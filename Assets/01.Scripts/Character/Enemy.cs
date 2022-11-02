using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class Enemy : CharacterModule
{
    public CharacterModule characterModule;
    public Transform target;
    public Rigidbody2D rb;

    private void Start()
    {
        Init(characterModule.defaultHP, characterModule.defaultDF, characterModule.defaultAD, characterModule.defaultSpeed, characterModule.defaultAS);
        rb = GetComponent<Rigidbody2D>();
        StartCoroutine(CharacterUpdate(0.01f));
    }

    public override IEnumerator KeyInPut(float timeDelay)
    {
        while(true)
        {
            if(target.position != this.transform.position)
            {
                rb.MovePosition(target.position);
            }
            yield return new WaitForSeconds(timeDelay);
        }
        
    }

    public override void AttackAnimation(float Angle)
    {

    }

    public override void FirstSkill()
    {

    }

    public override void SecondSkill()
    {

    }
}
