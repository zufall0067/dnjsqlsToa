using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireWarrior : CharacterModule
{
    public GameObject firstSkillEffect2;
    public GameObject firstSkillEffect3;

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


        /*Collider2D[] collis = Physics2D.OverlapCircleAll(transform.position, 1f);

        for(int i = 0; i < collis.Length; i++)
        {
            if(collis[i].gameObject.tag.Equals("Player"))
            {
                if (collis[i].gameObject.transform.position == this.transform.position)
                {
                    continue;
                }
                collis[i].gameObject.GetComponent<CharacterModule>().Damage(10);
            }
        }*/

        StartCoroutine(FirstSkillDelayChecker(1f));
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
