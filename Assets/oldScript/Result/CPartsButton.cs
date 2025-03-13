using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CPartsButton : MonoBehaviour
{
    CResultManager mResultManager;
    [SerializeField] int mPricep;

    // Start is called before the first frame update
    void Start()
    {
        mResultManager = GameObject.Find("ResultManager").GetComponent<CResultManager>();

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void PartsSelect()
    {
        mResultManager.ActiveIsPartsselect(mPricep);
    }
}
