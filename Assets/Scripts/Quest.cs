using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Quest : MonoBehaviour
{
    int no;
    string title;
    string target;
    string descript;
    string reward;

    [SerializeField]
    bool isComplete = false;

    public int No { get => no; set => no = value; }
    public string Title { get => title; set => title = value; }
    public string Target { get => target; set => target = value; }
    public string Descript { get => descript; set => descript = value; }
    public string Reward { get => reward; set => reward = value; }
    public bool IsComplete { get => isComplete; set => isComplete = value; }

    // Start is called before the first frame update
    void Start()
    {
        transform.GetChild(0).GetComponent<Text>().text = title;
        transform.GetChild(1).GetComponent<Text>().text = target;
    }

    internal void SetData(DBData dBData)
    {
        no = dBData.No;
        title = dBData.QuestName;
        target = dBData.MissionType;
        descript = dBData.MissionDescrip;
        reward = dBData.Reward;
    }


    // Update is called once per frame
    void Update()
    {
        
    }
}
