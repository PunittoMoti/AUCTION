using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;



public class CSceneMoveObject : MonoBehaviour
{
    [HideInInspector]
    [SerializeField] private string mScenename; // ���s���Ɏg���V�[�����i��\���j

#if UNITY_EDITOR
    [Header("�J�ڐ�V�[���I��")]
    [SerializeField] private UnityEditor.SceneAsset mSceneAsset; // �G�f�B�^�p
#endif


    // Start is called before the first frame update
    void Start()
    {
        //MoveScene();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void MoveScene()
    {
        SceneManager.LoadScene(mScenename);
    }


#if UNITY_EDITOR
    private void OnValidate()
    {
        // �G�f�B�^���sceneToLoadAsset���ύX����邽�тɌĂ΂�A
        // �V�[�����𕶎���Ƃ���sceneToLoad�֕ۑ����܂�
        if (mSceneAsset != null)
        {
            mScenename = mSceneAsset.name;
        }
    }
#endif
}
