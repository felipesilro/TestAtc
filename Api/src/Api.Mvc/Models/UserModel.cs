using System;
using System.ComponentModel.DataAnnotations;
using Api.Mvc.Utils;

namespace Api.Mvc.Models
{
    public class UserModel
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Campo Obrigatório.")]
        [MinLength(5, ErrorMessage = "Mínimo de 5 caracteres.")]
        [RegularExpression(@"^[a-zA-Z ]+$", ErrorMessage = "Use apenas caracteres alfabéticos.")]
        public string Name { get; set; }

        public string MaritalStatus { get; set; }

        [DisplayFormat(ApplyFormatInEditMode = false, DataFormatString = "{0:dd/MM/yyyy}")]
        public DateTime? BirthDate { get; set; }

        [RequiredIf("MaritalStatus", "Casado(a)", "Informar 'Nome' do cônjuge pois informou que é Casado(a).")]
        public string SpouseName { get; set; }

        [DisplayFormat(ApplyFormatInEditMode = false, DataFormatString = "{0:dd/MM/yyyy}")]
        [RequiredIf("MaritalStatus", "Casado(a)", "Informar 'Data de Nascimento' do cônjuge pois informou que é Casado(a).")]
        public DateTime? SpouseBirthDate { get; set; }
    }
}