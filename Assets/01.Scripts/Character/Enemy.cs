using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class Enemy : CharacterModule
{
    public CharacterModule characterModule;
    public Transform target;

    private void Start()
    {
        Init(characterModule.defaultHP, characterModule.defaultDF, characterModule.defaultAD, characterModule.defaultSpeed, characterModule.defaultAS);
        StartCoroutine(CharacterUpdate(0.01f));
    }

    public override IEnumerator KeyInPut(float timeDelay)
    {
        while(true)
        {
            this.gameObject.transform.DOMove(target.position, timeDelay);
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
