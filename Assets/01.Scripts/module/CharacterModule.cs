using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public abstract class CharacterModule : MonoBehaviour
{
    public Slider hpbar;

    public float defaultHP = 100f;
    public float defaultDF = 10f;
    public float defaultAD = 30f;
    public float defaultSpeed = 11.3f;
    public float defaultAS = 0.6f;

    public float currentHP = 100f;
    public float currentSpeed;

    public bool attackAble;
    public bool fisrtSkillAble;
    public bool secondSkillAble;

    public float iceTime;

    public float slowTime;

    public bool jumpAble;

    public Rigidbody2D rigidbody;
    public Vector2 mousePos, characterPos;
    public float angle;
    public int Level;

    public GameObject attackEffect;
    public GameObject levelUpEffect;
    public GameObject firstSkillEffect;
    public GameObject secondSkillEffect;
    public GameObject myObject;
    public Transform firePos;

    public void Update()
    {
        hpbar.value = (float)currentHP / defaultHP;
    }

    public IEnumerator CharacterUpdate(float timeDelay)
    {
        StartCoroutine(KeyInPut(timeDelay));
        var CorutineTimeDelay = new WaitForSeconds(timeDelay);
        while (true)
        {
            if (iceTime <= 0)
            {
                iceTime = 0;
            }
            if (slowTime <= 0)
            {
                slowTime = 0;
            }

            if (iceTime > 0)
            {
                currentSpeed = 0;
                iceTime -= 1f * 0.01f;
            }
            else if (slowTime > 0)
            {
                slowTime -= 0.25f * 0.1f;
                currentSpeed = defaultSpeed / 2;
            }
            else
            {
                currentSpeed = defaultSpeed;
            }

            mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            angle = Mathf.Atan2(mousePos.y - characterPos.y, mousePos.x - characterPos.x) * Mathf.Rad2Deg;
            //firePos.transform.rotation = Quaternion.AngleAxis(angle, Vector3.forward);
            yield return CorutineTimeDelay;
        }
    }

    private void OnDrawGizmos()
    {
        Gizmos.DrawCube(transform.position, new Vector3(2f, 1f, 1f));
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
        currentSpeed = defaultSpeed;
        rigidbody = GetComponent<Rigidbody2D>();
        myObject = this.gameObject;
    }

    public void Damage(float damage)
    {
        if (defaultDF - damage < 0)
            currentHP -= (damage - defaultDF);

        currentHP -= 1;
        hpbar.value = currentHP;
    }

    public void slow()
    {
        slowTime = 0.25f;
    }

    public void Ice()
    {
        iceTime = 2;
    }

    public void Attack(float AD, float AS, float Angle)
    {
        if (attackAble == false)
            return;

        attackAble = false;

        AttackAnimation(Angle);

        StartCoroutine(AttackDelayChecker(AS));
    }

    public abstract void AttackAnimation(float Angle);

    public IEnumerator AttackDelayChecker(float AS)
    {
        yield return new WaitForSeconds(AS);
        attackAble = true;
    }

    public void CharacterDead()
    {

        Destroy(this.gameObject);
    }

    void OnBecameInvisible()
    {
        CharacterDead();
    }

    public IEnumerator KeyInPut(float timeDelay)
    {
        float moveX;

        var CorutineTimeDelay = new WaitForSeconds(timeDelay);

        while (true)
        {
            moveX = 0;

            if (Input.GetKey(KeyCode.A))
            {
                moveX -= 1;
                //rigidbody.AddForce(Vector3.left * currentSpeed, ForceMode2D.Impulse);
            }

            if (Input.GetKey(KeyCode.D))
            {
                moveX += 1;
                //rigidbody.AddForce(Vector3.right * currentSpeed, ForceMode2D.Impulse);
            }

            if (Input.GetKey(KeyCode.S))
            {
                rigidbody.AddForce(Vector3.down, ForceMode2D.Impulse);
            }

            if (Input.GetKey(KeyCode.Q))
                FirstSkill();

            if (Input.GetKey(KeyCode.E))
                SecondSkill();

            if (Input.GetMouseButton(0))
            {
                Attack(defaultAD, defaultAS, angle);
            }

            if (Input.GetKey(KeyCode.Space) && jumpAble == true)
            {
                jumpAble = false;
                rigidbody.AddForce(Vector3.up * 6.5f, ForceMode2D.Impulse);
            }


            var velocity = Vector2.right * moveX * currentSpeed * Time.deltaTime;
            var curVel = rigidbody.velocity;

            if((curVel.x>0&&moveX<0)|| (curVel.x < 0 && moveX > 0))
            {
                curVel.x = 0;
                rigidbody.velocity = curVel;
            }
            float x = Mathf.Clamp(curVel.x, -7, 7);
            curVel.x = x;
            rigidbody.AddForce(velocity, ForceMode2D.Force);

            characterPos = transform.position;
            yield return CorutineTimeDelay;
        }
    }

    public void LevelUp()
    {
        Level++;
        Instantiate(levelUpEffect, transform.position, Quaternion.identity);
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

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Ground")
        {
            jumpAble = true;
        }
    }
}
