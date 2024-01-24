using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ChangeScene : MonoBehaviour
{
    [SerializeField]
    private GameObject button;
    [SerializeField]
    private string sceneName;
    [SerializeField]
    private GameObject sceneController;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "Player")
        {
            button.GetComponent<Button>().onClick.RemoveAllListeners();
            button.GetComponent<Button>().onClick.AddListener(delegate { sceneController.GetComponent<SceneController>().changeScene(sceneName); });
            button.SetActive(true);
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if(collision.tag == "Player" && button != null)
        {
            button.SetActive(false);
        }
    }
}
