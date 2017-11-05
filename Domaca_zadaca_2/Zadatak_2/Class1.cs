using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;
using Domaca_zadaca1;

namespace Zadatak_2
{
    public class TodoItem
    {
        public Guid Id { get; set; }

        public string Text { get; set; }

        public DateTime? DateCompleted { get; set; }
        public DateTime DateCreated { get; set; }

        // Shorter syntax for single line getters in C#6
        // public bool IsCompleted = > DateCompleted . HasValue ;
        public bool IsCompleted => DateCompleted.HasValue;

        public TodoItem(string text)
        {
            // Generates new unique identifier
            Id = Guid.NewGuid();
            // DateTime .Now returns local time , it wont always be what you expect
            // (depending where the server is).
            // We want to use universal (UTC ) time which we can easily convert to
            //local when needed.
            // ( usually done in browser on the client side )
            DateCreated = DateTime.UtcNow;
            Text = text;
        }

        public bool MarkAsCompleted()
        {
            if (!IsCompleted)
            {
                DateCompleted = DateTime.Now;
                return true;
            }
            return false;
        }

        public override int GetHashCode()
        {
            if (Text != null)
            {
                return Id.GetHashCode() + Text.GetHashCode() + DateCompleted.GetHashCode() + DateCreated.GetHashCode() + 7;
            }
            return Id.GetHashCode() + DateCompleted.GetHashCode() + DateCreated.GetHashCode() + 7;
        }

        public override bool Equals(object obj)
        {
            if (obj is TodoItem)
            {
                TodoItem todoitem = (TodoItem) obj;
                return Id.Equals(todoitem.Id);
            }
            return false;
        }
    }

    public interface ITodoRepository
    {
        /// <summary >
        /// Gets TodoItem for a given id
        /// </ summary >
        /// <returns > TodoItem if found , null otherwise </ returns >
        TodoItem Get(Guid todoId);
         /// <summary >
        /// Adds new TodoItem object in database .
        /// If object with the same id already exists ,
        /// method should throw DuplicateTodoItemException with the message
        ///  " duplicate id: {id }".
        /// </ summary >
        /// <returns > TodoItem that was added </ returns >
        TodoItem Add(TodoItem todoItem);
        /// <summary >
        /// Tries to remove a TodoItem with given id from the database .
        /// </ summary >
        /// <returns > True if success , false otherwise </ returns >
        bool Remove(Guid todoId);
        /// <summary >
        /// Updates given TodoItem in the database .
        /// If TodoItem does not exist , method will add one .
        /// </ summary >
        /// <returns > TodoItem that was updated </ returns >
        TodoItem Update(TodoItem todoItem);
        /// <summary >
        /// Tries to mark a TodoItem as completed in the database .
        /// </ summary >
        /// <returns > True if success , false otherwise </ returns >
        bool MarkAsCompleted(Guid todoId);
        /// <summary >
        /// Gets all TodoItem objects in the database , sorted by date created
       /// (descending )
            /// </ summary >
         List<TodoItem> GetAll () ;
        /// <summary >
        /// Gets all incomplete TodoItem objects in the database
        /// </ summary >
        List<TodoItem> GetActive();


        /// <summary >
        /// Gets all completed TodoItem objects in the database
        /// </ summary >
        List<TodoItem> GetCompleted();
        /// <summary >
        /// Gets all TodoItem objects in database that apply to the filter
        /// </ summary >
        List<TodoItem> GetFiltered(Func<TodoItem, bool> filterFunction);
    }

    /// <summary >
    /// Class that encapsulates all the logic for accessing TodoTtems .
    /// </ summary >
    public class TodoRepository : ITodoRepository
    {
        /// <summary >
        /// Repository does not fetch todoItems from the actual database ,
        /// it uses in memory storage for this excersise .
        /// </ summary >
        private readonly IGenericList<TodoItem> _inMemoryTodoDatabase;
        public TodoRepository(IGenericList<TodoItem> initialDbState = null)
        {
            if (initialDbState != null)
            {
                _inMemoryTodoDatabase = initialDbState;
            }
            else
            {
                _inMemoryTodoDatabase = new GenericList<TodoItem>();
            }
            // Shorter way to write this in C# using ?? operator :
            // x ?? y = > if x is not null , expression returns x. Else it will
            // return y.
            // _inMemoryTodoDatabase = initialDbState ?? new List < TodoItem >();
        }

        public TodoItem Get(Guid todoId)
        {
            return _inMemoryTodoDatabase.FirstOrDefault(i => i.Id == todoId);
        }

        public TodoItem Add(TodoItem todoItem)
        {
            if (_inMemoryTodoDatabase.Contains(todoItem))
            {
                throw  new DuplicateTodoItemException("duplicate id");
            }
            _inMemoryTodoDatabase.Add(todoItem);
            return todoItem;
        }

        public bool Remove(Guid todoId)
        {
          return  _inMemoryTodoDatabase.Remove(_inMemoryTodoDatabase.FirstOrDefault(i => i.Id == todoId));
        }

        public TodoItem Update(TodoItem todoItem)
        {
            TodoItem updateTodoItem;
            if (_inMemoryTodoDatabase.Contains(todoItem))
            {
                updateTodoItem = _inMemoryTodoDatabase.FirstOrDefault(i => i.Equals(todoItem));
                updateTodoItem.DateCompleted = todoItem.DateCompleted;
                updateTodoItem.Text = todoItem.Text;
                updateTodoItem.DateCreated = todoItem.DateCreated;
                return updateTodoItem;
            }
            _inMemoryTodoDatabase.Add(todoItem);
            return todoItem;
        }

        public bool MarkAsCompleted(Guid todoId)
        {
            TodoItem updateTodoItem;
            if (_inMemoryTodoDatabase.Contains(updateTodoItem =_inMemoryTodoDatabase.FirstOrDefault(i => i.Id == todoId)))
            {
                if (updateTodoItem != null)
                {
                   return updateTodoItem.MarkAsCompleted();
                }
            }
            return false;
        }

        public List<TodoItem> GetAll()
        {
            return _inMemoryTodoDatabase.OrderByDescending(i => i.DateCreated).ToList();
        }

        public List<TodoItem> GetActive()
        {
            return _inMemoryTodoDatabase.Where(i => i.DateCompleted == null).ToList();
        }

        public List<TodoItem> GetCompleted()
        {
            return _inMemoryTodoDatabase.Where(i => i.DateCompleted != null).ToList();
        }

        public List<TodoItem> GetFiltered(Func<TodoItem, bool> filterFunction)
        {
            return _inMemoryTodoDatabase.Where(i => filterFunction(i)).ToList();
        }
    }

    public class DuplicateTodoItemException : Exception
    {

        public DuplicateTodoItemException()
        {
        }

        public DuplicateTodoItemException(string message) : base(message)
        {
        }

        public DuplicateTodoItemException(string message, Exception inner) : base(message, inner)
        {
        }

        protected DuplicateTodoItemException(
            SerializationInfo info,
            StreamingContext context) : base(info, context)
        {
        }
    }

}