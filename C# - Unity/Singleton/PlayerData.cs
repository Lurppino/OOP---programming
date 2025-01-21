using UnityEngine;

public class PlayerData : MonoBehaviour
{
    public static PlayerData instance { get; private set; }

    public string playerName = "UserName";
    public int playerLvl = 15;
    public int playerHP = 50;

    public void SaveData()
    {
        Debug.Log("Saving data: " + playerName + " " + playerLvl + " " + playerHP);
    }

    public void LoadData()
    {
        Debug.Log("Loading data: " + playerName + " " + playerLvl + " " + playerHP);
    }

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }
}
