using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class checkScored : MonoBehaviour
{

    public GameObject hidden;
    public Transform spawnable;
    public float spawnCount;
    float scoreCount;
    // Start is called before the first frame update
    void Start()
    {
        scoreCount = 0;
    }

    // Updates scoreCount and starts 2 coroutines
    private void OnTriggerEnter(Collider other) {
        scoreCount +=1;
        GameObject.Find("ScoreCount1").GetComponent<UnityEngine.UI.Text>().text= "Score: "+scoreCount;
        GameObject.Find("ScoreCount2").GetComponent<UnityEngine.UI.Text>().text= "Score: "+scoreCount;
        StartCoroutine("MakeItRain");
        StartCoroutine("NowYouSeeNowImGone");
    }

    // sets the "hidden" (hidden text) object active for 3 seconds
    IEnumerator NowYouSeeNowImGone(){

        hidden.SetActive(true);
        yield return new WaitForSeconds(3);
        hidden.SetActive(false);

    }

    //Instantiates the given spawnable object spawnCount times around the area of the script-attached transform
    IEnumerator MakeItRain(){
        for(int i = 0; i < spawnCount; i++) {
            Vector3 pos = new Vector3(transform.position.x + Random.Range(-3f,3f),transform.position.y+10,transform.position.z+ Random.Range(-3f,3f));
           Transform spawned = Instantiate(spawnable,pos, Quaternion.identity) ;
           //spawned.gameObject.GetComponent<Rigidbody>().velocity= Vector3.zero;
           yield return new WaitForSeconds(Random.Range(0f,0.3f));   //slowly Instantiate the spawnable object, no need to rush ;)
        }


        


    }
}
