using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireWarrior : CharacterModule
{
    public override void AttackAnimation(float Angle)
    {
        GameObject clone = attackEffect;
        Instantiate(clone, firePos.position + firePos.forward, Quaternion.Euler(0,0,Angle));
    }

    public override void FirstSkill()
    {
        throw new System.NotImplementedException();
    }
    public override void SecondSkill()
    {
        throw new System.NotImplementedException();
    }

    private void Start()
    {
        Init(defaultHP, defaultDF, defaultAD, defaultSpeed, defaultAS);
        StartCoroutine(CharacterUpdate(0.01f));
    }
}
