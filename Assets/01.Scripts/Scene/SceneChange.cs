using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class SceneChange : MonoBehaviour
{
    public Button button, button2, button3, button4,button5;
    public string characterModule;

    private void Start()
    {
        DontDestroyOnLoad(this);
    }
    void OnEnable()
    {
        SceneManager.sceneLoaded -= OnSceneLoaded;
        SceneManager.sceneLoaded += OnSceneLoaded;
    }

    void OnDisable()
    {
        SceneManager.sceneLoaded -= OnSceneLoaded;
    }

    public void CharacterLoadScene()
    {
        SceneManager.LoadScene("Tutorial");
    }

    public void MainLoadScene()
    {
        SceneManager.LoadScene("StartScene");
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

    public void ChangeCharacterSceneSetting()
    {
        button = GameObject.Find("FireWarButton").GetComponent<Button>();
        button2 = GameObject.Find("IceADButton").GetComponent<Button>();
        button3 = GameObject.Find("PuchWarButton").GetComponent<Button>();
        button4 = GameObject.Find("SkeButton").GetComponent<Button>();
        button5 = GameObject.Find("AntButton").GetComponent<Button>();

        button.onClick.AddListener(() => CharacterSelect("FireWar"));
        button2.onClick.AddListener(() => CharacterSelect("IceAD")); 
        button3.onClick.AddListener(() => CharacterSelect("PuchWar"));
        button4.onClick.AddListener(() => CharacterSelect("Ske")); 
        button5.onClick.AddListener(() => CharacterSelect("AntMan")); 
    }

    public void MapSceneSetting()
    {
        GameObject clone = Resources.Load<GameObject>(characterModule);
        clone.gameObject.GetComponent<CharacterModule>().isPlayer = true;
        Instantiate(clone, Vector3.zero, Quaternion.identity);
    }
}
