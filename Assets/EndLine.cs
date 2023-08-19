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
#if UNITY_EDITOR // 에디터에서 종료와 빌드파일에서 종료
        UnityEditor.EditorApplication.isPlaying = false; // 에디터에서 종료
#else
        Application.Quit(); // 빌드에서 종료
#endif
    }
}
