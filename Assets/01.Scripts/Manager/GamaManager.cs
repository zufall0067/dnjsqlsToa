using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GamaManager : MonoBehaviour
{
    private static GamaManager Instance;
    public static GamaManager instance { get { return Instance; } }

    public GameObject[] playerChecker = new GameObject[2];

    public void PlayerInIt()
    {
        //if(GameObject.FindObjectOfType<CharacterModule>().gameObject.GetComponent<CheckedPlayer>)
        //GameObject.FindObjectOfType<CharacterModule>().gameObject.AddComponent<CheckedPlayer>();
  
    }
}
