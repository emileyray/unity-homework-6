using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class PlayerController : MonoBehaviour
{
    private Camera camera;
    private NavMeshAgent agent;
    public GameObject target;
    public CanvasGroup cg;
    void Start()
    {
        camera = Camera.main;
        agent = GetComponent<NavMeshAgent>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButton(0))
        {
            RaycastHit hit;
            if (Physics.Raycast(camera.ScreenPointToRay(Input.mousePosition), out hit))
            {
                agent.SetDestination(hit.point);
                target.transform.position = hit.point + new Vector3(0, 1, 0);
            }
            if (cg.alpha == 1.0f)
            {
                StartCoroutine(RemoveHint(1.0f));
            }
        }
    }
    
    IEnumerator RemoveHint(float aTime)
    {
        for (float t = 1.0f; t >= 0; t -= Time.deltaTime / aTime)
        {
            cg.alpha = t;
            yield return null;
        }
    }
}
