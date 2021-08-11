using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AtOliberMenu : OnFocus
{
    [Header("���� ���ϸ�����")]
    public Animator animator = null;

    public override void Focus()
    {
        animator.SetTrigger("On");
    }

    void Update()
    {
        // �޴��� �����ϸ� ���� Ŵ
        if (FocusManager.IsFocus(FocusManager.FocusTarget.Oliber))
        {
            Focus();
            this.enabled = false;
        }
    }
}
