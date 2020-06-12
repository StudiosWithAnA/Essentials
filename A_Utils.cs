using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

namespace AUtils
{

}
public class A_SCUtil
{
    public static void ChangeScene(int index)
    {
        SceneManager.LoadScene(index);
    }

    public static void ReloadScene()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}
public class A_
{

    public static void DeActivate(GameObject objectRef)
    {
        objectRef.SetActive(false);
    }
    public static void Activate(GameObject objectRef)
    {
        objectRef.SetActive(true);
    }

    public static void WriteTMP(TextMeshProUGUI Dis, string ValName)
    {
        Dis.text = ValName;
    }

    public static void Leave()
    {
        Application.Quit();
    }

    public static void GetMousePos(Camera cam, Vector2 pos)
    {
        pos = cam.ScreenToWorldPoint(Input.mousePosition);
    }

}
