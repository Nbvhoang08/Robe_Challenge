﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Fail : CanvasUI
{
    public void RetryBtn()
    {
        Time.timeScale = 1;
        StartCoroutine(ReLoad());
    }
    IEnumerator ReLoad()
    {
        yield return new WaitForSeconds(1);
        ReloadCurrentScene();
    }
    public void ReloadCurrentScene()
    {
        // Lấy tên của scene hiện tại 
        string currentSceneName = SceneManager.GetActiveScene().name;
        //Tải lại scene hiện tại
        SceneManager.LoadScene(currentSceneName);
        UIManager.Instance.CloseUIDirectly<Fail>();
    }
}
