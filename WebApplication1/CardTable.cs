//------------------------------------------------------------------------------
// <auto-generated>
//     Этот код создан по шаблону.
//
//     Изменения, вносимые в этот файл вручную, могут привести к непредвиденной работе приложения.
//     Изменения, вносимые в этот файл вручную, будут перезаписаны при повторном создании кода.
// </auto-generated>
//------------------------------------------------------------------------------

namespace WebApplication1
{
    using System;
    using System.Collections.Generic;
    
    public partial class CardTable
    {
        public int Id_card { get; set; }
        public int Id_Tour { get; set; }
        public int Id_Tourist { get; set; }
    
        public virtual TouristTable TouristTable { get; set; }
        public virtual TourTable TourTable { get; set; }
    }
}
