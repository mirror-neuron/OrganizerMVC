//------------------------------------------------------------------------------
// <auto-generated>
//     Этот код создан по шаблону.
//
//     Изменения, вносимые в этот файл вручную, могут привести к непредвиденной работе приложения.
//     Изменения, вносимые в этот файл вручную, будут перезаписаны при повторном создании кода.
// </auto-generated>
//------------------------------------------------------------------------------

namespace OrganizerMVC.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class Events
    {
        public int Id { get; set; }
        public byte Status { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public System.DateTime Start { get; set; }
        public Nullable<System.DateTime> End { get; set; }
        public bool FullDay { get; set; }
        public string Place { get; set; }
    }
}
