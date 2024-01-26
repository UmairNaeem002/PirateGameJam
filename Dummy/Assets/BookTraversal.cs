using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class BookTraversal : MonoBehaviour
{
    [SerializeField] private GameObject[] pages;
    [SerializeField] private bool bookFocused;
    int currentIndex;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    public void bookHasBeenPicked() {
        bookFocused = true;
        pages[0].SetActive(true);
        currentIndex = 0;
    }

    // Update is called once per frame
    void Update()
    {
        if (bookFocused) {
            if (Input.GetKeyDown(KeyCode.D)) {
                if (currentIndex == pages.Length-1) {
                    return;
                }
                pages[currentIndex].SetActive(false);
                currentIndex++;
                pages[currentIndex].SetActive(true);
            }
            if (Input.GetKeyDown(KeyCode.A)) {
                if (currentIndex == 0) {
                    return;
                }
                pages[currentIndex].SetActive(false);
                currentIndex--;
                pages[currentIndex].SetActive(true);
            } 
            if (Input.GetKeyDown(KeyCode.X)) {
                foreach (GameObject page in pages) {
                    page.SetActive(false);
                }
                currentIndex = 0;
                bookFocused = false;
            }
        }
    }

}
