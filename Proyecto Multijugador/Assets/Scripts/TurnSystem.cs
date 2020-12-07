using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class TurnSystem : MonoBehaviour
{
    public List<TurnClass> playersGroup;

    private void Start()
    {
        ResetTurns();
    }

    private void Update()
    {
        UpdateTurns();
    }

    void ResetTurns()
    {
        for(int i = 0; i < playersGroup.Count; i++)
        {
            if(i == 0)
            {
                playersGroup[i].isTurn = true;
                playersGroup[i].wasTurnPrev = false;
            }
            else
            {
                playersGroup[i].isTurn = false;
                playersGroup[i].wasTurnPrev = false;
            }
        }
    }

    void UpdateTurns()
    {
        for(int i = 0; i < playersGroup.Count; i++)
        {
            if(!playersGroup[i].wasTurnPrev)
            {
                playersGroup[i].isTurn = true;
                break;
            }
            else if(i == playersGroup.Count - 1 && playersGroup[i].wasTurnPrev)
            {
                ResetTurns();
            }
        }
    }
}

[System.Serializable]
public class TurnClass
{
    public GameObject playerGameObject;
    public bool isTurn = false;
    public bool wasTurnPrev = false;
}
