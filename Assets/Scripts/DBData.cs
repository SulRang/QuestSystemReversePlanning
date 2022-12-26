using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Data;

public class DBData
{
    int index;
    int no;
    string questClass;
    string questName;
    string missionType;
    string missionTarget;
    string missionDescrip;
    string reward;

    public DBData(object[] dataRow)
    {
        Index = int.Parse(dataRow[0].ToString());
        No = int.Parse(dataRow[1].ToString());
        QuestClass = dataRow[2].ToString();
        QuestName = dataRow[3].ToString();
        MissionType = dataRow[4].ToString();
        MissionTarget = dataRow[5].ToString();
        MissionDescrip = dataRow[6].ToString();
        Reward = dataRow[7].ToString();
    }
    public DBData(DataRow dataRow)
    {
        Index = int.Parse(dataRow[0].ToString());
        No = int.Parse(dataRow[1].ToString());
        QuestClass = dataRow[2].ToString();
        QuestName = dataRow[3].ToString();
        MissionType = dataRow[4].ToString();
        MissionTarget = dataRow[5].ToString();
        MissionDescrip = dataRow[6].ToString();
        Reward = dataRow[7].ToString();
    }

    public DBData(int _index, int _no, string _questClass, string _questName, string _missionType, string _missionTarget, string _missionDescrip, string _reward = "100G")
    {
        Index = _index;
        No = _no;
        QuestClass = _questClass;
        QuestName = _questName;
        MissionType = _missionType;
        MissionTarget = _missionTarget;
        MissionDescrip = _missionDescrip;
        Reward = _reward;
    }

    public int Index { get => index; private set => index = value; }
    public int No { get => no; private set => no = value; }
    public string QuestClass { get => questClass; private set => questClass = value; }
    public string QuestName { get => questName; private set => questName = value; }
    public string MissionType { get => missionType; private set => missionType = value; }
    public string MissionTarget { get => missionTarget; private set => missionTarget = value; }
    public string MissionDescrip { get => missionDescrip; private set => missionDescrip = value; }
    public string Reward { get => reward; private set => reward = value; }

}
