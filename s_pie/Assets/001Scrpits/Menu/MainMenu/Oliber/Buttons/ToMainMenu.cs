using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ToMainMenu : Selectable
{
    [Header("���� ���ϸ�����")]
    public Animator animator = null;

    public override void OnCursorLeft()
    {
        // TODO : ���ϸ��̼�
    }

    public override void OnCursorUp()
    {
        
    }

    public override void OnSelected()
    {
        Debug.Log("Off");
        animator.SetTrigger("Off"); // ������ ��, OliberLightsOffState �� �˾Ƽ� ī�޶� ������ ��
    }
}
