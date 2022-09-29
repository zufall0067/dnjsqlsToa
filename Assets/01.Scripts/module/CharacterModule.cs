using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class CharacterModule : MonoBehaviour
{
    public float defaultHP = 100f;
    public float defaultDF = 10f;
    public float defaultAD = 30f;
    public float defaultSpeed = 3.3f;
    public float defaultAS = 0.6f;

    public float currentHP;
    public float currentSpeed;

    public bool attackAble;
    public bool fisrtSkillAble;
    public bool secondSkillAble;

    public Rigidbody2D rigidbody;
    public int Level;

    public IEnumerator CharacterUpdate(float timeDelay)
    {
        StartCoroutine(KeyInPut(timeDelay));
        while (true)
        {
            yield return new WaitForSeconds(timeDelay);
        }
    }

    public void Init(float HP, float DF, float AD, float Speed, float AS)
    {
        defaultHP = HP;
        defaultDF = DF;
        defaultAD = AD;
        defaultSpeed = Speed;
        defaultAS = AS;

        attackAble = true;
        Level = 1;
        rigidbody = GetComponent<Rigidbody2D>();
    }

    public void Damage(float damage)
    {
        if (defaultDF - damage < 0)
             currentHP -= (damage - defaultDF);
        
        currentHP -= 1;
    }

    public void Attack(float AD, float AS)
    {
        if (attackAble == false)
            return;

        attackAble = false;

        AttackAnimation();

        StartCoroutine(AttackDelayChecker(AS));
    }

    public abstract void AttackAnimation();

    public IEnumerator AttackDelayChecker(float AS)
    {
        yield return new WaitForSeconds(AS);
        attackAble = true;
    }

    public IEnumerator KeyInPut(float timeDelay)
    {
        float moveX;
        float moveY;
        while(true)
        {
            moveY = moveX = 0;
            
            if (Input.GetKey(KeyCode.A))
                moveX += 1;

            if (Input.GetKey(KeyCode.D))
                moveX -= 1;

            if (Input.GetKey(KeyCode.S))
                moveY -= 1;

            if (Input.GetKey(KeyCode.Q))
                FirstSkill();

            if (Input.GetKey(KeyCode.E))
                SecondSkill();

            if (Input.GetMouseButton(0))
                Attack(defaultAD, defaultAS);

            if (Input.GetKey(KeyCode.Space))
                rigidbody.AddForce(Vector3.up * 2, ForceMode2D.Impulse);

            Debug.Log("ÀÔ·Â³¡");
            transform.Translate(new Vector3(moveX, moveY, 1).normalized * Time.deltaTime * currentSpeed);

            yield return new WaitForSeconds(timeDelay);
        }
    }

    public abstract void FirstSkill();
   

    public IEnumerator FirstSkillDelayChecker(float coolTime)
    {
        yield return new WaitForSeconds(coolTime);
        fisrtSkillAble = true;
    }

    public abstract void SecondSkill();

    public IEnumerator SecondSkillDelayChecker(float coolTime)
    {
        yield return new WaitForSeconds(coolTime);
        secondSkillAble = true;
    }
}
