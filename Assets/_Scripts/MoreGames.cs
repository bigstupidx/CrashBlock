using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;

public enum MoreGamesKey {ASAZ, CVSRR, HBSG };

public class MoreGames : MonoBehaviour {

    [SerializeField]
    private MoreGamesKey thisGame;
 
    [System.Serializable]
    public class GameList
    {
        public string gameName;
        public Sprite gameIcon;
        public MoreGamesKey GameKeyName;
        public string url;
    };

    public GameList[] gameList;

    private int gameListIndex;      //-- the index of the result game to display


    List<MoreGamesKey> randomGame = new List<MoreGamesKey>();

    [SerializeField]
    private Image buttonImage;



    // Use this for initialization
    void Start()
    {
        for (int i=0; i< gameList.Length; i++)
        {
            randomGame.Add(gameList[i].GameKeyName);
        }

       

        for (int i = 0; i < randomGame.Count; i++)       //--- discard the current game from the list
        {
            if (thisGame == randomGame[i])
            {
                randomGame.Remove(randomGame[i]);
            }
        }

        MoreGamesKey randomGameToDisplay = randomGame[Random.Range(0, randomGame.Count)];       //-- get a random game from the games left


        for (int i = 0; i < gameList.Length; i++)       //--- get a random game, and update the image and url
        {
            if (randomGameToDisplay == gameList[i].GameKeyName)
            {
                gameListIndex = i;
                buttonImage.sprite = gameList[i].gameIcon;


                return;
            }

        }
    }
	

    public void  OpenTheIndexGameURL()
    {
        
        Application.OpenURL(gameList[gameListIndex].url);
    }

}
