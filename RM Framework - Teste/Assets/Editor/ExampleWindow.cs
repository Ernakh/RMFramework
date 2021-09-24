using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

public class ExampleWindow : EditorWindow
{
    [MenuItem("RMFramework/RMFramework")]
    public static void showWindow()
    {
        GetWindow<ExampleWindow>("RMFramework");
    }

    Vector2 scrollPosition;
    public GameObject gameManager;
    void OnGUI()
    {
        scrollPosition = GUILayout.BeginScrollView(scrollPosition, GUILayout.Width(350), GUILayout.Height(250));
        GUILayout.Label("Clique nos botões para criar os objetos", EditorStyles.boldLabel);
        if (GUILayout.Button(new GUIContent("GameManager + Canvas + Local de Entrega", "Este objeto gerencia os pedidos, seus respectivos ingredientes, tempo de entrega, pontuação e tempo de partida. (NECESSÁRIO)")))
        {
            Object esferaTeste = AssetDatabase.LoadAssetAtPath("Assets/Editor/Prefabs/GameManager.prefab", typeof(GameObject));
            Instantiate(esferaTeste, new Vector3(-1.53f,1.91f, 0.99f), Quaternion.identity);
        }     
        else if (GUILayout.Button(new GUIContent("Caixa de Ingredientes 1", "GameObject que instancia os ingredientes. Os ingredientes são colocados no inspector. Caixas diferentes podem instanciar ingredientes diferentes. (NECESSÁRIO)")))
        {
            Object esferaTeste = AssetDatabase.LoadAssetAtPath("Assets/Editor/Prefabs/CaixaIngredientes1.prefab", typeof(GameObject));
            Instantiate(esferaTeste, new Vector3(-3.17f, 1.3f, 2.4f), Quaternion.identity);
        }
        else if (GUILayout.Button(new GUIContent("Caixa de Ingredientes 2", "GameObject que instancia os ingredientes. Os ingredientes são colocados no inspector. Caixas diferentes podem instanciar ingredientes diferentes. (NECESSÁRIO)")))
        {
            Object esferaTeste = AssetDatabase.LoadAssetAtPath("Assets/Editor/Prefabs/CaixaIngredientes2.prefab", typeof(GameObject));
            Instantiate(esferaTeste, new Vector3(4.89f, 1.3f, 2.31f), Quaternion.identity);
        }
        else if (GUILayout.Button(new GUIContent("Caixa de Ingredientes 3", "GameObject que instancia os ingredientes. Os ingredientes são colocados no inspector. Caixas diferentes podem instanciar ingredientes diferentes. (NECESSÁRIO)")))
        {
            Object esferaTeste = AssetDatabase.LoadAssetAtPath("Assets/Editor/Prefabs/CaixaIngredientes3.prefab", typeof(GameObject));
            Instantiate(esferaTeste, new Vector3(1, 1.3f, -2.14f), Quaternion.identity);
        }
        else if (GUILayout.Button(new GUIContent("Caixa de Ação", "O recipiente dos ingredientes e pedidos. (NECESSÁRIO)")))
        {
            Object esferaTeste = AssetDatabase.LoadAssetAtPath("Assets/Editor/Prefabs/CaixaDeAção.prefab", typeof(GameObject));
            Instantiate(esferaTeste, new Vector3(2.15f, 1.3f, 5), Quaternion.identity);
        }
        else if (GUILayout.Button(new GUIContent("Incinerador", "Objeto que destrói ingredientes e pedidos. Pode ser útil para limpar o cenário ou descartar pedidos errados. (OPCIONAL)")))
        {
            Object esferaTeste = AssetDatabase.LoadAssetAtPath("Assets/Editor/Prefabs/Incinerador.prefab", typeof(GameObject));
            Instantiate(esferaTeste, new Vector3(4.58f, 1.3f, 0), Quaternion.identity);
        }
        else if (GUILayout.Button(new GUIContent("Player 1", "O jogador. Pode ser jogado por teclado ou controle. (NECESSÁRIO)")))
        {
            Object esferaTeste = AssetDatabase.LoadAssetAtPath("Assets/Editor/Prefabs/Player1.prefab", typeof(GameObject));
            Instantiate(esferaTeste, new Vector3(0, 1.5f, 1.75f), Quaternion.identity);
        }
        else if (GUILayout.Button(new GUIContent("Bloco comum/mesa/balcão", "Este é um bloco comum e serve como mesa e balcão para colocar os objetos. Também pode ser usado como obstáculo. (RECOMENDADO)")))
        {
            Object esferaTeste = AssetDatabase.LoadAssetAtPath("Assets/Editor/Prefabs/BlocosCenario.prefab", typeof(GameObject));
            Instantiate(esferaTeste, new Vector3(0, 1.5f, 0), Quaternion.identity);
        }
        GUILayout.EndScrollView();
    }
}
