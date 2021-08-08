using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// �ϴ� ���� ī�޶� ����

public class CameraMover : MonoBehaviour
{
    static private CameraMover inst = null;                   // static �Լ� ���� ��

    private WaitForEndOfFrame wait = new WaitForEndOfFrame(); // ��� �ν��Ͻ��� �������� �ʾ���
    private Transform         cam  = null;                    // ������ �ڵ带 ����

    public delegate void Callback();                          // �ݹ��



    private void Awake()
    {
        inst = this;
        cam = Camera.main.transform;
    }


    /// <summary>
    /// ī�޶��� ��ġ�� �����մϴ�.
    /// </summary>
    /// <param name="pos">������ ��ġ</param>
    static public void SetCameraPos(Vector2 pos)
    {
        inst.cam.position = new Vector3(pos.x, pos.y, inst.cam.position.z);
    }


    /// <summary>
    /// ī�޶� �̵���ŵ�ϴ�.
    /// </summary>
    /// <param name="pos">�̵���ų ��ġ</param>
    static public void MoveCamera(Vector2 pos, float duration, Callback callback = null)
    {
        inst.StartCoroutine(inst.CamMovement(pos, duration, callback));
    }

    private IEnumerator CamMovement(Vector2 pos, float duration, Callback callback)
    {
        Vector2 origin = cam.position;
        Vector2 vect   = pos - (Vector2)cam.position; // lerp �뵵
        Vector3 lerp;                                 // ī�޶��� z �� ������

        // Sin�Լ� �뵵
        float degree = 0;
        float add    = Mathf.PI / 2.0f / duration; 


        while (degree <= Mathf.PI / 2.0f)
        {
            degree += add * Time.deltaTime;

            lerp = origin + vect * Mathf.Sin(degree);
            lerp.z = -10; 
            cam.position = lerp;

            yield return wait;
        }
        
        callback?.Invoke();
    }
}
