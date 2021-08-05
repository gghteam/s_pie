using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SelectManager : MonoBehaviour
{
    [Header("ĳ���� ����Ʈ, ���ʺ��� �־��ּ���.")]
    [SerializeField] private List<Animator> lights = new List<Animator>(); // �����

    static private SelectManager inst = null; // static �Լ� ���� ��

    private void Awake()
    {
        inst = this;
    }

    // ���� Ű�� �Լ�
    static public void LightOn(int index)
    {
        inst.lights[index].SetTrigger("On");
    }

    // ���� ���� �Լ�
    static public void LightOff(int index)
    {
        inst.lights[index].SetTrigger("Off");
    }
}
