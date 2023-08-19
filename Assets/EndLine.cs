using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class EndLine : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.GetComponent<Enemy>())
            ExitGame();
    }
    void ExitGame()
    {
#if UNITY_EDITOR // �����Ϳ��� ����� �������Ͽ��� ����
        UnityEditor.EditorApplication.isPlaying = false; // �����Ϳ��� ����
#else
        Application.Quit(); // ���忡�� ����
#endif
    }
}
