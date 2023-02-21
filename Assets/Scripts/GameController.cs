using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

public class GameController : MonoBehaviour
{

    public static GameController instance;
    public bool isGameStartedFirstTime;
    public bool isMusicOn;
    public int coins;
    public int weaponLevel;
    private GameData data;

    void Awake(){
        CreateInstance();
        InitializeGameVariables();
    }

    void CreateInstance(){
        if(instance != null){
            Destroy(gameObject);
        }
        else
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
    }

    void InitializeGameVariables(){
        Load();
        if(data != null){
            isGameStartedFirstTime = data.GetIsGameStartedFirstTime();
        }
        else
        {
            isGameStartedFirstTime = true;
        }
        if(isGameStartedFirstTime){
            isGameStartedFirstTime = false;
            isMusicOn = true;
            coins = 0;
            weaponLevel = 1;
            data = new GameData();
            data.SetIsGameStartedFirstTime(isGameStartedFirstTime);
            data.SetIsMusicOn(isMusicOn);
            data.SetCoins(coins);
            data.SetWeaponLevel(weaponLevel);
            Save();
            Load();
        }
        else
        {
            isGameStartedFirstTime = data.GetIsGameStartedFirstTime();
            isMusicOn = data.GetIsMusicOn();
            coins = data.GetCoins();
            weaponLevel = data.GetWeaponLevel();
        }
    }

    public void Save(){
        FileStream file = null;
        try{
            BinaryFormatter bf = new BinaryFormatter();
            file = File.Create(Application.persistentDataPath + "/data.dat");
            if(file != null){
                data.SetIsGameStartedFirstTime(isGameStartedFirstTime);
                data.SetIsMusicOn(isMusicOn);
                data.SetCoins(coins);
                data.SetWeaponLevel(weaponLevel);
                bf.Serialize(file, data);
            }
        }catch(Exception e){
            Debug.LogException(e, this);
        }finally{
            if(file != null){
                file.Close();
            }
        }
    }

    public void Load(){
        FileStream file = null;
        try{
            BinaryFormatter bf = new BinaryFormatter();
            file = File.Open(Application.persistentDataPath + "/data.dat", FileMode.Open);
            data = bf.Deserialize(file) as GameData;
        }catch(Exception e){
            Debug.LogException(e, this);
        }finally{
            if(file != null){
                file.Close();
            }
        }
    }
}

[Serializable]
class GameData{
    private bool isGameStartedFirstTime;
    private bool isMusicOn;
    private int coins;
    private int weaponLevel;

    public void SetIsGameStartedFirstTime(bool isGameStartedFirstTime){
        this.isGameStartedFirstTime = isGameStartedFirstTime;
    }

    public bool GetIsGameStartedFirstTime(){
        return this.isGameStartedFirstTime;
    }

    public void SetIsMusicOn(bool isMusicOn){
        this.isMusicOn = isMusicOn;
    }

    public bool GetIsMusicOn(){
        return this.isMusicOn;
    }

    public void SetCoins(int coins){
        this.coins = coins;
    }

    public int GetCoins(){
        return this.coins;
    }

    public void SetWeaponLevel(int weaponLevel){
        this.weaponLevel = weaponLevel;
    }

    public int GetWeaponLevel(){
        return this.weaponLevel;
    }
}
