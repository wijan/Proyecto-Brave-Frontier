using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Projecte_Final.Models
{
    public enum FileType
    {
        Avatar = 1, Photo
    }
    public class File
    {
        public int FileId { get; set; }
        [StringLength(255)]
        public string FileName { get; set; }
        [StringLength(100)]
        public string ContentType { get; set; }
        public byte[] Content { get; set; }
        public FileType FileType { get; set; }
        public ICollection<Objeto> Objetos { get; set; }
        public ICollection<Personaje> PersonajesIcono { get; set; }
        public ICollection<Personaje> PersonajesImagen { get; set; }
        public ICollection<Personaje> PersonajesGif { get; set; }
        public ICollection<Personaje> PersonajesGifAtaque { get; set; }
        public ICollection<Elemento> Elementos { get; set; }
    }
}