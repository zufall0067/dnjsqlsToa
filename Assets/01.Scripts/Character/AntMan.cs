using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AntMan : CharacterModule
{
    public Slider Hpbar;



    public float delayTime;
    public float endTime = 5f;


    public void Update()
    {
        Hpbar.value = (float)currentHP / (float)defaultHP;
        delayTime += 0.01f;
    }

    public void damage(float damage)
    {
        if (defaultDF - damage < 0)
            currentHP -= (damage - defaultDF);

        currentHP -= 1;
        Hpbar.value = currentHP;
        CharacterDead();
    }

    public override void AttackAnimation(float Angle)
    {
        GameObject clone = attackEffect;
        var ins = Instantiate(clone, firePos.position, Quaternion.Euler(0, 0, Angle));
        ins.transform.gameObject.GetComponent<AntManAttack>().myObject = this.myObject;
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


        var ins = Instantiate(clone, firePos.transform);
        ins.transform.gameObject.GetComponent<AntManFirstSkill>().myObject = this.myObject;
        yield return new WaitForSeconds(1f);
        gameObject.transform.localScale = new Vector3((float)0.3,(float)0.3,(float) 0.3);
        gameObject.GetComponent<CharacterModule>().currentHP -= 20;
        yield return new WaitForSeconds(5f);
        gameObject.transform.localScale = new Vector3((float)1, (float)1, (float)1);


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

        var ins = Instantiate(clone, gameObject.transform);
        ins.transform.gameObject.GetComponent<AntManSecondSkill>().myObject = this.myObject;
        yield return new WaitForSeconds(1f);
        gameObject.transform.localScale = new Vector3((float)3, (float)3, (float)3);
        gameObject.GetComponent<CharacterModule>().currentHP += 50;
        yield return new WaitForSeconds(5f);
        gameObject.transform.localScale = new Vector3((float)1, (float)1, (float)1);

        StartCoroutine(SecondSkillDelayChecker(5f));
    }

    private void Start()
    {
        Init(defaultHP, defaultDF, defaultAD, defaultSpeed, defaultAS);
        StartCoroutine(CharacterUpdate(0.01f));
    }
}
