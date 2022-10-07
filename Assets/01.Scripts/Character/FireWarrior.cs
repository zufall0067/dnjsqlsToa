using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireWarrior : CharacterModule
{
    public GameObject firstSkillEffect2;
    public GameObject firstSkillEffectBoom;

    public float secondSkillTime;
    public float secondSkillDelay;
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
        GameObject cloneBoom = firstSkillEffectBoom;

        Instantiate(clone, gameObject.transform);

        yield return new WaitForSeconds(2f);

        Instantiate(cloneBoom, this.gameObject.transform.position, Quaternion.identity).transform.GetComponent<FireManFisrtSkill>().myObject = this.myObject;

        StartCoroutine(FirstSkillDelayChecker(1f));
    }

    public override void SecondSkill()
    {
        if(!secondSkillAble || Level <= 2)
        {
            return;
        }

        secondSkillDelay = 5f;
        secondSkillTime = 0;
        secondSkillAble = false;

        GameObject clone = secondSkillEffect;

        currentSpeed = currentSpeed * 1.5f;
        Debug.Log(currentSpeed);
        
        StartCoroutine(SecendSkillCoroutine(clone));
    }

    public IEnumerator SecendSkillCoroutine(GameObject clone)
    {
        var WaitSecond = new WaitForSeconds(0.08f);
        while(secondSkillTime < secondSkillDelay)
        {
            secondSkillTime += 0.08f;
            Instantiate(clone, this.gameObject.transform.position - new Vector3(0,1,0), Quaternion.identity).transform.GetComponent<FireWarSecondSkillCollider>().myObject = this.myObject;
            yield return WaitSecond;
        }
        currentSpeed = defaultSpeed;
        StartCoroutine(SecondSkillDelayChecker(10f));
    }

    private void Start()
    {
        Init(defaultHP, defaultDF, defaultAD, defaultSpeed, defaultAS);
        StartCoroutine(CharacterUpdate(0.01f));
    }
}
