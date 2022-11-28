using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEditor;
using Random = System.Random;

public class GeneratingPlatforms : MonoBehaviour
{
    static int Platformсount = 1;
    static int maxСount = 32;

    public GameObject PlatformPrefab;

    public GameObject CombinePlatformPrefab;
    public GameObject EndPlatformPrefab;

    private static Random rand = new Random();

    public List<GameObject> CreatedPlatforms = new List<GameObject>();

    private void Awake()
    {

        if (Platformсount >= maxСount)
        {

            return;
        }
        StartCoroutine( CreateNextPlatforms() );
    }

    private void CreateCheckPlatforms(Transform ladder)
    {

        GameObject CheckPlatform = new GameObject("CheckPlatform");
        CheckPlatform.name = ladder.gameObject.GetInstanceID().ToString();
        CheckPlatform.transform.position = ladder.position + ladder.forward * 12;
        
        SphereCollider sc = CheckPlatform.AddComponent(typeof(SphereCollider)) as SphereCollider;
        sc.isTrigger = true;
        sc.radius = 5;
    }

    IEnumerator CreateNextPlatforms()
    {

        foreach(Transform child in transform)
        {

            if (child.name == "LaddersPlatform")
            {
                Randomize(child); 

                yield return new WaitForSecondsRealtime(0.33f);
                foreach (Transform ladder in child)
                {
                    yield return new WaitForSecondsRealtime(.2f);
                    Platformсount++;
                    yield return new WaitForSecondsRealtime(.25f);

                    Vector3 EulerAngles = gameObject.transform.eulerAngles;
                    EulerAngles.y = ladder.eulerAngles.y;
                    Quaternion Rotation = Quaternion.Euler(EulerAngles);
                                                                
                    Vector3 Position = ladder.position + ladder.forward * 12 - Vector3.up;

                    List<Collider> Colliders = new List<Collider>();

                    foreach (Collider collider in Physics.OverlapSphere(Position, 3.5f))
                    {
                        Colliders.Add(collider);
                    }

                    CreateCheckPlatforms(ladder);

                    if (Colliders.OfType<SphereCollider>().Any())
                    {
                        if (Platformсount >= maxСount)
                        {
                            CreatedPlatforms.Add(CreateEndPlatform(Position, Rotation, Colliders.OfType<SphereCollider>().First().transform.position, Colliders.OfType<SphereCollider>().First().transform.rotation ));
                        }
                        else
                        {
                            CreatedPlatforms.Add(CreateCombinedPlatform(Position, Rotation, Colliders.OfType<SphereCollider>().First().transform.position, Colliders.OfType<SphereCollider>().First().transform.rotation ));
                        }

                        foreach(Collider col in Colliders)
                        {
                            if ( col.transform.root.gameObject.GetComponent<GeneratingPlatforms>() )
                            {

                                foreach (GameObject Gobj in col.transform.root.gameObject.GetComponent<GeneratingPlatforms>().CreatedPlatforms)
                                {
                                    Destroy(Gobj);
                                }  

                            }
                            Destroy(col.transform.root.gameObject);
                        }
                        continue;
                    }

                    if (Platformсount >= maxСount)
                    {
                        CreateEndPlatform(Position, Rotation, Position, Rotation);
                        continue;
                    }

                    GameObject Platform = Instantiate(PlatformPrefab,Position,Rotation);
                    Platform.GetComponent<GeneratingPlatforms>().PlatformPrefab = PlatformPrefab;

                    CreatedPlatforms.Add(Platform);

                }

            }

        }

    }

    private GameObject CreateCombinedPlatform(Vector3 pos1, Quaternion rot1, Vector3 pos2, Quaternion rot2)
    {

        Vector3 MiddlePosition = new Vector3( ( pos1.x + pos2.x )/2, pos1.y, ( pos1.z + pos2.z )/2 ) - Vector3.up;

        Vector3 MiddleRotation = rot1.eulerAngles;
        MiddleRotation.y = ( rot1.eulerAngles.y + rot2.eulerAngles.y )/2;

        return Instantiate(CombinePlatformPrefab,MiddlePosition,Quaternion.Euler(MiddleRotation));
        
    }

    private GameObject CreateEndPlatform(Vector3 pos1, Quaternion rot1, Vector3 pos2 , Quaternion rot2)
    {
        Vector3 MiddlePosition = pos1;
        Vector3 MiddleRotation = rot1.eulerAngles;  

        if (pos1 != pos2)
        {
            MiddlePosition = new Vector3( ( pos1.x + pos2.x )/2, pos1.y, ( pos1.z + pos2.z )/2 ) - Vector3.up;
        }
        if (rot1 != rot2)
        {
            MiddleRotation = rot1.eulerAngles;
            MiddleRotation.y = ( rot1.eulerAngles.y + rot2.eulerAngles.y )/2;
        }

        return Instantiate(EndPlatformPrefab, MiddlePosition, Quaternion.Euler(MiddleRotation));
    }

    /*private bool TryCombinePlatform(GameObject platform)
    {

        Collider[] platformColliders = Physics.OverlapSphere(platform.transform.position, 3.5f);

        foreach( Collider platformCollider in platformColliders )
        {

            if ( platform.transform.Find("PlatformModel").Find("rock_platform").Find("Plane").gameObject != platformCollider.gameObject && platformCollider.gameObject.name == "Plane" )
            {

                CombinePlatforms(platform, platformCollider.gameObject);
                return true;
            }

        }

        return false;

    }*/

    private void Randomize(Transform LaddersPlatform)
    {

        List<Transform> childs = new List<Transform>();
        foreach (Transform child in LaddersPlatform)
        {
            childs.Add(child);
        }
        int randNum = rand.Next(0,childs.Count);
        GameObject randomObject = childs[randNum].gameObject;
        Destroy(randomObject);

        int chance = rand.Next(0,101);

        if (chance <= 33 )
        childs = new List<Transform>();
        foreach (Transform child in LaddersPlatform)
        {
            childs.Add(child);
        }
        randNum = rand.Next(0,childs.Count);
        randomObject = childs[randNum].gameObject;
        Destroy(randomObject);

    }

}