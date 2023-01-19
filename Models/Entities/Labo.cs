using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace WebApp.Models.Entities
{
    public class Labo
    {
        public int Id { get; set; }
        
       [Required(ErrorMessage = "Nom obligatoire")]
        public string Name { get; set; }
       
        [Required(ErrorMessage = "Email obligatoire")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Mot de passe obligatoire")]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        [NotMapped] // Does not effect with your database
        [Compare("Password", ErrorMessage = "Confirm password doesn't match, Type again !")]
        [DataType(DataType.Password)]
        public string ConfirmPassword { get; set; }
        public string Acronyme { get; set; }
        public string Tel { get; set; }
        public string Etablissement { get; set; }
        public string Responsable { get; set; }
        public string Type { get; set; }


    }
}
