using UnityEngine;

//The code defines a MonoBehaviour class "Graph" in Unity to plot a sine wave.

public class Graph : MonoBehaviour {

//The class includes a serialized field "pointPrefab" of Transform type to 
//reference a prefab for individual points in the graph.

	[SerializeField]
	Transform pointPrefab;

    //The class also includes two serialized fields, "resolution" and "length", 
    //both of type "Range" and int. "resolution" is used to set the number of 
    //points to be plotted in the graph and "length" sets the length of the 
    //graph.

    [SerializeField, Range(10, 100)]
	int resolution = 10;

    [SerializeField, Range(10, 100)]
    int length = 10;

    Transform[] points;

    //In the Awake() function, an array of Transform objects "points" is created
    //to store the instantiated point prefabs. 

    void Awake () {

        //The step size and position of each point is calculated based on the 
        //resolution, and each point is instantiated, scaled, and positioned 
        //accordingly.

        //Finally, the points are set as children of the transform component
        //attached to the current object, with their position relative to the 
        //parent set to false.

        float step = 2f / resolution;
        var position = Vector3.zero;
        var scale = Vector3.one * step;
        points = new Transform[resolution];
        for (int i = 0; i < resolution; i++) {
            Transform point = points[i] = Instantiate(pointPrefab);
            position.x = (i + 0.5f) * step - 1f;
			point.localPosition = position;
            point.localScale = scale;
            point.SetParent(transform, false);
        }
	}

    //In the Update() function, the y-value of each point is updated based on 
    //the sine function with its x-position and time as inputs. 
    //The updated local position of each point is then set.

    void Update () {
        float time = Time.time;
        for (int i = 0; i < resolution; i++) {
            Transform point = points[i];
            Vector3 position = point.localPosition;
            position.y = Mathf.Sin(Mathf.PI * (position.x + time));
            point.localPosition = position;
        }
		
}

}
