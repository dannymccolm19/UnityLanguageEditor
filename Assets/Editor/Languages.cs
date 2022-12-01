using UnityEngine;
using UnityEditor;
using System.Collections;
using System.Collections.Generic;


public class Languages : EditorWindow
{
    //To make different tabs for each language
    string[] toolbarStrings = {"English", "French", "Spanish", "German", "Italian"};
    int _toolbar_sel = 0;

    //The ScriptableObjects
    public English english;
    public French french;
    public Italian italian;
    public Spanish spanish;
    public German german;
    public KeyValues keyValues;

    private SerializedObject obj;
    private SerializedObject objK;
    private SerializedProperty x;
    private SerializedProperty message;
    private SerializedProperty key;
    private SerializedProperty keys;
    private SerializedProperty value;
    private SerializedProperty values;
  

    [MenuItem("Custom Editor/LanguageEditor")]
    public static void Init(){
        Languages window = (Languages)EditorWindow.GetWindow(typeof(Languages));
        window.Show();
        
    }


    void OnGUI()
    {
        EditorGUI.BeginChangeCheck();
        GUILayout.BeginHorizontal();
        _toolbar_sel = GUILayout.Toolbar(_toolbar_sel, toolbarStrings);
        GUILayout.EndHorizontal();

        switch(_toolbar_sel){
            case 0:
                obj = new SerializedObject(english);
                break;
            case 1:
                obj = new SerializedObject(french);
                break;
            case 2:
                obj = new SerializedObject(spanish);
                break;
            case 3:
                obj = new SerializedObject(german);
                break;
            case 4:
                obj = new SerializedObject(italian);
                break;

        }

        if (EditorGUI.EndChangeCheck()){
            obj.ApplyModifiedProperties();
            GUI.FocusControl(null);
        }
        
        EditorGUI.BeginChangeCheck();

        objK = new SerializedObject(keyValues);
        keys = objK.FindProperty("Keys");
        x = objK.FindProperty("x");

        values = obj.FindProperty("Values");

        for (int i = 0; i<= x.intValue; i++){

                key = keys.GetArrayElementAtIndex(i);
                value = values.GetArrayElementAtIndex(i);

                if (i !=  x.intValue){
                    EditorGUILayout.PropertyField(value, new GUIContent(key.stringValue));
                }
                
        }

        obj.ApplyModifiedProperties();
        EditorGUILayout.PropertyField(key, new GUIContent("New Key: "));
        objK.ApplyModifiedProperties();
        
        if(GUILayout.Button("Add new Key")){
            if(key.stringValue != ""){
                x.intValue++;
                obj.ApplyModifiedProperties();
                objK.ApplyModifiedProperties();
            }
            
        }

        if(GUILayout.Button("Remove most recent key")){
            
            x.intValue--;
            obj.ApplyModifiedProperties();
            objK.ApplyModifiedProperties();
            
        }

        
        if (EditorGUI.EndChangeCheck()){
            obj.ApplyModifiedProperties();
        }

    }
}