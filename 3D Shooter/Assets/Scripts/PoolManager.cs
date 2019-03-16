using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PoolManager : MonoBehaviour {

    static PoolManager Instance;
    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        else
            Destroy(gameObject);

        DontDestroyOnLoad(this);
    }

    public class Objects
    {
        public GameObject bullet;
        public int max_Size;
    }
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
