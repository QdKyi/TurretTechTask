using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    [SerializeField] private GameObject gameEndCanvas = null;
    [SerializeField] private TurretAI mainObject = null ;

    private int _minute;
    private int _second;

    // Start is called before the first frame update
    void Start()
    {
        gameEndCanvas.SetActive(false);
        mainObject.onDestroyed.AddListener(GameEnd);
        InvokeRepeating("Timer", 0, 1f);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0) && mainObject)
        {

            Object prefab = AssetDatabase.LoadAssetAtPath("Assets/Prefabs/Monster.prefab", typeof(GameObject));
            Vector3 mousePosition = new Vector3(Camera.main.ScreenToWorldPoint(Input.mousePosition).x, 1, Camera.main.ScreenToWorldPoint(Input.mousePosition).z);
            Instantiate(prefab, mousePosition, Quaternion.identity);

        }
    }

    private void GameEnd()
    {
            gameEndCanvas.GetComponentInChildren<Text>().text = "Time in game: " +  _minute.ToString("00") + ":" +  _second.ToString("00");
            gameEndCanvas.SetActive(true);

    }

    public void Restart()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name); // loads current scene
    }

    private void Timer()
    {
        if (gameEndCanvas.activeInHierarchy == false)
        {
            _minute = (int)(Time.timeSinceLevelLoad / 60f);
            _second = (int)(Time.timeSinceLevelLoad % 60f);
        }
        else
        {
            CancelInvoke("Timer");
        }
    }
}
