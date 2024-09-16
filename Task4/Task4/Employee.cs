﻿using System;

namespace Task4
{
  public abstract class Employee
  {
    public abstract string Name { get; set; }
    public abstract decimal BaseSalary { get; set; }

    public abstract decimal CalculateSalary();
  }
}
