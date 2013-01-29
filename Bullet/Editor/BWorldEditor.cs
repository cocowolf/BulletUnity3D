using UnityEngine;
using UnityEditor;

[CustomEditor(typeof(BWorld))]
public class BWorldEditor : Editor {

	private SerializedObject serObj;
    private SerializedProperty worldType;
    
	public void OnEnable () 
	{
		serObj = new SerializedObject (target); 
		worldType = serObj.FindProperty("WorldType");   	
	 
	}
	
	public override void OnInspectorGUI () 
    {
		 DrawDefaultInspector();    
    	//serObj.Update();
    	
    	 
    	
    	//serObj.ApplyModifiedProperties();
    }
}
