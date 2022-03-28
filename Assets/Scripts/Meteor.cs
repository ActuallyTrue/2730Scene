using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Meteor : MonoBehaviour
{
    float deathTime = 7f;
    float timer;
    // Start is called before the first frame update
    void Start()
    {
        timer = deathTime;
        Destroy(this.gameObject, deathTime);
    }

    // Update is called once per frame
    void Update()
    {
    }

    private void OnCollisionStay(Collision other) {
        if (other.gameObject.layer == 7)
        {
            Cursor.lockState = CursorLockMode.None;
            SceneManager.LoadScene(0);
        }
    }
}
