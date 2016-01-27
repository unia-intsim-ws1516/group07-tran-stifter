using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
//using System.Collections.Generic;
using System.Linq;

public class FillHighscores : MonoBehaviour {

    public Dictionary<string, int> highscores;
    private int scoreUpperBound = 1000;
    private GameObject np;
    public InputField inputF;
    private string newName;
    private GameDataContainer gdc;
    private int time;
    private int points;

    private GameObject name1;
    private GameObject name2;
    private GameObject name3;
    private GameObject name4;
    private GameObject name5;
    private GameObject points1;
    private GameObject points2;
    private GameObject points3;
    private GameObject points4;
    private GameObject points5;


    // Use this for initialization
    void Start () {
        np = GameObject.FindWithTag("NamesPoints");
        gdc = GameDataContainer.FindObjectOfType<GameDataContainer>();

        name1 = GameObject.FindWithTag("Name1");
        name2 = GameObject.FindWithTag("Name2");
        name3 = GameObject.FindWithTag("Name3");
        name4 = GameObject.FindWithTag("Name4");
        name5 = GameObject.FindWithTag("Name5");
        points1 = GameObject.FindWithTag("Points1");
        points2 = GameObject.FindWithTag("Points2");
        points3 = GameObject.FindWithTag("Points3");
        points4 = GameObject.FindWithTag("Points4");
        points5 = GameObject.FindWithTag("Points5");

        Debug.Log(name1);

        highscores = new Dictionary<string, int>();
        highscores.Add("S", 999);
        highscores.Add("Alice", 300);
        highscores.Add("Bob", 645);
        highscores.Add("Nobody", 5);

        newName = inputF.text;
        time = (int)gdc.timerUntilWin;
        points = calcPoints(time);


        fillTextFields(time, points);
        fillHighscoreTable();
    }



    private void fillHighscoreTable()
    {
        var items = from pair in highscores
                    orderby pair.Value descending
                    select pair;


        name1.GetComponent<Text>().text = items.ElementAt(0).Key;
        points1.GetComponent<Text>().text = items.ElementAt(0).Value.ToString();
        name2.GetComponent<Text>().text = items.ElementAt(1).Key;
        points2.GetComponent<Text>().text = items.ElementAt(1).Value.ToString();
        name3.GetComponent<Text>().text = items.ElementAt(2).Key;
        points3.GetComponent<Text>().text = items.ElementAt(2).Value.ToString();
        name4.GetComponent<Text>().text = items.ElementAt(3).Key;
        points4.GetComponent<Text>().text = items.ElementAt(3).Value.ToString();
        if( highscores.Count > 4 )
        {
            name5.GetComponent<Text>().text = items.ElementAt(4).Key;
            points5.GetComponent<Text>().text = items.ElementAt(4).Value.ToString();
        }
    }

    private void fillTextFields( int time, int points)
    {
        Text notification = GameObject.FindWithTag("notification").GetComponent<Text>();
        Text notificationTime = GameObject.FindWithTag("notificationTime").GetComponent<Text>();
        Text notificationPoints = GameObject.FindWithTag("notificationPointsAchieved").GetComponent<Text>();



        notificationTime.text = time.ToString() + " sec.";
        if( gdc.loosing == false )
        {
            notificationPoints.text = points.ToString();
        }
        else
        {
            notification.text = "You failed! Booh!";
            notificationPoints.text = "0";
        }
 
    }

    public void inputFinished()
    {
        newName = inputF.text;
        highscores.Add(newName, points);
        fillHighscoreTable();
    }

    private int calcPoints( int time )
    {
        return (int)(scoreUpperBound - time);
    }
	
	// Update is called once per frame
	void Update () {
	
	}
}
