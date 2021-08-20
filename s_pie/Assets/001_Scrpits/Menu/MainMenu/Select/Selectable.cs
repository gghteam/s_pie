using System.Collections;
using System.Collections.Generic;
using UnityEngine;

abstract public class Selectable : MonoBehaviour
{
    [HideInInspector] public int index; // SelectManager ���� ���� ���� index

    private void OnTriggerEnter2D(Collider2D collision)
    {
        SelectManager.ToggleSelected(index);
        OnCursorUp();
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        SelectManager.ToggleSelected(index);
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
