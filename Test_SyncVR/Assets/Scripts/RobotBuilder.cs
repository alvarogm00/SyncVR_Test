using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RobotBuilder : MonoBehaviour
{
    public int currentBodyPart;

    [SerializeField] List<RobotPart> heads = new List<RobotPart>();
    [SerializeField] List<RobotPart> chests = new List<RobotPart>();
    [SerializeField] List<RobotPart> legs = new List<RobotPart>();

    GameManager gm;
    void Start()
    {
        gm = FindObjectOfType<GameManager>();
    }

    public void BuildPart(int partId)
    {
        if(currentBodyPart == 0)
        {
            for (int i = 0; i < heads.Count; i++)
            {
                if(heads[i].id == partId)
                {
                    heads[i].gameObject.SetActive(true);
                    break;
                }
            }
        }
        else if(currentBodyPart == 1)
        {
            for (int i = 0; i < heads.Count; i++)
            {
                if (chests[i].id == partId)
                {
                    chests[i].gameObject.SetActive(true);
                    break;
                }
            }

        }
        else
        {
            for (int i = 0; i < heads.Count; i++)
            {
                if (legs[i].id == partId)
                {
                    legs[i].gameObject.SetActive(true);
                    break;
                }
            }
        }

        currentBodyPart++;
        CheckBodyParts();
    }

    void CheckBodyParts()
    {
        if(currentBodyPart >= 3)
        {
            gm.FinishGame();
        }
    }
}
