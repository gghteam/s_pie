using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ToMenuPosition : Selectable
{
    [Header("ī�޶� �̵� ��ġ")]
    public Transform moveTo = null;

    [Header("�̵��� ��ġ Enum")]
    public FocusManager.FocusTarget location;

    [Header("ī�޶� �̵� �ð�")]
    public float duration = 2.0f;


    public override void OnCursorUp()
    {
        if (LightSelectManager.isSelected) return;
        LightSelectManager.LightOn(index); // �ش��ϴ� �ε����� ������ Ų��
    }

    public override void OnCursorLeft()
    {
        if (LightSelectManager.isSelected) return;
        LightSelectManager.LightOff(index); // �ش��ϴ� �ε����� ������ ����
    }

    public override void OnSelected()
    {
        // �ش� ��ġ�� �̵��� ������ ī�޶� ���߰� �ִ� �޴� ������ ��������
        CameraMover.MoveCamera(moveTo.position, duration, () => FocusManager.SetFocus(location));
    }
}
