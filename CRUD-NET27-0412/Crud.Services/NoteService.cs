using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Crud.Services {
    public class NoteService {
        public int Insert(Model.Note note) {
            using (var db = new Model.NoteContext()) {
                db.Notes.Add(note);
                return db.SaveChanges();
            }
        }

        public List<Model.Note> GetAll() {
            using (var db = new Model.NoteContext()) {
                return db.Notes.ToList();
            }
        }

        public Model.Note Get(int id) {
            using (var db = new Model.NoteContext()) {
                return db.Notes.Find(id);
            }
        }

        public List<Model.Note> GetByType(int id) {
            using (var db = new Model.NoteContext()) {
                return db.Notes.Where(x => x.NoteTypeId == id).ToList();
            }
        }

        public int Delete(int id) {
            using (var db = new Model.NoteContext()) {
                var note = new Model.Note { Id = id };
                db.Notes.Attach(note);
                db.Notes.Remove(note);

                return db.SaveChanges();
            }
        }

        public int Update(Model.Note note) {
            using (var db = new Model.NoteContext()) {
                //1.查询出要修改的对象
                var noteOld = db.Notes.Find(note.Id);
                //2.设置新的属性值
                noteOld.Title = note.Title;
                noteOld.Content = note.Content;
                noteOld.NoteTypeId = note.NoteTypeId;
                return db.SaveChanges();
            }
        }
    }
}
