using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class UiContoller : MonoBehaviour
{
    public AudioSource audioSource;
    public AudioClip[] clips;
    public GameObject pauseMenu;
    
    // Start is called before the first frame update
    void Start()
    {
        pauseMenu.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.P))
        {
            pauseMenu.SetActive(true);
            Time.timeScale = 0;
        }
    }
    public void LoadLevel(int index)
    {
        SceneManager.LoadScene(index);
    }
    public void ReturnToMenu()
    {
        SceneManager.LoadScene(0);
    }
    public void Quit()
    {
        Application.Quit();
    }

    public void playclick()
    {
        audioSource.PlayOneShot(clips[Random.Range(0, clips.Length)]);
    }
}
