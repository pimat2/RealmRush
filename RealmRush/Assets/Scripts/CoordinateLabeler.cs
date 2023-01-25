using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
[ExecuteAlways]
public class CoordinateLabeler : MonoBehaviour
{
    TextMeshPro label;
    Vector2Int coordinates = new Vector2Int();
    Waypoint waypoint;
    [SerializeField] Color defaultColor = Color.white;
    [SerializeField] Color newColor = Color.grey;
    void Awake() {
        waypoint = GetComponentInParent<Waypoint>();
        label = GetComponent<TextMeshPro>();
        DisplayCoordinates();    
        label.enabled = false;
    }
    // Update is called once per frame
    void Update()
    {
        if(!Application.isPlaying){
            DisplayCoordinates();
            UpdateObjectName();
        }
        ColorCoordinates();
        ToggleLabels();
    }
    void DisplayCoordinates(){
        coordinates.x = Mathf.RoundToInt(transform.parent.position.x / UnityEditor.EditorSnapSettings.move.x);
        coordinates.y = Mathf.RoundToInt(transform.parent.position.z / UnityEditor.EditorSnapSettings.move.z);
        label.text = coordinates.x + "," + coordinates.y;
    }
    void UpdateObjectName(){
        transform.parent.name = coordinates.ToString();
    }
    void ColorCoordinates(){
        if(waypoint.IsNotPlaceable == true){
            label.color = newColor;
        }
        else{
            label.color = defaultColor;
        }
    }
    void ToggleLabels(){
        if(Input.GetKeyDown(KeyCode.C)){
            label.enabled = !label.IsActive();
        }
    }
}
