using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Crud.Model {
    public class NoteContext : DbContext{

        public NoteContext() {
            Database.SetInitializer<NoteContext>(new DataBaseInitilizer());
        }

        public DbSet<Note> Notes { get; set; }
        public DbSet<NoteType> NoteTypes { get; set; }

    }

    /// <summary>
    /// 数据库初始化策略类：
    /// DropCreateDatabaseIfModelChanges：当模型类发生改变后，重建数据库
    /// </summary>
    public class DataBaseInitilizer : DropCreateDatabaseIfModelChanges<NoteContext> {
        /// <summary>
        /// 初始表中的数据
        /// </summary>
        /// <param name="context"></param>
        protected override void Seed(NoteContext context) {
            var type1 = new NoteType { Name = "我的心事" };
            var type2 = new NoteType { Name = "教学笔记" };
            var type3 = new NoteType { Name = "我的情书" };

            context.NoteTypes.Add(type1);
            context.NoteTypes.Add(type2);
            context.NoteTypes.Add(type3);

            context.SaveChanges();

            base.Seed(context);
        }
    }
}
