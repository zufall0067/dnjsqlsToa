using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GearRotate : MonoBehaviour
{
    public int rotate = 0;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(rotate == 0)
        {
            transform.Rotate(new Vector3(0,0,47) * Time.deltaTime * 1);
            rotate++;
        }
        else
        {
            transform.Rotate(new Vector3(0, 0, 45) * Time.deltaTime);
        }
    }
}
