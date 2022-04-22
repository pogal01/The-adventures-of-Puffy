using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;

public class Exit_Collision : MonoBehaviour
{
    [SerializeField]
    PolygonCollider2D collision;
    [SerializeField]
    int WhichScene;

    public GameObject Loading_Panel;
    public Slider slider;
    public TMP_Text progress_Text;

    void OnCollisionEnter2D(Collision2D col)
    {
        if (col.gameObject.tag == "Player")
        {
            Debug.Log("Collision with Exit confirmed");
            Debug.Log("Heading to Scene" + WhichScene);
            StartCoroutine(Load_Asynchronously(WhichScene));
        }
    }

    public IEnumerator Load_Asynchronously(int scene_Index)
    {
        AsyncOperation operation = SceneManager.LoadSceneAsync(scene_Index);

        Loading_Panel.SetActive(true);

        while (!operation.isDone)
        {
            float progress = Mathf.Clamp01(operation.progress);

            Debug.Log(progress);

            slider.value = progress;
            progress_Text.text = progress * 100f + "%";

            yield return null;
        }

        while (operation.isDone)
        {
            Loading_Panel.SetActive(false);
        }
    }
}
