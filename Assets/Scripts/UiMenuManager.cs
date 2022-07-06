using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class UiMenuManager : MonoBehaviour
{
    public void UserNameEntered(string userName)
    {
        DataManager.Instance.UserName = userName;
    }
}
