using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneTransitor : MonoBehaviour
{
    [SerializeField] private string scene;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            SceneManager.LoadScene(scene);
        }
    }
}
