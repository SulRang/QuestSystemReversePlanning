
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class QuestInformation : MonoBehaviour
{
    int no;
    string title;
    string target;
    string descript;
    string reward;

    [SerializeField]
    Text titleText;
    [SerializeField]
    Text targetText;
    [SerializeField]
    Text descriptText;

    [SerializeField]
    Button progressBtn;
    [SerializeField]
    Button giveUpBtn;
    [SerializeField]
    Button completeBtn;

    public int No { get => no; set => no = value; }
    public string Title { get => title; set => title = value; }
    public string Target { get => target; set => target = value; }
    public string Descript { get => descript; set => descript = value; }
    public string Reward { get => reward; set => reward = value; }

    internal void SetQuest(GameObject selectQuest)
    {
        Quest quest = selectQuest.GetComponent<Quest>();
        no = quest.No;
        title = quest.Title;
        target = quest.Target;
        descript = quest.Descript;
        reward = quest.Reward;

        titleText.text = title;
        targetText.text = target;
        descriptText.text = descript;

        ToggleButton(selectQuest);
    }

    private void ToggleButton(GameObject selectQuest)
    {
        if (selectQuest.transform.parent != null)
        {
            if (selectQuest.transform.parent.name == "ProgressContainer")
            {
                if(selectQuest.GetComponent<Quest>().IsComplete)
                {
                    completeBtn.gameObject.SetActive(true);
                }
                progressBtn.interactable = false;
                giveUpBtn.interactable = true;
            }
            else if (selectQuest.transform.parent.name == "QuestContainer")
            {
                giveUpBtn.interactable = false;
                progressBtn.interactable = true;
            }
        }
        else
        {
            giveUpBtn.interactable = false;
            progressBtn.interactable = false;
        }
    }
}
