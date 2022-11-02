using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TutorialsManager : MonoBehaviour
{
    [SerializeField][Header("Tutorials items")] TutorialsItemControl[] items;
    int itemIndex = 0;
    // Start is called before the first frame update
    void Start()
    {
        // ��� �������� ��Ȱ��ȭ �ϰ�, ù��° �͸� Ȱ��ȭ �Ѵ�.
        if (items == null)
            return;

        if (items.Length == 0)
            return;

        foreach (var item in items)
        {
            item.gameObject.SetActive(false);
        }

        itemIndex = -1;
        ActiveNextItem();
    }


    // ���� �������� Ȱ��ȭ �Ѵ�.
    public void ActiveNextItem()
    {
        // ���� ������ ��Ȱ��ȭ
        if (itemIndex > -1 && itemIndex < items.Length)
        {
            items[itemIndex].gameObject.SetActive(false);
        }

        // �ε��� ����
        itemIndex++;

        if (itemIndex > -1 && itemIndex < items.Length)
        {
            items[itemIndex].gameObject.SetActive(true);
        }

    }
}

