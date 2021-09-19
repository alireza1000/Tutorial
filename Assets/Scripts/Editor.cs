using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


    [ExecuteInEditMode]
    public class Editor : MonoBehaviour
    {
        [SerializeField] [Range(1f, 50f)] private float grid = 10f;
        void Update()
        {
            Vector3 editPos;

            editPos.x = Mathf.RoundToInt(transform.position.x / grid) * grid;

            editPos.z = Mathf.RoundToInt(transform.position.z / grid) * grid;
            

            transform.position = new Vector3(editPos.x, 0f, editPos.z);

            float k = Mathf.RoundToInt(transform.position.x / grid) * grid;
        

    }

       
    }

