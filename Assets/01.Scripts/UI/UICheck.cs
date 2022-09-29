using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class UICheck : MonoBehaviour
{
    public TextMeshProUGUI CheckPrefab;
    public GameObject CheckBoxPrefab;
    public void Update()
    {
        CheckUI();  
        Debug.Log(Input.mousePosition);
    }

    public void CheckUI()
    {
        if (Input.mousePosition == CheckPrefab.transform.position)
        {
            Debug.Log("ddd");
            CheckBoxPrefab.SetActive(true);
        }
    }
}
