using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseSelect : MonoBehaviour
{
    [Header("선택 용도의 컬라이더 오브젝트")]
    [SerializeField] private Transform trmCollider = null; // 마우스를 따라다닐 컬라이더 오브젝트

    void Update()
    {
        FollowMouse();
    }

    private void FollowMouse()
    {
        trmCollider.position = Camera.main.ScreenToWorldPoint(Input.mousePosition);

        // TODO : 마우스 클릭
    }
}
