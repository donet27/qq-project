using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Crud.Model
{
    public class NoteType
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public ICollection<Note> Notes { get; set; }
    }
}
