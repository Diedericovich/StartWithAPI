using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace StartWithAPI.DTO
{
    public class RegisterDTO
    {
        // DTO = Data Transfer Object

        [Required]
        //ingebouwde beveiliging voor uw gegevens. Dit kan zowel in FrontEnd als BackEnd.
        //Als je het maar op 1 plaats doet, doe het dan in BackEnd, want beveiliging in de FrontEnd kan gemakkelijk gebypassed worden.
        public string Name { get; set; }
        
        [Required]
        public string Password { get; set; }

    }

}
