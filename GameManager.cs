using Godot;
using System;
using Godot.Collections;


public partial class GameManager : Node2D
{
    public static GameManager Singleton { get; private set; }
    public string PreviousScene = "";
    public bool IsPaused;
    public bool IsInventoryOpen = false;
    public string CurrentScene = "res://scenes/ui.tscn";
    private int _currentLevel = 1;
    public Dictionary<string, int> Inventory = new Dictionary<string, int>();
    public bool IsHidden;
    public bool GameOver = false;


    // Called when the node enters the scene tree for the first time.
    public override void _Ready()
    {
        if (Singleton != null)
        {
            QueueFree();
            return;
        }

        Singleton = this;


        GD.Print("GameManager Ready");
    }

    // Called every frame. 'delta' is the elapsed time since the previous frame.
    public override void _Process(double delta)
    {
        OnGameOver();
    }

    public void LoadLevel(int levelId = -1)
    {
        if (levelId != -1)
        {
            GD.Print("Loading Level: " + levelId);
            _currentLevel = levelId;
            GD.Print("Current Level: " + _currentLevel);
        }

        GD.Print("Loading Level");
        ChangeScene("res://scenes/levels/level_" + _currentLevel.ToString() + ".tscn");
    }

    public void LoadNextLevel()
    {
        CurrentLevel(_currentLevel + 1);
        LoadLevel();
    }


    public void ChangeScene(string scene, bool savePrevious = true)
    {
        GD.Print("Changing scene: start");
        if (savePrevious)
        {
            GD.Print("Saving previous scene: " + CurrentScene);
            PreviousScene = CurrentScene;
        }

        CurrentScene = scene;
        ResetInventory();
        GameOver = false;
        IsInventoryOpen = false;
        IsPaused = false;
        GetTree().Paused = false;
        this.GetTree().ChangeSceneToFile(scene);
    }


    public void ChangePreviousScene()
    {
        var temporaryOld = CurrentScene;
        CurrentScene = PreviousScene;
        GD.Print("Changing to previous scene: " + PreviousScene);
        this.GetTree().ChangeSceneToFile(PreviousScene);
        PreviousScene = temporaryOld;
    }

    public void AddToInventory(string item)
    {
        item = item.ToLower();
        if (Inventory.ContainsKey(item))
        {
            Inventory[item] += 1;
        }
        else
        {
            Inventory.Add(item, 1);
        }
    }

    public void RemoveFromInventory(string item)
    {
        item = item.ToLower();
        if (Inventory.ContainsKey(item))
        {
            Inventory[item] -= 1;
            if (Inventory[item] <= 0)
            {
                Inventory.Remove(item);
            }
        }
    }

    public bool CheckIfItemInInventory(string item)
    {
        item = item.ToLower();
        if (Inventory.ContainsKey(item))
        {
            return true;
        }

        return false;
    }

    public void ResetInventory()
    {
        Inventory.Clear();
    }

    public void OnGameOver()
    {
        if (!GameOver)
        {
            return;
        }

        ChangeScene("res://scenes/UI/GameOver.tscn");
    }

        public int CurrentLevel(int value = -1)
    {
        if (value == -1)
        {
            return _currentLevel;
        }
        GD.Print($"Changing CurrentLevel from {_currentLevel} to {value}");
        _currentLevel = value;
        return _currentLevel;
    }

}