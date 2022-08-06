using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Leak : MonoBehaviour{
    List<GameObject> leaks;
    public GameObject leakPrefab;
    void Start(){
        leaks = new List<GameObject>();
    }

    void Update(){
        int i;
        for(i = 0; i < GameManagement.boat.leaks.Count; i++){
            GameObject lp;
            Vector2 leak = GameManagement.boat.leaks[i];

            if(i >= leaks.Count){
                leaks.Add(Instantiate(leakPrefab, transform));
            }
            lp = leaks[i];
            lp.transform.localPosition = new Vector3(leak.x, leak.y, 0);
        }
        
        for(; i < leaks.Count; i++){
            Destroy(leaks[i]);
            leaks.RemoveAt(i);
        }
    }
}
