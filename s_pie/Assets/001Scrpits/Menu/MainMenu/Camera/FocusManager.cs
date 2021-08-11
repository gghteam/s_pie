using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FocusManager : MonoBehaviour
{
    // ī�޶� ���߰� �ִ� �޴�
    private bool[] targets = new bool[4] { true, false, false, false };

    static private FocusManager inst = null; // static �Լ� ���� �뵵

    private void Awake()
    {
        inst = this;
    }

    public enum FocusTarget
    {
        Main = 0,
        Oliber,
        Bianca,
        Option,

        END_OF_ENUM // �ݺ��� ���� ����ϱ� ����
    }

    /// <summary>
    /// ī�޶� ���߰� �ִ� �޴��� �˷��ݴϴ�.
    /// </summary>
    /// <param name="target">���߰� �ִ� �޴�</param>
    static public void SetFocus(FocusTarget target)
    {
        inst.targets[(int)target] = true;


        // ���߰� ���� ���� �޴� �������� false �� �ٲ�
        for (int i = 0; i < (int)FocusTarget.END_OF_ENUM; ++i)
        {
            if (i == (int)target) continue;

            inst.targets[i] = false;
        }

    }

    /// <summary>
    /// ī�޶� ���� �ش�Ǵ� ���߰� �ִ��� �˷��ݴϴ�
    /// </summary>
    /// <param name="target">Ȯ���� �޴�</param>
    /// <returns>bool[target]</returns>
    static public bool IsFocus(FocusTarget target)
    {
        return inst.targets[(int)target];
    }
}
