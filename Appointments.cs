//------------------------------------------------------------------------------
// <auto-generated>
//     Ce code a été généré à partir d'un modèle.
//
//     Des modifications manuelles apportées à ce fichier peuvent conduire à un comportement inattendu de votre application.
//     Les modifications manuelles apportées à ce fichier sont remplacées si le code est régénéré.
// </auto-generated>
//------------------------------------------------------------------------------

namespace AppointmentWPF2
{
    using System;
    using System.Collections.Generic;
    
    public partial class Appointments
    {
        public int Id { get; set; }
        public System.DateTime DateHour { get; set; }
        public string Subject { get; set; }
        public int idCustomer { get; set; }
        public int idBroker { get; set; }
    
        public virtual Brokers Brokers { get; set; }
        public virtual Customers Customers { get; set; }
    }
}