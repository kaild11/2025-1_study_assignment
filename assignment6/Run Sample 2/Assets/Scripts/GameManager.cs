using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public UIManager MyUIManager;

    public GameObject Character;
    public GameObject CamObj;

    const float CharacterSpeed = 3f;

    public int NowScore = 0;

    void Awake()
    {
        MyUIManager.DisplayScore(NowScore);
        MyUIManager.DisplayMessage("", 0);
    }

    void Update()
    {
        MoveCharacter();
    }

    void LateUpdate()
    {
        MoveCam();
    }

    void MoveCam()
    {
        if (Character && CamObj)
        {
            Vector3 pos = CamObj.transform.position;
            pos.x = Character.transform.position.x;
            pos.y = Character.transform.position.y;
            CamObj.transform.position = pos;
        }
    }

    void MoveCharacter()
    {
        if (Character)
        {
            Character.transform.position += Vector3.right * CharacterSpeed * Time.deltaTime;
        }
    }

    public void GameOver()
    {
        Destroy(Character);
        MyUIManager.DisplayMessage("Game Over!", 3f);
        MyUIManager.RestartButton.SetActive(true);
    }

    public void GetPoint(int point)
    {
        NowScore += point;
        MyUIManager.DisplayScore(NowScore);
    }

    public void RestartGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
