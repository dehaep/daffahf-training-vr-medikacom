using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class NewBehaviourScript : MonoBehaviour
{

    public string characterString;

    public int bilanganbulat;

    public float bilanganPecahan;

    public bool kondisi;


    // Start is called before the first frame update
    void Start()
    {
        
        Debug.Log("I Hate Unity!");

        UbahScene("Scene pertama");
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void UbahScene(string sceneName)
    {

        SceneManager.LoadScene(sceneName);

    }
}
