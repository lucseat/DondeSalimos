using System.ComponentModel.DataAnnotations;

namespace DondeSalimosAPI.Models
{
    public class Grupo
    {
        [Key]
        public int id_grupo { get; set; }
        public string nombreGrupo { get; set; }
        public int cantIntegrantes { get; set; }
        //enlace es para la comunicacion en whatsapp o telegram etc
        public string enlaceComunicacion { get; set; }
        public int localizacion { get; set; }
        public Cliente clientes { get; set; }
        public Administrador administradores { get; set; }
    }
}
