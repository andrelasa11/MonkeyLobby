using UnityEngine;
using System;

public class DatabaseManager : MonoBehaviour
{
    public static DatabaseManager instance;
    private Database database;
    public PetController petController;
    public TimingController timingController;
    public bool shouldSave = false;

    private void Awake()
    {
        database = new Database();

        if (instance == null) instance = this;
        else Debug.LogWarning("More than one DatabaseManager!");
    }

    private void Start()
    {
        Pet pet = LoadPet();
        if (pet != null)
        {
            petController.Initialize
                (pet.dirt,
                pet.happiness,
                pet.energy,
                pet.food,
                5, 5, 5, 5,
                DateTime.Parse(pet.lastTimeDirt),
                DateTime.Parse(pet.lastTimeHappiness),
                DateTime.Parse(pet.lastTimeEnergy),
                DateTime.Parse(pet.lastTimeFood));
        }
    }

    private void Update()
    {
        if(timingController.gameHourTimer <= 0 || shouldSave == true)
        {
            Pet pet = new Pet
                (petController.lastTimeDirt.ToString(),
                petController.lastTimeHappiness.ToString(),
                petController.lastTimeEnergy.ToString(),
                petController.lastTimeFood.ToString(),
                petController.dirt,
                petController.happiness,
                petController.energy,
                petController.food);

            SavePet(pet);
        }
    }

    public void SavePet (Pet pet)
    {
        database.SaveData("pet", pet);
        shouldSave = false;
    }

    public Pet LoadPet()
    {
        Pet returnValue = null;

        database.LoadData<Pet>("pet", (pet) =>
        {
            returnValue = pet;
        }
        );

        return returnValue;
    }
}
