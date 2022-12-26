using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QuestContainer : MonoBehaviour
{
    int maxSize = 3;
    int stackSize = 0;


    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void ReloadQuestList()
    {
        List<GameObject> questList = new List<GameObject>();
        foreach (Transform child in transform)
        {
            child.gameObject.SetActive(false);
            if(!questList.Contains(child.gameObject))
                questList.Add(child.gameObject);
        }
        if (questList.Count > 3)
        {
            for(int i =0; i<3; i++)
            {
                int j = Random.Range(0, questList.Count - 1);
                while(questList[j].activeInHierarchy != false)
                {
                    j = (++j)%questList.Count;
                }
                questList[j].SetActive(true);
            }
        }
        else
        {
            for(int i=0; i<questList.Count; i++)
            {
                questList[i].SetActive(true);
            }
        }
    }
}
