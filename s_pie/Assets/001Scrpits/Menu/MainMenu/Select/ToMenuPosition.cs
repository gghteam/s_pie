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

    [Header("�۵��� ����Ʈ")]
    public Animator cellingLight = null;

    public override void OnCursorUp()
    {
        if (cellingLight != null)
        {
            cellingLight.SetTrigger("On");
        }
    }

    public override void OnCursorLeft()
    {
        if (cellingLight != null)
        {
            cellingLight.SetTrigger("Off");
        }
    }

    public override void OnSelected()
    {
        // �ش� ��ġ�� �̵��� ������ ī�޶� ���߰� �ִ� �޴� ������ ��������
        CameraMover.MoveCamera(moveTo.position, duration, () => FocusManager.SetFocus(location));
    }
}
