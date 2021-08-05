using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseSelect : MonoBehaviour
{
    [Header("���� �뵵�� �ö��̴� ������Ʈ")]
    [SerializeField] private Transform trmCollider = null; // ���콺�� ����ٴ� �ö��̴� ������Ʈ

    void Update()
    {
        FollowMouse();
    }

    private void FollowMouse()
    {
        trmCollider.position = Camera.main.ScreenToWorldPoint(Input.mousePosition);

        // TODO : ���콺 Ŭ��
    }
}
