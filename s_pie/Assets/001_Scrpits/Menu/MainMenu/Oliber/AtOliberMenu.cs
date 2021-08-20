using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AtOliberMenu : OnFocus
{
    [Header("���� ���ϸ�����")]
    public Animator animator = null;

    // TODO : ��� ������ �� ��
    public override void Focus()
    {
        if (animator.GetCurrentAnimatorClipInfo(0)[0].clip.name == "OliberLightsOff")
            animator.SetTrigger("On");
    }
    
    void Update()
    {
        // �޴��� �����ϸ� ���� Ŵ
        if (FocusManager.IsFocus(FocusManager.FocusTarget.Oliber))
        {
            Focus();
        }
    }
}
