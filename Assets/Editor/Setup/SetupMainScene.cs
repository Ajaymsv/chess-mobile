using UnityEditor;
using UnityEditor.SceneManagement;
using UnityEngine;
using UnityEngine.SceneManagement;

// Editor utility to create a Main.unity scene with wired GameObjects: Board, GameController, Camera, Light, and placeholder prefabs.
public class SetupMainScene
{
    [MenuItem("Chess/Setup Main Scene")]
    public static void CreateMainScene()
    {
        // Create new empty scene
        var scene = EditorSceneManager.NewScene(NewSceneSetup.EmptyScene, NewSceneMode.Single);
        scene.name = "Main";

        // Create Board root
        var boardGO = new GameObject("Board");
        var boardController = boardGO.AddComponent<BoardController>();

        // Board root for squares and pieces
        var boardRoot = new GameObject("BoardRoot");
        boardRoot.transform.parent = boardGO.transform;
        boardController.boardRoot = boardRoot.transform;

        // Add MoveHighlighter to board
        var moveHighlighter = boardGO.AddComponent<MoveHighlighter>();

        // Create GameController
        var gameControllerGO = new GameObject("GameController");
        var gameController = gameControllerGO.AddComponent<GameController>();
        gameController.boardController = boardController;

        // Main Camera
        var cameraGO = new GameObject("Main Camera");
        var camera = cameraGO.AddComponent<Camera>();
        camera.tag = "MainCamera";
        camera.transform.position = new Vector3(0, 10, -10);
        camera.transform.LookAt(Vector3.zero);
        boardController.mainCamera = camera;

        // Directional Light
        var lightGO = new GameObject("Directional Light");
        var light = lightGO.AddComponent<Light>();
        light.type = LightType.Directional;
        light.transform.rotation = Quaternion.Euler(50f, -30f, 0f);

        // Create placeholder prefabs folder and a simple pawn prefab
        var prefabsFolder = "Assets/Prefabs/";
        if (!AssetDatabase.IsValidFolder(prefabsFolder.TrimEnd('/')))
        {
            AssetDatabase.CreateFolder("Assets", "Prefabs");
        }

        // Create a simple pawn primitive and save it as a prefab
        var pawn = GameObject.CreatePrimitive(PrimitiveType.Cylinder);
        pawn.name = "WhitePawn_Placeholder";
        pawn.transform.localScale = new Vector3(0.5f, 1f, 0.5f);

        var pawnPath = prefabsFolder + "WhitePawn_Placeholder.prefab";
        UnityEditor.PrefabUtility.SaveAsPrefabAsset(pawn, pawnPath);
        GameObject.DestroyImmediate(pawn);

        // Save the scene to Assets/Scenes/Main.unity
        var scenesFolder = "Assets/Scenes";
        if (!AssetDatabase.IsValidFolder(scenesFolder.TrimEnd('/')))
        {
            AssetDatabase.CreateFolder("Assets", "Scenes");
        }

        var scenePath = scenesFolder + "/Main.unity";
        EditorSceneManager.SaveScene(scene, scenePath);

        EditorUtility.DisplayDialog("Setup Main Scene", "Main.unity scene has been created at " + scenePath + ". Open it in the Editor to continue.", "OK");
        AssetDatabase.Refresh();
    }
}

// Note: This file assumes the existing runtime scripts (BoardController, GameController, MoveHighlighter) are present in the project (they were added in the initial commit). After opening the project in Unity, run the menu item: Chess -> Setup Main Scene to generate the Main.unity scene and placeholder prefabs.
