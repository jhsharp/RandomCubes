/****
 * Created By: Jacob Sharp
 * Date Created: Jan 24, 2022
 * 
 * Last Edited By: Jacob Sharp
 * Date Last Edited: Jan 26, 2022
 * 
 * Description: Spawn multiple cube prefabs into the scene.
 ****/

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomCubes : MonoBehaviour
{
    public GameObject cubePrefab; // object prefab to be spawned in
    public float scalingFactor = 0.95f; // amount cubes will shrink each frame
    public int numberOfCubes = 0; // Total number of cubes instantiated
    [HideInInspector] public List<GameObject> gameObjectList; // list of all the cubes

    // Start is called before the first frame update
    void Start()
    {
        gameObjectList = new List<GameObject>(); // instantiate the list
    }

    // Update is called once per frame
    void Update()
    {
        numberOfCubes++; // add to number of cubes
        GameObject newCube = Instantiate<GameObject>(cubePrefab); // create a new cube
        newCube.name = "Cube" + numberOfCubes; // label new cube by number
        newCube.transform.position = Random.insideUnitSphere; // random location inside a sphere of r=1 centered at the script object's location
        newCube.GetComponent<Renderer>().material.color = new Color(Random.Range(0f, 1f), Random.Range(0f, 1f), Random.Range(0f, 1f));
        gameObjectList.Add(newCube); // add new cube to list

        List<GameObject> removedCubes = new List<GameObject>();

        foreach (GameObject cube in gameObjectList)
        {
            cube.transform.localScale *= scalingFactor; // scale down each cube by scaling factor
            if (cube.transform.localScale.x < 0.1f)
            {
                removedCubes.Add(cube); // add cube to removed cubes list
            }
        }

        foreach (GameObject cube in removedCubes)
        {
            gameObjectList.Remove(cube); // remove cube from list
            Destroy(cube); // destroy the cube
        }
    }
}
