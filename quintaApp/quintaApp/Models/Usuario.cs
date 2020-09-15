using System;
using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;
using CompareAttribute = System.ComponentModel.DataAnnotations.CompareAttribute;

namespace quintaApp.Models
{
    public class Usuario
    {
        //validação na própria classe, usa a required e a sua respectiva using
        //passar um parametro que é a mensagem de erro
        //fica igual o not null do BD
        //mas aqui NÃO é uma validação especifica.
        
            //minimo, maximo, mensagem
        [Range(1,200,ErrorMessage ="O id deve estar entre 1 e 200!")]
        public ushort idUsu { get; set; }

        [Required(ErrorMessage ="O nome é obrigatório!")]
        public string nomeUsu { get; set; }

        [StringLength(50, MinimumLength =5,ErrorMessage ="Insira uma informação de 5 a 50 caracteres")]
        public string obsUsu { get; set; }

        //mascara, formatação
        [Required(ErrorMessage ="Informe a data de nascimento no formato dd/mm/yyyy")]
        [DisplayFormat(DataFormatString ="{0:dd/MM/yyyy}", ApplyFormatInEditMode = true)]
        public DateTime nascUsu { get; set; }

        [Required(ErrorMessage ="Informe o email")]
        [RegularExpression(@"^[a-zA-Z]+(([\'\,\.-][a-zA-Z ])?[a-zA-Z])\s+<(\w[-.\w]*\w@\w[-.\W]*\W\.\W{2,3})>$|^(\w[-.\w]*\w@\w[-.\w]*\w\.\w{2,3})$",ErrorMessage="Digite um email valido")]
        public string emailUsu { get; set; }

        [Remote("Validalogin","Usuario",ErrorMessage ="Este login já existe")]
        [Required(ErrorMessage ="Informe o login!")]
        [RegularExpression(@"[a-zA-Z]{5,15}",ErrorMessage="Somente letras, no minimo 5 e no maximo 15")]
        public string loginUsu { get; set; }

        [Required(ErrorMessage = "A senha é obrigatória!")]
        public string senhaUsu { get; set; }

        [Compare("senhaUsu", ErrorMessage = "As senhas são diferentes!")]
        public string confirmarUsu { get; set; }
    }
}