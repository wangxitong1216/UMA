using System.Collections.Generic;
using UnityEngine;
using UMA.CharacterSystem;
using UMA;
using System;
using System.IO;

[Serializable]
public class BodyCoin
{
    public string partName;
    public float value;
}

public class BodyCoinList
{
    public List<BodyCoin> infoList = new();
}

public class JiaoHu : MonoBehaviour
{
    [SerializeField] DynamicCharacterAvatar avatar;
    Dictionary<string, DnaSetter> allDNA = new();

    void Start()
    {
        avatar.CharacterCreated.AddListener(Initialize);
    }

    private void Initialize(UMAData umaData)
    {
        allDNA = avatar.GetDNA();
    }

    //移动端调用传json
    public void ValueChanged(string json)
    {
        BodyCoinList bodyCoinList = JsonUtility.FromJson<BodyCoinList>(json);

        foreach (var info in bodyCoinList.infoList)
        {
            switch (info.partName)
            {
                case "armLength":
                case "armWidth":
                case "belly":
                case "breastSize":
                case "feetSize":
                case "forearmLength":
                case "forearmWidth":
                case "gluteusSize":
                case "headSize":
                case "legSeparation":
                case "height":
                case "legsSize":
                case "lowerMuscle":
                case "lowerWeight":
                case "mouthSize":
                case "neckThickness":
                case "upperMuscle":
                case "upperWeight":
                case "waist":
                case "handsSize":
                    allDNA[info.partName].Set(info.value);
                    avatar.ForceUpdate(true, false, false);
                    break;
                default:
                    break;
            }
        }
    }

    public void LoadStreamingAssets()
    {
        BodyCoinList bodyCoinList = LoadJsonData();       

        foreach (var info in bodyCoinList.infoList)
        {
            switch (info.partName)
            {
                case "armLength":
                case "armWidth":
                case "belly":
                case "breastSize":
                case "feetSize":
                case "forearmLength":
                case "forearmWidth":
                case "gluteusSize":
                case "headSize":
                case "legSeparation":
                case "height":
                case "legsSize":
                case "lowerMuscle":
                case "lowerWeight":
                case "mouthSize":
                case "neckThickness":
                case "upperMuscle":
                case "upperWeight":
                case "waist":
                case "handsSize":
                    allDNA[info.partName].Set(info.value);
                    avatar.ForceUpdate(true, false, false);
                    break;
                default:
                    break;
            }
            
        }
    }

    private void SaveBodyCoin()
    {
        BodyCoinList bodyCoinList = new();

        BodyCoin a = new();
        a.partName = "height";
        a.value = 0.7f;

        BodyCoin b = new();
        b.partName = "armLength";
        b.value = 0.3f;

        bodyCoinList.infoList.Add(a);
        bodyCoinList.infoList.Add(b);
        SaveJsonData(bodyCoinList);
    }

    private void SaveJsonData(BodyCoinList coin)
    {
        string json = JsonUtility.ToJson(coin, true);
        string filePath = Application.streamingAssetsPath + "/bodycoin.json";
        using (StreamWriter sw = new StreamWriter(filePath))
        {
            sw.WriteLine(json);
            sw.Close();
            sw.Dispose();
        }
    }

    private BodyCoinList LoadJsonData()
    {
        string json;
        string filePath = Application.streamingAssetsPath + "/bodycoin.json";
        if (File.Exists(filePath))
        {
            using (StreamReader sr = new StreamReader(filePath))
            {
                json = sr.ReadToEnd();
                sr.Close();
            }

            BodyCoinList coin = JsonUtility.FromJson<BodyCoinList>(json);

            return coin;
        }
        return null;
    }
}
