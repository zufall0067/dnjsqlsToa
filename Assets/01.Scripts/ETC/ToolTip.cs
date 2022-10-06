using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ToolTip : MonoBehaviour
{
    public GameObject[] tooltip;

    public void ButtonClick()
    {
        tooltip[0] .SetActive(true);
    }
    public void ButtonClickExit()
    {
        tooltip[0].SetActive(false);
    }

    public void ButtonClick1()
    {
        tooltip[1].SetActive(true);
    }
    public void ButtonClickExit1()
    {
        tooltip[1].SetActive(false);
    }

    public void ButtonClick2()
    {
        tooltip[2].SetActive(true);
    }
    public void ButtonClickExit2()
    {
        tooltip[2].SetActive(false);
    }
    public void ButtonClick3()
    {
        tooltip[3].SetActive(true);
    }
    public void ButtonClickExit3()
    {
        tooltip[3].SetActive(false);
    }
}
