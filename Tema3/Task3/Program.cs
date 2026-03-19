using System;
using System.Collections.Generic;

namespace MedicalPatiennts;
abstract class Person
{
    public string FullName { get; set; }
    public int Age { get; set; }
    public string HealthStatus { get; set; }

    public Person(string fullName, int age, string healthStatus)
    {
        FullName = fullName;
        Age = age;
        HealthStatus = healthStatus;
    }
}

sealed class Patient : Person
{
    public string Diagnosis { get; set; }

    public Patient(string fullName, int age, string healthStatus, string diagnosis)
        : base(fullName, age, healthStatus)
    {
        Diagnosis = diagnosis;
    }
}

sealed class Doctor : Person
{
    public string Specialty { get; set; }

    public Doctor(string fullName, int age, string healthStatus, string specialty)
        : base(fullName, age, healthStatus)
    {
        Specialty = specialty;
    }
}

class Hospital
{
    public Person[] People { get; set; }

    public Hospital(Person[] people)
    {
        People = people;
    }

    public Patient GetMostCriticalPatient()
    {
        Patient mostCritical = null;
        int maxLevel = -1;

        foreach (Person person in People)
        {
            if (person is Patient patient)
            {
                int level = GetHealthLevel(patient.HealthStatus);
                if (level > maxLevel)
                {
                    maxLevel = level;
                    mostCritical = patient;
                }
            }
        }

        return mostCritical;
    }

    public Doctor[] GetDoctorsBySpecialty(string specialty)
    {
        List<Doctor> result = new List<Doctor>();

        foreach (Person person in People)
        {
            if (person is Doctor doctor && doctor.Specialty == specialty)
            {
                result.Add(doctor);
            }
        }

        return result.ToArray();
    }

    private int GetHealthLevel(string status)
    {
        if (status == "critical") return 3;
        if (status == "severe") return 2;
        if (status == "mild") return 1;
        return 0;
    }
}

class Program
{
    static void Main()
    {
        Person[] people = new Person[]
        {
            new Patient("Швед Руслан", 45, "critical", "Инфаркт"),
            new Patient("Мосевич Артур", 30, "mild", "Простуда"),
            new Doctor("Шубзда Ярослав", 50, "good", "Кардиолог"),
            new Doctor("Макарчук Богдан", 40, "good", "Терапевт")
        };

        Hospital hospital = new Hospital(people);

        Patient critical = hospital.GetMostCriticalPatient();
        Console.WriteLine("Самый тяжелый пациент:");
        Console.WriteLine($"{critical.FullName} - {critical.HealthStatus} ({critical.Diagnosis})");

        Console.WriteLine("\nВрачи-кардиологи:");
        Doctor[] cardiologists = hospital.GetDoctorsBySpecialty("Кардиолог");
        foreach (Doctor d in cardiologists)
        {
            Console.WriteLine(d.FullName);
        }
    }
}