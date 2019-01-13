using UnityEngine;
using UnityEngine.AI;

public class PlayerController : MonoBehaviour {

    public Camera cam;

    public NavMeshAgent agent;

    public LineRenderer lr;

    private DrawNavMeshPath drawer;

    private void Start()
    {
        drawer.SetLineRenderer(lr);
    }

    // Update is called once per frame
    void Update ()
    {
		if (Input.GetMouseButtonDown(0))
        {
            // Input.mousePosition: screen coordinates
            // cam.ScreenPointToRay: shoots a 
            Ray ray = cam.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;

            // true if hit something, false if it didn't
            if (Physics.Raycast(ray, out hit))
            {
                // MOVE OUR AGENT
                agent.SetDestination(hit.point);
                // DRAW PATH
                DrawNavMeshPath.path = agent.path.corners;
                // OnDrawGizmos();
            }
            

        }
	}

    void OnDrawGizmos()
    {

        var nav = GetComponent<NavMeshAgent>();
        if (nav == null || nav.path == null)
            return;

        var line = this.GetComponent<LineRenderer>();
        if (line == null)
        {
            line = this.gameObject.AddComponent<LineRenderer>();
            line.material = new Material(Shader.Find("Sprites/Default")) { color = Color.yellow };
            line.SetWidth(0.5f, 0.5f);
            line.SetColors(Color.yellow, Color.yellow);
        }

        var path = nav.path;

        line.SetVertexCount(path.corners.Length);

        for (int i = 0; i < path.corners.Length; i++)
        {
            line.SetPosition(i, path.corners[i]);
        }

    }
}
