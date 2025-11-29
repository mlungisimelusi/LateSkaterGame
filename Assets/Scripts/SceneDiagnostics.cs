using UnityEngine;

public class SceneDiagnostics : MonoBehaviour
{
    void Start()
    {
        GameObject[] players = GameObject.FindGameObjectsWithTag("Player");
        Debug.Log("Number of Players in scene: " + players.Length);
    }
}
