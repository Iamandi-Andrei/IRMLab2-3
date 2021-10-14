using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class FallingPrevent : MonoBehaviour
{
    

    public float maxMapDepth;
    void Start()
    {
        StartCoroutine("Faaaaling");
    }

    // a basic "go through every possible gameObject" to check if something fell off the map and send it back above the map
    IEnumerator Faaaaling(){
        while(true){

            List<GameObject> rootObjects = new List<GameObject>();
            Scene scene = SceneManager.GetActiveScene();
            scene.GetRootGameObjects(rootObjects);
  
            for (int i = 0; i < rootObjects.Count; ++i)
            {
                GameObject gameObject = rootObjects[i];
                if(gameObject.transform.position.y<maxMapDepth){
                    Vector3 temp=new Vector3(transform.position.x+Random.Range(-1f,1f),10,transform.position.z+Random.Range(-1f,1f));
                    gameObject.transform.position=temp;
                    gameObject.GetComponent<Rigidbody>().velocity= Vector3.zero;
      
                 }
                 yield return new WaitForSeconds(0.01f);
            }



            yield return new WaitForSeconds(0.1f);
        }



    }
}
