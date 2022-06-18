using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class endMode : MonoBehaviour
{
    public Fungus.Flowchart endFlowchart;

    // Start is called before the first frame update
    void Start()
    {
        endFlowchart.SetStringVariable("lastCharaName", chooseMode.charaNames[chooseMode.SelectCharaIdx]);
    }

    public void BackTitle() {
        SceneManager.LoadScene("title");
    }

}
