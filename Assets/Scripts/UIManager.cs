using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class UIManager : MonoBehaviour
{
    DBController dBController;
    List<DBData> dBDatas = new List<DBData>();

    [SerializeField]
    List<GameObject> progressQuests = new List<GameObject>();
    [SerializeField]
    List<GameObject> quests = new List<GameObject>();

    [SerializeField]
    GameObject questPrefab;
    [SerializeField]
    GameObject selectQuest;
    [SerializeField]
    GameObject selectQuestInfor;

    GameObject QuestContainer;
    GameObject ProgressContainer;

    // Start is called before the first frame update
    void Start()
    {
        dBController = GameObject.Find("DBController").GetComponent<DBController>();
        QuestContainer = GameObject.Find("QuestContainer");
        ProgressContainer = GameObject.Find("ProgressContainer");
        selectQuest = questPrefab;
        selectQuestInfor.GetComponent<QuestInformation>().SetQuest(questPrefab);
        initQuest();
    }

    public void initQuest()
    {
        dBDatas = dBController.GetDBDatas();
        for (int i = 0; i < dBDatas.Count; i++)
        {
            GameObject questObj = Instantiate(questPrefab, QuestContainer.transform);
            questObj.GetComponent<Quest>().SetData(dBDatas[i]);
            quests.Add(questObj);
        }
        QuestContainer.GetComponent<QuestContainer>().ReloadQuestList();
    }

    // Update is called once per frame
    void Update()
    {
        if (quests.Count < 1)
            initQuest();
    }

    public void SelectQuest()
    {
        selectQuest = EventSystem.current.currentSelectedGameObject;
        Debug.Log(selectQuest);
        //selectQuest = selectedQuest;
        selectQuestInfor.GetComponent<QuestInformation>().SetQuest(selectQuest);
    }

    public void ProgressQuest()
    {
        if (progressQuests.Count < 2)
        {
            progressQuests.Add(selectQuest);
            selectQuest.transform.parent = ProgressContainer.transform;
            quests.Remove(selectQuest);
            selectQuestInfor.GetComponent<QuestInformation>().SetQuest(selectQuest);
        }
        else
        {
            Debug.Log("진행가능한 의뢰는 최대 2개입니다.");
        }
    }

    public void CompleteQuest()
    {
        quests.Add(selectQuest);
        selectQuest.transform.parent = QuestContainer.transform;
        progressQuests.Remove(selectQuest);
        selectQuestInfor.GetComponent<QuestInformation>().SetQuest(questPrefab);
        selectQuest.SetActive(false);
    }

    public void GiveUpQuest()
    {
        quests.Add(selectQuest);
        selectQuest.transform.parent = QuestContainer.transform;
        progressQuests.Remove(selectQuest);
        selectQuestInfor.GetComponent<QuestInformation>().SetQuest(questPrefab);
        selectQuest.SetActive(false);
    }

}
