//------------------------------------------------------------------------------
// <auto-generated>
//     Этот код создан по шаблону.
//
//     Изменения, вносимые в этот файл вручную, могут привести к непредвиденной работе приложения.
//     Изменения, вносимые в этот файл вручную, будут перезаписаны при повторном создании кода.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Popryzhenok.AppData
{
    using System;
    using System.Collections.Generic;
    
    public partial class Employee
    {
        public int ID { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Patronymic { get; set; }
        public System.DateTime DateOfBirth { get; set; }
        public string PassportSeries { get; set; }
        public string PassportNumber { get; set; }
        public byte[] HavingAFamily { get; set; }
        public string HealthProblems { get; set; }
    
        public virtual Production Production { get; set; }
    }
}
