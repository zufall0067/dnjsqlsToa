using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// �����ϱ� ������ 1��
/// </summary>
public class TutorialsItemControl : MonoBehaviour
{
    public enum ItemType
    {
        touch
    }

    [SerializeField][Header("�����ϱ� ������ ����")] ItemType itemType;
    [SerializeField][Header("����� �Է� ������ ����ð�")] float timeToInput;
    [SerializeField][Header("����� �Է� ���� ǥ���� ���ӿ�����Ʈ")] GameObject gameObjectToShow;

    bool isReadyToInput = false;


    private void Start()
    {

    }
    private void OnEnable()
    {

        Invoke("ShowGameObject", timeToInput);

    }
    // Update is called once per frame
    void Update()
    {
        // �Է´�� ���°� �Ǹ� ��ġ�� �Է� �޴´�.
        if (isReadyToInput)
        {
            if (itemType == ItemType.touch)
            {
                // �Է��� �ϸ� ��� ����
                if (Input.GetMouseButtonDown(0))
                {
                    Run();
                }

            }

        }

    }

    virtual protected void Run()
    {
        if (gameObjectToShow == null)
            return;

        // ǥ�� item ��Ȱ��ȭ �ϰ�
        gameObjectToShow.SetActive(false);

        // ���� ������ Ȱ��ȭ
        TutorialsManager parentTutorialsManager = parentTutorialsManager = transform.parent.GetComponent<TutorialsManager>();
        if (parentTutorialsManager != null)
        {
            parentTutorialsManager.ActiveNextItem();
        }

        Time.timeScale = 1.0f;
    }

    void ShowGameObject()
    {
        isReadyToInput = true;
        Time.timeScale = 0.0f;

        if (gameObjectToShow == null)
            return;

        gameObjectToShow.SetActive(true);
    }
}


