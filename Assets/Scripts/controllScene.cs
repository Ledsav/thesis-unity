using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class controllScene : MonoBehaviour
{


    public float timerGame;
    public int next_scene;

    //objects 
    //public GameObject RIG;
    public GameObject door;
    public GameObject cup;
    public GameObject ghost;
    public GameObject jar;
    public GameObject ghost2;
    public GameObject frame;
    public GameObject ghost3;
    public GameObject ghost4;
    public GameObject ghost5;
    public AudioSource audios;
    public AudioSource audios2;
    public GameObject Ligths;

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

    public float force1;
    public float force2;



    // Start is called before the first frame update
    void Start()
    {
        //RIG.transform.position = new Vector3(11.0699997f, 3.08999991f, -23.7399998f);
        //RIG.transform.rotation = new Quaternion(0, -0.218228355f, 0, 0.975897729f);
        timerGame = 5 * 60;
        finish1 = false;
        finish2 = false;
        finish3 = false;
        finish4 = false;
        finish5 = false;
        finish6 = false;
        finish7 = false;
        finish8 = false;
        finish9 = false;
        finish10 = false;
        finish11 = false;
        finish12 = false;
        force1 =10;
        force2 = 4;
    }

    // Update is called once per frame
    void Update()
    {
        timerGame -= Time.deltaTime;


        if (timerGame <= (5 * 60) - (60 / 2) & finish1 == false) 
        {
            TriggerDoor();
            finish1 = true;
        }

        if (timerGame <= (5 * 60) - (60) & finish2 == false)
        {
            GhostTrigger(ghost);
            
            finish2 = true;
        }


        if (timerGame <= (5 * 60) - (64) & finish3 == false)
        {
            cup.GetComponent<Rigidbody>().AddForce(cup.transform.up * force1 + cup.transform.forward * force2, ForceMode.Impulse);

            finish3 = true;
        }

        if (timerGame <= (5 * 60) - (90) & finish4 == false)
        {
            
            jar.GetComponent<Animator>().enabled = true;

            finish4 = true;
        }

        if (timerGame <= (5 * 60) - (120) & finish5 == false)
        {
            //ghost2.SetActive(false);
            audios.Play();

            finish5 = true;
        }


        if (timerGame <= (5 * 60) - (125) & finish6 == false)
        {
            //ghost2.SetActive(false);
            ghost2.SetActive(true);
            GhostTrigger(ghost2);

            finish6 = true;
        }

        if (timerGame <= (5 * 60) - (155) & finish7 == false)
        {

            frame.GetComponent<Rigidbody>().useGravity = true;
            frame.GetComponent<AudioSource>().Play();


            finish7 = true;
        }

        if (timerGame <= (5 * 60) - (180) & finish8 == false)
        {
            //ghost2.SetActive(false);
            ghost3.SetActive(true);
            GhostTrigger(ghost3);



            finish8 = true;
        }

        if (timerGame <= (5 * 60) - (180) & finish7 == false)
        {
            //ghost2.SetActive(false);
            audios2.GetComponent<AudioSource>().Play();



            finish7 = true;
        }


        if (timerGame <= (5 * 60) - (210) & finish9 == false)
        {
            //ghost2.SetActive(false);
            audios2.GetComponent<AudioSource>().Play();



            finish9 = true;
        }

        if (timerGame <= (5 * 60) - (240) & finish10 == false)
        {


            ghost4.SetActive(true);
            ghost4.GetComponent<AudioSource>().Play();
            GhostTrigger(ghost4);

            finish10 = true;
        }

        if (timerGame <= (5 * 60) - (265) & finish11 == false)
        {

            Ligths.GetComponent<Animator>().enabled = true;

            finish11 = true;
        }

        if (timerGame <= (5 * 60) - (270) & finish12 == false)
        {


            ghost5.SetActive(true);
            GhostTrigger(ghost5);

            finish12 = true;
        }

        if (timerGame <= 0)
        {


            loadNext();
        }
    }

    public void TriggerDoor()
    {
        door.GetComponent<AudioSource>().Play();
        door.GetComponent<Animator>().enabled=true;
        
    }

    public void GhostTrigger(GameObject ghost) 
    
    {
        //ghost.GetComponent<AudioSource>().Play();
       
       ghost.GetComponent<Animator>().enabled = true;

    }




    public void loadNext() 
    {
        SceneManager.LoadScene(next_scene);
    }
}
