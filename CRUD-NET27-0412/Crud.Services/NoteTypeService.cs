using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Crud.Services
{
    public class NoteTypeService
    {
        public List<Model.NoteType> GetAll() {
            using (Model.NoteContext db = new Model.NoteContext()) {
                return db.NoteTypes.ToList();
            }
        }

    }
}
