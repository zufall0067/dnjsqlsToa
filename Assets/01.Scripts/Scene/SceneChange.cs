using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class SceneChange : MonoBehaviour
{
    public Button button, button2, button3, button4;
    public CharacterModule characterModule;

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

    public void CharacterSelect(CharacterModule character)
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

        }
    }

    public void ChangeCharacterSceneSetting()
    {
        button = GameObject.Find("C1").transform.GetChild(1).GetComponent<Button>();
        button2 = GameObject.Find("C2").transform.GetChild(1).GetComponent<Button>();
        button3 = GameObject.Find("C3").transform.GetChild(1).GetComponent<Button>();
        button4 = GameObject.Find("C4").transform.GetChild(1).GetComponent<Button>();

        
    }

    public void MapSceneSetting()
    {

    }
}
