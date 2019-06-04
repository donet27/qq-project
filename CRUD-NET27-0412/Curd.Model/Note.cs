using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Crud.Model {
    public class Note {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Content { get; set; }
        public DateTime CreateDate { get; set; }

        public int NoteTypeId { get; set; }

        public NoteType NoteType { get; set; }
    }
}
