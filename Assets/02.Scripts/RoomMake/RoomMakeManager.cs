using System;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;
using Random = UnityEngine.Random;

public class RoomMakeManager : MonoBehaviour
{
    [SerializeField] private List<Image> crewImgs;
    [SerializeField] private List<Button> imposterCntBtns;
    [SerializeField] private List<Button> maxPlayerCntBtns;
    
    private CreateGameRoomData _roomData;
    
    private void Start()
    {
        for (int i = 0; i < crewImgs.Count; i++)
        {
            Material materialInstance = Instantiate(crewImgs[i].material);
            crewImgs[i].material = materialInstance;
        }
        _roomData = new CreateGameRoomData() { imposterCnt = 1, maxPlayerCnt = 12 };
        UpdateCrewImages();
    }

    public void UpdateImposterCnt(int count)
    {
        _roomData.imposterCnt = count;

        for (int i = 0; i < imposterCntBtns.Count; i++)
        {
            if (i == count - 1)
            {
                imposterCntBtns[i].image.color = new Color(1f, 1f, 1f, 1f);
            }
            else
            {
                imposterCntBtns[i].image.color = new Color(1f, 1f, 1f, 0f);
            }
        }

        int limitMaxPlayer = count == 1 ? 4 : count == 2 ? 7 : count == 3 ? 9 : 11;

        if (limitMaxPlayer > _roomData.maxPlayerCnt)
        {
            UpdateMaxPlayerCnt(limitMaxPlayer);
        }
        else
        {
            UpdateMaxPlayerCnt(_roomData.maxPlayerCnt);
        }

        for (int i = 0; i < maxPlayerCntBtns.Count; i++)
        {
            var text = maxPlayerCntBtns[i].GetComponentInChildren<TMP_Text>();
            if (i < limitMaxPlayer - 4)
            {
                maxPlayerCntBtns[i].interactable = false;
                text.color = Color.gray;
            }
            else
            {
                maxPlayerCntBtns[i].interactable = true;
                text.color = Color.white;
            }
        }
    }
    public void UpdateMaxPlayerCnt(int count)
    {
        _roomData.maxPlayerCnt = count;
        for (int i = 0; i < maxPlayerCntBtns.Count; i++)
        {
            if (i == count - 4)
            {
                maxPlayerCntBtns[i].image.color = new Color(1f, 1f, 1f, 1f);
            }
            else
            {
                maxPlayerCntBtns[i].image.color = new Color(1f, 1f, 1f, 0f);
            }
        }
        
        UpdateCrewImages();
    }

    private void UpdateCrewImages()
    {
        for (int i = 0; i < crewImgs.Count; i++)
        {
            crewImgs[i].material.SetColor("_PlayerColor", Color.white);
        }
        int imposterCnt = _roomData.imposterCnt;
        int idx = 0;
        while (imposterCnt != 0)
        {
            if (idx >= _roomData.maxPlayerCnt)
            {
                idx = 0;
            }

            if (crewImgs[idx].material.GetColor("_PlayerColor") != Color.red && Random.Range(0, 5) == 0)
            {
                crewImgs[idx].material.SetColor("_PlayerColor", Color.red); 
                imposterCnt--;
            }

            idx++;
        }

        for (int i = 0; i < crewImgs.Count; i++)
        {
            if (i < _roomData.maxPlayerCnt)
            {
                crewImgs[i].gameObject.SetActive(true);
            }
            else
            {
                crewImgs[i].gameObject.SetActive(false);
            }
        }
    }
    
    
}

// 이 클래스를 이용해 새로 만드는 방의 데이터를 저장해 두었다가 방 생성 시 데이터를 전달한다.
public class CreateGameRoomData
{
    public int imposterCnt;
    public int maxPlayerCnt;
}