﻿using System;
using System.Collections.Generic;
using System.IO;

namespace Task3
{
  class Phonebook
  {
    private static Phonebook phonebook;

    public string Path { get; private set; }

    private Phonebook(string path) 
    { 
      this.Path = path;
    }

    public static Phonebook getPhonebook(string path)
    {
      if(phonebook==null)
        phonebook = new Phonebook(path);//Вызывает приватный конструктор. Должен вернуть объект класса Phonebook,
                                        //в котором лежит List<Abonent>
      return phonebook;
    }

    public List<Abonent> abonent = GetAbonents(GetStrings(phonebook.Path));

    private static List<string> GetStrings(string path)
    {
      FileInfo file = new FileInfo(path);

      if (!file.Exists)
        file.Create();

      var abonentsStrings = new List<string>();

      using (StreamReader sr = new StreamReader(path))
      {
        string line;

        while ((line = sr.ReadLine()) != null)
        {
          abonentsStrings.Add(line);
        }
      }
      return abonentsStrings;
    }

    private static List<Abonent> GetAbonents(List<string> abonentsStrings)
    {
      var abonents = new List<Abonent>();
      foreach (var str in abonentsStrings)
      {
        var abonentInfo = str.Split(' ');
        var abonent = new Abonent();
        abonent.PhoneNumber = abonentInfo[0];
        abonent.Name = abonentInfo[1];
        abonents.Add(abonent);
      }
      return abonents;
    }    
  }
}
