using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightSelectManager: MonoBehaviour
{
    [Header("ĳ���� ����Ʈ, ���ʺ��� �־��ּ���.")]
    [SerializeField] private List<Animator>   lights = new List<Animator>();        // �����
    [SerializeField] private List<Selectable> selectables = new List<Selectable>(); // ���� ������Ʈ
                     private List<bool>       isLightsOn = new List<bool>();        // ���� ����

    static private LightSelectManager inst = null; // static �Լ� ���� ��

    static public bool isSelected = false; // �޴��� �����ߴ���


    private void Awake()
    {
        inst = this;

        SetLightsStatusList();
    }

    // isLightsOn ����Ʈ �ʱ�ȭ
    private void SetLightsStatusList()
    {
        for (int count = 0; count < lights.Count; ++count) // lights ����Ʈ ũ��� ���� ����
        {
            isLightsOn.Add(false);
        }
    }

    // ���� Ű�� �Լ�
    static public void LightOn(int index)
    {
        inst.lights[index].SetTrigger("On");
        inst.isLightsOn[index] = true;
    }

    // ���� ���� �Լ�
    static public void LightOff(int index)
    {
        inst.lights[index].SetTrigger("Off");
        inst.isLightsOn[index] = false;
    }

    /// <summary>
    /// �޴� ���� �Լ�
    /// </summary>
    static public void Select()
    {
        int idx = inst.GetCurrentSelected();

        if (idx != -1)
        {
            inst.selectables[idx].OnSelected();
            isSelected = true;
        }
    }

    /// <summary>
    /// ���� ���õ� �Ŵ��� �ε����� �����ɴϴ�.
    /// </summary>
    /// <returns>���� �����ִ� ���� �ε���.<br></br>���� ��� -1</returns>
    private int GetCurrentSelected()
    {
        for (int i = 0; i < isLightsOn.Count; ++i)
        {
            if (isLightsOn[i]) // �����ִٸ� �ε��� ��ȯ
            {
                return i;
            }
        }

        return -1;
    }
}
