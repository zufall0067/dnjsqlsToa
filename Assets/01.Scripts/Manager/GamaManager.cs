using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GamaManager : MonoBehaviour
{
    private static GamaManager Instance;
    public static GamaManager instance { get { return Instance; } }

    public List<GameObject> checkedPlayer = new List<GameObject>();

    public void PlayerInIt()
    {
        GameObject temp;
        temp = GameObject.FindObjectOfType<CharacterModule>().gameObject;
        if (!GameObject.FindObjectOfType<CharacterModule>().gameObject.GetComponent<CheckedPlayer>())
        {
            GameObject.FindObjectOfType<CharacterModule>().gameObject.AddComponent<CheckedPlayer>();
            checkedPlayer.Add(temp);
        }
        
  
    }
}
