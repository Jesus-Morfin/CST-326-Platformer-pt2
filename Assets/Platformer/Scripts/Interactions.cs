using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Interactions : MonoBehaviour
{
    public TextMeshProUGUI question;
    public TextMeshProUGUI score;
    private int coins = 0;
    private int scoreCount = 0;
    void Update()
    {

        Vector3 direction = Vector3.up;
        Vector3 opposite = Vector3.down;
        Ray ray = new Ray(transform.position, transform.TransformDirection(direction/5f));
        Ray ray2 = new Ray(transform.position, transform.TransformDirection(opposite/5f));
        
        Debug.DrawRay(transform.position, transform.TransformDirection(direction * 2f));

            RaycastHit hit;

            if (Physics.Raycast(ray, out hit, 1000f))
            {
                if (hit.collider.gameObject.tag == "Brick")
                {
                    Debug.Log("Brick destroyed");
                    Destroy(hit.collider.gameObject);
                    scoreCount += 100;
                    this.score.text = scoreCount.ToString();
                }

                if (hit.collider.gameObject.tag == "QuestionBlock")
                {
                    Debug.Log("Coins");
                    coins++;
                    if (coins < 10)
                    {
                        this.question.text = "x0" + coins.ToString();
                    }
                    else
                    {
                        this.question.text = "x" + coins.ToString();
                    }
                }
                if (hit.collider.gameObject.tag == "Hazard")
                {
                    Debug.Log("Death by hazard");
                }
            }

            RaycastHit bottom;
            if (Physics.Raycast(ray2, out bottom, 1000f))
            {
                if (bottom.collider.gameObject.tag == "Water")
                {
                    Debug.Log("Death by water");
                }
                if (bottom.collider.gameObject.tag == "Hazard")
                {
                    Debug.Log("Death by hazard");
                }
            }


    }
}
