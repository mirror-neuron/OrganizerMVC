//------------------------------------------------------------------------------
// <auto-generated>
//     Этот код создан по шаблону.
//
//     Изменения, вносимые в этот файл вручную, могут привести к непредвиденной работе приложения.
//     Изменения, вносимые в этот файл вручную, будут перезаписаны при повторном создании кода.
// </auto-generated>
//------------------------------------------------------------------------------

namespace OrganizerMVC.App_Data
{
    using System;
    using System.Collections.Generic;
    
    public partial class ContactsEmails
    {
        public int Id { get; set; }
        public int ContactId { get; set; }
        public string Email { get; set; }
    
        public virtual Contacts Contacts { get; set; }
    }
}
