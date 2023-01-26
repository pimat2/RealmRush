using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
[ExecuteAlways]
[RequireComponent(typeof(TextMeshPro))]
public class CoordinateLabeler : MonoBehaviour
{
    TextMeshPro label;
    Vector2Int coordinates = new Vector2Int();
    GridManager gridManager;
    
    [SerializeField] Color defaultColor = Color.white;
    [SerializeField] Color newColor = Color.grey;
    [SerializeField] Color exploredColor = Color.yellow;
    [SerializeField] Color pathColor = Color.red;
    void Awake() {
        gridManager = FindObjectOfType<GridManager>();
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
        if(gridManager == null){
            return;
        }
        Node node = gridManager.GetNode(coordinates);
        if(node == null){
            return;
        }
        if(!node.isWalkable){
            label.color = newColor;
        }
        else if(node.isPath){
            label.color = pathColor;
        }
        else if(node.isExplored){
            label.color = exploredColor;
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
