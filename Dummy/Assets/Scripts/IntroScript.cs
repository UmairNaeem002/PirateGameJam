using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Video;

public class IntroScript : MonoBehaviour
{
    [SerializeField] private VideoPlayer introVideo;
    [SerializeField] private GameObject background;
    [SerializeField] private GameObject menu;
    // Start is called before the first frame update
    void Start()
    {
        // introVideo.Play();
        StartCoroutine(StartIntro());
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    IEnumerator StartIntro() {
        introVideo.Play();
        yield return new WaitForSeconds(4f);
        introVideo.gameObject.SetActive(false);
        background.SetActive(true);
        menu.GetComponent<Animator>().SetBool("reveal", true);
    }

    public void OnClickStart() {
        SceneManager.LoadScene(1);
    }

    public void OnExitClicked() {
        Application.Quit();
    }
}
