using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SelectManager: MonoBehaviour
{
    [Header("���� ������ ������Ʈ��")]
    [SerializeField] private List<Selectable> selectables = new List<Selectable>(); // ���� ������Ʈ
                     private List<bool>       selected    = new List<bool>();       // ���� ����

    static private SelectManager inst = null; // static �Լ� ���� ��

    private void Awake()
    {
        inst = this;

        SetSelectablesIndex();
        SetSelectedStatusList();
    }

    #region �ʱ�ȭ

    // Selectable.index ����
    private void SetSelectablesIndex()
    {
        for (int i = 0; i < selectables.Count; ++i)
        {
            selectables[i].index = i;
        }
    }

    // selected ����Ʈ �ʱ�ȭ
    private void SetSelectedStatusList()
    {
        for (int count = 0; count < selectables.Count; ++count) // lights ����Ʈ ũ��� ���� ����
        {
            selected.Add(false);
        }
    }

    #endregion


    // ����
    static public void ToggleSelected(int index)
    {
        inst.selected[index] = !inst.selected[index];
    }

    /// <summary>
    /// ���� �Լ�
    /// </summary>
    static public void Select()
    {
        int idx = inst.GetCurrentSelected();
        
        if (idx != -1)
        {
            inst.selectables[idx].OnSelected();
        }
    }

    /// <summary>
    /// ���� ���õ� �Ŵ��� �ε����� �����ɴϴ�.
    /// </summary>
    /// <returns>���� �����ִ� ���� �ε���.<br></br>���� ��� -1</returns>
    private int GetCurrentSelected()
    {
        for (int i = 0; i < selected.Count; ++i)
        {
            if (selected[i]) // �����ִٸ� �ε��� ��ȯ
            {
                return i;
            }
        }

        return -1;
    }

    /// <summary>
    /// Selectables ������Ʈ�� ���� �����ɴϴ�
    /// </summary>
    /// <returns>Count of </returns>
    static public int GetSelectableObjectCount()
    {
        return inst.selectables.Count;
    }
}
