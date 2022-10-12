using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PuchWarrior : CharacterModule
{
    public GameObject firstSkillEffect3;


    public GameObject secondSkillEffect2;

    public GameObject attackEffect1;

    public float delayTime;
    public float endTime = 5f;

    public void Update()
    {
        delayTime += 0.01f;
    }

    public override void AttackAnimation(float Angle)
    {
        GameObject clone = attackEffect;
        var ins = Instantiate(clone, firePos.position + firePos.forward, Quaternion.Euler(0, 0, Angle));
        ins.transform.gameObject.GetComponent<PunchAttack>().myObject = this.myObject;
        if (delayTime <= endTime)
        {
            StartCoroutine(DelayCheck(angle));
            Debug.Log(DelayCheck(angle));
            delayTime = 0f;
        }
        if(delayTime >= 5.1f)
        {
            Debug.Log("0");
            delayTime = 0f;
        }
    }

    public IEnumerator DelayCheck(float angle)
    {
        yield return new WaitForSeconds(0.2f);
        Debug.Log("기다료");
        var ins = Instantiate(attackEffect, firePos.position + firePos.forward, Quaternion.Euler(0, 0, angle));
        Debug.Log("나온다");
        ins.transform.gameObject.GetComponent<PunchAttack>().myObject = this.myObject;
        yield return new WaitForSeconds(0.2f);
        Debug.Log("기다료");
        ins = Instantiate(attackEffect1, firePos.position + firePos.up, Quaternion.Euler(0, 0, angle));
        Debug.Log("나온다");
        ins.transform.gameObject.GetComponent<PunchAttack>().myObject = this.myObject;

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
        GameObject clone3 = firstSkillEffect3;


        Instantiate(clone, gameObject.transform);
        yield return new WaitForSeconds(1f);
        var ins = Instantiate(clone3, this.gameObject.transform.position, Quaternion.identity);

        yield return new WaitForSeconds(7f);
        Destroy(ins);

        StartCoroutine(FirstSkillDelayChecker(1f));
    }

    public override void SecondSkill()
    {
        if (secondSkillAble == false || Level <= 2)
        {
            return;
        }

        secondSkillAble = false;
        StartCoroutine(SecondSkillCorutine());
    }

    public IEnumerator SecondSkillCorutine()
    {
        GameObject clone = secondSkillEffect;
        GameObject clone1 = secondSkillEffect2;

        Instantiate(clone1, gameObject.transform);

        yield return new WaitForSeconds(1f);

        var ins = Instantiate(clone, firePos.position + firePos.forward, Quaternion.Euler(0, 0, Mathf.Atan2(mousePos.y - characterPos.y, mousePos.x - characterPos.x) * Mathf.Rad2Deg));
        ins.transform.gameObject.GetComponent<PunchWarriorSceondSkill>().myObject = this.myObject;
        for (int i = 0; i < 200; i++)
        {
            yield return new WaitForSeconds(0.01f);
            ins.transform.Translate(Vector2.right / 5f);
        }
        //Collider2D collis = Physics2D.OverlapCircle(transform.position, 1f);
        Destroy(ins);

        StartCoroutine(SecondSkillDelayChecker(5f));
    }

    private void Start()
    {
        Init(defaultHP, defaultDF, defaultAD, defaultSpeed, defaultAS);
        StartCoroutine(CharacterUpdate(0.01f));
    }
}
