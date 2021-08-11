using System.Collections;
using System.Collections.Generic;
using UnityEngine;

abstract public class Selectable : MonoBehaviour
{
    public int index;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        LightSelectManager.LightOn(index);
        OnCursorUp();
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        LightSelectManager.LightOff(index);
        OnCursorLeft();
    }

    /// <summary>
    /// ���콺 �����Ͱ� ���� ���� ��
    /// </summary>
    abstract public void OnCursorUp();

    /// <summary>
    /// ���콺 �����Ͱ� �̰��� ���� ��
    /// </summary>
    abstract public void OnCursorLeft();

    /// <summary>
    /// ���õǾ��� ��
    /// </summary>
    abstract public void OnSelected();
}
