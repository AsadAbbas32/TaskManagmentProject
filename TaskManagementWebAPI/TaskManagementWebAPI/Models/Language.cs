using System;
using System.Collections.Generic;

namespace TaskManagementWebAPI.Models
{
    public partial class Language
    {
        public Language()
        {
            FilmLanguage = new HashSet<Film>();
            FilmOriginalLanguage = new HashSet<Film>();
        }

        public byte LanguageId { get; set; }
        public string Name { get; set; }
        public DateTime LastUpdate { get; set; }

        public virtual ICollection<Film> FilmLanguage { get; set; }
        public virtual ICollection<Film> FilmOriginalLanguage { get; set; }
    }
}
