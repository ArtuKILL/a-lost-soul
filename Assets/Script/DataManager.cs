﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DataManager : MonoBehaviour
{

    public static DataManager manager;
    private Dictionary<Stat, int> stats;
    private int coins;

    private void Awake()
    {
        if (manager == null)    //Esto ocurre en la primera instancia de la clase
        {
            DontDestroyOnLoad(gameObject);
            stats = new Dictionary<Stat, int>();
            stats.Add(Stat.Health, 5);
            stats.Add(Stat.Strength, 1);
            stats.Add(Stat.Defense, 1);
            coins = 0;
            manager = this; //Entonces se asigna este objeto a la variable estática para mantenerse en la ejecución de todo el juego
        }
        else if (manager != this)   //Para las siguientes instancias de la clase, el atributo estático sigue siendo el anterior asignado, entonces iguala los datos que este tenga para replicarlos en el nivel
        {
            stats = manager.getStats();
            coins = manager.getCoins();
            if (stats[Stat.Health] == 0)    //Si el player muere, se reestablecen los datos de la instancia actual
            {
                stats[Stat.Health] = 5;
                stats[Stat.Strength] = 1;
                stats[Stat.Defense] = 1;
            }
        }
    }

    private void Update()   //Se actualizan los datos del atributo estático
    {
        manager.setStats(stats);
        manager.setCoins(coins);
    }

    public Dictionary<Stat, int> getStats()
    {
        return stats;
    }

    public int getCoins()
    {
        return coins;
    }

    public void setStats(Dictionary<Stat, int> stat)
    {
        stats = stat;
    }

    public void setCoins(int coin)
    {
        coins = coin;
    }
}