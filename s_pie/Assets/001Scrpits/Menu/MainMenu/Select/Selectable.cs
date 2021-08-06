using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Selectable : MonoBehaviour
{
    [Header("ī�޶� �̵� ����")]
    [Header("�ε�ȭ�� ��ġ")]
    public Transform loadingTrm = null;

    [Header("ī�޶� �̵� ��ġ")]
    public Transform moveTo = null;

    [Header("�̵� �ð�")]
    public float duration = 2.0f;

    [Header("���� ����")]
    [Header("�ε���")]
    public int       index  = 0;


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (LightSelectManager.isSelected) return;
        LightSelectManager.LightOn(index);
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (LightSelectManager.isSelected) return;
        LightSelectManager.LightOff(index);
    }

    public void OnSelected()
    {
        CameraMover.MoveCamera(moveTo.position, duration);
    }
}
