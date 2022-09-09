using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    CameraController cameraController;
    DroneController droneController;

    Shape[] shapes;
    BuilderTrigger[] buildTriggers;

    public Animator doorAnim;
    public Animator robotAnim;
    public GameObject pauseMenu;
    private void Awake()
    {
        cameraController = FindObjectOfType<CameraController>();
        droneController = FindObjectOfType<DroneController>();
        shapes = FindObjectsOfType<Shape>();
        buildTriggers = FindObjectsOfType<BuilderTrigger>();
        pauseMenu.SetActive(false);
        cameraController.enabled = false;
    }
    private void Start()
    {
        Invoke("Begin", 1f);
    }
    void Begin()
    {
        cameraController.enabled = true;
    }
    public void StartGame()
    {
        SceneManager.LoadScene(1);
    }

    public void RestartGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void ExitGame()
    {
        Application.Quit();
    }

    public void PauseGame()
    {
        pauseMenu.SetActive(true);
        droneController.enabled = false;
        cameraController.isControllingDrone = false;
    }

    public void ResumeGame()
    {
        pauseMenu.SetActive(false);
        droneController.enabled = true;
        cameraController.isControllingDrone = true;
    }
    public void FinishGame()
    {
        droneController.gameObject.SetActive(false);

        foreach (Shape s in shapes)
        {
            s.gameObject.SetActive(false);
        }

        foreach (BuilderTrigger b in buildTriggers)
        {
            b.gameObject.SetActive(false);
        }

        doorAnim.SetTrigger("Open");
        robotAnim.SetTrigger("Show");

        Invoke("RestartGame", 8f);
    }
}
