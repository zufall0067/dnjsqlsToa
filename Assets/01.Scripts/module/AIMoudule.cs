using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AIMoudule : MonoBehaviour
{
    public Rigidbody2D rigidbody;
    public RaycastHit hit;
    public Transform AITransform;
    public Transform target;

    [Header("±‚∫ª Ω∫≈»")]
    public float defaultHP;

    void Start()
    {
        AITransform = GetComponent<Transform>();
        rigidbody = GetComponent<Rigidbody2D>();
        target = FindObjectOfType<CharacterModule>().gameObject.transform;
    }

    void FixedUpdate()
    {
        rigidbody.velocity = new Vector2(target.position.x, target.position.y);
    }

    public void SetTarget()
    {
        //Physics2D.OverlapBoxAll(this.transform.position, 3f);
        if (Physics.Raycast(target.transform.position, Vector2.down, out hit, 1f))
        {
            target.transform.position = hit.transform.position;
        }
    }

    public void Damage()
    {
        Debug.Log("a");
    }

    private void Update()
    {
        Debug.DrawRay(this.transform.position, Vector2.down, Color.red, 1f);
    }
}
