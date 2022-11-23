using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GamaManager : MonoBehaviour
{
    private static GamaManager Instance;
    public static GamaManager instance { get { return Instance; } }

    bool isPlay = false;

    float tick = 0f;

    private void Start()
    {
        isPlay = false;
        tick = 0f;
    }

    public void DeadPlayer()
    {
        isPlay = false;
    }

    public void GameStart()
    {
        tick = 0f;
        isPlay = true;


    }

    public IEnumerator TimeChecker()
    {
        WaitForSeconds waitForSeconds = new WaitForSeconds(0.01f);
        while(isPlay)
        {
            yield return waitForSeconds;
            tick += 0.01f;
        }
    }
}
