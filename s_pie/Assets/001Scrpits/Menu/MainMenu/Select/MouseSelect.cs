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
        SelectMouse();
    }

    private void FollowMouse()
    {
        trmCollider.position = Camera.main.ScreenToWorldPoint(Input.mousePosition);
    }

    private void SelectMouse()
    {
        if (Input.GetMouseButtonDown(0))
        {
            LightSelectManager.Select();
        }
    }
}
