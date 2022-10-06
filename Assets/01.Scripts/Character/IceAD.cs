using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IceAD : CharacterModule
{
    public GameObject firstSkillEffect2;
    public GameObject firstSkillEffect3;

    public GameObject secondSkillEffect1;
    public GameObject secondSkillEffect2;

    public override void AttackAnimation(float Angle)
    {
        GameObject clone = attackEffect;
        Instantiate(clone, firePos.position + firePos.forward, Quaternion.Euler(0, 0, Angle)).transform.gameObject.GetComponent<IceADAttack>().myObject = this.myObject;
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

        Instantiate(clone, this.gameObject.transform.position, Quaternion.identity).transform.gameObject.GetComponent<IceADFirstSkill>().myObject = this.myObject; 
        //Collider2D collis = Physics2D.OverlapCircle(transform.position, 1f);

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
        GameObject clone = secondSkillEffect1;
        GameObject clone1 = secondSkillEffect2;

        Instantiate(clone1, gameObject.transform);

        yield return new WaitForSeconds(2f);

        Instantiate(clone, this.gameObject.transform.position, Quaternion.identity).transform.gameObject.GetComponent<IceADSecondSkill>().myObject = this.myObject;
        //Collider2D collis = Physics2D.OverlapCircle(transform.position, 1f);

        StartCoroutine(SecondSkillDelayChecker(1f));
    }

    private void Start()    
    {
        Init(defaultHP, defaultDF, defaultAD, defaultSpeed, defaultAS);
        StartCoroutine(CharacterUpdate(0.01f));
    }
}
