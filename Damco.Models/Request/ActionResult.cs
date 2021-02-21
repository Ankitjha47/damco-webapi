using System;
using System.Collections.Generic;
using System.Text;

namespace Damco.Models.Request
{
    public class ActionResult<T> where T : ActionResult<T>, new()
    {
        public bool success { get; set; }

        public string message { get; set; }

        public ActionResult<T> Failed(string message)
        {
            this.message = message;
            this.success = false;

            return this;
        }
        public static T SuccessResult { get { return new T() { success = true, message = "success!" }; } }
    }

    public class ItemResult<T> : ActionResult<ItemResult<T>>
    {
        public T data { get; set; }
    }

    public class ListResult<T> : ActionResult<ListResult<T>>
    {
        public IEnumerable<T> data { get; set; }
    }
}
