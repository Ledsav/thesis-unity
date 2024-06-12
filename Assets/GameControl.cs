using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.XR;




public class GameControl : MonoBehaviour
{
    public float timerGame;
    public int next_scene;
   





    //control+
    private bool finish1;
    private bool finish2;
    private bool finish3;
    private bool finish4;
    private bool finish5;
    private bool finish6;
    private bool finish7;
    private bool finish8;
    private bool finish9;
    private bool finish10;
    private bool finish11;
    private bool finish12;
    void Start()
    {
        //Rig.transform.position = pos;
        //Rig.transform.rotation = rot;
    }


 



void Update()
    {
        timerGame -= Time.deltaTime;

  

        if (timerGame <= 0)
        {


            loadNext();
        }
    }

    public void loadNext()
    {
        SceneManager.LoadScene(next_scene);
    }
}
