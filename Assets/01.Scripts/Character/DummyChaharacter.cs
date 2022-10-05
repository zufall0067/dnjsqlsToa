using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DummyChaharacter : CharacterModule
{
    public void Start()
    {
        this.StartCoroutine(CharacterUpdate(0.01f));    
        Init(defaultHP,0,0,0,0);
        StopCoroutine(this.KeyInPut(0.01f));
    }

    public override void AttackAnimation(float Angle)
    {
        return;
    }

    public override void FirstSkill()
    {
        return;
    }

    public override void SecondSkill()
    {
        return;
    }
}
