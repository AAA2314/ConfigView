using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ConfigButton : MonoBehaviour
{
    [SerializeField] GameObject settingView;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    public void ConfigOpen()
    {
        settingView.SetActive(true);
    }

    public void ConfigClose()
    {
        settingView.SetActive(false);

    }

    public void GameEnd()
    {
        SceneManager.LoadScene("OpeningScene");//シーンを切り替える処理
    }
}
