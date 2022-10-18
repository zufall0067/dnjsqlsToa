using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class SceneChange : MonoBehaviour
{
    public Button button, button2, button3, button4;
    public string characterModule;

    private void Start()
    {
        DontDestroyOnLoad(this);
    }

    public void CharacterLoadScene()
    {
        SceneManager.LoadScene("ChangeCharacterScene");
    }

    public void BattleStartLoadScene()
    {
        SceneManager.LoadScene("Map");
    }

    public void CharacterSelect(string character)
    {
        characterModule = character;
        BattleStartLoadScene();
    }

    public void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        if(scene.name.Equals("ChangeCharacterScene"))
        {
            ChangeCharacterSceneSetting();
        }

        if(scene.name.Equals("Map"))
        {
            MapSceneSetting();
        }
    }

    List<KeyValuePair<string, string>> keyValue = new List<KeyValuePair<string, string>>();
    private void Awake()
    {
        keyValue.Add(new KeyValuePair<string, string>("C1","FirWar"));
    }
    public void ChangeCharacterSceneSetting()
    {
        for(int i=0;i<4;i++)
        { 
        }
        button = GameObject.Find("C1").transform.GetChild(1).GetComponent<Button>();
        button2 = GameObject.Find("C2").transform.GetChild(1).GetComponent<Button>();
        button3 = GameObject.Find("C3").transform.GetChild(1).GetComponent<Button>();
        button4 = GameObject.Find("C4").transform.GetChild(1).GetComponent<Button>();

        button.onClick.AddListener(() => CharacterSelect("FireWar"));
        button2.onClick.AddListener(() => CharacterSelect("IceAD")); 
        button3.onClick.AddListener(() => CharacterSelect("PuchWar"));
        button4.onClick.AddListener(() => CharacterSelect("Ske")); 
    }

    public void MapSceneSetting()
    {
        GameObject clone = Instantiate(Resources.Load(characterModule), ,Quaternion.identity);
    }
}
