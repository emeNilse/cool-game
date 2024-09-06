using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class wave : MonoBehaviour
{

    [SerializeField] float cosine;
    [SerializeField] float sine;
    [SerializeField] float tangent;
    public float myTime = 0;
    public float myOffset = 0;
    Vector3 position = new Vector3();
    Vector3 direction = new Vector3();
    Vector3 rotation = new Vector3();
    Material myM;
    public Transform[] Children;
    Color lerpedColor = Color.white;
    Renderer renderer;
    // Start is called before the first frame update

    void Start()
    {
        //for (int i = 0; i < rows; i++)
        //{
          //  for(int j = 0; j < cols; j++)
            //{
              //  var copy = Instantiate(Cubeprefab, transform);
                //copy.transform.position = new Vector3(i, 0, j);
            //}
        //} This requires prefabs, this problem can be done without it
        myM = GetComponent<MeshRenderer>().material;


    }

    // Update is called once per frame
    void Update()
    {
        myTime = Time.time;
        
        //for(int i = 0; i < Children.Length; i++)
        //{
          //  myOffset = 
        //}
        myOffset = ((float)gameObject.transform.position.x + (float)gameObject.transform.position.z) * (float)-0.2;
        cosine = Mathf.Cos( Time.time + myOffset);
        sine = Mathf.Sin( Time.time + myOffset);
        tangent = Mathf.Tan( Time.time + myOffset);
        transform.position += new Vector3(0, cosine, 0) * Time.deltaTime;
        transform.Rotate(10.0f * cosine * Time.deltaTime, 0, 10.0f * cosine * Time.deltaTime);


        lerpedColor = Color.Lerp(Color.blue, Color.green, cosine * Time.deltaTime);
        // renderer.material.color = lerpedColor;
        myM.color = new Color(sine, cosine, 0);


    }
}
