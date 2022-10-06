using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireWarrior : CharacterModule
{
    public GameObject firstSkillEffect2;
    public GameObject firstSkillEffect3;

    [Header("2번째 스킬")]
    public GameObject secondSkillEffect;

    public override void AttackAnimation(float Angle)
    {
        GameObject clone = attackEffect;
        Instantiate(clone, firePos.position + firePos.forward, Quaternion.Euler(0,0,Angle));
    }

    public override void FirstSkill()
    {
        if (fisrtSkillAble == false || Level <= 1)
        {
            return;
        }

        fisrtSkillAble = false;

       StartCoroutine(FirstSkillCoroutine());
    }

    public IEnumerator FirstSkillCoroutine()
    {
        GameObject clone = firstSkillEffect;
        //GameObject clone2 = firstSkillEffect2;
        GameObject clone3 = firstSkillEffect3;

        //Instantiate(clone2, gameObject.transform);
        Instantiate(clone3, gameObject.transform);

        yield return new WaitForSeconds(2f);

        Instantiate(clone, this.gameObject.transform.position, Quaternion.identity);

        StartCoroutine(FirstSkillDelayChecker(1f));
    }

    public override void SecondSkill()
    {
        GameObject clone = secondSkillEffect;

        currentSpeed = currentSpeed * 1.5f;
        Instantiate(clone, this.gameObject.transform.position, Quaternion.identity);

        StartCoroutine(SecondSkillDelayChecker(1f));
    }

    private void Start()
    {
        Init(defaultHP, defaultDF, defaultAD, defaultSpeed, defaultAS);
        StartCoroutine(CharacterUpdate(0.01f));
    }
}
